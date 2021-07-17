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
    public partial class Frm_DangNhap : Form
    {
        DoiTac doiTac = new DoiTac();
        public static class ControlID
        {
            public static string textData { get; set; }
        }
        public Frm_DangNhap()
        {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (doiTac.dangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                Trangchu f = new Trangchu(doiTac.laychucvu(txtTaiKhoan.Text, txtMatKhau.Text).Trim(), txtTaiKhoan.Text);
                ControlID.textData = txtTaiKhoan.Text;
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }

        private void ckPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPassword.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }
    }
}
