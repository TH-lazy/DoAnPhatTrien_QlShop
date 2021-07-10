using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}