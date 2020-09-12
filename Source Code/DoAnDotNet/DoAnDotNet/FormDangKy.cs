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
    public partial class FormDangKy : Form
    {
        ketNoi cn;
        public FormDangKy()
        {
            InitializeComponent();
            cn = new ketNoi();
        }

        public bool userNameIsExist(String userName)
        {
            bool result = false;
            try
            {
                if (cn.consql.State == ConnectionState.Closed)
                {
                    cn.consql.Open();
                }
                String selectStr = "select * from login where UserName = '" + userName + "'";
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

        public void addAccount(String userName, String passWord)
        {
            try
            {
                if (cn.consql.State == ConnectionState.Closed)
                {
                    cn.consql.Open();
                }
                String selectStr = "insert login(UserName,PassWord,ChucVu) values('"+userName+"','"+passWord+"','User')";
                SqlCommand cmd = new SqlCommand(selectStr, cn.consql);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Đăng ký thành công với tên đăng nhập là: " + userName + ", mật khẩu là: " + passWord);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xử lý, vui lòng thử lại. Xin cảm ơn");
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
        }

        private void txt_TenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space || ((!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back));
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            String userName = txt_TenDangNhap.Text;
            String passWord = txt_MatKhau.Text;
            String passWord_Retype = txt_MatKhau2.Text;
            if (userNameIsExist(userName))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn một tên khác");
                txt_TenDangNhap.Focus();
                return;
            }
            if (!passWord_Retype.Equals(passWord))
            {
                MessageBox.Show("Mật khẩu và mật khẩu nhập lại không trùng khớp, hãy chắc rằng bạn đã tắt Caplock,\nVui lòng kiểm tra lại");
                txt_MatKhau2.Focus();
                return;
            }
            addAccount(userName, passWord);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FormDangNhap formDN = new FormDangNhap();
            formDN.Show();
            this.Hide();
        }
    }
}
