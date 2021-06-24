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
    public partial class Frm_DSDoiTac : DevExpress.XtraEditors.XtraForm
    {
        string quyen = "";
        DoiTac doitac = new DoiTac();
        public Frm_DSDoiTac()
        {
            InitializeComponent();
        }

        public Frm_DSDoiTac(string mess) : this()
        {
            quyen = mess;
        }

        private void Frm_DSDoiTac_Load(object sender, EventArgs e)
        {
            if (quyen == "nhanvien")
            {
                lblThongTin.Text = "Nhân Viên";
                drv_doitac.DataSource = doitac.loadNhanVien();
            }
            else
            {
                lblThongTin.Text = "Khách Hàng";
                drv_doitac.DataSource = doitac.loadKhachHang();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (quyen =="nhanvien")
            {
                drv_doitac.DataSource = doitac.loadNhanVien();
            }
            else
            {
                drv_doitac.DataSource = doitac.loadKhachHang();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (quyen == "nhanvien")
            {
                Frm_NhanVien f = new Frm_NhanVien("nhanvien");
                f.Show();

            }
            else
            {
                Frm_NhanVien f = new Frm_NhanVien("khachhang");
                f.Show();
            }
        }
    }
}