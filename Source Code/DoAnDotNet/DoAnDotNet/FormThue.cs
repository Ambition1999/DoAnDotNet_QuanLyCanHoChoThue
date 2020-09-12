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
    public partial class FormThue : Form
    {
        String _cmnd;
        ketNoi cn;
        String cmnd1 = "";
        String maToaNha;
        String maCanHo;
        public String cmnd
        {
            get { return _cmnd; }
            set { _cmnd = value; }
        }
       
        public FormThue(String ch,String tn)
        {
            InitializeComponent();
            cn = new ketNoi();
            maCanHo = ch;
            maToaNha = tn;
            
        }
        //public FormThue(String s)
        //{
        //    maCanHo = s;
        //}
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemKhacHang_Click(object sender, EventArgs e)
        {
            FormThemKhachHang themkh = new FormThemKhachHang();
            themkh.ShowDialog();
            String cmnd12 = themkh.maKH;
            cn.consql.Open();
            String str = "select * from Khach_hang where cmnd='" + cmnd12 + "'";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            SqlDataReader re = cm.ExecuteReader();
            while (re.Read())
            {
                String ten = re["Tenkh"].ToString();
                String[] arr = ten.Split(' ');
                for (int i = 0; i < arr.Count() - 1; i++)
                {
                    lbHoLot.Text += arr[i] + " ";
                }

                lbTen.Text = arr[arr.Count() - 1];
                lbDiaChi.Text = re["diachi"].ToString();
                lbEmail.Text = re["email"].ToString();
                lbCMND.Text = re["cmnd"].ToString();
                lbSDT.Text = re["sodt"].ToString();

            }
            cn.consql.Close();
        }

        private void FormThue_Load(object sender, EventArgs e)
        {
            loadCanHo();
        }
        private void loadCanHo(){
            cn.consql.Open();
            String str = "select * from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha and ma_canho='" + maCanHo + "' and t.ma_toanha='" + maToaNha + "'";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            SqlDataReader re = cm.ExecuteReader();
            while (re.Read())
            {
                lbTenToaNha.Text = re["ten_toanha"].ToString();
                lbTang.Text = re["tang"].ToString();
                maToaNha = re["ma_toanha"].ToString();
                String maph = re["ma_canho"].ToString();
                String[] arrSP = maph.Split('_');
                lbSoPhong.Text = arrSP[1];
                lbDienTich.Text = re["dientich"].ToString();
                String s = re["diachi"].ToString();
                String[] arr = s.Split(',');
                lbThanhPho.Text = arr[0];
                lbQuan.Text = arr[1];
                lbXa.Text = arr[2];
                lbTongTienThue.Text = re["TienThue"].ToString();
            }
            cn.consql.Close();
        }
        private void btnChonKhachHang_Click(object sender, EventArgs e)
        {
            ChonKhachHang chon = new ChonKhachHang();
            chon.ShowDialog();
            String cmq = chon.cmnd;
            cmnd1 = cmq;
            cn.consql.Open();
            String str = "select * from Khach_hang where cmnd='"+cmnd1+"'";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            SqlDataReader re = cm.ExecuteReader();
            while (re.Read())
            {
                String ten = re["Tenkh"].ToString();
                String[] arr = ten.Trim().Split(' ');
                lbHoLot.Text = "";
                for (int i = 0; i < arr.Count() - 1;i++ )
                {
                    lbHoLot.Text +=arr[i];

                }
                lbTen.Text = arr[arr.Count()-1];
                lbDiaChi.Text = re["diachi"].ToString();
                lbEmail.Text = re["email"].ToString();
                lbCMND.Text = re["cmnd"].ToString();
                lbSDT.Text = re["sodt"].ToString();

            }
            cn.consql.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (ktThang() < 90)
            {
                MessageBox.Show("Phải thuê ít nhất 3 tháng !!!!");
                return;
            }
            if (!ktNhap())
            {
                MessageBox.Show("Chưa nhập đủ dữ liệu !!!!");
                return;
            }
            if (cmnd1 != "")
            {
                cn.consql.Open();
                String sday = pickerNgayBatDau.Text;
                String eday = pickerNgayKetThuc.Text;
                int ngaythue = ktThang();
                double tongTien = ngaythue * double.Parse(lbTongTienThue.Text) / 30;
                double tiencoc = double.Parse(txtTienCoc.Text);
                double tienconLai = tongTien - tiencoc;
                String str = "set dateformat dmy insert into hd_thue values('" + sday + "','" + eday + "','" + ngaythue + "','" + tongTien + "','" + tiencoc + "','" + tienconLai + "','" + maToaNha + "','" + maCanHo + "','" + cmnd1 + "')";
                SqlCommand cm = new SqlCommand(str, cn.consql);
                int a = cm.ExecuteNonQuery();
                if (a >= 1)
                {
                    MessageBox.Show("Thêm thành công!!!");
                    Form1 f = new Form1();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại . Lỗi !!!!!!!!");
                }
                cn.consql.Close();
            }
            else
            {
                MessageBox.Show("Chưa chọn khách hàng!!!!");
            }            
        }
        private bool ktNhap()
        {
            if (txtTienCoc.Text != "" && txtTienConLai.Text != "")
            {
                return true;
            }
            return false;
        }

        private void txtTienCoc_TextChanged(object sender, EventArgs e)
        {
            if (ktThang()<90&&txtTienCoc.Text.Length>0)
            {
                txtTienCoc.Text = "";
                MessageBox.Show("Mời nhập ngày trước!!!");
                return;
            }
            if (txtTienCoc.Text.Length >= 1)
            {
                txtTienConLai.Text = "" + ((double.Parse(lbTongTienThue.Text)/30)*ktThang() - double.Parse(txtTienCoc.Text));
            }
        }

        private void txtTienCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private int ktThang()
        {
            DateTime end = Convert.ToDateTime(pickerNgayKetThuc.Text);
            DateTime start = Convert.ToDateTime(pickerNgayBatDau.Text);
            TimeSpan tgChenhLech = end.Subtract(start);
            int a = tgChenhLech.Days;
            return a;
            
        }

        private void lbXa_Click(object sender, EventArgs e)
        {

        }

        private void pickerNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            if (txtTienCoc.Text.Length > 0)
            {
                txtTienConLai.Text = "" + ((double.Parse(lbTongTienThue.Text) / 30) * ktThang() - double.Parse(txtTienCoc.Text));
            }
        }
       
    }
}
