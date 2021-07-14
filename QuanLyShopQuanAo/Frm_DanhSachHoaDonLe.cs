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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<HoaDonBanLe> l = new List<HoaDonBanLe>();
            l = hoadon.lay();
            foreach (var item in l)
            {
                hoadon.xoaHDR(item.MaHDL);
            }
            gridControl1.DataSource = hoadon.loadHoaDon();
            MessageBox.Show("Ok");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = hoadon.layHDChuaGiao("Chưa giao hàng");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string trangthai = "Đã giao";
            List<ChiTietHoaDonBanLe> hd = hoadon.loadHDCT(int.Parse(gridView2.GetFocusedRowCellValue("MaCTHDL").ToString()));
            foreach (var item in hd)
            {
                if (item.GhiChu == "Chưa giao hàng")
                {
                    if (hoadon.UpdateCTHDL(int.Parse(gridView2.GetFocusedRowCellValue("MaCTHDL").ToString()), trangthai))
                    {
                        gridControl2.DataSource = hoadon.loadChiTietHD(int.Parse(gridView1.GetFocusedRowCellValue("MaHDL").ToString()));
                        MessageBox.Show("Thành công.");
                    }
                }
            }
        }
    }
}