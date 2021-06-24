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
using System.Xml;
using DAL_BLL;

namespace QuanLyShopQuanAo
{
    public partial class Frm_NhanVien : DevExpress.XtraEditors.XtraForm
    {
        DoiTac doitac = new DoiTac();
        string loaidoitac = "";
        public Frm_NhanVien()
        {
            InitializeComponent();
        }

        public Frm_NhanVien(string mess) : this()
        {
            loaidoitac = mess;
        }
        private void Frm_NhanVien_Load(object sender, EventArgs e)
        {
            if (loaidoitac == "khachhang")
            {             
                lblDoitac.Text = "Khách Hàng";
                lblLoaiDoiTac.Text = "Loại khách";
                cbodoitac.DataSource = doitac.loadLoaiKhach();
                cbodoitac.DisplayMember = "TenLoai";
                cbodoitac.ValueMember = "LoaiKH";
                lblLuong_Diem.Text = "Điểm tích lũy";
                lblmadoitac.Text = "Mã khách hàng";
                lbltendoitac.Text = "Tên khách hàng";
                txt_luong.Enabled = false;
            }
            else
            {
                
                lblDoitac.Text = "Nhân Viên";
                lblLoaiDoiTac.Text = "Chức vụ";
                cbodoitac.DataSource = doitac.loadChucVu();
                cbodoitac.DisplayMember = "TenCV";
                cbodoitac.ValueMember = "MaCV";
                lblLuong_Diem.Text = "Lương";
                lblmadoitac.Text = "Mã nhân viên";
                lbltendoitac.Text = "Tên nhân viên";
            }  
            
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //DateTime.ParseExact(dtpNgaySinh.Text, "dd/MM/yyyy", null).ToString("yyyy/MM/dd")



            if (txt_tendoitac.Text == "" || txt_Diachi.Text =="" || txtEmail.Text =="" || txt_TK.Text =="" || txt_MK.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin");
                return;
            }

            if (loaidoitac == "nhanvien" )
            {
                //string chuoinv;
                //if (doitac.demNV()>0)
                //{
                    
                //    chuoinv = doitac.maMax();
                //}
                //else
                //{
                //    chuoinv = "NV0001";
                //}
                //string ma = chuoinv.Substring(0, 5);
                
                //int maso = int.Parse(chuoinv.Substring(5));
                //int manew = maso + 1;
                //string chuoinew = ma + manew;
                //txtmadoitac.Text = chuoinew;

                if (doitac.ThemNV(txt_tendoitac.Text, cboGioitinh.Text, DateTime.ParseExact(dtpNgaySinh.Text, "dd/MM/yyyy", null), txt_Diachi.Text, txtEmail.Text, txt_SDT.Text, cbodoitac.SelectedValue.ToString(), int.Parse(txt_luong.Text), txt_TK.Text, txt_MK.Text, DateTime.ParseExact(dtpNgayTao.Text, "dd/MM/yyyy", null)))
                {
                    cleartext();
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                //string chuoikh;
                //if (doitac.demKH()>0)
                //{
                    
                //    chuoikh = doitac.maMaxKH();
                //}
                //else
                //{
                //    chuoikh = "KH0001";
                //}
                //string ma = chuoikh.Substring(0, 5);
                
                //int maso = int.Parse(chuoikh.Substring(5));
                //int manew = maso + 1;
                //string chuoinew = ma + manew;
                //txtmadoitac.Text = chuoinew;

                if (doitac.ThemKH(txt_tendoitac.Text, cboGioitinh.Text, DateTime.ParseExact(dtpNgaySinh.Text, "dd/MM/yyyy", null), txt_Diachi.Text, txtEmail.Text, txt_SDT.Text, cbodoitac.SelectedValue.ToString(), int.Parse(txt_luong.Text), txt_TK.Text, txt_MK.Text, DateTime.ParseExact(dtpNgayTao.Text, "dd/MM/yyyy", null)))
                {
                    cleartext();
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            
            if (loaidoitac == "khachhang")
            {
                if (txt_TK.Text == "" && txt_SDT.Text == "0")
                {
                    MessageBox.Show("Bạn phải nhập tài khoản hoặc số điện thoại của khách hàng muốn sửa");
                    return;
                }
                List<KhachHang> kh = new List<KhachHang>();
                kh = doitac.TimKhachHang(txt_SDT.Text, txt_TK.Text);
                foreach (var item in kh)
                {
                    txtmadoitac.Text = item.MaKH.ToString();
                    txt_tendoitac.Text = item.TenKH;
                    cboGioitinh.Text = item.GioiTinh;
                    dtpNgaySinh.Text = item.NgaySinh.ToString();
                    txt_Diachi.Text = item.DiaChi;
                    txtEmail.Text = item.Email;
                    txt_SDT.Text = item.SoDienThoai;
                    cbodoitac.DisplayMember = item.LoaiKH;
                    txt_luong.Text = item.DiemThuong.ToString();
                    txt_TK.Text = item.Taikhoan;
                    txt_MK.Text = item.Matkhau;
                    dtpNgayTao.Text = item.NgayDK.ToString();
                }
            }
            else
            {
                if (txt_TK.Text == "" && txt_SDT.Text == "0")
                {
                    MessageBox.Show("Bạn phải nhập tài khoản hoặc số điện thoại của nhân viên muốn sửa");
                    return;
                }
                List<NhanVien> kh = new List<NhanVien>();
                kh = doitac.TimNhanVien(txt_SDT.Text, txt_TK.Text);
                foreach (var item in kh)
                {
                    txtmadoitac.Text = item.MaNV.ToString();
                    txt_tendoitac.Text = item.TenNV;
                    cboGioitinh.Text = item.GioiTinh;
                    dtpNgaySinh.Text = item.NgaySinh.ToString();
                    txt_Diachi.Text = item.DiaChi;
                    txtEmail.Text = item.Email;
                    txt_SDT.Text = item.SoDienThoai;
                    cbodoitac.DisplayMember = item.MaCV;
                    txt_luong.Text = item.Luong.ToString();
                    txt_TK.Text = item.TenDN;
                    txt_MK.Text = item.MatKhau;
                    dtpNgayTao.Text = item.NgayDK.ToString();
                }
            }    
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        public void cleartext()
        {
            txtmadoitac.ResetText();
            txt_tendoitac.ResetText();
            txt_Diachi.ResetText();
            txtEmail.ResetText();
            txt_SDT.Text = "0";
            txt_luong.Text = "0";
            txt_TK.ResetText();
            txt_MK.ResetText();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txt_TK.Text == "" && txt_SDT.Text == "0")
            {
                MessageBox.Show("Bạn phải nhập tài khoản hoặc số điện thoại của người muốn xóa");
                return;
            }
            if (doitac.xoadoitac(txt_SDT.Text,txt_TK.Text))
            {

                cleartext();
                MessageBox.Show("Xóa Thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (loaidoitac == "khachhang")
            {
                if (doitac.UpdateKH(int.Parse(txtmadoitac.Text), txt_tendoitac.Text, cboGioitinh.Text, DateTime.ParseExact(dtpNgaySinh.Text, "dd/MM/yyyy", null), txt_Diachi.Text, txtEmail.Text, txt_SDT.Text, cbodoitac.SelectedValue.ToString(), int.Parse(txt_luong.Text), txt_TK.Text, txt_MK.Text, DateTime.ParseExact(dtpNgayTao.Text, "dd/MM/yyyy", null)))
                {
                    cleartext();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else
            {
                if (doitac.UpdateNV(int.Parse(txtmadoitac.Text), txt_tendoitac.Text, cboGioitinh.Text, DateTime.ParseExact(dtpNgaySinh.Text, "dd/MM/yyyy", null), txt_Diachi.Text, txtEmail.Text, txt_SDT.Text, cbodoitac.SelectedValue.ToString(), int.Parse(txt_luong.Text), txt_TK.Text, txt_MK.Text, DateTime.ParseExact(dtpNgayTao.Text, "dd/MM/yyyy", null)))
                {
                    cleartext();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_SDT_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            /*if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
             */
        }

        private void txt_luong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}