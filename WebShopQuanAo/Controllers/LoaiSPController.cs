using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopQuanAo.Models;

namespace WebShopQuanAo.Controllers
{
    public class LoaiSPController : Controller
    {

        Data_QLBanQuanAoEntities1 db = new Data_QLBanQuanAoEntities1();
        // GET: LoaiSP
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult SPDanhChoNam(string maLoai = "Nam")
        {
            var ListSp = db.HangHoas.Where(s => s.DanhCho == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPDanhChoNu(string maLoai = "Nữ")
        {
            var ListSp = db.HangHoas.Where(s => s.DanhCho == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPTheoLH1(string maLoai = "LH0001")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH2(string maLoai = "LH0002")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH3(string maLoai = "LH0003")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH4(string maLoai = "LH0004")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH5(string maLoai = "LH0005")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH6(string maLoai = "LH0006")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH7(string maLoai = "LH0007")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH8(string maLoai = "LH0008")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH9(string maLoai = "LH0009")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH10(string maLoai = "LH0010")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH11(string maLoai = "LH0011")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPTheoLH12(string maLoai = "LH0012")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH13(string maLoai = "LH0013")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH14(string maLoai = "LH0014")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH15(string maLoai = "LH0015")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH16(string maLoai = "LH0016")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH17(string maLoai = "LH0017")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH18(string maLoai = "LH0018")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH19(string maLoai = "LH0019")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH20(string maLoai = "LH0020")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }
        public ViewResult SPTheoLH21(string maLoai = "LH0021")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPTheoLH22(string maLoai = "LH0022")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPTheoLH23(string maLoai = "LH0023")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPTheoLH24(string maLoai = "LH0024")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPTheoLH25(string maLoai = "LH0025")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

        }

        public ViewResult SPTheoLH26(string maLoai = "LH0026")
        {
            var ListSp = db.HangHoas.Where(s => s.MaLoai == maLoai).ToList();
            if (ListSp.Count == 0)
            {
                ViewBag.SanPham = "Không có Sản Phẩm nào thuộc Loại này !";
            }
            return View(ListSp);

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
                chiTietHangHoas = db.ChiTietHangHoas.Select(m => m).Where(ma => ma.MaHang == ms).ToList(),
            };
            return View(tables);
        }
    }
}