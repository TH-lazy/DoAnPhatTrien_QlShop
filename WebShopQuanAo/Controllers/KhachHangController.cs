using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopQuanAo.Models;
using WebShopQuanAo.Common;
using System.Data;

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
                Session["user"] = new User()
                {
                    login = tendn,
                    UserName = kq.TenKH
                };
                var userSession = new User();
                userSession.login = tendn;
                userSession.UserName = kq.TenKH;
                Session.Add(CommonConstans.USER_SESSION,userSession);
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


        public ActionResult KhachHangPartial()
        {
            var session = Session[WebShopQuanAo.Common.CommonConstans.USER_SESSION];
            ViewBag.UserName = session;
            return PartialView();
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


        public ViewResult ThongTinTaiKhoan()
        {
            string tk = "";
            var user = Session["user"] as User;
            tk = user.login;
            var List = db.KhachHangs.Single(s => s.Taikhoan == tk);
            return View(List);

        }

        public ActionResult ThongTinTaiKhoan1()
        {
            string tk = "";
            var user = Session["user"] as User;
            tk = user.login;
            var List = db.KhachHangs.Single(s => s.Taikhoan == tk);
            KhachHang sp = db.KhachHangs.Single(d => d.Taikhoan == tk);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        public ActionResult ThongTinTaiKhoan1(KhachHang sp)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Attach(sp);
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowSanPham", "SanPham");
            }
            return View(sp);
        }


        public ActionResult DangXuat()
        {
            Session["user"] = null;

            return RedirectToAction("ShowSanPham", "SanPham");
        }

    }
}