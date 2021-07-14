using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShopQuanAo
{
    public partial class Trangchu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string chucvu = "";
        string taikhoan = "";
        public Trangchu()
        {
            InitializeComponent();
        }

        public Trangchu(string mess, string tk): this()
        {
            chucvu = mess;
            taikhoan = tk;
        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
            if (chucvu.Equals("CV0001"))
            {
                xtraTabPage4.Visible = true;
                xtraTabPage1.PageEnabled = xtraTabPage2.PageEnabled = xtraTabPage3.PageEnabled = xtraTabPage5.PageEnabled = xtraTabPage6.PageEnabled = xtraTabPage7.PageEnabled = xtraTabPage8.PageEnabled = xtraTabPage9.PageEnabled = xtraTabPage10.PageEnabled = false;
            }
        }

        private void a_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_HangHoa f = new Frm_HangHoa();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_NhanVien f = new Frm_NhanVien();
            f.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frm_Kho f = new Frm_Kho();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_NhaCungCap f = new Frm_NhaCungCap();
            f.Show();
        }

        private void btnThemHangHoa_Click(object sender, EventArgs e)
        {
            Frm_HangHoa f = new Frm_HangHoa();
            f.Show();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            Frm_NhanVien f = new Frm_NhanVien("khachhang");
            f.Show();
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            Frm_NhaCungCap f = new Frm_NhaCungCap();
            f.Show();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            Frm_NhanVien f = new Frm_NhanVien();
            f.Show();
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            Frm_Kho f = new Frm_Kho();
            f.Show();
        }

        private void btnThemNhanVien_Click_1(object sender, EventArgs e)
        {
            Frm_NhanVien f = new Frm_NhanVien("nhanvien");
            f.Show();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDSHang_Click(object sender, EventArgs e)
        {
            Frm_ChiTietHangHoa f = new Frm_ChiTietHangHoa();
            f.Show();
        }

        private void btnDSKhach_Click(object sender, EventArgs e)
        {
            
            Frm_DSDoiTac f = new Frm_DSDoiTac("khachhang");
            f.Show();
        }

        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            Frm_DSDoiTac f = new Frm_DSDoiTac("nhanvien");
            f.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("loaihang");
            f.Show();
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("thue");
            f.Show();
        }

        private void btnDanhMucPhi_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("phi");
            f.Show();
        }

        private void simpleButton12_Click_1(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("dvt");
            f.Show();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("mausac");
            f.Show();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("kichthuoc");
            f.Show();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("hinhthuc");
            f.Show();
        }

        private void btnLoaiKH_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("loaikhach");
            f.Show();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("chucvu");
            f.Show();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Frm_ManHinhBanLe f = new Frm_ManHinhBanLe(taikhoan);
            f.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Frm_DanhSachHoaDonLe f = new Frm_DanhSachHoaDonLe();
            f.Show();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Frm_ChiTien f = new Frm_ChiTien();
            f.Show();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Frm_NhapHang f = new Frm_NhapHang();
            f.Show();
        }
    }
}