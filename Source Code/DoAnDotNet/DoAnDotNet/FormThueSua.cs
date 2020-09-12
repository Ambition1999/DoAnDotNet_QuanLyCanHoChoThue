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
using System.Windows.Forms.Design;

namespace DoAnDotNet
{
    public partial class FormThueSua : Form
    {
        public FormThueSua(string ma)
        {
            
            mahd = ma;
            cn = new ketNoi();
            InitializeComponent();
            show();
            int chieurong = Screen.PrimaryScreen.WorkingArea.Width;
            int chieudai = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size(chieurong, chieudai);

        }
        ketNoi cn;
        String cmnd;
        string mahd;
        public void nhan(string ma)
        {
            mahd = ma;
        }
        SqlDataAdapter da_HD;
        DataSet ds_HD;
        public void show()
        {
            try
            {
                loadTN();
                loadCH();
                string str = "select * from hd_Thue";
                da_HD = new SqlDataAdapter(str, cn.consql);
                ds_HD = new DataSet();
                da_HD.Fill(ds_HD, "HD");
                DataColumn[] co = new DataColumn[1];
                co[0] = ds_HD.Tables[0].Columns[0];
                ds_HD.Tables[0].PrimaryKey = co;
                DataRow dr = ds_HD.Tables[0].Rows.Find(mahd);
                txtTienCoc.Text = dr["tiencoc"].ToString();
                txtTienConLai.Text = dr["tienconlai"].ToString();
                pickerNgayBatDau.Text = dr["ngaybatdau"].ToString();
                pickerNgayKetThuc.Text = dr["ngayketthuc"].ToString();
                lbCMND.Text = dr["cmnd"].ToString();

                DataRow drTN = ds_TN.Tables[0].Rows.Find(dr["ma_toanha"].ToString());
                if (drTN != null)
                {
                    cboToaNha.Text = drTN["ten_toanha"].ToString();
                }
                string dc = drTN["diachi"].ToString();
                string[] ar = dc.Split(',');
                lbQuan.Text = ar[1];
                lbThanhPho.Text = ar[2];
                lbXa.Text = ar[0];
                cboCanHo.Text = dr["ma_canho"].ToString();

                string str1 = "select * from khach_hang";
                SqlDataAdapter da_KH = new SqlDataAdapter(str1, cn.consql);
                DataSet ds_KH = new DataSet();
                da_KH.Fill(ds_KH, "KH");
                DataColumn[] co1 = new DataColumn[1];
                co[0] = ds_KH.Tables[0].Columns[0];
                ds_KH.Tables[0].PrimaryKey = co;
                DataRow dr1 = ds_KH.Tables[0].Rows.Find(lbCMND.Text);
                lbEmail.Text = dr1["email"].ToString();
                lbDiaChi.Text = dr1["diachi"].ToString();
                lbSDT.Text = dr1["sodt"].ToString();
                string x = dr1["tenkh"].ToString();
                string[] arr = x.Split(' ');
                string holot = "";
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    holot += arr[i] + " ";
                }
                lbHoLot.Text = holot.Trim();
                lbTen.Text = arr[arr.Length - 1];


                DataRow dr2 = ds_CH.Tables[0].Rows.Find(new object[] { dr["ma_canho"].ToString(), dr["ma_toanha"].ToString() });
                lbTang.Text = dr2["tang"].ToString();
                lbDienTich.Text = dr2["dientich"].ToString();


              //  DataRow dr11 = ds_CH.Tables[0].Rows.Find(new object[] { cboCanHo.Text, cboToaNha.SelectedValue });
                lbTongTienThue.Text = dr["tongtien"].ToString();
            }
            catch
            { 
            
            }
        }
        SqlDataAdapter da_CH;
        DataSet ds_CH;

        SqlDataAdapter da_TN;
        DataSet ds_TN;
        public void loadTN()
        {
            try
            {
                string str2 = "select * from toa_nha";
                da_TN = new SqlDataAdapter(str2, cn.consql);
                ds_TN = new DataSet();
                da_TN.Fill(ds_TN, "TN");
                DataColumn[] co = new DataColumn[1];
                co[0] = ds_TN.Tables[0].Columns[0];
                ds_TN.Tables[0].PrimaryKey = co;
                cboToaNha.DataSource = ds_TN.Tables[0];
                cboToaNha.ValueMember = "ma_ToaNha";
                cboToaNha.DisplayMember = "ten_toanha";
            }
            catch
            { }
        }
        public void loadCH()
        {
            try
            {
            string str2 = "select * from can_ho";
            da_CH = new SqlDataAdapter(str2, cn.consql);
            ds_CH = new DataSet();
            da_CH.Fill(ds_CH, "CH");
            DataColumn[] co2 = new DataColumn[2];
            co2 = new DataColumn[] { ds_CH.Tables[0].Columns[0], ds_CH.Tables[0].Columns[1] };
            ds_CH.Tables[0].PrimaryKey = co2;
            }
            catch
            { }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemKhacHang_Click(object sender, EventArgs e)
        {
            try
            {
                FormThemKhachHang themkh = new FormThemKhachHang();
                DialogResult r= themkh.ShowDialog();
                if (r == DialogResult.OK)
                    themkh.Close();
                else if (r == DialogResult.Cancel)
                    themkh.Close();
            }
            catch
            { 
            
            }
        }

        private void FormThueSua_Load(object sender, EventArgs e)
        {

        }

        private void btnChonKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                ChonKhachHang chon = new ChonKhachHang();
                chon.ShowDialog();
                String cmq = chon.cmnd;
                cmnd = cmq;
                cn.consql.Open();
                String str = "select * from Khach_hang where cmnd='" + cmnd + "'";    
                SqlCommand cm = new SqlCommand(str, cn.consql);
                SqlDataReader re = cm.ExecuteReader();
                while (re.Read())
                {
                    String x = re["Tenkh"].ToString();
                    string[] arr = x.Split(' ');
                    string holot = "";
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        holot += arr[i] + " ";
                    }
                    lbHoLot.Text = holot.Trim();
                    lbTen.Text = arr[arr.Length - 1];
                    lbDiaChi.Text = re["diachi"].ToString();
                    lbEmail.Text = re["email"].ToString();
                    lbCMND.Text = re["cmnd"].ToString();
                    lbSDT.Text = re["sodt"].ToString();
                }
                cn.consql.Close();
            }
            catch 
            {

            }
        }
        private bool ktNhap()
        {
            if (txtTienCoc.Text != "")
            {
                return true;
            }
            return false;
        }

        private void txtTienCoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTienCoc.Text.Length >= 1)
                {
                    double tienConLai= (double.Parse(lbTongTienThue.Text) - double.Parse(txtTienCoc.Text));
                    if (tienConLai < 0)
                    {
                        MessageBox.Show("Tiền cọc phải nhỏ hơn tiền thuê");
                        txtTienConLai.Text = 0 + "";
                        btnXacNhan.Enabled = false;
                        return;
                    }
                    btnXacNhan.Enabled = true;
                    txtTienConLai.Text = tienConLai+"";
                }
            }
            catch
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "select * from can_ho where ma_toanha='" + cboToaNha.SelectedValue + "'";
                SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
                DataSet ds = new DataSet();
                da.Fill(ds, "CH");
                DataColumn[] co = new DataColumn[1];
                co[0] = ds.Tables[0].Columns[0];
                ds.Tables[0].PrimaryKey = co;
                cboCanHo.DataSource = ds.Tables[0];
                cboCanHo.ValueMember = "ma_canho";
                cboCanHo.DisplayMember = "ma_canho";

                DataRow drTN = ds_TN.Tables[0].Rows.Find(cboToaNha.SelectedValue);
                if (drTN != null)
                {
                    cboToaNha.Text = drTN["ten_toanha"].ToString();
                }
                string dc = drTN["diachi"].ToString();
                string[] ar = dc.Split(',');
                lbQuan.Text = ar[1];
                lbThanhPho.Text = ar[2];
                lbXa.Text = ar[0];
            }
            catch
            {

            }
        }

        private void cboCanHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow dr2 = ds_CH.Tables[0].Rows.Find(new object[] { cboCanHo.Text, cboToaNha.SelectedValue });
                lbTang.Text = dr2["tang"].ToString();
                lbDienTich.Text = dr2["dientich"].ToString();
            }
            catch
            {

            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (ktNhap())
                {
                    DataRow dr = ds_HD.Tables[0].Rows.Find(mahd);
                    if (dr != null)
                    {
                        DateTime bd,kt;
                        try
                        {
                            dr["ngaybatdau"] = pickerNgayBatDau.Value.ToString("dd/MM/yyyy");
                            bd=pickerNgayBatDau.Value;

                        }
                        catch
                        {
                            dr["ngaybatdau"] = pickerNgayBatDau.Value.ToString("MM/dd/yyyy");
                            bd=pickerNgayBatDau.Value;
                        }
                        try
                        {
                            dr["ngayketthuc"] = pickerNgayKetThuc.Value.ToString("dd/MM/yyyy");
                            kt=pickerNgayKetThuc.Value;
                        }
                        catch 
                        {
                            dr["ngayketthuc"] = pickerNgayKetThuc.Value.ToString("MM/dd/yyyy");
                            kt=pickerNgayKetThuc.Value;
                        }
                        TimeSpan time = kt - bd;
                        int tongSoNgay = time.Days;
                        if (tongSoNgay < 90)
                        {
                            MessageBox.Show("Phải Thuê Ít Nhất 3 Tháng(90 Ngày)");
                            return;
                        }
                        dr["tiencoc"] = txtTienCoc.Text;
                        dr["ma_toanha"] = cboToaNha.SelectedValue;
                        dr["ma_canho"] = cboCanHo.Text;
                        dr["CMND"] = lbCMND.Text;
                        dr["tongtien"] = lbTongTienThue.Text;
                        dr["tienconlai"] = txtTienConLai.Text;
                        dr["songaythue"] = tongSoNgay;
                        SqlCommandBuilder s = new SqlCommandBuilder(da_HD);
                        da_HD.Update(ds_HD, "HD");
                        MessageBox.Show("Sửa Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Không Có Dòng Này");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập đủ dữ liệu !!!!");
                }
            }
            catch
            {

            }
        }

        private void pickerNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime bd = pickerNgayBatDau.Value;
                DateTime kt = pickerNgayKetThuc.Value;

                cn.consql.Open();
                string str = "select tienthue from can_ho where ma_canho='" + cboCanHo.Text + "' and ma_toanha='" + cboToaNha.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(str, cn.consql);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                double tienThue = double.Parse(rd["tienthue"].ToString());
                rd.Close();
                cn.consql.Close();
                double tienNgay = (double)tienThue / 30;

                TimeSpan ts = kt - bd;
                double tongTien = (double)ts.Days * tienNgay;
                lbTongTienThue.Text = tongTien.ToString();
                double tienCoc = double.Parse(txtTienCoc.Text);
                txtTienConLai.Text = tongTien - tienCoc + "";
            }
            catch
            {
                cn.consql.Close();
            }
        }

        private void pickerNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime bd = pickerNgayBatDau.Value;
                DateTime kt = pickerNgayKetThuc.Value;

                cn.consql.Open();
                string str = "select tienthue from can_ho where ma_canho='" + cboCanHo.Text + "' and ma_toanha='" + cboToaNha.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(str, cn.consql);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                double tienThue = double.Parse(rd["tienthue"].ToString());
                rd.Close();
                cn.consql.Close();
                double tienNgay = (double)tienThue / 30;

                TimeSpan ts = kt - bd;
                double tongTien = (double)ts.Days * tienNgay;
                lbTongTienThue.Text = tongTien.ToString();
                double tienCoc = double.Parse(txtTienCoc.Text);
                txtTienConLai.Text = tongTien - tienCoc + "";
            }
            catch
            {
                cn.consql.Close();
            }
        }

        private void txtTienCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }
    }
}
