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
    public partial class Frm_DanhSachHoaDonLe : DevExpress.XtraEditors.XtraForm
    {
        HoaDonLeDALBLL hoadon = new HoaDonLeDALBLL();
        public Frm_DanhSachHoaDonLe()
        {
            InitializeComponent();
        }

        private void Frm_DanhSachHoaDonLe_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = hoadon.loadHoaDon();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = hoadon.loadChiTietHD(int.Parse(gridView1.GetFocusedRowCellValue("MaHDL").ToString()));
        }
    }
}