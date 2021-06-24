using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuanLyShopQuanAo
{
    public partial class Frm_HangHoa : DevExpress.XtraEditors.XtraForm
    {
        string hanhdong = "";
        public String maqr;
        MemoryStream ms;
        MemoryStream ms1;
        MemoryStream ms2;
        MemoryStream ms3;
        byte[] arrImage;
        byte[] arrImage1;
        byte[] arrImage2;
        byte[] arrImage3;
        HangHoaDALBLL h = new HangHoaDALBLL();
        KhoDALBLL k = new KhoDALBLL();
        public Frm_HangHoa()
        {
            InitializeComponent();
        }

        private void Frm_HangHoa_Load(object sender, EventArgs e)
        {
            cboDVT.DataSource = h.loadDonViTinh();
            cboDVT.DisplayMember = "TenDVT";
            cboDVT.ValueMember = "MaDVT";


            cboKho.DataSource = k.LoadKho();
            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "MaKho";


            cboLoHang.DataSource = h.loadLoHang();
            cboLoHang.DisplayMember = "TenLo";
            cboLoHang.ValueMember = "MaLo";


            cboMau.DataSource = h.loadMauSac();
            cboMau.DisplayMember = "TenMau";
            cboMau.ValueMember = "MaMau";


            cboSize.DataSource = h.loadKichThuoc();
            cboSize.DisplayMember = "TenSize";
            cboSize.ValueMember = "MaSize";

            cboLoaiHang.DataSource = h.loadLoaiHang();
            cboLoaiHang.DisplayMember = "TenLoai";
            cboLoaiHang.ValueMember = "MaLoai";


            drvSize.DataSource = h.loadKichThuoc();
            drvMau.DataSource = h.loadMauSac();
            drv_DVT.DataSource = h.loadDonViTinh();

            h.capnhatkho();
        }

        private void btnThemHinhDD_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                picdd.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms = new MemoryStream();
                picdd.Image.Save(ms, picdd.Image.RawFormat);
                arrImage = ms.GetBuffer();
                ms.Close();
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {    
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (txtTenHang.Text == "" || txtGiaLe.Text == "" || txtGiaSi.Text.ToString() == "" || txtGiaMua.Text.ToString() == "")
                {
                    MessageBox.Show("Phải nhập đủ thông tin hàng hóa.");
                    return;
                }
                if (txtKieuDang.Text == "" || txtXuatXu.Text == "" || txtNSX.Text == "" || txtQuyCach.Text == "" || txtTrongluong.Text == "" || txtChieudai.Text == "" || txtChieurong.Text == "")
                {
                    MessageBox.Show("Phải nhập đủ thông tin bổ sung");
                    return;
                }
                if (h.ThemHH(txtMaHang.Text, txtTenHang.Text, int.Parse(txtSoluong.Text), cboDVT.SelectedValue.ToString(), cboLoHang.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboLoaiHang.SelectedValue.ToString(), txtKieuDang.Text, txtXuatXu.Text, txtNSX.Text, DateTime.ParseExact(dtpNamSX.Text, "dd/MM/yyyy", null), float.Parse(txtGiaMua.Text), float.Parse(txtGiaLe.Text), float.Parse(txtGiaSi.Text), int.Parse(txtTrongluong.Text), int.Parse(txtChieudai.Text), int.Parse(txtChieurong.Text), txtQuyCach.Text, ""))
                {
                    MessageBox.Show("Thêm thành công.");
                    txtMaHang2.Text = txtMaHang.Text;
                    cleartext();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
            }

            if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                
                if (h.ThemCTHH(txtMaHang2.Text,cboMau.SelectedValue.ToString(),cboSize.SelectedValue.ToString(),int.Parse(txtSoLuongct.Text),arrImage,arrImage1,arrImage2,arrImage3))
                {
                    int tongsl = h.tongTonKho(txtMaHang2.Text);
                    if(h.UpdateSLHH(txtMaHang2.Text, tongsl))
                    {  
                        MessageBox.Show("Thêm thành công.");
                        txtMaHang2.Text = "";
                        txtSoLuongct.Text = "";
                        picdd.Image = null;
                        pich1.Image = null;
                        pich2.Image = null;
                        pich3.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại.");
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
            }
            
        }

        

        private void btnThemHinh1_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                pich1.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms1 = new MemoryStream();
                pich1.Image.Save(ms1, pich1.Image.RawFormat);
                arrImage1 = ms1.GetBuffer();
                ms1.Close();
            }
        }

        private void btnThemHinh2_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                pich2.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms2 = new MemoryStream();
                pich2.Image.Save(ms2, pich2.Image.RawFormat);
                arrImage2 = ms2.GetBuffer();
                ms2.Close();
            }
        }

        private void btnThemHinh3_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                pich3.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms3 = new MemoryStream();
                pich3.Image.Save(ms3, pich3.Image.RawFormat);
                arrImage3 = ms3.GetBuffer();
                ms3.Close();
            }
        }

        private void txtGiaLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaSi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTrongluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChieudai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChieurong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemDVT_Click(object sender, EventArgs e)
        {
            string madvt = "";
            string tendvt = "";
            foreach (DataGridViewRow row in drv_DVT.SelectedRows)
            {
                madvt = row.Cells[0].Value.ToString();
                tendvt = row.Cells[1].Value.ToString();
            }

            if (h.ThemDVT(madvt,tendvt))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("mausac");
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("kichthuoc");
            f.Show();
        }

        private void btnXoaMau_Click(object sender, EventArgs e)
        {
            string mam = "";
            string tenm = "";
            foreach (DataGridViewRow row in drvMau.SelectedRows)
            {
                mam = row.Cells[0].Value.ToString();
                tenm = row.Cells[1].Value.ToString();
            }
            if (h.XoaMau(mam))
            {
                drvMau.DataSource = h.loadMauSac();
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                txtMaHang2.Text = "";
                this.Close();
            }
        }

        public void cleartext()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtGiaLe.Text = "";
            txtGiaSi.Text = "";
            txtGiaMua.Text = "";
            txtMoTa.Text = "";
            txtKieuDang.Text = "";
            txtNSX.Text = "";
            txtXuatXu.Text = "";
            txtQuyCach.Text = "";
            txtTrongluong.Text = "";
            txtChieudai.Text = "";
            txtChieurong.Text = "";
            txtMaHang2.Text = "";
            picdd.Image = null;
            pich1.Image = null;
            pich2.Image = null;
            pich3.Image = null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            h.capnhatkho();
            if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                txtSoLuongct.Text = "0";
                picdd.Image = null;
                pich1.Image = null;
                pich2.Image = null;
                pich3.Image = null;
            }
            else
            {
                cleartext();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            int tonghang = 0;
            hanhdong = "sua";
            DialogResult r = MessageBox.Show("Bạn muốn quét mã?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Frm_Qrcode f = new Frm_Qrcode(this, "f1");
                f.Show();
            }
            else
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                {
                    tonghang = h.tongTonKho(txtMaHang.Text);
                    txtMaHang2.Text = txtMaHang.Text;
                    List<HangHoa> lhh = new List<HangHoa>();
                    lhh = h.layHangHoa(txtMaHang.Text);
                    //List<ChiTietHangHoa> lct = new List<ChiTietHangHoa>();
                    //lct = h.layCTHangHoa(maqr);

                    foreach (var item in lhh)
                    {
                        txtMaHang.Text = item.MaHang;
                        txtTenHang.Text = item.TenHang;
                        txtSoluong.Text = item.SoLuongTon.ToString();
                        cboDVT.DisplayMember = item.MaDVT;
                        cboLoHang.DisplayMember = item.MaLo;
                        cboKho.DisplayMember = item.MaKho;
                        cboLoaiHang.DisplayMember = item.MaLoai;
                        txtKieuDang.Text = item.KieuDang;
                        txtXuatXu.Text = item.XuatXu;
                        txtNSX.Text = item.NhaSanXuat;
                        dtpNamSX.Text = item.NamSanXuat.ToString();
                        txtGiaLe.Text = item.GiaBanLe.ToString();
                        txtGiaSi.Text = item.GiaBanSi.ToString();
                        txtGiaMua.Text = item.GiaMua.ToString();
                        txtTrongluong.Text = item.TrongLuong.ToString();
                        txtChieudai.Text = item.ChieuDai.ToString();
                        txtChieurong.Text = item.ChieuRong.ToString();
                        txtQuyCach.Text = item.QuyCach;
                        txtMoTa.Text = item.MoTa;
                    }
                    h.UpdateSLHH(txtMaHang.Text, tonghang);
                }
                else
                {
                    txtMaHang2.Enabled = true;
                    cboMaCT.DataSource = h.loadChiTietHangHoa(txtMaHang2.Text);
                    cboMaCT.DisplayMember = "MaCTHH";
                    cboMaCT.ValueMember = "MaCTHH";

                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            hanhdong = "xoa";
            
            DialogResult r = MessageBox.Show("Bạn muốn quét mã?", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Frm_Qrcode f = new Frm_Qrcode(this, "f1");
                f.Show();
            }
            else
            {
                //txtMaHang2.Enabled = true;
                //cboMaCT.DataSource = h.loadChiTietHangHoa(txtMaHang2.Text);
                //cboMaCT.DisplayMember = "MaCTHH";
                //cboMaCT.ValueMember = "MaCTHH";
                if (h.xoaHH(txtMaHang.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    cleartext();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int tonghang = 0;
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                tonghang = h.tongTonKho(txtMaHang.Text);
                if (h.UpdateHH(txtMaHang.Text, txtTenHang.Text, int.Parse(txtSoluong.Text), cboDVT.SelectedValue.ToString(), cboLoHang.SelectedValue.ToString(), cboKho.SelectedValue.ToString(), cboLoaiHang.SelectedValue.ToString(), txtKieuDang.Text, txtXuatXu.Text, txtNSX.Text, DateTime.ParseExact(dtpNamSX.Text, "dd/MM/yyyy", null), float.Parse(txtGiaMua.Text), float.Parse(txtGiaLe.Text), float.Parse(txtGiaSi.Text), int.Parse(txtTrongluong.Text), int.Parse(txtChieudai.Text), int.Parse(txtChieurong.Text), txtQuyCach.Text, ""))
                {
                    h.UpdateSLHH(txtMaHang.Text, tonghang);
                    MessageBox.Show("Sửa thành công.");
                    cleartext();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            else
            {
                tonghang = h.tongTonKho(txtMaHang2.Text);
                if (h.UpdateCTHH(txtMaHang2.Text,int.Parse(cboMaCT.SelectedValue.ToString()),cboMau.SelectedValue.ToString(),cboSize.SelectedValue.ToString(),int.Parse(txtSoLuongct.Text),arrImage,arrImage1,arrImage2,arrImage3))
                {
                    h.UpdateSLHH(txtMaHang2.Text, tonghang);
                    MessageBox.Show("Sửa thành công.");
                    txtSoLuongct.Text = "0";
                    cleartext();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        internal void capnhat()
        {
            txtMaHang.Text = maqr;
            txtMaHang2.Text = maqr;
            if (hanhdong == "sua")
            {
                List<HangHoa> lhh = new List<HangHoa>();
                lhh = h.layHangHoa(maqr);
                //List<ChiTietHangHoa> lct = new List<ChiTietHangHoa>();
                //lct = h.layCTHangHoa(maqr);

                foreach (var item in lhh)
                {
                    txtMaHang.Text = item.MaHang;
                    txtTenHang.Text = item.TenHang;
                    txtSoluong.Text = item.SoLuongTon.ToString();
                    cboDVT.Text = h.layTenDVT(item.MaDVT);
                    cboLoHang.Text = h.layTenLo(item.MaLo);
                    cboKho.Text = h.layTenKho(item.MaKho);
                    cboLoaiHang.Text = h.layTenLoai(item.MaLoai);
                    txtKieuDang.Text = item.KieuDang;
                    txtXuatXu.Text = item.XuatXu;
                    txtNSX.Text = item.NhaSanXuat;
                    dtpNamSX.Text = item.NamSanXuat.ToString();
                    txtGiaLe.Text = item.GiaBanLe.ToString();
                    txtGiaSi.Text = item.GiaBanSi.ToString();
                    txtGiaMua.Text = item.GiaMua.ToString();
                    txtTrongluong.Text = item.TrongLuong.ToString();
                    txtChieudai.Text = item.ChieuDai.ToString();
                    txtChieurong.Text = item.ChieuRong.ToString();
                    txtQuyCach.Text = item.QuyCach;
                    txtMoTa.Text = item.MoTa;
                }
            }
            else
            {
                if (h.xoaHH(maqr))
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void btnThemDVT_Click_1(object sender, EventArgs e)
        {
            Frm_DanhMuc f = new Frm_DanhMuc("dvt");
            f.Show();
        }

        private void btnXoaSize_Click(object sender, EventArgs e)
        {
            string mas = "";
            string tens = "";
            foreach (DataGridViewRow row in drvSize.SelectedRows)
            {
                mas = row.Cells[0].Value.ToString();
                tens = row.Cells[1].Value.ToString();
            }
            if (h.XoaSize(mas))
            {
                drvSize.DataSource = h.loadKichThuoc();
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnXoaDongdvt_Click(object sender, EventArgs e)
        {
            string madvt = "";
            string tendvt = "";
            foreach (DataGridViewRow row in drv_DVT.SelectedRows)
            {
                madvt = row.Cells[0].Value.ToString();
                tendvt = row.Cells[1].Value.ToString();
            }
            if (h.XoaDVT(madvt))
            {
                drv_DVT.DataSource = h.loadDonViTinh();
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            //if (hanhdong == "sua")
            //{
                string ma = txtMaHang.Text;
                //int mact = int.Parse(cboMaCT.SelectedValue.ToString());
                List<HangHoa> lhh = new List<HangHoa>();
                //List<ChiTietHangHoa> lct = new List<ChiTietHangHoa>();
                lhh = h.layHangHoa(ma);
                //lct = h.layCTHangHoa(mact);

                foreach (var item in lhh)
                {
                    txtMaHang.Text = item.MaHang;
                    txtTenHang.Text = item.TenHang;
                    txtSoluong.Text = item.SoLuongTon.ToString();
                    cboDVT.DisplayMember = item.MaDVT;
                    cboLoHang.DisplayMember = item.MaLo;
                    cboKho.DisplayMember = item.MaKho;
                    cboLoaiHang.DisplayMember = item.MaLoai;
                    txtKieuDang.Text = item.KieuDang;
                    txtXuatXu.Text = item.XuatXu;
                    txtNSX.Text = item.NhaSanXuat;
                    dtpNamSX.Text = item.NamSanXuat.ToString();
                    txtGiaLe.Text = item.GiaBanLe.ToString();
                    txtGiaSi.Text = item.GiaBanSi.ToString();
                    txtGiaMua.Text = item.GiaMua.ToString();
                    txtTrongluong.Text = item.TrongLuong.ToString();
                    txtChieudai.Text = item.ChieuDai.ToString();
                    txtChieurong.Text = item.ChieuRong.ToString();
                    txtQuyCach.Text = item.QuyCach;
                    txtMoTa.Text = item.MoTa;
                }
            //}

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMaHang2_TextChanged(object sender, EventArgs e)
        {
            string mm = txtMaHang2.Text;
            cboMaCT.DataSource = h.loadChiTietHangHoa(mm);
            cboMaCT.DisplayMember = "MaCTHH";
            cboMaCT.ValueMember = "MaCTHH";

        }

        private void txtMaHang2_KeyDown(object sender, KeyEventArgs e)
        {
            picdd.Image = null;
            pich1.Image = null;
            pich2.Image = null;
            pich3.Image = null;
            if (e.KeyCode == Keys.Enter)
            {
                int mm = int.Parse(cboMaCT.SelectedValue.ToString());
                List<ChiTietHangHoa> lct = new List<ChiTietHangHoa>();
                lct = h.layCTHangHoa(mm);
                foreach (var item in lct)
                {
                    //cboMaCT.DisplayMember = item.MaCTHH.ToString();
                    cboSize.DisplayMember = item.MaSize;
                    cboMau.DisplayMember = item.MaMau;
                    txtSoLuongct.Text = item.SoLuong.ToString();

                    byte[] bImage = null;
                    bImage = (byte[])item.Hinhdaidien.ToArray();
                    MemoryStream ms = new MemoryStream(bImage);
                    picdd.Image = Image.FromStream(ms);

                    byte[] bImage1 = null;
                    bImage1 = (byte[])item.Hinh1.ToArray();
                    MemoryStream ms1 = new MemoryStream(bImage1);
                    pich1.Image = Image.FromStream(ms1);

                    byte[] bImage2 = null;
                    bImage2 = (byte[])item.Hinh2.ToArray();
                    MemoryStream ms2 = new MemoryStream(bImage2);
                    pich2.Image = Image.FromStream(ms2);

                    byte[] bImage3 = null;
                    bImage3 = (byte[])item.Hinh3.ToArray();
                    MemoryStream ms3 = new MemoryStream(bImage3);
                    pich3.Image = Image.FromStream(ms3);

                    arrImage = bImage ;
                    arrImage1 = bImage1 ;
                    arrImage2 = bImage2 ;
                    arrImage3 = bImage3;
                }
            }
        }

        private void cboMaCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            picdd.Image = null;
            pich1.Image = null;
            pich2.Image = null;
            pich3.Image = null;
            if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                int mmm = int.Parse(cboMaCT.Text);
                List<ChiTietHangHoa> lct = new List<ChiTietHangHoa>();
                lct = h.layCTHangHoa(mmm);
                foreach (var item in lct)
                {
                    //cboMaCT.DisplayMember = item.MaCTHH.ToString();
                    cboSize.Text = item.MaSize;
                    cboMau.Text = h.layTenMau(item.MaMau);
                    txtSoLuongct.Text = item.SoLuong.ToString();

                    if ((byte[])item.Hinhdaidien.ToArray() != null && (byte[])item.Hinh1.ToArray() != null && (byte[])item.Hinh2.ToArray() != null && (byte[])item.Hinh3.ToArray() != null)
                    {
                        byte[] bImage = null;
                        bImage = (byte[])item.Hinhdaidien.ToArray();
                        MemoryStream ms = new MemoryStream(bImage);
                        picdd.Image = Image.FromStream(ms);

                        byte[] bImage1 = null;
                        bImage1 = (byte[])item.Hinh1.ToArray();
                        MemoryStream ms1 = new MemoryStream(bImage1);
                        pich1.Image = Image.FromStream(ms1);

                        byte[] bImage2 = null;
                        bImage2 = (byte[])item.Hinh2.ToArray();
                        MemoryStream ms2 = new MemoryStream(bImage2);
                        pich2.Image = Image.FromStream(ms2);

                        byte[] bImage3 = null;
                        bImage3 = (byte[])item.Hinh3.ToArray();
                        MemoryStream ms3 = new MemoryStream(bImage3);
                        pich3.Image = Image.FromStream(ms3);
                        arrImage = bImage;
                        arrImage1 = bImage1;
                        arrImage2 = bImage2;
                        arrImage3 = bImage3;
                    }
                }
            }
        }
    }
}