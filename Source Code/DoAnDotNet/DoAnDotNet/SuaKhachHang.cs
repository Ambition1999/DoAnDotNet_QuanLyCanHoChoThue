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
    public partial class SuaKhachHang : Form
    {
        ketNoi cn;
        String _cmnd;

        public String cmnd
        {
            get { return _cmnd; }
            set { _cmnd = value; }
        }
        public SuaKhachHang(String s)
        {
            cn = new ketNoi();
            InitializeComponent();
            cmnd = s;
        }

        private void SuaKhachHang_Load(object sender, EventArgs e)
        {
            loadText();
        }
        private void loadText()
        {
            cn.consql.Open();
            String str = "select * from khach_hang where cmnd='"+cmnd+"'";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            SqlDataReader re = cm.ExecuteReader();
            while (re.Read())
            {
                cboGioiTinh.Text = re["gioitinh"].ToString();
                txtDiaChi.Text = re["diachi"].ToString();
                txtEmaill.Text = re["email"].ToString();
                String s = re["tenkh"].ToString();
                String[] arr = s.Split(' ');
                txtHoLot.Text = arr[0] +" "+arr[1];
                txtTen.Text = arr[2];
                matxtCMND.Text = re["cmnd"].ToString();
                matxtSDT.Text = re["sodt"].ToString();
            }
            matxtCMND.Enabled = false;
            cn.consql.Close();

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (ktNhap() )
            {
                    cn.consql.Open();
                    String ten=txtHoLot.Text+" "+txtTen.Text;
                    String sdt=matxtSDT.Text;
                    String email= txtEmaill.Text;
                    String dc=txtDiaChi.Text;
                    String gt=cboGioiTinh.Text;                  
                    String str = "update khach_hang set  tenkh=N'" +ten+ "',sodt='" +sdt+ "',email='" +email + "',diachi=N'" +dc+ "',gioitinh=N'"+gt+"' where cmnd='"+cmnd+"'";
                    SqlCommand cm = new SqlCommand(str, cn.consql);
                    int a = cm.ExecuteNonQuery();
                    if (a != 0)
                    {
                        MessageBox.Show("Sửa thành công!!!");
                    }
                    else
                        MessageBox.Show("Thất bại");
                    cn.consql.Close();
                }
         
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu!!");
            }
        
        }
        private bool ktNhap()
        {
            if (txtHoLot.Text != "" && txtTen.Text != "" && txtDiaChi.Text != "" && txtEmaill.Text != "" && matxtCMND.Text != "" && matxtSDT.Text != "" && cboGioiTinh.Text != "")
            {
                return true;
            }
            return false;
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
