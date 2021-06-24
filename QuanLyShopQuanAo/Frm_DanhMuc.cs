using DevExpress.XtraEditors;
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

namespace QuanLyShopQuanAo
{
    public partial class Frm_DanhMuc : DevExpress.XtraEditors.XtraForm
    {
        string loaidm = "";
        HangHoaDALBLL hh = new HangHoaDALBLL();
        DoiTac doitac = new DoiTac();
        public Frm_DanhMuc()
        {
            InitializeComponent();
        }

        public Frm_DanhMuc(string mess): this()
        {
            loaidm = mess;
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_DanhMuc_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        public void loaddata()
        {
            if (loaidm == "loaihang")
            {
                lbldanhmuc.Text = "Loại Hàng Hóa";
                lblMaDM.Text = "Mã loại hàng";
                lblTenDM.Text = "Tên loại hàng";
                drv_DM.DataSource = hh.loadLoaiHang();
            }
            else if (loaidm == "thue")
            {
                lbldanhmuc.Text = "Thuế";
                lblMaDM.Text = "Mã loại thuế";
                lblTenDM.Text = "Tên loại thuế";
                drv_DM.DataSource = hh.loadThue();
            }
            else if (loaidm == "phi")
            {
                lbldanhmuc.Text = "Phí";
                lblMaDM.Text = "Mã loại phí";
                lblTenDM.Text = "Tên loại phí";
                drv_DM.DataSource = hh.loadPhi();
            }
            else if (loaidm == "dvt")
            {
                lbldanhmuc.Text = "Đơn vị tính";
                lblMaDM.Text = "Mã đơn vị tính";
                lblTenDM.Text = "Tên đơn vị tính";
                drv_DM.DataSource = hh.loadDonViTinh();
            }
            else if (loaidm == "mausac")
            {
                lbldanhmuc.Text = "Màu sắc";
                lblMaDM.Text = "Mã màu sắc";
                lblTenDM.Text = "Tên màu sắc";
                drv_DM.DataSource = hh.loadMauSac();
            }
            else if (loaidm == "kichthuoc")
            {
                lbldanhmuc.Text = "Kích thước";
                lblMaDM.Text = "Mã Size";
                lblTenDM.Text = "Tên Size";
                drv_DM.DataSource = hh.loadKichThuoc();
            }
            else if (loaidm == "hinhthuc")
            {
                lbldanhmuc.Text = "Hình Thức Thanh Toán";
                lblMaDM.Text = "Mã hình thức";
                lblTenDM.Text = "Tên hình thức";
                drv_DM.DataSource = hh.loadHinhThuc();
            }
            else if (loaidm == "loaikhach")
            {
                lbldanhmuc.Text = "Loại Khách Hàng";
                lblMaDM.Text = "Mã loại khách";
                lblTenDM.Text = "Tên loại khách";
                drv_DM.DataSource = doitac.loadLoaiKhach();
            }
            else
            {
                lbldanhmuc.Text = "Chức Vụ";
                lblMaDM.Text = "Mã chức vụ";
                lblTenDM.Text = "Tên chức vụ";
                drv_DM.DataSource = doitac.loadChucVu();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtMaDM.Text == ""||txtTenDM.Text =="")
            {
                MessageBox.Show("Không được để trống thông tin.");
                return;
            }
            if (loaidm == "loaihang")
            {
                if (hh.ThemLoaiHang(txtMaDM.Text,txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = hh.loadLoaiHang();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else if (loaidm == "thue")
            {
                if (hh.ThemThue(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = hh.loadThue();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else if (loaidm == "phi")
            {
                if (hh.ThemPhi(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = hh.loadPhi();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else if (loaidm == "dvt")
            {
                if (hh.ThemDVT(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = hh.loadDonViTinh();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else if (loaidm == "mausac")
            {
                if (hh.ThemMau(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = hh.loadMauSac();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else if (loaidm == "kichthuoc")
            {
                if (hh.ThemSize(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = hh.loadKichThuoc();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else if (loaidm == "hinhthuc")
            {
                if (hh.ThemHinhThuc(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = hh.loadHinhThuc();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else if (loaidm == "loaikhach")
            {
                if (doitac.ThemLoaiKhach(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = doitac.loadLoaiKhach();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
            else
            {
                if (doitac.ThemChucVu(txtMaDM.Text, txtTenDM.Text))
                {

                    MessageBox.Show("Thêm thành công.");
                    drv_DM.DataSource = doitac.loadChucVu();
                    txtMaDM.Text = "";
                    txtTenDM.Text = "";
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtMaDM.Text == "")
            {
                MessageBox.Show("Không được để trống mã.");
                return;
            }
            if (loaidm == "loaihang")
            {
                if (hh.XoaLoaiHang(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = hh.loadLoaiHang();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else if (loaidm == "thue")
            {
                if (hh.XoaThue(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = hh.loadThue();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else if (loaidm == "phi")
            {
                if (hh.XoaPhi(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = hh.loadPhi();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else if (loaidm == "dvt")
            {
                if (hh.XoaDVT(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = hh.loadDonViTinh();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else if (loaidm == "mausac")
            {
                if (hh.XoaMau(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = hh.loadMauSac();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else if (loaidm == "kichthuoc")
            {
                if (hh.XoaSize(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = hh.loadKichThuoc();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else if (loaidm == "hinhthuc")
            {
                if (hh.XoaHinhThuc(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = hh.loadHinhThuc();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else if (loaidm == "loaikhach")
            {
                if (doitac.XoaLoaiKhach(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = doitac.loadLoaiKhach();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
            else
            {
                if (doitac.XoaChucVu(txtMaDM.Text))
                {

                    MessageBox.Show("Xóa thành công.");
                    drv_DM.DataSource = doitac.loadChucVu();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }

            }
        }

        private void drv_DM_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in drv_DM.SelectedRows)
            {
                txtMaDM.Text = row.Cells[0].Value.ToString();
                txtTenDM.Text = row.Cells[1].Value.ToString();
            }    
        }
    }
}