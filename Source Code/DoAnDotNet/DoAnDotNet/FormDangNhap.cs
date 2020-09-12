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
    public partial class FormDangNhap : Form
    {
        ketNoi cn;
        public FormDangNhap()
        {
            InitializeComponent();
            cn = new ketNoi();
        }

        public bool accoutIsExist(String userName, String passWord)
        {
            bool result = false;
            try
            {
                if (cn.consql.State == ConnectionState.Closed)
                {
                    cn.consql.Open();
                }
                String selectStr = "select * from login where UserName = '" + userName + "' and PassWord = '" + passWord + "'";
                SqlCommand cmd = new SqlCommand(selectStr, cn.consql);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Close();
                    result = true;
                }
                else
                {
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình thực thi truy vấn dữ liệu");
            }
            finally
            {
                if (cn.consql.State == ConnectionState.Open)
                {
                    cn.consql.Close();
                }
            }
            return result;
        }

        public String getChucVu(String userName, String passWord)
        {
            try
            {
                if (cn.consql.State == ConnectionState.Closed)
                {
                    cn.consql.Open();
                }
                String selectStr = "select ChucVu from login where UserName = '" + userName + "' and PassWord = '" + passWord + "'";
                SqlCommand cmd = new SqlCommand(selectStr, cn.consql);
                String rd = cmd.ExecuteScalar().ToString();
                if (String.IsNullOrEmpty(rd))
                {
                    return null;
                }
                return rd;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình thực thi truy vấn dữ liệu");
                return null;
            }
            finally
            {
                if (cn.consql.State == ConnectionState.Open)
                {
                    cn.consql.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txt_TaiKhoan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_TaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space || ((!char.IsLetter(e.KeyChar) &&  !char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back));
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            String userName = txt_TaiKhoan.Text;
            String passWord = txt_MatKhau.Text;
            if (accoutIsExist(userName, passWord))
            {
                
                String chucVu = getChucVu(userName, passWord);
                if (String.IsNullOrEmpty(chucVu))
                {
                    MessageBox.Show("Tài khoản không khả dụng. Xin hãy chọn tài khoản khác");
                    return;
                }
                MessageBox.Show("Đăng nhập thành công, Xin chào " + userName);
                Form1 formMain = new Form1(userName,chucVu.Trim());
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác, vui lòng kiểm tra và thử lại.");
            }
            
        }

        private void linklbl_TaiKhoanMoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy formDK = new FormDangKy();
            formDK.Show();
            this.Hide();
        }

    }
}
