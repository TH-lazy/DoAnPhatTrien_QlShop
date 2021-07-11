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

        public ActionResult ThemGioHang(string ms, string strUrl)
        {
            List<GioHang> lstGioHang = layGioHang();

            GioHang HangHoa = lstGioHang.Find(sp => sp.iMaSP == ms);
            if (HangHoa == null)
            {
                HangHoa = new GioHang(ms);
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
            //ddh.DaThanhToan = "Chưa thanh toán";
            //ddh.TinhTrangGiaoHang = 0;
            db.HoaDonBanLes.Add(ddh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                ChiTietHoaDonBanLe ctdh = new ChiTietHoaDonBanLe();
                ctdh.MaHDL = ddh.MaHDL;
                ctdh.MaHang = item.iMaSP;
                ctdh.SoLuong = item.iSoLuong;
                ctdh.HangHoa.GiaBanLe = item.dDonGia;
                db.ChiTietHoaDonBanLes.Add(ctdh);

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