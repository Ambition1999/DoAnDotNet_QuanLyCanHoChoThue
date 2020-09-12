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
    public partial class ThanhToan : Form
    {
        public ThanhToan()
        {
            InitializeComponent();
            kn = new ketNoi();
            txtMaHD.Enabled = false;
            txtTienConLai.Enabled = false;
        }
        ketNoi kn;
        string maHD = "";
        string tienCL = "";
        public void nhan(string MaHD,string tien)
        {
            maHD = MaHD;
            tienCL = tien;
            show();
        }
        public void show()
        {
            txtMaHD.Text = maHD;

            dtpNgayTT.Text = DateTime.Now.ToShortDateString();

            txtTienConLai.Text = tienCL;
        }
        private void btnXN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoTien.Text == "")
                {
                    MessageBox.Show("Mời Nhập Số Tiền");
                    return;
                }
                else
                {
                    string str = "select * from thanh_toan";
                    SqlDataAdapter da = new SqlDataAdapter(str, kn.consql);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "TT");
                    DataRow nr = ds.Tables[0].NewRow();
                    nr["ma_hdthue"] = txtMaHD.Text;
                    nr["tientt"] = txtSoTien.Text;
                    DateTime ngay;
                    try
                    {
                        nr["ngaytt"] = dtpNgayTT.Value.ToString("dd/MM/yyyy");
                        ngay = dtpNgayTT.Value;

                    }
                    catch 
                    {
                        nr["ngaytt"] = dtpNgayTT.Value.ToString("MM/dd/yyyy");
                        ngay = dtpNgayTT.Value;

                    }
                    if (ngay > DateTime.Now)
                    {
                        MessageBox.Show("Ngày Thêm Thanh Toán phải Nhỏ Hơn Ngày Hiện Tại");
                        return;
                    }
                    ds.Tables[0].Rows.Add(nr);
                    SqlCommandBuilder s = new SqlCommandBuilder(da);
                    da.Update(ds, "TT");
                    MessageBox.Show("Thêm Thanh Toán Thành Công");
                }
            }catch
            {

            }
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double soTienNhap = 0;
                try
                {
                    soTienNhap = double.Parse(txtSoTien.Text);
                }
                catch
                {
                    soTienNhap = 0;
                }
                double tienConLai = double.Parse(tienCL);
                double z = tienConLai - soTienNhap;
                if (z < 0)
                {
                    MessageBox.Show("Tiền nhập vào phải nhỏ hơn tiền còn lại");
                    txtTienConLai.Text = 0 + "";
                    btnXN.Enabled = false;
                    return;
                }
                btnXN.Enabled = true;
                txtTienConLai.Text = z + "";
            }
            catch
            { }
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
