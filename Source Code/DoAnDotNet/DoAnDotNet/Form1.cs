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
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAnDotNet
{
    public partial class Form1 : Form
    {
        ketNoi cn;
        SqlDataAdapter da_ToaNha, da_CanHo1;
        DataSet ds_ToaNha, ds_CanHo1;
        DataColumn[] key1 = new DataColumn[1];
        SqlDataAdapter daHienthi;
        SqlDataAdapter daCanHo;
        DataSet dsData;
        DataColumn[] key = new DataColumn[1];
        DataColumn[] keyCanHo = new DataColumn[2];
        SqlDataAdapter daKhachHang;
        DataSet dsKhachHang;
        DataColumn[] keyKH = new DataColumn[1];

        String userName; String quyen;
        public Form1()
        {
            InitializeComponent();
            cn = new ketNoi();
            addListViewItem();
            addToListView();
            loadGridThue();
            loadGridChiTiet();
            dgvHDThue.ReadOnly = true;
            dgvHDThue.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvHDThue.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHDThue.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        public Form1(String userName, String quyen)
        {
            InitializeComponent();
            cn = new ketNoi();
            addListViewItem();
            addToListView();
            loadGridThue();
            loadGridChiTiet();
            dgvHDThue.ReadOnly = true;
            dgvHDThue.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvHDThue.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHDThue.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

            this.userName = userName;
            this.quyen = quyen;
        }

        public String selectTabPage
        {
            set { tab_Main.SelectTab(value); }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlDataAdapter da_TT;
        DataSet ds_TT;
        public void loadGridChiTiet()
        {
            string str = "select ma_tt as 'Mã TT',ma_hdthue as 'Mã HD',tientt as 'Tiền TT',ngaytt as 'Ngày TT' from thanh_toan";
            da_TT = new SqlDataAdapter(str, cn.consql);
            ds_TT = new DataSet();
            da_TT.Fill(ds_TT, "TT");
            dgvChiTiet.DataSource = ds_TT.Tables[0];
            DataColumn[] co = new DataColumn[1];
            co[0] = ds_TT.Tables[0].Columns[0];
            ds_TT.Tables[0].PrimaryKey = co;
        }
        SqlDataAdapter da_Thue;
        DataSet ds_Thue;
        public void loadGridThue()
        {
            string str = "select ma_hdthue as 'Mã HD Thuê',ngaybatdau as 'Ngày Bắt Đầu',ngayketthuc as 'Ngày Kết Thúc',tiencoc as 'Tiền Cọc',tienconlai as 'Tiền Còn Lại',tongtien as 'Tổng Tiền', ma_toanha as 'Mã Tòa Nhà',ma_canho as 'Mã Căn Hộ',CMND from hd_thue";
            da_Thue = new SqlDataAdapter(str, cn.consql);
            ds_Thue = new DataSet();
            da_Thue.Fill(ds_Thue, "Thue");
            dgvHDThue.DataSource = ds_Thue.Tables[0];
            DataColumn[] co = new DataColumn[1];
            co[0] = ds_Thue.Tables[0].Columns[0];
            ds_Thue.Tables[0].PrimaryKey = co;

            int count = 0;
            double tong = 0;
            count = dgvHDThue.RowCount - 1;
            lblTongSoHD.Text = count + "";
            for (int i = 0; i < count - 1; i++)
            {
                double x = double.Parse(dgvHDThue.Rows[i].Cells["Tiền Cọc"].FormattedValue.ToString());
                double y = double.Parse(dgvHDThue.Rows[i].Cells["Tiền Còn Lại"].FormattedValue.ToString());
                double z = x + y;
                tong += z;
            }
            lblTongTien.Text = tong + "";
        }
        /// <summary>
        private void loadGridCanHo()
        {
            String str = "select c.ma_canho as 'Mã căn hộ',t.ma_toanha as 'Mã tòa nhà',tang as 'Tầng',t.Ten_toanha as 'Tên tòa nhà',c.dientich as 'Diện tích',tienthue as 'Tiền Thuê',TrangThai as 'Trạng thái' from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha";
            String str1 = "select * from Can_Ho";
            daHienthi = new SqlDataAdapter(str, cn.consql);
            daCanHo = new SqlDataAdapter(str1, cn.consql);
            dsData = new DataSet();
            daHienthi.Fill(dsData, "HienThi");
            daCanHo.Fill(dsData, "CanHo");
            dgvCanHo.DataSource = dsData.Tables["HienThi"];

            keyCanHo = new DataColumn[] { dsData.Tables["CanHo"].Columns[0], dsData.Tables["CanHo"].Columns[1] };
            dsData.Tables["CanHo"].PrimaryKey = keyCanHo;

        }
        private void loadGridKhacHang()
        {
            String str = "select cmnd as 'CMND',tenkh as 'Họ tên',sodt as 'Số điện thoại',email,diachi as 'Địa chỉ',gioitinh as 'Giới tính' from Khach_hang";
            daKhachHang = new SqlDataAdapter(str, cn.consql);
            dsKhachHang = new DataSet();
            daKhachHang.Fill(dsKhachHang, "KH");
            dgvKhachHang.DataSource = dsKhachHang.Tables["KH"];
            keyKH[0] = dsKhachHang.Tables["KH"].Columns[0];
            dsKhachHang.Tables["KH"].PrimaryKey = keyKH;

        }
        private void loadCboToaNha()
        {
            String str = "select * from toa_nha";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "ToaNha");
            DataRow r = ds.Tables["ToaNha"].NewRow();
            r["ten_toanha"] = "Tất cả";
            r["ma_toanha"] = "0";
            ds.Tables["ToaNha"].Rows.InsertAt(r, 0);
            cboToaNha.DataSource = ds.Tables["ToaNha"];
            cboToaNha.DisplayMember = "ten_toanha";
            cboToaNha.ValueMember = "ma_toanha";
        }
        private void loadCboCanHo()
        {
            String str = "";
            if (cboToaNha.SelectedIndex != 0)
            {
                str = "select distinct ma_toanha,tang from can_ho where ma_toanha='" + cboToaNha.SelectedValue.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
                DataSet ds = new DataSet();
                da.Fill(ds, "CanHo");
                DataRow r = ds.Tables["CanHo"].NewRow();
                r["tang"] = 0;
                r["ma_toanha"] = "0";
                ds.Tables["CanHo"].Rows.InsertAt(r, 0);
                cboCanHo.DataSource = ds.Tables["CanHo"];
                cboCanHo.DisplayMember = "tang";
                cboCanHo.ValueMember = "ma_toanha";
            }

        }
        /// </summary>
        List<String> listTenToaNha = new List<String>();

        //tạo listview danh sách tòa nhà
        public void addListViewItem()
        {
            // reset list.
            listTenToaNha.Clear();
            String selectStr = "select * from toa_nha";
            da_ToaNha = new SqlDataAdapter(selectStr, cn.consql);
            ds_ToaNha = new DataSet();
            da_ToaNha.Fill(ds_ToaNha, "build");

            key1[0] = ds_ToaNha.Tables["build"].Columns[0];
            ds_ToaNha.Tables["build"].PrimaryKey = key1;

            for (int i = 0; i < ds_ToaNha.Tables["build"].Rows.Count; i++)
            {
                listTenToaNha.Add(ds_ToaNha.Tables["build"].Rows[i]["Ten_ToaNha"].ToString());
            }
        }

        public void addToListView()
        {
            // reset lại list view tòa nhà
            lsv_ToaNha.Clear();
            ImageList imgList = new ImageList();
            int i = 0;
            foreach (var item in listTenToaNha)
            {
                lsv_ToaNha.LargeImageList = imageList1;
                lsv_ToaNha.Items.Add(item).SubItems.Add("");
                lsv_ToaNha.Items[i].ImageIndex = 2;
                i++;
            }
        }

        List<CanHo> listApart = new List<CanHo>();

        // tạo mới danh sách căn hộ của tòa nahf.
        private void addListCanHo(int maToaNha)
        {
            listApart.Clear();
            String selectStr = "select * from can_ho where Ma_ToaNha = " + maToaNha;
            da_CanHo1 = new SqlDataAdapter(selectStr, cn.consql);
            ds_CanHo1 = new DataSet();
            da_CanHo1.Fill(ds_CanHo1, "apart");

            key1[0] = ds_CanHo1.Tables["apart"].Columns[0];
            ds_CanHo1.Tables["apart"].PrimaryKey = key1;

            for (int i = 0; i < ds_CanHo1.Tables["apart"].Rows.Count; i++)
            {
                CanHo apa = new CanHo();
                apa.ma_canho = ds_CanHo1.Tables["apart"].Rows[i]["Ma_CanHo"].ToString();
                apa.tang = int.Parse(ds_CanHo1.Tables["apart"].Rows[i]["tang"].ToString());
                apa.dienTich = ds_CanHo1.Tables["apart"].Rows[i]["dientich"].ToString();
                apa.trangThai = ds_CanHo1.Tables["apart"].Rows[i]["trangthai"].ToString();
                listApart.Add(apa);
            }
        }

        // lấy mã căn hộ
        private int getIdBuilding(String tenToaNha)
        {
            if (cn.consql.State == ConnectionState.Closed)
                cn.consql.Open();

            ListViewItem item = lsv_ToaNha.FocusedItem;
            String strSelected = item.SubItems[0].Text;
            String selectStr = "select top 1 Ma_ToaNha from toa_nha where Ten_ToaNha = N'" + strSelected + "'";
            SqlCommand cmd = new SqlCommand(selectStr, cn.consql);
            int idBuilding = (int)cmd.ExecuteScalar();

            if (cn.consql.State == ConnectionState.Open)
                cn.consql.Close();

            return idBuilding;
        }


        // đổ dữ liệu lên label tòa nhà
        private void hienThiLabel(int maToaNha)
        {
            DataRow dr = ds_ToaNha.Tables["build"].Rows.Find(maToaNha);
            if (dr != null)
            {
                lblMaToaNha.Text = dr["Ma_ToaNha"].ToString();
                lblTenToaNha.Text = dr["Ten_ToaNha"].ToString();
                lbl_SoCanHo.Text = dr["Sl_CanHo"].ToString();
                lbl_DiaChi.Text = dr["DiaChi"].ToString();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cn.consql.State == ConnectionState.Closed)
                    cn.consql.Open();

                ListViewItem item = lsv_ToaNha.FocusedItem;
                String strSelected = item.SubItems[0].Text;
                String selectStr = "select Sl_CanHo  from toa_nha where Ten_ToaNha = N'" + strSelected + "'";
                SqlCommand cmd = new SqlCommand(selectStr, cn.consql);
                int slCanHo = (int)cmd.ExecuteScalar();

                if (cn.consql.State == ConnectionState.Open)
                    cn.consql.Close();

                int n = slCanHo;

                //tạo mới list căn hộ tương ứng với tòa nhà đã chọn
                int idBuilding = getIdBuilding(strSelected);
                addListCanHo(idBuilding);
                // đổ dữ liệu lên label form tòa nhà
                hienThiLabel(idBuilding);
                // đổi tên groupbox theo tên tòa nhà
                groupBox_DsCanHo.Text = "Danh sách căn hộ cho thuê tòa nhà " + lblTenToaNha.Text;

                int count = 0;
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < n; i++)
                {
                    Button BtnNew = new Button();
                    BtnNew.Height = 80;
                    BtnNew.Width = 80;
                    //BtnNew.Location = new Point(80*i, 80*j);
                    if (count <= listApart.Count - 1)
                    {
                        String ma_CanHo = listApart[count].ma_canho.ToString();
                        String[] arrSoPhong = ma_CanHo.Split('_');
                        String info = "Phòng số: " + arrSoPhong[1] + "\nTầng: " + listApart[count].tang + "\nDiện tích: " + listApart[count].dienTich + "\nTrạng thái: " + listApart[count].trangThai;
                        BtnNew.Text = "P." + arrSoPhong[1]; // lấy thuộc tính mã căn hộ trong list căn hộ
                        BtnNew.Name = listApart[count].ma_canho.Trim();
                        toolTip1.SetToolTip(BtnNew, info);
                        if (listApart[count].trangThai.Equals("Chưa thuê"))
                        {
                            BtnNew.BackColor = Color.Green;
                            BtnNew.ForeColor = Color.White;
                        }
                        else
                        {
                            BtnNew.BackColor = Color.OrangeRed;
                            BtnNew.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        BtnNew.Text = "Trống";
                    }
                    BtnNew.Click += new EventHandler(Button_ClickEvent);
                    flowLayoutPanel1.Controls.Add(BtnNew);
                    count++;
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void Button_ClickEvent(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            String ma_CanHo = btn.Name;
            this.tab_Main.SelectTab("tabPage1");
            int rowIndex = -1;
            DataTable dt = dsData.Tables["HienThi"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().Equals(ma_CanHo))
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex == -1)
            {
                MessageBox.Show("Tìm kiếm không thành công");
            }
            else
            {
                try
                {
                    dgvCanHo.FirstDisplayedScrollingRowIndex = rowIndex;
                    dgvCanHo.ClearSelection();
                    dgvCanHo.Rows[rowIndex].Selected = true;
                }
                catch (Exception ex) { }
            }
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            FormThemToaNha formThemTN = new FormThemToaNha();
            formThemTN.Show();
            this.Hide();
            // làm thế nào để gọi form khác mà vẫn giữ được form nền (gọi lại thì event vẫn đc s.dung)
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsv_ToaNha.FocusedItem.Index >= 0 && lsv_ToaNha.FocusedItem != null)
                {
                    String tenToaNha = lsv_ToaNha.FocusedItem.Text;
                    FormSuaToaNha formSuaTN = new FormSuaToaNha(tenToaNha);
                    formSuaTN.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tòa nhà để thao tác");
                    return;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Vui lòng chọn một tòa nhà để thao tác");
            }

        }

        private bool kiemTraKhoaNgoai_tblToaNha(int maToaNha)
        {
            if (cn.consql.State == ConnectionState.Closed)
                cn.consql.Open();

            String selectStr = "select * from can_ho where Ma_ToaNha =" + maToaNha;
            SqlCommand cmd = new SqlCommand(selectStr, cn.consql);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Close();
                if (cn.consql.State == ConnectionState.Open)
                    cn.consql.Close();
                return true; // tồn tại
            }
            else
            {
                rd.Close();
                if (cn.consql.State == ConnectionState.Open)
                    cn.consql.Close();
                return false; // không tồn tại
            }
        }

        private void bnt_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có chắc muốn xóa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    if (lsv_ToaNha.FocusedItem.Index >= 0 && lsv_ToaNha.FocusedItem != null)
                    {
                        String tenToaNha = lsv_ToaNha.FocusedItem.Text;
                        int maToaNha = getIdBuilding(tenToaNha);
                        if (kiemTraKhoaNgoai_tblToaNha(maToaNha))
                        {
                            MessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa");
                        }
                        else
                        {
                            DataRow dr = ds_ToaNha.Tables["build"].Rows.Find(maToaNha);
                            if (dr != null)
                            {
                                dr.Delete();
                            }
                            SqlCommandBuilder cB = new SqlCommandBuilder(da_ToaNha);
                            da_ToaNha.Update(ds_ToaNha, "build");
                            MessageBox.Show("Xóa tòa nhà " + tenToaNha + " thành công");
                            addListViewItem();
                            addToListView();
                        }

                    }
                }
            }
            catch (Exception ex) { }
        }

        private void btnTatCaCanHo_Click(object sender, EventArgs e)
        {
            loadGridCanHo();
        }

        private void btnCanHoChuaThue_Click(object sender, EventArgs e)
        {
            String str = "select c.ma_canho as 'Mã căn hộ',t.ma_toanha as 'Mã tòa nhà',tang as 'Tầng',t.Ten_toanha as 'Tên tòa nhà',c.dientich as 'Diện tích',tienthue as 'Tiền Thuê',TrangThai as 'Trạng thái' from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha and c.TrangThai=N'Chưa thuê'";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "HienThi");
            dgvCanHo.DataSource = ds.Tables["HienThi"];
        }

        private void btnCanHoDaThue_Click(object sender, EventArgs e)
        {
            String str = "select c.ma_canho as 'Mã căn hộ',t.ma_toanha as 'Mã tòa nhà',tang as 'Tầng',t.Ten_toanha as 'Tên tòa nhà',c.dientich as 'Diện tích',tienthue as 'Tiền Thuê',TrangThai as 'Trạng thái' from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha and c.TrangThai=N'Đã thuê'";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "HienThi");
            dgvCanHo.DataSource = ds.Tables["HienThi"];
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            if (dgvCanHo.SelectedRows.Count != 0 && dgvCanHo.SelectedRows[0].Cells[6].Value.ToString() == "Chưa thuê")
            {
                String mach = dgvCanHo.SelectedRows[0].Cells[0].Value.ToString();
                String matn = dgvCanHo.SelectedRows[0].Cells[1].Value.ToString();
                FormThue thue = new FormThue(mach, matn);
                thue.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Căn hộ này đã được thuê!!!");
        }

        private void tsbtnThem_Click(object sender, EventArgs e)
        {
            FormThem them = new FormThem();
            them.ShowDialog();
            loadGridCanHo();
        }

        private void tsbtnSua_Click(object sender, EventArgs e)
        {
            String mach = dgvCanHo.SelectedRows[0].Cells[0].Value.ToString();
            String matn = dgvCanHo.SelectedRows[0].Cells[1].Value.ToString();
            FormSuaCanHo sua = new FormSuaCanHo(mach, matn);
            sua.ShowDialog();
            loadGridCanHo();
        }

        private void tsbtnXoa_Click(object sender, EventArgs e)
        {
            DialogResult re;
            re = MessageBox.Show("Chắc chắn xóa??", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (re == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < dgvCanHo.SelectedRows.Count; i++)
                    {
                        String mach = dgvCanHo.SelectedRows[i].Cells[0].Value.ToString();
                        String matn = dgvCanHo.SelectedRows[i].Cells[1].Value.ToString();
                        DataRow r = dsData.Tables["CanHo"].Rows.Find(new object[] { mach, matn });
                        if (r != null)
                        {
                            xoaChiTietCH(mach);
                            r.Delete();
                            i--;
                        }
                    }
                    SqlCommandBuilder bu = new SqlCommandBuilder(daCanHo);
                    daCanHo.Update(dsData, "CanHo");
                    MessageBox.Show("Xóa thành công!!");
                    loadGridCanHo();
                }
                catch
                {
                    MessageBox.Show("Căn hộ này đang được thuê . Không thể xóa . Lỗi !!!");
                }
            }
        }

        private void tsHienThiTheoGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = "";
            if (tsHienThiTheoGia.SelectedIndex == 0)
            {
                str = "select c.ma_canho as 'Mã căn hộ',t.ma_toanha as 'Mã tòa nhà',tang as 'Tầng',t.Ten_toanha as 'Tên tòa nhà',c.dientich as 'Diện tích',tienthue as 'Tiền Thuê',TrangThai as 'Trạng thái' from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha order by tienthue asc";
            }
            else
                str = "select c.ma_canho as 'Mã căn hộ',t.ma_toanha as 'Mã tòa nhà',tang as 'Tầng',t.Ten_toanha as 'Tên tòa nhà',c.dientich as 'Diện tích',tienthue as 'Tiền Thuê',TrangThai as 'Trạng thái' from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha order by tienthue desc";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "HienThi");
            dgvCanHo.DataSource = ds.Tables["HienThi"];
        }

        private void cboToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboToaNha.SelectedIndex != 0)
            {
                cboCanHo.Enabled = true;
                loadCboCanHo();
            }
            else
            {
                loadGridCanHo();
                cboCanHo.Enabled = false;
            }
        }

        private void cboCanHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = "";
            if (cboCanHo.SelectedIndex != 0)
            {
                str = "select c.ma_canho as 'Mã căn hộ',t.ma_toanha as 'Mã tòa nhà',tang as 'Tầng',t.Ten_toanha as 'Tên tòa nhà',c.dientich as 'Diện tích',tienthue as 'Tiền Thuê',TrangThai as 'Trạng thái' from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha and c.ma_toanha='" + cboCanHo.SelectedValue.ToString() + "' and tang='" + cboCanHo.Text + "'";
            }
            else
            {
                str = "select c.ma_canho as 'Mã căn hộ',t.ma_toanha as 'Mã tòa nhà',tang as 'Tầng',t.Ten_toanha as 'Tên tòa nhà',c.dientich as 'Diện tích',tienthue as 'Tiền Thuê',TrangThai as 'Trạng thái' from can_ho c,toa_nha t where c.ma_toanha=t.ma_toanha and c.ma_toanha='" + cboToaNha.SelectedValue.ToString() + "'";

            }
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "HienThi");
            dgvCanHo.DataSource = ds.Tables["HienThi"];
        }

        private void tsbtnThemKH_Click(object sender, EventArgs e)
        {
            FormThemKhachHang themkh = new FormThemKhachHang();
            themkh.ShowDialog();
            loadGridKhacHang();
        }

        private void tsbtnSuaKH_Click(object sender, EventArgs e)
        {
            SuaKhachHang suakh = new SuaKhachHang(dgvKhachHang.SelectedRows[0].Cells[0].Value.ToString());
            suakh.ShowDialog();
            loadGridKhacHang();
        }

        private void tsbtnXoaKH_Click(object sender, EventArgs e)
        {
            DialogResult re;
            re = MessageBox.Show("Chắc chắn xóa??", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (re == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < dgvKhachHang.SelectedRows.Count; i++)
                    {
                        DataRow r = dsKhachHang.Tables["KH"].Rows.Find(dgvKhachHang.SelectedRows[i].Cells[0].Value.ToString());
                        if (r != null)
                        {
                            r.Delete();
                            i--;
                        }
                    }
                    SqlCommandBuilder bu = new SqlCommandBuilder(daKhachHang);
                    daKhachHang.Update(dsKhachHang, "KH");
                    MessageBox.Show("Xóa thành công!!");
                    loadGridKhacHang();
                }
                catch
                {
                    MessageBox.Show("Khách hàng này đang thuê nhà . Không thể xóa . Lỗi !!!");
                    loadGridKhacHang();
                }
            }
        }

        private void tscboLocTheoChuCai_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str = "";
            if (tscboLocTheoChuCai.SelectedIndex == 0)
            {
                str = "select cmnd as 'CMND',tenkh as 'Họ tên',sodt as 'Số điện thoại',email,diachi as 'Địa chỉ',gioitinh as 'Giới tính' from khach_hang order by tenkh";
            }
            else
                str = "select cmnd as 'CMND',tenkh as 'Họ tên',sodt as 'Số điện thoại',email,diachi as 'Địa chỉ',gioitinh as 'Giới tính' from khach_hang order by tenkh desc";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "KH");
            dgvKhachHang.DataSource = ds.Tables["KH"];
        }

        private void tscboLocTheoGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = "";
            if (tscboLocTheoGioiTinh.SelectedIndex == 1)
            {
                s = "select cmnd as 'CMND',tenkh as 'Họ tên',sodt as 'Số điện thoại',email,diachi as 'Địa chỉ',gioitinh as 'Giới tính'  from khach_hang where gioitinh=N'" + tscboLocTheoGioiTinh.Text + "'";

            }
            else if (tscboLocTheoGioiTinh.SelectedIndex == 2)
            {
                s = "select cmnd as 'CMND',tenkh as 'Họ tên',sodt as 'Số điện thoại',email,diachi as 'Địa chỉ',gioitinh as 'Giới tính'  from khach_hang where gioitinh=N'" + tscboLocTheoGioiTinh.Text + "'";

            }
            else
            {
                s = "select cmnd as 'CMND',tenkh as 'Họ tên',sodt as 'Số điện thoại',email,diachi as 'Địa chỉ',gioitinh as 'Giới tính' from khach_hang";
            }
            SqlDataAdapter da = new SqlDataAdapter(s, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "KH");
            dgvKhachHang.DataSource = ds.Tables["KH"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadCboToaNha();
            loadGridCanHo();
            loadGridKhacHang();
            cboCanHo.Enabled = false;
            if (!String.IsNullOrEmpty(quyen))
            {
                if (!quyen.Equals("admin"))
                {
                    tsbtnXoa.Enabled = false;
                    bnt_Xoa.Enabled = false;
                    tsbtnXoa.Enabled = false;
                    tsbXoaTT.Enabled = false;
                    tsbtnXoaKH.Enabled = false;
                    tsbXoa.Enabled = false;
                    quảnLýTàiKhoảnNgườiDùngToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbHoTen.Text = dgvKhachHang.SelectedRows[0].Cells[1].Value.ToString();
            lbSDT.Text = dgvKhachHang.SelectedRows[0]
                .Cells[2].Value.ToString();
            lbEmail.Text = dgvKhachHang.SelectedRows[0].Cells[3].Value.ToString();
            lbDiaChi.Text = dgvKhachHang.SelectedRows[0].Cells[4].Value.ToString();
            lbCMND.Text = dgvKhachHang.SelectedRows[0].Cells[0].Value.ToString();
            lbGioiTinh.Text = dgvKhachHang.SelectedRows[0].Cells[5].Value.ToString();
        }
        string maHD;
        private void tsbSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (maHD == null)
                {
                    MessageBox.Show("Mời Chọn Dòng Muốn Sửa");
                    return;
                }
                FormThueSua f = new FormThueSua(maHD);
                DialogResult r = f.ShowDialog(this);
                if (r == DialogResult.Cancel)
                    f.Close();
                else if (r == DialogResult.OK)
                {
                    loadGridKhacHang();
                    loadGridThue();
                }
            }
            catch
            {
                MessageBox.Show("Mời Chọn Dòng Muốn Sửa!");
            }
        }

        private void tsbXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (maHD == null)
                {
                    MessageBox.Show("Mời Chọn Dòng Để Xóa");
                    return;
                }
                string str = "select * from thanh_toan where ma_hdthue='" + maHD + "'";
                cn.consql.Open();
                SqlCommand cmd = new SqlCommand(str, cn.consql);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Close();
                    cn.consql.Close();
                    MessageBox.Show("Không Thể Xóa Dòng Này");
                    return;
                }
                else
                {
                    rd.Close();
                    cn.consql.Close();
                    DataRow dr = ds_Thue.Tables[0].Rows.Find(maHD);
                    if (dr != null)
                    {
                        dr.Delete();
                        SqlCommandBuilder s = new SqlCommandBuilder(da_Thue);
                        da_Thue.Update(ds_Thue, "Thue");
                        loadGridThue();
                    }
                    else
                        MessageBox.Show("Mời Chọn Dòng Để Xóa");
                }
                maHD = null;

                lblMaHD.Text = "";
                lblTenTN.Text = "";
                lblNgayBatDau.Text = "";
                lblNgayKetThuc.Text = "";
                lblTenNguoiThue.Text = "";
                lblSoPhong.Text = "";
                lblSDT.Text = "";
                lblDiaChi.Text = "";
                lblTienThue.Text = "";
            }
            catch
            {

            }
        }

        private void tsbThemTT_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ds_Thue.Tables[0].Rows.Find(maHD);
                if (dr != null)
                {
                    ThanhToan g = new ThanhToan();
                    g.nhan(lblMaHD.Text, dr["Tiền Còn Lại"].ToString());
                    DialogResult r = g.ShowDialog(this);
                    if (r == DialogResult.OK)
                    {
                        g.Close();
                        loadGridChiTiet();
                        loadGridThue();
                    }
                    else
                        g.Close();
                }
                else
                    MessageBox.Show("Mời Chọn Dòng Để Thêm Thanh Toán");
            }
            catch
            {

            }
        }

        private void dgvHDThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maHD = dgvHDThue.Rows[e.RowIndex].Cells["Mã HD Thuê"].FormattedValue.ToString();
                if (dgvHDThue.CurrentCell == null || dgvHDThue.CurrentCell.Value == null || e.RowIndex == -1 || e.ColumnIndex == -1)
                    return;
                if (dgvHDThue.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    lblMaHD.Text = dgvHDThue.Rows[e.RowIndex].Cells["Mã HD Thuê"].FormattedValue.ToString();
                    lblNgayBatDau.Text = dgvHDThue.Rows[e.RowIndex].Cells["Ngày Bắt Đầu"].FormattedValue.ToString();
                    lblNgayKetThuc.Text = dgvHDThue.Rows[e.RowIndex].Cells["Ngày Kết Thúc"].FormattedValue.ToString();
                    double x = double.Parse(dgvHDThue.Rows[e.RowIndex].Cells["Tiền Cọc"].FormattedValue.ToString());
                    double y = double.Parse(dgvHDThue.Rows[e.RowIndex].Cells["Tiền Còn Lại"].FormattedValue.ToString());
                    lblTienThue.Text = (x + y) + "";
                    lblSoPhong.Text = dgvHDThue.Rows[e.RowIndex].Cells["Mã Căn Hộ"].FormattedValue.ToString();

                    cn.consql.Open();
                    string maToaNha = dgvHDThue.Rows[e.RowIndex].Cells["Mã Tòa Nhà"].FormattedValue.ToString();
                    string str = "select * from toa_nha where ma_toanha='" + maToaNha + "'";
                    SqlCommand cmd = new SqlCommand(str, cn.consql);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    lblTenTN.Text = rd["ten_toanha"].ToString();
                    rd.Close();
                    cn.consql.Close();

                    string cm = dgvHDThue.Rows[e.RowIndex].Cells["cmnd"].FormattedValue.ToString();
                    cn.consql.Open();
                    string str1 = "select * from khach_hang where cmnd='" + cm + "'";
                    SqlCommand cmd1 = new SqlCommand(str1, cn.consql);
                    SqlDataReader rd1 = cmd1.ExecuteReader();
                    rd1.Read();
                    lblTenNguoiThue.Text = rd1["tenkh"].ToString();
                    lblSDT.Text = rd1["sodt"].ToString();
                    lblDiaChi.Text = rd1["diachi"].ToString();
                    rd1.Close();
                    cn.consql.Close();
                }
            }
            catch (Exception e1)
            {
                maHD = null;
            }
        }

        private void tsbLoc_Click(object sender, EventArgs e)
        {
            if (cboLoc.Text != "")
            {
                string str = "";
                if (cboLoc.Text == "Gần đây")
                    str = "set dateformat dmy select ma_hdthue as 'Mã HD Thuê',ngaybatdau as 'Ngày Bắt Đầu',ngayketthuc as 'Ngày Kết Thúc',tiencoc as 'Tiền Cọc',tienconlai as 'Tiền Còn Lại',tongtien as 'Tổng Tiền', ma_toanha as 'Mã Tòa Nhà',ma_canho as 'Mã Căn Hộ',CMND from hd_thue order by NgayBatDau desc";
                else if (cboLoc.Text == "Cũ hơn")
                    str = "set dateformat dmy select ma_hdthue as 'Mã HD Thuê',ngaybatdau as 'Ngày Bắt Đầu',ngayketthuc as 'Ngày Kết Thúc',tiencoc as 'Tiền Cọc',tienconlai as 'Tiền Còn Lại',tongtien as 'Tổng Tiền', ma_toanha as 'Mã Tòa Nhà',ma_canho as 'Mã Căn Hộ',CMND from hd_thue order by NgayBatDau asc";
                SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
                DataSet ds = new DataSet();
                da.Fill(ds, "Thue");
                dgvHDThue.DataSource = ds.Tables[0];
                DataColumn[] co = new DataColumn[1];
                co[0] = ds.Tables[0].Columns[0];
                ds.Tables[0].PrimaryKey = co;
            }
            else
                MessageBox.Show("Mời Chọn Kiểu Trước Khi Lọc");
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            loadGridThue();
        }

        private void btnTrongThoiHan_Click(object sender, EventArgs e)
        {
            string ngayNow = DateTime.Now.ToString("dd/MM/yyyy");
            string str = "set dateformat dmy select ma_hdthue as 'Mã HD Thuê',ngaybatdau as 'Ngày Bắt Đầu',ngayketthuc as 'Ngày Kết Thúc',tiencoc as 'Tiền Cọc',tienconlai as 'Tiền Còn Lại',tongtien as 'Tổng Tiền', ma_toanha as 'Mã Tòa Nhà',ma_canho as 'Mã Căn Hộ',CMND from hd_thue where ngayketthuc>='" + ngayNow + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "Thue");
            dgvHDThue.DataSource = ds.Tables[0];
            DataColumn[] co = new DataColumn[1];
            co[0] = ds.Tables[0].Columns[0];
            ds.Tables[0].PrimaryKey = co;
        }

        private void btnDaKetThuc_Click(object sender, EventArgs e)
        {
            string ngayNow = DateTime.Now.ToString("dd/MM/yyyy");
            string str = "set dateformat dmy select ma_hdthue as 'Mã HD Thuê',ngaybatdau as 'Ngày Bắt Đầu',ngayketthuc as 'Ngày Kết Thúc',tiencoc as 'Tiền Cọc',tienconlai as 'Tiền Còn Lại',tongtien as 'Tổng Tiền', ma_toanha as 'Mã Tòa Nhà',ma_canho as 'Mã Căn Hộ',CMND from hd_thue where ngayketthuc<'" + ngayNow + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "Thue");
            dgvHDThue.DataSource = ds.Tables[0];
            DataColumn[] co = new DataColumn[1];
            co[0] = ds.Tables[0].Columns[0];
            ds.Tables[0].PrimaryKey = co;
        }

        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTim.Text != "")
            {
                string str = "select ma_tt as 'Mã TT',ma_hdthue as 'Mã HD',tientt as 'Tiền TT',ngaytt as 'Ngày TT' from thanh_toan where ma_HDThue='" + txtTim.Text.Trim() + "'";
                SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
                DataSet ds = new DataSet();
                da.Fill(ds, "TT");
                dgvChiTiet.DataSource = ds.Tables[0];
                DataColumn[] co = new DataColumn[1];
                co[0] = ds.Tables[0].Columns[0];
                ds.Tables[0].PrimaryKey = co;
            }
            else
            {
                MessageBox.Show("Mời Nhập Mã HD Thuê Cần Tìm");
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            loadGridChiTiet();
        }

        private void btnGanDay_Click(object sender, EventArgs e)
        {

            string str = "set dateformat dmy select ma_tt as 'Mã TT',ma_hdthue as 'Mã HD',tientt as 'Tiền TT',ngaytt as 'Ngày TT' from thanh_toan order by NgayTT desc";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "TT");
            dgvChiTiet.DataSource = ds.Tables[0];
            DataColumn[] co = new DataColumn[1];
            co[0] = ds.Tables[0].Columns[0];
            ds.Tables[0].PrimaryKey = co;
        }

        private void btnCuHon_Click(object sender, EventArgs e)
        {
            string str = "set dateformat dmy select ma_tt as 'Mã TT',ma_hdthue as 'Mã HD',tientt as 'Tiền TT',ngaytt as 'Ngày TT' from thanh_toan order by NgayTT asc";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "TT");
            dgvChiTiet.DataSource = ds.Tables[0];
            DataColumn[] co = new DataColumn[1];
            co[0] = ds.Tables[0].Columns[0];
            ds.Tables[0].PrimaryKey = co;
        }

        private void tsbXoaTT_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ds_TT.Tables[0].Rows.Find(maGD);
                if (dr != null)
                {
                    dr.Delete();
                }
                else
                    MessageBox.Show("Mời Chọn Dòng Để Xóa");
                SqlCommandBuilder s = new SqlCommandBuilder(da_TT);
                da_TT.Update(ds_TT, "TT");
                loadGridChiTiet();
                loadGridThue();
                maGD = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Mời Chọn Dòng Để Xóa");
            }
        }
        string maGD;
        private void tsbSuaTT_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ds_TT.Tables[0].Rows.Find(maGD);
                if (dr != null)
                {
                    SuaThanhToan s = new SuaThanhToan();
                    s.nhan(dr["Mã TT"].ToString(), dr["Mã HD"].ToString());
                    DialogResult r = s.ShowDialog(this);
                    if (r == DialogResult.Cancel)
                    {
                        s.Close();
                        return;
                    }
                    else if (r == DialogResult.OK)
                    {
                        loadGridChiTiet();
                        loadGridThue();
                        return;
                    }
                }
                else
                    MessageBox.Show("Mời Chọn Dòng Để Sửa");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Mời Chọn Dòng Để Sửa");
            }
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                maGD = dgvChiTiet.Rows[e.RowIndex].Cells["Mã TT"].FormattedValue.ToString();
            }
            catch (Exception e1)
            {
                maGD = null;
            }
        }

        private void tableLayoutPanel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvHDThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {

        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void xoaChiTietCH(String ma)
        {
            cn.consql.Open();
            SqlCommand cm = new SqlCommand("delete chi_tiet_can_ho where macanho='" + ma + "'", cn.consql);
            int a = cm.ExecuteNonQuery();
            if (a >= 1)
            {
                MessageBox.Show("Xóa chi tiết căn hộ thành công!!");
            }
            //else
            //    MessageBox.Show("Xóa chi tiết căn hộ không thành công!!");
            cn.consql.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < dgvCanHo.Rows.Count - 1; i++)
            {
                String mach = dgvCanHo.Rows[i].Cells[0].Value.ToString();
                String matn = dgvCanHo.Rows[i].Cells[1].Value.ToString();
                DateTime end = layKetThuc(mach, matn);
                DataRow row = dsData.Tables["CanHo"].Rows.Find(new object[] { mach, matn });
                if (!ktTinhTrang(now, end))
                {
                    row["TrangThai"] = "Chưa thuê";

                }
                else
                {
                    row["TrangThai"] = "Đã thuê";
                }
                SqlCommandBuilder bu = new SqlCommandBuilder(daCanHo);
                daCanHo.Update(dsData, "CanHo");

            }
            loadGridCanHo();
        }
        private bool ktTinhTrang(DateTime now, DateTime end)
        {
            TimeSpan tgChenhLech = now.Subtract(end);
            int a = tgChenhLech.Days;
            if (a < 0)
            {
                return true;

            }
            return false;
        }
        private DateTime layKetThuc(String mach, String matn)
        {
            cn.consql.Open();
            String str = "select ngayketthuc from hd_thue where ma_canho='" + mach + "' and ma_toanha='" + matn + "' order by ngayketthuc desc";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            var a = cm.ExecuteScalar();
            if (a != null)
            {
                cn.consql.Close();
                return (DateTime)a;
            }
            cn.consql.Close();
            return DateTime.Now;

        }

        private void dgvCanHo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvCanHo.SelectedRows[0];
            lbMaCanHo.Text = r.Cells[0].Value.ToString();
            lbMaToaNha.Text = r.Cells[1].Value.ToString();
            lbDienTich.Text = r.Cells[4].Value.ToString();
            lbGia.Text = r.Cells[5].Value.ToString();
        }

        private void btnChiTietCH_Click(object sender, EventArgs e)
        {

            DataGridViewRow r = dgvCanHo.SelectedRows[0];
            String mach = r.Cells[0].Value.ToString();
            String matn = r.Cells[1].Value.ToString();
            if (!ktChiTiet(mach, matn))
            {
                MessageBox.Show("Căn hộ này chưa được cập nhật chi tiết!!!!");
                return;
            }

            if (r != null)
            {
                FormXemChiTietCanHo xem = new FormXemChiTietCanHo(mach, matn);
                xem.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mời chọn căn hộ!!");
            }


        }
        private bool ktChiTiet(String mach, String matn)
        {
            cn.consql.Open();
            String str = "select  * from can_ho c,toa_nha t,chi_tiet_can_ho ct where c.Ma_CanHo=ct.MaCanHo and c.Ma_ToaNha=t.Ma_ToaNha and c.Ma_CanHo='" + mach + "' and t.Ma_ToaNha='" + matn + "'";
            SqlCommand cm = new SqlCommand(str, cn.consql);
            var a = cm.ExecuteScalar();
            if (a != null)
            {
                cn.consql.Close();
                return true;
            }
            cn.consql.Close();
            return false;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void khởiĐộngLạiChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(quyen) && !String.IsNullOrEmpty(userName))
            {
                Form1 form = new Form1(userName, quyen);
                form.Show();
                this.Close();
            }
            else
            {
                Form1 form = new Form1();
                form.Show();
                this.Close();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap dn = new FormDangNhap();
            dn.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new MyCrystalHD().ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        string ma = "";
        private void clickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ma = dgvHDThue.SelectedRows[0].Cells[0].Value.ToString();
            MyCrystalCTHD c = new MyCrystalCTHD(ma);
            c.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //Tìm và đặt giá trị MAX cho trục Y
            int max = Convert.ToInt32(dgvChiTiet.Rows[0].Cells[2].Value);
            for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                if (max < Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value))
                    max = Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value);
            if (chart1.ChartAreas[0].AxisY.Maximum < max) chart1.ChartAreas[0].AxisY.Maximum = max;

            chart1.Series.Clear();
            for (int n = 0; n < dgvChiTiet.Rows.Count; n++) //Duyệt từ dòng đầu tiên đến dòng cuối cùng của dataGridView1
            {
                Series s = new Series();
                DataPoint p = new DataPoint();
                p.XValue = n;
                p.SetValueY(Convert.ToDouble(dgvChiTiet.Rows[n].Cells[2].Value));
                p.AxisLabel = "Ma_TT " + (dgvChiTiet.Rows[n].Cells[0].Value);
                s.Points.Add(p);
                chart1.Series.Add(s);
            }
        }

        private void tab_Main_Selected(object sender, TabControlEventArgs e)
        {
            if (tab_Main.SelectedIndex == 5)
            {
                //Tìm và đặt giá trị MAX cho trục Y
                int max = Convert.ToInt32(dgvCanHo.Rows[0].Cells[5].Value);
                for (int i = 0; i < dgvCanHo.Rows.Count; i++)
                    if (max < Convert.ToInt32(dgvCanHo.Rows[i].Cells[2].Value))
                        max = Convert.ToInt32(dgvCanHo.Rows[i].Cells[2].Value);
                if (chart1.ChartAreas[0].AxisY.Maximum < max) chart1.ChartAreas[0].AxisY.Maximum = max;

                chart1.Series.Clear();
                for (int n = 0; n < dgvCanHo.Rows.Count; n++)
                {
                    String Name = "Mã căn hộ: " + dgvCanHo.Rows[n].Cells[0].Value + "/ Mã tòa nhà: " + dgvCanHo.Rows[n].Cells[1].Value;
                    Series s = new Series();
                    s.Name = Name;
                    DataPoint p = new DataPoint();
                    p.XValue = n;
                    p.SetValueY(Convert.ToDouble(dgvCanHo.Rows[n].Cells[5].Value));
                    //p.AxisLabel = n.ToString();
                    //p.Name = n.ToString();
                    p.BorderWidth = 2;
                    s.Points.Add(p);
                    chart1.Series.Add(s);
                }
            }
        }

        private void quảnLýTàiKhoảnNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.Show();
            this.Hide();
        }








    }
}
