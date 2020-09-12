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
    public partial class SuaCanHo : Form
    {
        Connection cn;
        String _mach;

        public String mach
        {
          get { return _mach; }
          set { _mach = value; }
        }
        public SuaCanHo(String ma)
        {
            mach=ma;
            cn = new Connection();
            InitializeComponent();
        }

        private void SuaCanHo_Load(object sender, EventArgs e)
        {
            loadText();
            loadCboToaNha();
            loadCboDonVi();
        }
        private void loadCboToaNha()
        {
            String str = "select * from toa_nha";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "ToaNha");
            cboToaNha.DataSource = ds.Tables["ToaNha"];
            cboToaNha.DisplayMember = "ten_toanha";
            cboToaNha.ValueMember = "ma_toanha";
        }
        private void loadText()
        {
            cn.con.Open();
            String str = "select * from can_ho c,toa_nha t where ma_canho='" +mach+ "' and t.ma_toanha=c.ma_toanha";
            SqlCommand cm = new SqlCommand(str, cn.con);
            SqlDataReader re = cm.ExecuteReader();
            while (re.Read())
            {
                cboToaNha.Text = re["ten_toanha"].ToString();
                cboDonVi.Text = re["Donvitien"].ToString();
                txtDienTich.Text = re["dientich"].ToString();
                txtGiaThue.Text = re["tienthue"].ToString();
                txtTang.Text = re["tang"].ToString();
                txtTrangThai.Text = re["TrangThai"].ToString();
            }
            String[] arr = mach.Split('_');
            txtSoPhong.Text = arr[1];
            txtSoPhong.Enabled = false;
            txtTang.Enabled = false;
            cn.con.Close();

        }
        private void loadCboDonVi()
        {
            String str = "select distinct DonViTien,ma_canho from can_ho";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "DonVi");
            cboDonVi.DataSource = ds.Tables["DonVi"];
            cboDonVi.DisplayMember = "DonViTien";
            cboDonVi.ValueMember = "ma_canho";
        }
         private bool ktNhap()
        {
            if (cboToaNha.Text != "" && cboDonVi.Text != "" && txtTrangThai.Text != "" && txtTang.Text != "" && txtSoPhong.Text != "" && txtGiaThue.Text != "" && txtDienTich.Text != "")
            {
                return true;
            }
            return false;
        }
        //private bool ktSoPhong(String s){
        //        cn.con.Open();
        //        String str = "select * from can_ho where sophong='" + txtSoPhong.Text + "'";
        //        SqlCommand cm = new SqlCommand(str, cn.con);
        //        var a= cm.ExecuteScalar();        
        //        if (a == null)
        //        {
        //            cn.con.Close();
        //            return true;
        //        }
        //        cn.con.Close();
        //        return false;
        //    }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if (ktNhap() )
            {
                //if (ktSoPhong(txtSoPhong.Text))
                //{
                    cn.con.Open();
                    String matn=cboToaNha.SelectedValue.ToString();
                    String tang=txtTang.Text;
                    String gia= txtGiaThue.Text;
                    String dv=cboDonVi.Text;
                    String tt=txtTrangThai.Text;
                    String sp=txtSoPhong.Text;
                    String dt=txtDienTich.Text;
                    String str = "update can_ho set  tienthue='" +gia+ "',donvitien='" +dv+ "',dientich='" +dt + "',trangthai=N'" +tt+ "' where ma_canho='"+mach+"'";
                    SqlCommand cm = new SqlCommand(str, cn.con);
                    int a = cm.ExecuteNonQuery();
                    if (a != 0)
                    {
                        MessageBox.Show("Sửa thành công!!!");
                    }
                    else
                        MessageBox.Show("Thất bại");
                    cn.con.Close();
                }
            //    //else
            //    //{
            //    //    MessageBox.Show("Số phòng này đã tồn tại!!!");
            //    //    txtSoPhong.Focus();
            //    //}
            //}
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu!!");
            }
        }
        }
    }

