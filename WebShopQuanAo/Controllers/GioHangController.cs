using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopQuanAo.Models;

namespace WebShopQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        Data_QLBanQuanAoEntities1 db = new Data_QLBanQuanAoEntities1();
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }

        public List<GioHang> layGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(string ms, int msct, string strUrl)
        {
            List<GioHang> lstGioHang = layGioHang();

            GioHang HangHoa = lstGioHang.Find(sp => sp.iMaSP == ms && sp.iMaCTSP == msct);
            if (HangHoa == null)
            {
                HangHoa = new GioHang(ms,msct);
                lstGioHang.Add(HangHoa);
                return Redirect(strUrl);

            }
            else
            {
                HangHoa.iSoLuong++;
                return Redirect(strUrl);
            }
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }

        private void capNhatSoLuong(string mahang, int mact)
        {
            int sl = 0;
            List<ChiTietHangHoa> ls = new List<ChiTietHangHoa>();
            ls = db.ChiTietHangHoas.Select(m => m).Where(ma => ma.MaHang == mahang && ma.MaCTHH == mact).ToList();
            foreach (var item in ls)
            {
                sl = sl + int.Parse(item.SoLuong.ToString());
            }
            HangHoa hh = db.HangHoas.Single(m => m.MaHang == mahang);
            hh.SoLuongTon = sl;
            db.SaveChanges();
        }

        private void trusoluong(string mahang, int mact, int soluong)
        {
            int so = 0;
            ChiTietHangHoa ct = db.ChiTietHangHoas.Single(ma => ma.MaHang == mahang && ma.MaCTHH == mact);
            so = int.Parse(ct.SoLuong.ToString());
            so = so - soluong;
            ct.SoLuong = so;
            db.SaveChanges();
        }

        private double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                ttt += lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }


        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index1", "Home");
            }
            List<GioHang> lstGioHang = layGioHang();

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return PartialView();
        }

        public ActionResult XoaGioHang(string msp)
        {
            List<GioHang> lstgh = layGioHang();
            GioHang sp = lstgh.Single(m => m.iMaSP == msp);
            if (sp != null)
            {
                lstgh.RemoveAll(s => s.iMaSP == msp);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (lstgh.Count == 0)
            {
                return RedirectToAction("ShowSanPham", "SanPham");
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult CapNhatGioHang(string masp, FormCollection f)
        {
            List<GioHang> lstgh = layGioHang();
            GioHang sp = lstgh.Single(m => m.iMaSP == masp);
            if (sp != null)
            {
                
                sp.iSoLuong = int.Parse(f["txtsl"].ToString());
             
                sp.sSize = f["txtss"];
                sp.sMauSac = f["txtsm"];
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult XoaAll()
        {
            List<GioHang> lstgh = layGioHang();
            lstgh.Clear();
            return RedirectToAction("GioHang", "GioHang");
        }

        [HttpGet]
        public ActionResult Dathang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("ShowSanPham", "SanPham");
            }
            List<GioHang> lstGioHang = layGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }


        [HttpPost]
        public ActionResult Dathang(FormCollection f)
        {
            HoaDonBanLe ddh = new HoaDonBanLe();

            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = layGioHang();
            ddh.MaKH = kh.MaKH;
            ddh.NgayLap = DateTime.Now;
            ddh.NgayHT = DateTime.Now;
            ddh.MaNV = 2;
            ddh.MaThue = "LT0001";
            ddh.MaHT = "HT0004";
            ddh.TongTien = TongThanhTien();
            //ddh.DaThanhToan = "Chưa thanh toán";
            //ddh.TinhTrangGiaoHang = 0;
            db.HoaDonBanLes.Add(ddh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                ChiTietHoaDonBanLe ctdh = new ChiTietHoaDonBanLe();
                ctdh.MaHDL = ddh.MaHDL;
                ctdh.MaHang = item.iMaSP;
                ctdh.MaCTHH = item.iMaCTSP;
                ctdh.GiaBan = item.dDonGia;
                ctdh.SoLuong = item.iSoLuong;
                ctdh.ThanhTien = item.dThanhTien;
                ctdh.GhiChu = "Chưa giao hàng";
                db.ChiTietHoaDonBanLes.Add(ctdh);
                trusoluong(item.iMaSP,item.iMaCTSP,item.iSoLuong);
                capNhatSoLuong(item.iMaSP, item.iMaCTSP);
            }
            db.SaveChanges();
            
            Session["GioHang"] = null;
            
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }


        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}