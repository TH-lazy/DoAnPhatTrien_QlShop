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
    public partial class Frm_ManHinhBanLe : DevExpress.XtraEditors.XtraForm
    {
        
        int mahdl;

        float tienhang;
        public String maqr;
        string nhanvien ="";

        QLShopDataContext qlhds = new QLShopDataContext();
        HangHoaDALBLL hanghoa = new HangHoaDALBLL();
        DoiTac doiTac = new DoiTac();
        KhoDALBLL kho = new KhoDALBLL();
        HoaDonLeDALBLL hd = new HoaDonLeDALBLL();

        public Frm_ManHinhBanLe()
        {
            InitializeComponent();
        }

        public Frm_ManHinhBanLe(string nv): this()
        {
            nhanvien = nv;
        }

        private void Frm_ManHinhBanLe_Load(object sender, EventArgs e)
        {
            cboHangHoa.DataSource = hanghoa.loadHangHoa();
            cboHangHoa.DisplayMember = "TenHang";
            cboHangHoa.ValueMember = "MaHang";

            cboNhanVien.DataSource = doiTac.laynhanvien(nhanvien);
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";

            cboKhoHang.DataSource = kho.LoadKho();
            cboKhoHang.DisplayMember = "TenKho";
            cboKhoHang.ValueMember = "MaKho";

            cboKhachHang.DataSource = doiTac.loadKhachHang();
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";

            cboThue.DataSource = hanghoa.loadThue();
            cboThue.DisplayMember = "TenThue";
            cboThue.ValueMember = "MaThue";

            cboHT.DataSource = hanghoa.loadHinhThuc();
            cboHT.DisplayMember = "TenHT";
            cboHT.ValueMember = "MaHT";


            if (rdoMacDinh.Checked)
            {
                cboKhachHang.Enabled = false;
                txtDiaChi.Enabled = false;
            }
            else
            {
                cboKhachHang.Enabled = true;
                txtDiaChi.Enabled = true;
            }
            hanghoa.capnhatkho();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Frm_Qrcode f = new Frm_Qrcode(this,"f2");
            f.Show();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            //cboHangHoa.DataSource = hanghoa.loadHangHoa();
            cboHangHoa.Text = gridView1.GetFocusedRowCellValue("TenHang").ToString();
            //cboHangHoa.ValueMember = gridView1.GetFocusedRowCellValue("TenHang").ToString();
        }

        private void cboHangHoa_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {

            float dongia = 0;
            float thanhtien = 0;
            int soluongton = 0;
            //int soluongmua = soluong;
            int soluongtonct = 0;
            int soluongmua;
            List<HangHoa> lhh = new List<HangHoa>();
            lhh = hanghoa.layHangHoa(cboHangHoa.SelectedValue.ToString());
            

            foreach (var item in lhh)
            {
                dongia = float.Parse(item.GiaBanLe.ToString());
                soluongton = int.Parse(item.SoLuongTon.ToString());
            }

            


            if (e.KeyCode == Keys.Enter)
            {
                int mauhang = hanghoa.layMauHang(cboHangHoa.SelectedValue.ToString(),cboSize.SelectedValue.ToString(), cboMau.SelectedValue.ToString());
                List<ChiTietHangHoa> lct = new List<ChiTietHangHoa>();
                lct = hanghoa.layCTTheoHang(cboHangHoa.SelectedValue.ToString(),mauhang);
                foreach (var item in lct)
                {
                    soluongtonct = int.Parse(item.SoLuong.ToString());
                }
                soluongmua = int.Parse(txtSoLuong.Text);

                if (soluongtonct < soluongmua)
                {
                    MessageBox.Show("Trong kho không còn đủ số lượng.");
                    return;
                }

                thanhtien = soluongmua * dongia;
                if (hd.themCTHoaDon(mahdl, cboHangHoa.SelectedValue.ToString(), mauhang, soluongmua, dongia, thanhtien, ""))
                {
                    cboHangHoa.Focus();
                    gridControl1.DataSource = hd.loadChiTietHD(mahdl);
                    txtSoLuong.Text = "";
                    tienhang = tienhang + dongia;

                    //txtTienHang.Text = tienhang.ToString();
                    txtTienHang.Text = hd.tongTien(mahdl).ToString();
                    txtTongTien.Text = (float.Parse(txtTienHang.Text) - (float.Parse(txtTienGiam.Text) + float.Parse(txtTienThue.Text))).ToString();
                    hanghoa.UpdateSLHHCT(cboHangHoa.SelectedValue.ToString(),mauhang ,soluongtonct - soluongmua);
                    soluongton =  hanghoa.tongTonKho(cboHangHoa.SelectedValue.ToString());
                    hanghoa.UpdateSLHH(cboHangHoa.SelectedValue.ToString(),soluongton );
                    hanghoa.capnhatkho();
                }
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdoKhachVip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMacDinh.Checked)
            {
                cboKhachHang.Enabled = false;
                txtDiaChi.Enabled = false;
            }
            else
            {
                cboKhachHang.Enabled = true;
                txtDiaChi.Enabled = true;
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            if (hd.themHoaDon(DateTime.ParseExact(dtpNgayLap.Text, "dd/MM/yyyy", null), DateTime.ParseExact(dtpNgayLap.Text, "dd/MM/yyyy", null), int.Parse(cboKhachHang.SelectedValue.ToString()), int.Parse(cboNhanVien.SelectedValue.ToString()), cboThue.SelectedValue.ToString(), int.Parse(txtThue.Text), float.Parse(txtTienThue.Text), float.Parse(txtGiamGia.Text), float.Parse(txtTienGiam.Text), float.Parse(txtTongTien.Text), "",cboHT.SelectedValue.ToString()))
            {
                cboHangHoa.Focus();
                txtSoLuong.Enabled = true;
                mahdl = hd.layMaMax();
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Enabled == false)
            {
                MessageBox.Show("Hiện tại không có hóa đơn để xóa.");
                return;
            }
            DialogResult r = MessageBox.Show("Bạn có muốn xóa hóa đơn này?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                if (hd.xoaHDL(mahdl))
                {
                    MessageBox.Show("Xóa thành công.");
                    gridControl1.DataSource = "";
                    txtSoLuong.Enabled = false;
                    txtSoLuong.Text = "";
                    txtTienHang.Text = "0";
                    txtThue.Text = "0";
                    txtTienThue.Text = "0";
                    txtGiamGia.Text = "0";
                    txtTienGiam.Text = "0";
                    txtTongTien.Text = "0";
                    txtTienKhachDua.Text = "0";
                    txtTienThoi.Text = "0";
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void txtThue_TextChanged(object sender, EventArgs e)
        {
            if (txtThue.Text == "")
            {
                txtThue.Text = "0";
            }
            else
            {
                int thue = int.Parse(txtThue.Text.ToString());
                float tienthue = (float)thue / 100 * float.Parse(txtTienHang.Text.ToString());
                txtTienThue.Text = tienthue.ToString();
                txtTongTien.Text = (float.Parse(txtTienHang.Text) + float.Parse(txtTienThue.Text) - float.Parse(txtTienGiam.Text) ).ToString();

            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (txtGiamGia.Text == "")
            {
                txtGiamGia.Text = "0";
            }
            else
            {
                float giamgia = float.Parse(txtGiamGia.Text.ToString());
                float tiengiam = giamgia / 100 * float.Parse(txtTienHang.Text.ToString());
                txtTienGiam.Text = tiengiam.ToString();
                txtTongTien.Text = (float.Parse(txtTienHang.Text) + float.Parse(txtTienThue.Text) - float.Parse(txtTienGiam.Text)).ToString();
            }
        }

        private void txtTienGiam_TextChanged(object sender, EventArgs e)
        {
            if (txtTienGiam.Text == "")
            {
                txtTienGiam.Text = "0";
            }
            if (txtGiamGia.Text == "0")
            {
                txtTongTien.Text = (float.Parse(txtTienHang.Text) + float.Parse(txtTienThue.Text) - float.Parse(txtTienGiam.Text) ).ToString();
            }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txtTienKhachDua.Text == "")
            {
                txtTienKhachDua.Text = "0";
            }
            else
            {
                int tiendua = int.Parse(txtTienKhachDua.Text);
                int tienhang = int.Parse(txtTongTien.Text);
                txtTienThoi.Text = (tiendua - tienhang).ToString();
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (hd.capNhatHoaDon(mahdl, int.Parse(txtThue.Text), float.Parse(txtTienThue.Text), float.Parse(txtGiamGia.Text), float.Parse(txtTienGiam.Text), float.Parse(txtTongTien.Text)))
            {
                MessageBox.Show("Lưu hóa đơn thành công.");
                txtSoLuong.Text = "";
                txtTienHang.Text = "0";
                txtThue.Text = "0";
                txtTienThue.Text = "0";
                txtGiamGia.Text = "0";
                txtTienGiam.Text = "0";
                txtTongTien.Text = "0";
                txtTienKhachDua.Text = "0";
                txtTienThoi.Text = "0";
                txtSoLuong.Enabled = false;
                gridControl1.DataSource = "";
            }
        }

        private void txtTienGiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Enabled == false)
            {
                MessageBox.Show("Hiện tại không có hóa đơn để xóa.");
                return;
            }
            int soluongton = 0;
            int mact = int.Parse(gridView1.GetFocusedRowCellValue("MaCTHDL").ToString());
            int sl = int.Parse(gridView1.GetFocusedRowCellValue("SoLuong").ToString());
            int mauhang = int.Parse(gridView1.GetFocusedRowCellValue("MaCTHH").ToString());
            string mahang =gridView1.GetFocusedRowCellValue("MaHang").ToString();
            //List<ChiTietHoaDonBanLe> lct = new List<ChiTietHoaDonBanLe>();
            //lct = hd.lay1CTHDL(mact);
            //foreach (var item in lct)
            //{
            //    mahang = item.MaHang;
            //    mauhang = int.Parse(item.MaCTHH.ToString());
            //}

            List<ChiTietHangHoa> lhh = new List<ChiTietHangHoa>();
            lhh = hanghoa.layCTTheoHang(mahang,mauhang);

            foreach (var item in lhh)
            {
                soluongton = int.Parse(item.SoLuong.ToString());
            }
 

            if (hd.xoa1CTHDL(mact))
            {
                hanghoa.UpdateSLHH(cboHangHoa.SelectedValue.ToString(), soluongton + sl);
                hanghoa.tongTonKho(mahang);
                MessageBox.Show("Đã xóa.");
                txtTienHang.Text = hd.tongTien(mahdl).ToString();
                gridControl1.DataSource = hd.loadChiTietHD(mahdl);

            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = hd.loadChiTietHD(mahdl);
            hanghoa.capnhatkho();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void txtTienHang_TextChanged(object sender, EventArgs e)
        {
            float giamgia = float.Parse(txtGiamGia.Text.ToString());
            float tiengiam = giamgia / 100 * float.Parse(txtTienHang.Text.ToString());
            txtTienGiam.Text = tiengiam.ToString();
            txtTongTien.Text = (float.Parse(txtTienHang.Text) - (float.Parse(txtTienGiam.Text) + float.Parse(txtTienThue.Text))).ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Frm_NhanVien f = new Frm_NhanVien("khachhang");
            f.Show();
        }

        internal void capnhat()
        {
            string ten = "";
            List<HangHoa> l = new List<HangHoa>();
            l = hanghoa.layTenHH(maqr);
            foreach (var item in l)
            {
                ten = item.TenHang;
            }
            cboHangHoa.Text = ten;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            
        }

        private void cboHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSize.DataSource = hanghoa.laySizeHang(cboHangHoa.SelectedValue.ToString());
            cboSize.DisplayMember = "MaSize";
            cboSize.ValueMember = "MaSize";

            //cboMau.DataSource = hanghoa.layMauHang(cboSize.SelectedValue.ToString());
            //cboMau.DisplayMember = "TenMau";
            //cboMau.ValueMember = "MaMau";

            cboKhoHang.DataSource = hanghoa.layKhoHang(cboHangHoa.SelectedValue.ToString());
            cboKhoHang.DisplayMember = "TenKho";
            cboKhoHang.ValueMember = "MaKho";
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMau.DataSource = null;
            cboMau.DataSource = hanghoa.layMauHang(cboHangHoa.SelectedValue.ToString(),cboSize.SelectedValue.ToString());
            cboMau.DisplayMember = "TenMau";
            cboMau.ValueMember = "MaMau";
        }
    }
}