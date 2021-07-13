using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopQuanAo.Models
{
    public class GioHang
    {
        Data_QLBanQuanAoEntities1 db = new Data_QLBanQuanAoEntities1();
        public string iMaSP { set; get; }
        public int iMaCTSP { set; get; }
        public string sTenSP { set; get; }
        public string sAnhBia { set; get; }
        public double dDonGia { set; get; }
        public int iSoLuong { set; get; }

        public string sSize { set; get; }
        public string sMauSac { set; get; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }


        public GioHang(string MaSanPham, int MaCTSanPham)
        {
            iMaSP = MaSanPham;
            iMaCTSP = MaCTSanPham;
            HangHoa hh = db.HangHoas.Single(s => s.MaHang == iMaSP);
            ChiTietHangHoa cthh = db.ChiTietHangHoas.Single(s => s.MaCTHH == iMaCTSP && s.MaHang == iMaSP);
            sSize = cthh.MaSize;
            sMauSac = cthh.MauSac.TenMau;
            sTenSP = hh.TenHang;
            sAnhBia = hh.HinhAnh;
            dDonGia = double.Parse(hh.GiaBanLe.ToString());
            iSoLuong = 1;
        }
    }
}