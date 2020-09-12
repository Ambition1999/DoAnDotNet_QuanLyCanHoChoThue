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
    public partial class FormThemKhachHang : Form
    {
        ketNoi cn;
        public String maKH { get; set; }
        public FormThemKhachHang()
        {
            InitializeComponent();
            cn = new ketNoi();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (ktNhap())
            {
                if (ktCMND(matxtCMND.Text))
                {
                    cn.consql.Open();
                    String a = txtHoLot.Text + " " + txtTen.Text;
                    String str ="insert into khach_hang values('"+matxtCMND.Text+"',N'"+a+"','"+matxtSDT.Text+"','"+txtEmaill.Text+"','"+txtDiaChi.Text+"',N'"+cboGioiTinh.Text+"')";
                    SqlCommand cm = new SqlCommand(str, cn.consql);
                    int kt = cm.ExecuteNonQuery();
                    if (kt == 1)
                    {
                        MessageBox.Show("Thêm khách hàng thành công !!");
                        maKH = matxtCMND.Text;
                    }
                    else
                        MessageBox.Show("Thêm khách hàng thất bại!!!");
                    cn.consql.Close();
                }
                else
                    MessageBox.Show("Số cmnd bị trùng !!!!");
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ dữ liệu!!!");
            }
        }
        private bool ktNhap()
        {
            if (txtTen.Text != "" && txtHoLot.Text != "" && txtEmaill.Text != "" && txtDiaChi.Text != ""&&matxtCMND.Text!=""&&cboGioiTinh.Text!="")
            {
                return true;
            }
            return false;
        }
        private bool ktCMND(String cmnd)
        {
            cn.consql.Open();
            String str = "select cmnd from khach_hang where cmnd='" + cmnd + "'";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            var a = cm.ExecuteScalar();
            if (a == null)
            {
                cn.consql.Close();
                return true;
            }           
            cn.consql.Close();
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormThemKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void matxtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
