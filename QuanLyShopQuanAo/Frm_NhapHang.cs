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
    public partial class Frm_NhapHang : DevExpress.XtraEditors.XtraForm
    {
        DoiTac doitac = new DoiTac();
        HangHoaDALBLL hanghoa = new HangHoaDALBLL();
        NhaCC ncc = new NhaCC();
        NhapHangDALBLL nh = new NhapHangDALBLL();
        public Frm_NhapHang()
        {
            InitializeComponent();
        }

        private void btnReChiTiet_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhapCT.Text = "";
            txtSoLuong.Text = "0";
            txtGiaVon.Text = "0";
            txtThanhTien.Text = "0";
            txtMoTaCt.Text = "";
        }

        private void btnCNChiTiet_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = nh.loadCTPhieuNhapHang(txtMaPhieuNhapCT.Text);

            cboHangHoa.DataSource = hanghoa.loadHangHoa();
            cboHangHoa.DisplayMember = "TenHang";
            cboHangHoa.ValueMember = "MaHang";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhap.Text = "";
            txtMoTa.Text = "";
        }

        private void Frm_NhapHang_Load(object sender, EventArgs e)
        {
            cboLoHang.DataSource = hanghoa.loadLoHang();
            cboLoHang.DisplayMember = "TenLo";
            cboLoHang.ValueMember = "MaLo";


            cboNhaCC.DataSource = ncc.loadNCC();
            cboNhaCC.DisplayMember = "TenNCC";
            cboNhaCC.ValueMember = "MaNCC";


            cboNhanVien.DataSource = doitac.loadNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";


            cboHangHoa.DataSource = hanghoa.loadHangHoa();
            cboHangHoa.DisplayMember = "TenHang";
            cboHangHoa.ValueMember = "MaHang";

            gridControl1.DataSource = nh.loadPhieuNhapHang();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaVon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "")
            {
                txtSoLuong.Text = "0";
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * float.Parse(txtGiaVon.Text)).ToString();
            }
            else
            {
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * float.Parse(txtGiaVon.Text)).ToString();
            }
        }

        private void txtGiaVon_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaVon.Text == "")
            {
                txtGiaVon.Text = "0";
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * float.Parse(txtGiaVon.Text)).ToString();
            }
            else
            {
                txtThanhTien.Text = (int.Parse(txtSoLuong.Text) * float.Parse(txtGiaVon.Text)).ToString();
            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            if (txtThanhTien.Text == "")
            {
                txtThanhTien.Text = "0";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (nh.ThemPNK(txtMaPhieuNhap.Text,DateTime.ParseExact(dtpNgayHT.Text, "dd/MM/yyyy", null),int.Parse(cboNhanVien.SelectedValue.ToString()),cboLoHang.SelectedValue.ToString(),cboNhaCC.SelectedValue.ToString(),txtMoTa.Text))
            {
                MessageBox.Show("Thêm thành công.");
                gridControl1.DataSource = nh.loadPhieuNhapHang();
                txtMaPhieuNhap.Text = "";
                txtMoTa.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (nh.xoaPNK(gridView1.GetFocusedRowCellValue("MaPhieuNhap").ToString()))
            {
                MessageBox.Show("Xóa thành công.");
                gridControl1.DataSource = nh.loadPhieuNhapHang();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhap.Text = gridView1.GetFocusedRowCellValue("MaPhieuNhap").ToString();
            txtMaPhieuNhapCT.Text = txtMaPhieuNhap.Text;
            cboLoHang.Text = gridView1.GetFocusedRowCellValue("TenLo").ToString();
            cboNhaCC.Text = gridView1.GetFocusedRowCellValue("TenNCC").ToString();
            cboNhanVien.Text = gridView1.GetFocusedRowCellValue("TenNV").ToString();
            dtpNgayHT.Text = gridView1.GetFocusedRowCellValue("NgayLapPhieu").ToString();
            txtMoTa.Text = gridView1.GetFocusedRowCellValue("MoTa").ToString();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            txtMaPhieuNhapCT.Text = gridView2.GetFocusedRowCellValue("MaPhieuNhap").ToString();
            cboHangHoa.Text = gridView2.GetFocusedRowCellValue("TenHang").ToString();
            txtSoLuong.Text = gridView2.GetFocusedRowCellValue("SoLuong").ToString();
            txtGiaVon.Text = gridView2.GetFocusedRowCellValue("GiaVon").ToString();
            txtThanhTien.Text = gridView2.GetFocusedRowCellValue("ThanhTien").ToString();
            txtMoTaCt.Text = gridView2.GetFocusedRowCellValue("MoTa").ToString();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = nh.loadPhieuNhapHang();
        }

        private void txtMaPhieuNhap_TextChanged(object sender, EventArgs e)
        {
            txtMaPhieuNhapCT.Text = txtMaPhieuNhap.Text;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (nh.ThemCTPNK(txtMaPhieuNhapCT.Text,cboHangHoa.SelectedValue.ToString(),int.Parse(txtSoLuong.Text),float.Parse(txtGiaVon.Text),float.Parse(txtThanhTien.Text),txtMoTaCt.Text))
            {
                MessageBox.Show("Thêm thành công.");
                //txtMaPhieuNhapCT.Text = "";
                gridControl2.DataSource = nh.loadCTPhieuNhapHang(txtMaPhieuNhapCT.Text);
                txtSoLuong.Text = "0";
                txtGiaVon.Text = "0";
                txtThanhTien.Text = "0";
                txtMoTaCt.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
                txtSoLuong.Text = "0";
                txtGiaVon.Text = "0";
                txtThanhTien.Text = "0";
                txtMoTaCt.Text = "";
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (nh.xoaCTPNK(txtMaPhieuNhapCT.Text,int.Parse(gridView2.GetFocusedRowCellValue("MaCTPN").ToString())))
            {
                MessageBox.Show("Xóa thành công.");
                gridControl2.DataSource = nh.loadCTPhieuNhapHang(txtMaPhieuNhapCT.Text);
                txtMaPhieuNhapCT.Text = "";
                txtSoLuong.Text = "0";
                txtGiaVon.Text = "0";
                txtThanhTien.Text = "0";
                txtMoTaCt.Text = "";
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }
    }
}