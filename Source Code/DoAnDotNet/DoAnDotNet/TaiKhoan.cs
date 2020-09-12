using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DoAnDotNet
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
            kn = new ketNoi();
            loadGrid();
            dgvTK.ReadOnly = true;
            dgvTK.AllowUserToAddRows = false;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtChucVu.Enabled = false;
            txtEmail.Enabled = false;
            txtMK.Enabled = false;
            txtName.Enabled = false;
            this.MaximizeBox = false;
        }
        ketNoi kn;
        SqlDataAdapter da_TK;
        DataSet ds_TK;
        public void loadGrid()
        {
            try
            {
                string str = "select UserName,PassWord,diachiemail as 'Email',chucvu as 'Chức Vụ' from login";
                da_TK = new SqlDataAdapter(str, kn.consql);
                ds_TK = new DataSet();
                da_TK.Fill(ds_TK, "TK");

                DataColumn[] co = new DataColumn[1];
                co[0] = ds_TK.Tables[0].Columns[0];

                ds_TK.Tables[0].PrimaryKey = co;
                dgvTK.DataSource = ds_TK.Tables[0];
            }
            catch
            { }
        }
        private void TaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtChucVu.Enabled = true;
            txtEmail.Enabled = true;
            txtMK.Enabled = true;
            txtName.Enabled = true;

            txtChucVu.Text = "";
            txtEmail.Text = "";
            txtMK.Text = "";
            txtName.Text = "";
            btnLuu.Enabled = true;
            
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTK.CurrentCell == null || dgvTK.CurrentCell.Value == null || e.RowIndex == -1 || e.ColumnIndex == -1)
                    return;
                if (dgvTK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                    txtEmail.Text = dgvTK.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                    txtName.Text = dgvTK.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                    txtMK.Text = dgvTK.Rows[e.RowIndex].Cells["PassWord"].FormattedValue.ToString();
                    txtChucVu.Text = dgvTK.Rows[e.RowIndex].Cells["Chức Vụ"].FormattedValue.ToString();
                }
            }
            catch
            { }
        }
        public bool ktNhap()
        {
            if (txtName.Text == "" || txtMK.Text == "" || txtEmail.Text == "" || txtChucVu.Text == "")
                return false;
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktNhap())
                {
                    DataRow dr = ds_TK.Tables[0].Rows.Find(txtName.Text);
                    if (dr != null)
                    {
                        DialogResult r = MessageBox.Show("Bạn Có Muốn Sửa?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            dr["Email"] = txtEmail.Text;
                            dr["PassWord"] = txtMK.Text;
                            dr["Chức Vụ"] = txtChucVu.Text;
                            SqlCommandBuilder s = new SqlCommandBuilder(da_TK);
                            da_TK.Update(ds_TK, "TK");
                            MessageBox.Show("Thành Công.");
                            loadGrid();
                        }
                    }
                    else
                    {
                        try
                        {
                            DataRow dr1 = ds_TK.Tables[0].NewRow();
                            dr1["Email"] = txtEmail.Text;
                            dr1["PassWord"] = txtMK.Text;
                            dr1["UserName"] = txtName.Text;
                            dr1["Chức Vụ"] = txtChucVu.Text;
                            ds_TK.Tables[0].Rows.Add(dr1);
                            SqlCommandBuilder s = new SqlCommandBuilder(da_TK);
                            da_TK.Update(ds_TK, "TK");
                            MessageBox.Show("Thành Công.");
                            loadGrid();
                        }
                        catch
                        {
                            MessageBox.Show("UserName đã trùng.");
                        }
                    }
                }
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            catch
            { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtChucVu.Enabled = true;
            txtEmail.Enabled = true;
            txtMK.Enabled = true;

            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ds_TK.Tables[0].Rows.Find(txtName.Text);
                if (dr != null)
                {
                    dr.Delete();
                    SqlCommandBuilder s = new SqlCommandBuilder(da_TK);
                    da_TK.Update(ds_TK, "TK");
                    MessageBox.Show("Thành Công.");
                    loadGrid();
                }
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            catch
            { 
            
            }
        }

        private void TaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn Có Muốn Thoát?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
