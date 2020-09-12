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
    public partial class FormSuaToaNha : Form
    {
        private Form1 formMain;
        SqlDataAdapter da_toaNha;
        DataSet ds_toaNha;
        DataColumn[] key = new DataColumn[1];
        ketNoi cn;
        int maToaNha;
        public FormSuaToaNha()
        {
            InitializeComponent();
            formMain = new Form1();
            cn = new ketNoi();
            addTextBoxToList();

            String selectStr = "select * from toa_nha";
            da_toaNha = new SqlDataAdapter(selectStr, cn.consql);
            ds_toaNha = new DataSet();
            da_toaNha.Fill(ds_toaNha, "build");

            key[0] = ds_toaNha.Tables["build"].Columns[0];
            ds_toaNha.Tables["build"].PrimaryKey = key;
        }

        public FormSuaToaNha(String tenToaNhaForm1): this()
        {
            maToaNha = getIdBuilding(tenToaNhaForm1);
        }

        // lấy mã căn hộ
        private int getIdBuilding(String tenToaNha)
        {
            if (cn.consql.State == ConnectionState.Closed)
                cn.consql.Open();
            String selectStr = "select top 1 Ma_ToaNha from toa_nha where Ten_ToaNha = N'" + tenToaNha + "'";
            SqlCommand cmd = new SqlCommand(selectStr, cn.consql);
            int idBuilding = (int)cmd.ExecuteScalar();

            if (cn.consql.State == ConnectionState.Open)
                cn.consql.Close();

            return idBuilding;
        }

        List<TextBox> listTextBox = new List<TextBox>();
        void addTextBoxToList()
        {
            addList(this);
        }

        private void addList(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                    listTextBox.Add((TextBox)c);
                if (c.Controls.Count > 0)
                    addList(c);
            }
        }

        private bool enableBtnThem()
        {
            foreach (TextBox item in listTextBox)
            {
                if (item.Text.Trim().Length == 0)
                    return false;
            }
            return true;
        }

        private void loadDataToTextBox(int maToaNha)
        {
            //try
            //{
                if (maToaNha == null)
                {
                    return;
                }
                DataRow dr = ds_toaNha.Tables["build"].Rows.Find(maToaNha);
                if (dr != null)
                {
                    txt_TenToaNha.Text = dr["Ten_ToaNha"].ToString();
                    String diaChi = dr["DiaChi"].ToString();
                    String[] arrDiaChi = diaChi.Split(',');
                    txt_PhuongXa.Text = arrDiaChi[0];
                    txt_QuanHuyen.Text = arrDiaChi[1];
                    txt_ThanhPho.Text = arrDiaChi[2];
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Eror when inset data to textbox");
            //}
            
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ds_toaNha.Tables["build"].Rows.Find(maToaNha);
                dr["Ten_ToaNha"] = txt_TenToaNha.Text;
                String diaChi = txt_PhuongXa.Text + ", " + txt_QuanHuyen.Text + ", " + txt_ThanhPho.Text;
                dr["DiaChi"] = diaChi.Trim();

                SqlCommandBuilder cB = new SqlCommandBuilder(da_toaNha);
                da_toaNha.Update(ds_toaNha, "build");
                MessageBox.Show("Sửa tòa nhà " + txt_TenToaNha.Text + " thành công.");
                btn_XacNhan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại");
            }


        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            txt_TenToaNha.Clear();
            txt_ThanhPho.Clear();
            txt_QuanHuyen.Clear();
            txt_PhuongXa.Clear();
            txt_TenToaNha.Focus();
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            formMain.Show();
            formMain.selectTabPage = "tabPage2";
            formMain.addListViewItem();
            formMain.addToListView();
            this.Hide();
        }

        private void txt_TenToaNha_TextChanged(object sender, EventArgs e)
        {
            btn_XacNhan.Enabled = enableBtnThem();
        }

        private void FormSuaToaNha_Load(object sender, EventArgs e)
        {
            btn_XacNhan.Enabled = false;
            txt_TenToaNha.Focus();
            txt_MaToaNha.Text = maToaNha.ToString();
            loadDataToTextBox(maToaNha);
            txt_MaToaNha.Enabled = false;
        }
    }
}
