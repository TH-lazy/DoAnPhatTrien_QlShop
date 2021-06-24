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
    public partial class Frm_ChiTien : DevExpress.XtraEditors.XtraForm
    {
        DoiTac doitac = new DoiTac();
        HangHoaDALBLL hanghoa = new HangHoaDALBLL();
        PhieuChiTienDALBLL phieuchi = new PhieuChiTienDALBLL();
        public Frm_ChiTien()
        {
            InitializeComponent();
        }

        private void Frm_ChiTien_Load(object sender, EventArgs e)
        {
            drv_DSChiTien.DataSource = phieuchi.loadPhieuChiTien();

            cboNhanVien.DataSource = doitac.loadNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";

            cboLyDoNop.DataSource = hanghoa.loadPhi();
            cboLyDoNop.DisplayMember = "TenPhi";
            cboLyDoNop.ValueMember = "MaPhi";

            cboHinhThuc.DataSource = hanghoa.loadHinhThuc();
            cboHinhThuc.DisplayMember = "TenHT";
            cboHinhThuc.ValueMember = "MaHT";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            drv_DSChiTien.DataSource = phieuchi.loadPhieuChiTien();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (phieuchi.themPhieuChi(DateTime.ParseExact(dtpNgayLap.Text, "dd/MM/yyyy", null),txtChungTu.Text,int.Parse(cboNhanVien.SelectedValue.ToString()),cboLyDoNop.SelectedValue.ToString(),float.Parse(txtSoTien.Text),cboHinhThuc.SelectedValue.ToString()))
            {
                MessageBox.Show("Thêm thành công.");
                txtChungTu.Text = "";
                txtSoTien.Text = "0";
                drv_DSChiTien.DataSource = phieuchi.loadPhieuChiTien();
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            if (txtSoTien.Text == "")
            {
                txtSoTien.Text = "0";
            }
        }

        private void drv_DSChiTien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //List<PhieuChiTien> l = new List<PhieuChiTien>();
            //l = phieuchi.layPhieuChiTien(int.Parse(gridView1.GetFocusedRowCellValue("MaPhieuChi").ToString()));
            //foreach (var item in l)
            //{
            //}
            if (phieuchi.suaPhieuChi(int.Parse(gridView1.GetFocusedRowCellValue("MaPhieuChi").ToString()),DateTime.ParseExact(dtpNgayLap.Text, "dd/MM/yyyy", null), txtChungTu.Text,int.Parse(cboNhanVien.SelectedValue.ToString()), cboLyDoNop.SelectedValue.ToString(), float.Parse(txtSoTien.Text), cboHinhThuc.SelectedValue.ToString()))
            {
                MessageBox.Show("Sửa thành công.");
                txtChungTu.Text = "";
                txtSoTien.Text = "0";
                drv_DSChiTien.DataSource = phieuchi.loadPhieuChiTien();
            }
            else
            {
                MessageBox.Show("Sửa thất bại.");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (phieuchi.xoaPhieuChi(int.Parse(gridView1.GetFocusedRowCellValue("MaPhieuChi").ToString())))
            {
                MessageBox.Show("Xóa thành công.");
                txtChungTu.Text = "";
                txtSoTien.Text = "0";
                drv_DSChiTien.DataSource = phieuchi.loadPhieuChiTien();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void drv_DSChiTien_Click(object sender, EventArgs e)
        {
            cboNhanVien.Text = gridView1.GetFocusedRowCellValue("TenNV").ToString();
            cboLyDoNop.Text = gridView1.GetFocusedRowCellValue("TenPhi").ToString();
            cboHinhThuc.Text = gridView1.GetFocusedRowCellValue("TenHT").ToString();
            txtSoTien.Text = gridView1.GetFocusedRowCellValue("SoTien").ToString();
            txtChungTu.Text = gridView1.GetFocusedRowCellValue("MaChungTu").ToString();
            dtpNgayLap.Text = gridView1.GetFocusedRowCellValue("NgayLap").ToString();
        }
    }
}