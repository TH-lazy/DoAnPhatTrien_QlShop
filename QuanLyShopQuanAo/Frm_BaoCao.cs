using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using OfficeOpenXml;
using System.IO;

namespace QuanLyShopQuanAo
{
    public partial class Frm_BaoCao : Form
    {
        string loaiBC = "";
        HangHoaDALBLL hh = new HangHoaDALBLL();
        NhapHangDALBLL nhaph = new NhapHangDALBLL();
        DoiTac doiTac = new DoiTac();
        KhoDALBLL kho = new KhoDALBLL();
        NhaCC nhacc = new NhaCC();
        HoaDonLeDALBLL hoadon = new HoaDonLeDALBLL();

        int maNV = 0, maKH = 0, cothue = -1;
        string maLo = null, maNCC = null, maHang = null, maHT = null;
        DateTime d0 = DateTime.MinValue, d1 = DateTime.MinValue;
        public Frm_BaoCao()
        {
            InitializeComponent();
        }

        public Frm_BaoCao(string mess): this()
        {
            loaiBC = mess;
        }

        private void Frm_BaoCao_Load(object sender, EventArgs e)
        {
            loadData();
            dateEdit1.DateTime = dateEdit2.DateTime = DateTime.Now;
            dateEdit1.Text = dateEdit2.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void loadData()
        {
            switch(loaiBC)
            {
                case "bk_nhapkho":
                    {
                        lbltenbaocao.Text = "Bảng kê Phiếu nhập kho";
                        setupForm_BKNhapKho();
                        dataGridView1.DataSource = nhaph.loadPhieuNhapHang();
                        lblDK4.Visible = lblDK5.Visible = lblDK6.Visible = false;
                        comboBox4.Visible = comboBox5.Visible = comboBox6.Visible = false;
                    }
                    break;
                case "bk_ctnhapkho":
                    {
                        lbltenbaocao.Text = "Bảng kê chi tiết Phiếu nhập kho";
                        setupForm_BKCTNhapKho();
                        dataGridView1.DataSource = nhaph.layCTPNK_DK(maNV, maLo, maNCC, maHang, d0, d1);
                        lblDK5.Visible = lblDK6.Visible = false;
                        comboBox5.Visible = comboBox6.Visible = false;
                    }
                    break;
                case "bk_hoadonle":
                    {
                        lbltenbaocao.Text = "Bảng kê hóa đơn bán lẻ";
                        setupForm_BKHDL();
                        dataGridView1.DataSource = hoadon.load_HoaDon(maNV, maKH, maHT, cothue, d0, d1);
                        lblDK5.Visible = lblDK6.Visible = false;
                        comboBox5.Visible = comboBox6.Visible = false;
                    }
                    break;
                case "bk_cthoadonle":
                    {
                        lbltenbaocao.Text = "Bảng kê chi tiết hóa đơn bán lẻ";
                        setupForm_BKHDLCT();
                        dataGridView1.DataSource = hoadon.load_CTHoaDon(maNV, maKH, maHT, maHang, cothue, d0, d1);
                        lblDK6.Visible = false;
                        comboBox6.Visible = false;
                    }break;
            }
        }

        private void setupForm_BKNhapKho()
        {
            lblDK1.Text = "NV lập phiếu";
            lblDK1.Enabled = false;
            comboBox1.DataSource = doiTac.loadNhanVien();
            comboBox1.DisplayMember = "TenNV";
            comboBox1.ValueMember = "MaNV";
            comboBox1.Enabled = false;
            lblDK2.Text = "Lô";
            lblDK2.Enabled = false;
            comboBox2.DataSource = hh.loadLoHang();
            comboBox2.DisplayMember = "TenLo";
            comboBox2.ValueMember = "MaLo";
            comboBox2.Enabled = false;
            lblDK3.Text = "Nhà cung cấp";
            lblDK3.Enabled = false;
            comboBox3.DataSource = nhacc.loadNCC();
            comboBox3.DisplayMember = "TenNCC";
            comboBox3.ValueMember = "MaNCC";
            comboBox3.Enabled = false;
        }

        private void setupForm_BKCTNhapKho()
        {
            setupForm_BKNhapKho();
            lblDK4.Text = "Tên hàng";
            comboBox4.DataSource = hh.Lay_MaHangTenHang();
            comboBox4.DisplayMember = "TenHang";
            comboBox4.ValueMember = "MaHang";
        }

        private void setupForm_BKHDL()
        {
            lblDK1.Text = "Khách hàng";
            lblDK1.Enabled = false;
            comboBox1.DataSource = doiTac.loadKhachHang();
            comboBox1.DisplayMember = "TenKH";
            comboBox1.ValueMember = "MaKH";
            comboBox1.Enabled = false;
            lblDK2.Text = "NV lập";
            lblDK2.Enabled = false;
            comboBox2.DataSource = doiTac.loadNhanVien();
            comboBox2.DisplayMember = "TenNV";
            comboBox2.ValueMember = "MaNV";
            comboBox2.Enabled = false;
            lblDK3.Text = "Hình thức TT";
            lblDK3.Enabled = false;
            comboBox3.DataSource = hh.loadHinhThuc();
            comboBox3.DisplayMember = "TenHT";
            comboBox3.ValueMember = "MaHT";
            comboBox3.Enabled = false;
            lblDK4.Text = "Tiền thuế";
            lblDK4.Enabled = false;
            comboBox4.DataSource = new List<(int key, string value)>(2) { (0,"= 0"), (1, "> 0") };
            comboBox4.DisplayMember = "value";
            comboBox4.ValueMember = "key";
            comboBox4.Enabled = false;
        }

        private void setupForm_BKHDLCT()
        {
            setupForm_BKHDL();
            lblDK5.Text = "Tên hàng";
            lblDK5.Enabled = false;
            comboBox5.DataSource = hh.Lay_MaHangTenHang();
            comboBox5.DisplayMember = "TenHang";
            comboBox5.ValueMember = "MaHang";
            comboBox5.Enabled = false;
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            switch (loaiBC)
            {
                case "bk_nhapkho":
                    {
                        LocDL_BKPhNhapKho();
                    }
                    break;
                case "bk_ctnhapkho":
                    {
                        LocDL_BKPhNhapKhoCT();
                    }
                    break;
                case "bk_hoadonle":
                    {
                        LocDL_BKHDLe();
                    }
                    break;
                case "bk_cthoadonle":
                    {
                        LocDL_BKHDLeCT();
                    }
                    break;
            }
            
        }

        private void LocDL_BKPhNhapKho()
        {
            d0 = dateEdit1.DateTime;
            d1 = dateEdit2.DateTime;
            if (comboBox1.Enabled && comboBox1.SelectedItem != null)
            {
                maNV = int.Parse(comboBox1.SelectedValue.ToString());
            }
            if (comboBox2.Enabled && comboBox2.SelectedItem != null)
            {
                maLo = comboBox2.SelectedValue.ToString();
            }
            if (comboBox3.Enabled && comboBox3.SelectedItem != null)
            {
                maNCC = comboBox3.SelectedValue.ToString();
            }
            if(d0 == DateTime.MinValue || d1 == DateTime.MinValue)
            {
                MessageBox.Show("Chưa chọn khoảng thời gian.");
                return;
            }
            else if(d0 > d1)
            {
                MessageBox.Show("Khoảng thời gian không hợp lệ.");
                return;
            }
            dataGridView1.DataSource = nhaph.lay_PNK_DK(maNV, maLo, maNCC, d0, d1);
        }

        private void LocDL_BKPhNhapKhoCT()
        {
            d0 = dateEdit1.DateTime;
            d1 = dateEdit2.DateTime;
            if (comboBox1.Enabled && comboBox1.SelectedItem != null)
            {
                maNV = int.Parse(comboBox1.SelectedValue.ToString());
            }
            if (comboBox2.Enabled && comboBox2.SelectedItem != null)
            {
                maLo = comboBox2.SelectedValue.ToString();
            }
            if (comboBox3.Enabled && comboBox3.SelectedItem != null)
            {
                maNCC = comboBox3.SelectedValue.ToString();
            }
            if (comboBox4.Enabled && comboBox4.SelectedItem != null)
            {
                maHang = comboBox4.SelectedValue.ToString();
            }
            if (d0 == DateTime.MinValue || d1 == DateTime.MinValue)
            {
                MessageBox.Show("Chưa chọn khoảng thời gian.");
                return;
            }
            else if (d0 > d1)
            {
                MessageBox.Show("Khoảng thời gian không hợp lệ.");
                return;
            }
            dataGridView1.DataSource = nhaph.layCTPNK_DK(maNV, maLo, maNCC, maHang, d0, d1);
        }

        private void LocDL_BKHDLe()
        {
            d0 = dateEdit1.DateTime;
            d1 = dateEdit2.DateTime;
            if (comboBox1.Enabled && comboBox1.SelectedItem != null)
            {
                maKH = int.Parse(comboBox1.SelectedValue.ToString());
            }
            if (comboBox2.Enabled && comboBox2.SelectedItem != null)
            {
                maNV = int.Parse(comboBox2.SelectedValue.ToString());
            }
            if (comboBox3.Enabled && comboBox3.SelectedItem != null)
            {
                maHT = comboBox3.SelectedValue.ToString();
            }
            if(comboBox4.Enabled && comboBox4.SelectedItem != null)
            {
                cothue = comboBox4.SelectedIndex; // SelectedValue.ToString()--> parse int
            }
            if (d0 == DateTime.MinValue || d1 == DateTime.MinValue)
            {
                MessageBox.Show("Chưa chọn khoảng thời gian.");
                return;
            }
            else if (d0 > d1)
            {
                MessageBox.Show("Khoảng thời gian không hợp lệ.");
                return;
            }
            dataGridView1.DataSource = hoadon.load_HoaDon(maKH, maNV, maHT, cothue, d0, d1);
        }

        private void LocDL_BKHDLeCT()
        {
            d0 = dateEdit1.DateTime;
            d1 = dateEdit2.DateTime;
            if (comboBox1.Enabled && comboBox1.SelectedItem != null)
            {
                maKH = int.Parse(comboBox1.SelectedValue.ToString());
            }
            if (comboBox2.Enabled && comboBox2.SelectedItem != null)
            {
                maNV = int.Parse(comboBox2.SelectedValue.ToString());
            }
            if (comboBox3.Enabled && comboBox3.SelectedItem != null)
            {
                maHT = comboBox3.SelectedValue.ToString();
            }
            if (comboBox4.Enabled && comboBox4.SelectedItem != null)
            {
                cothue = comboBox4.SelectedIndex; // SelectedValue.ToString()--> parse int
            }
            if(comboBox5.Enabled && comboBox5.SelectedItem != null)
            {
                maHang = comboBox5.SelectedValue.ToString();
            }
            if (d0 == DateTime.MinValue || d1 == DateTime.MinValue)
            {
                MessageBox.Show("Chưa chọn khoảng thời gian.");
                return;
            }
            else if (d0 > d1)
            {
                MessageBox.Show("Khoảng thời gian không hợp lệ.");
                return;
            }
            dataGridView1.DataSource = hoadon.load_CTHoaDon(maNV, maKH, maHT, maHang, cothue, d0, d1);
        }

        private void sbtExport_Click(object sender, EventArgs e)
        {
            switch (loaiBC)
            {
                case "bk_nhapkho":
                    {
                        Export_BKPhieuNhap();
                    }break;
                case "bk_ctnhapkho":
                    {
                        Export_BKCTPhieuNhap();
                    }break;
                case "bk_hoadonle":
                    {
                        Export_BKHoaDonLe();
                    }
                    break;
                case "bk_cthoadonle":
                    {
                        Export_BKHoaDonLeCT();
                    }
                    break;
            }
            
        }

        private void sbtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDieuKien_Click(object sender, EventArgs e)
        {
            if (lblDieuKien.Text == "Điều kiện lọc")
            {
                // have enabled but is have visibled ?
                lblDK1.Enabled = lblDK2.Enabled = lblDK3.Enabled = true;
                lblDK4.Enabled = lblDK5.Enabled = lblDK6.Enabled = true;
                comboBox1.Enabled = comboBox2.Enabled = comboBox3.Enabled = true;
                comboBox4.Enabled = comboBox5.Enabled = comboBox6.Enabled = true;
                lblDieuKien.Text = "Hủy điều kiện";
            }
            else // = "Hủy điều kiện"
            {
                lblDK1.Enabled = lblDK2.Enabled = lblDK3.Enabled = false;
                lblDK4.Enabled = lblDK5.Enabled = lblDK6.Enabled = false;
                comboBox1.Enabled = comboBox2.Enabled = comboBox3.Enabled = false;
                comboBox4.Enabled = comboBox5.Enabled = comboBox6.Enabled = false;
                lblDieuKien.Text = "Điều kiện lọc";
                maNV = 0; maKH = 0; cothue = -1;
                maLo = maNCC = maHang  = maHT = null;
                d0 = d1 = DateTime.MinValue;
            }
        }

        private void lblFilter_MouseLeave(object sender, EventArgs e)
        {
            lblFilter.BackColor = Color.Transparent;
        }

        private void lblDieuKien_MouseLeave(object sender, EventArgs e)
        {
            lblDieuKien.BackColor = Color.Transparent;
        }

        private void lblFilter_MouseEnter(object sender, EventArgs e)
        {
            lblFilter.BackColor = Color.DeepSkyBlue;
        }

        private void lblDieuKien_MouseEnter(object sender, EventArgs e)
        {
            lblDieuKien.BackColor = Color.DeepSkyBlue;
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            d0 = dateEdit1.DateTime;
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            d1 = dateEdit2.DateTime;
        }

        private void Export_BKPhieuNhap()
        {
            // prepare the file paths
            string _Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileGoc = _Path + @"\BaoCao\BK_PhieuNhapKho.xlsx";
            string tag = GetFormattedDateTime();
            string fileCopy = _Path + @"\BaoCao_Exported\BK_PhieuNhapKho_" + tag + ".xlsx";
            // copy file
            File.Copy(fileGoc, fileCopy);
            // create required instances
            FileInfo info = new FileInfo(fileCopy);
            ExcelPackage excel = new ExcelPackage(info);
            List<ChiTiet_PhieuNhapKho> list = nhaph.lay_CTPNK_DK(maNV, maLo, maNCC, maHang, d0, d1);

            if (d0 != DateTime.MinValue && d1 != DateTime.MinValue)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "Từ " + d0.ToString("dd/MM/yyyy") + " đến " + d1.ToString("dd/MM/yyyy");
            }
            else
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "(tất cả phiếu nhập kho)";
            }
            excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Style.Font.Italic = true;
            var data = list.GroupBy(pn => new { pn.MaPhieuNhap, pn.PhieuNhapKho.NgayLapPhieu, pn.PhieuNhapKho.MaNV, pn.PhieuNhapKho.MoTa })
                .Select(pn => new { ma = pn.Key, sl = pn.Sum(p => p.SoLuong), tt = pn.Sum(p => p.ThanhTien) }).ToList();

            #region --- Inserting data to excel ---
            int row = 8;
            for(int index = 0; index < data.Count; index++)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 1].Value = index + 1; // stt
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 2].Value = data[index].ma.MaPhieuNhap;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 3].Value = data[index].ma.NgayLapPhieu;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 4].Value = data[index].ma.MaNV;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 5].Value = data[index].sl;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 6].Value = data[index].tt;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 7].Value = data[index].ma.MoTa;
                row++;
                excel.Workbook.Worksheets["Sheet1"].InsertRow(row, 1, row - 1);
            }
            #endregion

            for (int k = 2; k <= 7; k++)
                excel.Workbook.Worksheets["Sheet1"].Column(k).AutoFit();
            excel.SaveAs(info);
            // open and show file excel
            System.Diagnostics.Process.Start(fileCopy);
        }

        private void Export_BKCTPhieuNhap()
        {
            // prepare the file paths
            string _Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileGoc = _Path + @"\BaoCao\BK_PhieuNhapKhoCT.xlsx";
            string tag = GetFormattedDateTime();
            string fileCopy = _Path + @"\BaoCao_Exported\BK_PhieuNhapKhoCT_" + tag + ".xlsx";
            // copy file
            File.Copy(fileGoc, fileCopy);
            // create required instances
            FileInfo info = new FileInfo(fileCopy);
            ExcelPackage excel = new ExcelPackage(info);
            List<ChiTiet_PhieuNhapKho> list = nhaph.lay_CTPNK_DK(maNV, maLo, maNCC, maHang, d0, d1);

            if (d0 != DateTime.MinValue && d1 != DateTime.MinValue)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "Từ " + d0.ToString("dd/MM/yyyy") + " đến " + d1.ToString("dd/MM/yyyy");
            }
            else
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "(tất cả chi tiết phiếu nhập kho)";
            }
            excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Style.Font.Italic = true;

            #region --- Inserting data to excel ---
            int stt = 1;
            int row = 8;
            foreach(ChiTiet_PhieuNhapKho ct in list)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 1].Value = stt;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 2].Value = ct.MaPhieuNhap;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 3].Value = ct.PhieuNhapKho.NgayLapPhieu;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 4].Value = ct.PhieuNhapKho.NhanVien.TenNV;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 5].Value = ct.PhieuNhapKho.MaNCC;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 6].Value = ct.PhieuNhapKho.NhaCungCap.TenNCC;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 7].Value = ct.MaHang;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 8].Value = ct.HangHoa.TenHang;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 9].Value = ct.HangHoa.MaDVT;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 10].Value = ct.SoLuong;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 11].Value = ct.GiaVon;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 12].Value = ct.ThanhTien;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 13].Value = ct.HangHoa.LoHang.TenLo;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 14].Value = ct.MoTa;
                row++;
                stt++;
                excel.Workbook.Worksheets["Sheet1"].InsertRow(row, 1, row - 1);
            }
            #endregion

            for (int i = 2; i <= 14; i++)
                excel.Workbook.Worksheets["Sheet1"].Column(i).AutoFit();
            excel.SaveAs(info);
            // open and show file excel
            System.Diagnostics.Process.Start(fileCopy);
        }

        private void Export_BKHoaDonLe()
        {
            // prepare the file paths
            string _Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileGoc = _Path + @"\BaoCao\BK_HoaDonBanLe.xlsx";
            string tag = GetFormattedDateTime();
            string fileCopy = _Path + @"\BaoCao_Exported\BK_HoaDonBanLe_" + tag + ".xlsx";
            // copy file
            File.Copy(fileGoc, fileCopy);
            // create required instances
            FileInfo info = new FileInfo(fileCopy);
            ExcelPackage excel = new ExcelPackage(info);
            List<HoaDonBanLe> list = hoadon.layDS_HDLe(maNV, maKH, maHT, cothue, d0, d1);
            if (d0 != DateTime.MinValue && d1 != DateTime.MinValue)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "Từ " + d0.ToString("dd/MM/yyyy") + " đến " + d1.ToString("dd/MM/yyyy");
            }
            else
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "(tất cả hóa đơn bán lẻ)";
            }
            excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Style.Font.Italic = true;

            #region --- Inserting data to excel ---
            int stt = 1;
            int row = 8;
            foreach(HoaDonBanLe hd in list)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 1].Value = stt;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 2].Value = hd.MaHDL;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 3].Value = hd.NgayLap.Value.ToString("dd/MM/yyyy");
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 4].Value = hd.MaNV;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 5].Value = hd.MaKH;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 6].Value = hd.KhachHang.DiaChi;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 7].Value = hd.KhachHang.SoDienThoai;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 8].Value = hd.SoTienThue;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 9].Value = hd.SoTienGiam;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 10].Value = hd.TongTien;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 11].Value = hd.GhiChu;
                row++;
                stt++;
                excel.Workbook.Worksheets["Sheet1"].InsertRow(row, 1, row - 1);
            }
            #endregion

            for (int i = 2; i <= 11; i++)
                excel.Workbook.Worksheets["Sheet1"].Column(i).AutoFit();
            excel.SaveAs(info);
            // open and show file exel
            System.Diagnostics.Process.Start(fileCopy);
        }

        private void Export_BKHoaDonLeCT()
        {
            // prepare the file paths
            string _Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileGoc = _Path + @"\BaoCao\BK_HoaDonBanLeCT.xlsx";
            string tag = GetFormattedDateTime();
            string fileCopy = _Path + @"\BaoCao_Exported\BK_HoaDonBanLeCT_" + tag + ".xlsx";
            // copy file
            File.Copy(fileGoc, fileCopy);
            // create required instances
            FileInfo info = new FileInfo(fileCopy);
            ExcelPackage excel = new ExcelPackage(info);
            List<ChiTietHoaDonBanLe> list = hoadon.LayDS_ChiTietHDLe(maNV, maKH, maHT, maHang, cothue, d0, d1);
            if (d0 != DateTime.MinValue && d1 != DateTime.MinValue)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "Từ " + d0.ToString("dd/MM/yyyy") + " đến " + d1.ToString("dd/MM/yyyy");
            }
            else
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Value = "(tất cả chi tiết hóa đơn bán lẻ)";
            }
            excel.Workbook.Worksheets["Sheet1"].Cells[5, 1].Style.Font.Italic = true;

            #region --- Inserting data to excel ---
            int stt = 1;
            int row = 8;
            foreach(ChiTietHoaDonBanLe c in list)
            {
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 1].Value = stt;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 2].Value = c.MaHDL;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 3].Value = c.HoaDonBanLe.NgayLap.Value.ToString("dd/MM/yyyy");
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 4].Value = c.HoaDonBanLe.NhanVien.TenNV;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 5].Value = c.HoaDonBanLe.MaKH;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 6].Value = c.HoaDonBanLe.KhachHang.TenKH;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 7].Value = c.MaHang;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 8].Value = c.HangHoa.TenHang;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 9].Value = c.HangHoa.MaDVT;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 10].Value = c.SoLuong;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 11].Value = c.ThanhTien;
                excel.Workbook.Worksheets["Sheet1"].Cells[row, 12].Value = c.GhiChu;
                row++;
                stt++;
                excel.Workbook.Worksheets["Sheet1"].InsertRow(row, 1, row - 1);
            }
            #endregion

            for (int i = 2; i <= 12; i++)
                excel.Workbook.Worksheets["Sheet1"].Column(i).AutoFit();
            excel.SaveAs(info);
            // open and show file excel
            System.Diagnostics.Process.Start(fileCopy);
        }

        /// <summary>
        ///     Get current DateTime value with format: ddMMyyyy_hhmmss <br/>
        ///     This formatted string use to create report files.
        /// </summary>
        /// <returns> A formatted string represent current DateTime. </returns>
        private string GetFormattedDateTime()
        {
            int d = DateTime.Now.Day, M = DateTime.Now.Month, y = DateTime.Now.Year;
            string day = d.ToString(), month = M.ToString(), year = y.ToString();
            int h = DateTime.Now.Hour, m = DateTime.Now.Minute, s = DateTime.Now.Second;
            string hour = h.ToString(), min = m.ToString(), sec = s.ToString();
            
            if (d < 10)
                day = "0" + day;
            if (M < 10)
                month = "0" + month;
            if (h < 10)
                hour = "0" + hour;
            if (m < 10)
                min = "0" + min;
            if (s < 10)
                sec = "0" + sec;
            return day + month + year + "_" + hour + min + sec;
        }
    }
}
