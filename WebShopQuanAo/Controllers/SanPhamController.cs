using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopQuanAo.Models;

namespace WebShopQuanAo.Controllers
{
    public class SanPhamController : Controller
    {
        Data_QLBanQuanAoEntities1 db = new Data_QLBanQuanAoEntities1();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowSanPham()
        {
            var ListHangHoa = db.HangHoas.OrderBy(s => s.MaHang).ToList();
            return View(ListHangHoa);
        }


        public HangHoa XemChiTiet(string ms)
        {
            return db.HangHoas.Find(ms);
        }

        public ActionResult XemChiTietSp(string ms)
        {
            string sp = XemChiTiet(ms).MaHang;
            if (sp == null)
            {
                return HttpNotFound();
            }
            ChiTietHangHoa chitiet = db.ChiTietHangHoas.Single(s => s.MaHang == ms);
            if (chitiet == null)
            {
                return HttpNotFound();
            }
            return View(chitiet);
        }


        public ActionResult XemChiTietSp1(string ms)
        {
            string sp = XemChiTiet(ms).MaHang;
            if (sp == null)
            {
                return HttpNotFound();
            }
            var tables = new SanPhamModel
            {
                hangHoas = db.HangHoas.Select(m => m).Where(ma => ma.MaHang == ms).ToList(),
                chiTietHangHoas = db.ChiTietHangHoas.Select(m => m).Where(ma =>ma.MaHang == ms).ToList(),          
            };
            return View(tables);
        }
    }
}