using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopQuanAo.Models;

namespace WebShopQuanAo.Controllers
{
    public class KhachHangController : Controller
    {
        Data_QLBanQuanAoEntities1 db = new Data_QLBanQuanAoEntities1();
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(KhachHang kh, FormCollection f)
        {
            var tendn = f["TenDN"];
            var mt = f["Matkhau"];
            var kq = db.KhachHangs.SingleOrDefault(sp => sp.Taikhoan == tendn && sp.Matkhau == mt);
            if (kq != null)
            {
                Session["TaiKhoan"] = kq;
                return RedirectToAction("ShowSanPham", "SanPham");
            }
            else
            {
                ViewBag.Kq = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            var hoten = f["HotenKH"];
            var gt = f["GioiTinh"];
            var tendn = f["TenDN"];
            var matkhau = f["Matkhau"];
            var rematkhau = f["ReMatkhau"];
            var dienthoai = f["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/DD/YYYY}", f["NgaySinh"]);
            var email = f["Email"];
            var diachi = f["Diachi"];
            var tenDN = db.KhachHangs.SingleOrDefault(sp => sp.Taikhoan == tendn);
            if (tenDN != null)
            {
                ViewData["Loi7"] = "tên đăng nhập đã tồn tại";
            }
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Vui lòng nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(rematkhau))
            {
                ViewData["Loi4"] = "Vui lòng nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Vui lòng nhập số điện thoại";
            }
            if (rematkhau != matkhau)
            {
                ViewData["Loi6"] = "Vui lòng nhập đúng mật khẩu";
            }
            if (!String.IsNullOrEmpty(hoten)&&!String.IsNullOrEmpty(gt) && !String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau) && (rematkhau == matkhau) && !String.IsNullOrEmpty(dienthoai))
            {
                kh.TenKH = hoten;
                kh.GioiTinh = gt;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                kh.DiaChi = diachi;
                kh.Email = email;
                kh.SoDienThoai = dienthoai;
                kh.LoaiKH = "LKH0001";
                kh.DiemThuong = 0;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.NgayDK = DateTime.Now;
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangNhap", "KhachHang");
            }
            return View();

        }

    }
}