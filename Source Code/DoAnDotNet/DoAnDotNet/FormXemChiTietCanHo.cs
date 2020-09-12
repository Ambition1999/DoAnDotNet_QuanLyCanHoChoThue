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
    public partial class FormXemChiTietCanHo : Form
    {
        ketNoi cn;
        private String mach, matn;
        public FormXemChiTietCanHo(String macanho,String matoanha)
        {
            mach = macanho;
            matn = matoanha;
            cn = new ketNoi();
            InitializeComponent();
        }

        private void FormXemChiTietCanHo_Load(object sender, EventArgs e)
        {
            loadText();
        }
        private void loadText()
        {
            cn.consql.Open();
            String str = "select  * from can_ho c,toa_nha t,chi_tiet_can_ho ct where c.Ma_CanHo=ct.MaCanHo and c.Ma_ToaNha=t.Ma_ToaNha and c.Ma_CanHo='" + mach + "' and t.Ma_ToaNha='" + matn + "'";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            SqlDataReader re = cm.ExecuteReader();
            while (re.Read())
            {
                lbMaCH.Text = mach;
                lbMaTN.Text = matn;
                lbTenTN.Text = re["ten_toanha"].ToString();
                String s = re["ma_canho"].ToString();
                String[] arr = s.Split('_');
                lbSoPH.Text = arr[1];
                lbTang.Text = arr[0];
                lbDiaChi.Text = re["DiaChi"].ToString();
                lbDienTich.Text = re["dientich"].ToString();
                lbThangMay.Text = re["thangmay"].ToString();
                lbBanCong.Text = re["bancong"].ToString();
                lbNoiThat.Text = re["noithat"].ToString();
                lbTrangThai.Text = re["trangthai"].ToString();
                lbTienThue.Text = re["tienthue"].ToString();
                String anh=re["hinhanh"].ToString();
                String[] arrAnh=anh.Split(';');
                //pictureCanHo.Image =Image.FromFile("C:\\Users\\quan1\\OneDrive\\Máy tính\\DoAnDotNetdgffhf\\DoAnDotNet (1)\\DoAnDotNet\\DoAnDotNet\\hinhanh\\"+arrAnh[0]+"");
                //pictureCanHo.Image = Image.FromFile("C:\\Users\\USER\\Documents\\Zalo Received Files\\DoAnDotNetdgffhf (1)\\DoAnDotNetdgffhf\\hinhanh\\" + arrAnh[0] + "");
                pictureCanHo.Image = Image.FromFile("C:\\Users\\Admin\\Desktop\\DoAnDotNetTheLast\\DoAnDotNetdgffhf (1)\\DoAnDotNetdgffhf\\hinhanh\\" + arrAnh[0] + "");
                pictureCanHo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            cn.consql.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            FormThue thue = new FormThue(mach, matn);
            thue.ShowDialog();
        }
    }
}
