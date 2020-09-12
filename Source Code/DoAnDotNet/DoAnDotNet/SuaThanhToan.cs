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
    public partial class SuaThanhToan : Form
    {
        public SuaThanhToan()
        {
            InitializeComponent();
            txtMaTT.Enabled = false;
            txtMaHD.Enabled = false;
            txtTienConLai.Enabled = false;
            kn = new ketNoi();
            load();
        }
        ketNoi kn;
        string maTT = "",maHD="";
        public void nhan(string MaTT,string MaHD)
        {
            maHD = MaHD;
            maTT = MaTT;
            show();
        }
        SqlDataAdapter da_TT;
        DataSet ds_TT;
        public void load()
        {
            try
            {
                string str = "select * from thanh_toan";
                da_TT = new SqlDataAdapter(str, kn.consql);
                ds_TT = new DataSet();
                da_TT.Fill(ds_TT, "TT");
                DataColumn[] co = new DataColumn[1];
                co[0] = ds_TT.Tables[0].Columns[0];
                ds_TT.Tables[0].PrimaryKey = co;
            }
            catch
            { }
        }
        public void show()
        {
            try
            {
                txtMaHD.Text = maHD;
                txtMaTT.Text = maTT;
                DataRow dr = ds_TT.Tables[0].Rows.Find(maTT);
                if (dr != null)
                {
                    txtSoTien.Text = dr["tienTT"].ToString();
                    dtpNgayTT.Text = dr["ngayTT"].ToString();
                }
                kn.consql.Open();
                string str = "select * from hd_thue where ma_hdthue='" + txtMaHD.Text + "'";
                SqlCommand cmd = new SqlCommand(str, kn.consql);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                txtTienConLai.Text = rd["tienconlai"].ToString();
                rd.Close();
                kn.consql.Close();
                tienBD = double.Parse(txtTienConLai.Text) + double.Parse(txtSoTien.Text);
            }
            catch
            { }
        }
        private void btnXN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoTien.Text != "")
                {
                    DataRow dr = ds_TT.Tables[0].Rows.Find(maTT);
                    dr["tienTT"] = txtSoTien.Text;
                    DateTime ngay;
                    try
                    {
                        dr["ngaytt"] = dtpNgayTT.Value.ToString("dd/MM/yyyy");
                        ngay = dtpNgayTT.Value;

                    }
                    catch
                    {
                        dr["ngaytt"] = dtpNgayTT.Value.ToString("MM/dd/yyyy");
                        ngay = dtpNgayTT.Value;

                    }
                    if (ngay > DateTime.Now)
                    {
                        MessageBox.Show("Ngày Thêm Phải Nhỏ Hơn Ngày Hiện Tại");
                        return;
                    }
                    SqlCommandBuilder s = new SqlCommandBuilder(da_TT);
                    da_TT.Update(ds_TT, "TT");
                    MessageBox.Show("Update Complete!");
                }
                else
                    MessageBox.Show("Mời Nhập Đầy Đủ Thông Tin");
            }
            catch
            { 
            
            }
        }
        double tienBD = -1;
        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSoTien.Text != ""&&tienBD!=-1)
                {
                    double tienConLai = tienBD - double.Parse(txtSoTien.Text);
                    if (tienConLai < 0)
                    {
                        btnXN.Enabled = false;
                        MessageBox.Show("Số tiền nhập vào phải nhỏ hơn tiền còn lại");
                        txtTienConLai.Text = "0";
                        return;
                    }
                    btnXN.Enabled = true;
                    txtTienConLai.Text = tienConLai + "";
                }
            }
            catch
            {

            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }
    }
}
