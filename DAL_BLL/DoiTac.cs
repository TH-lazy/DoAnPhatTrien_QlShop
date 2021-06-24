using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DoiTac
    {
        QLShopDataContext qlDoitac = new QLShopDataContext();
        public DoiTac()
        { }

        public IQueryable<ChucVu> loadChucVu()
        {
            return qlDoitac.ChucVus.Select(cv => cv);
        }

        public IQueryable<LoaiKhachHang> loadLoaiKhach()
        {
            return qlDoitac.LoaiKhachHangs.Select(lk => lk);
        }

        //public int KTNhanVien(string manv)
        //{
        //    return qlDoitac.NhanViens.Select(t => t).Where(m => m.MaNV == manv).Count();
        //}

        //public string maMax()
        //{
        //    return qlDoitac.NhanViens.Select(m => m).Max(p => p.MaNV);
        //}

        //public string maMaxKH()
        //{
        //    return qlDoitac.KhachHangs.Select(m => m).Max(p => p.MaKH);
        //}

        public bool ThemNV(string tennv,string gioitinh, DateTime ngaysinh, string diachi, string email, string sodienthoai, string macv, int luong, string tk, string matkhau, DateTime ngayvaolam)
        {
            //if (KTNhanVien(manv)==0)
            //{
                NhanVien nv = new NhanVien();
                //nv.MaNV = manv;
                nv.TenNV = tennv;
                nv.GioiTinh = gioitinh;
                nv.NgaySinh = ngaysinh;
                nv.DiaChi = diachi;
                nv.Email = email;
                nv.SoDienThoai = sodienthoai;
                nv.MaCV = macv;
                nv.Luong = luong;
                nv.TenDN = tk;
                nv.MatKhau = matkhau;
                nv.NgayDK = ngayvaolam;
                qlDoitac.NhanViens.InsertOnSubmit(nv);
                qlDoitac.SubmitChanges();
                return true;
            //}
            //return false;
        }

        //public int KTKhachHang(string makh)
        //{
        //    return qlDoitac.KhachHangs.Select(kh => kh).Where(m => m.MaKH == makh).Count();
        //}

        public int KTKhachHang(string sdt,string tk)
        {
            return qlDoitac.KhachHangs.Select(kh => kh).Where(m => m.SoDienThoai == sdt|| m.Taikhoan == tk).Count();
        }

        public int KTNhanVien(string sdt, string tk)
        {
            return qlDoitac.NhanViens.Select(kh => kh).Where(m => m.SoDienThoai == sdt || m.TenDN == tk).Count();
        }

        public List<KhachHang> TimKhachHang(string sdt, string tk)
        {
            return qlDoitac.KhachHangs.Select(kh => kh).Where(m => m.SoDienThoai == sdt || m.Taikhoan == tk).ToList(); 
        }

        public List<NhanVien> TimNhanVien(string sdt, string tk)
        {
            return qlDoitac.NhanViens.Select(kh => kh).Where(m => m.SoDienThoai == sdt || m.TenDN == tk).ToList(); 
        }



        public bool ThemKH(string tenkh, string gioitinh, DateTime ngaysinh, string diachi, string email, string sodienthoai, string loaikh, int diemthuong, string tk, string matkhau, DateTime ngaydk)
        {
            //if (KTNhanVien(makh) == 0)
            //{
                KhachHang kh = new KhachHang();
                //kh.MaKH = makh;
                kh.TenKH = tenkh;
                kh.GioiTinh = gioitinh;
                kh.NgaySinh = ngaysinh;
                kh.DiaChi = diachi;
                kh.Email = email;
                kh.SoDienThoai = sodienthoai;
                kh.LoaiKH = loaikh;
                kh.DiemThuong = diemthuong;
                kh.Taikhoan = tk;
                kh.Matkhau = matkhau;
                kh.NgayDK = ngaydk;
                qlDoitac.KhachHangs.InsertOnSubmit(kh);
                qlDoitac.SubmitChanges();
                return true;
            //}
           // return false;
        }


        public bool UpdateNV(int manv, string tennv, string gioitinh, DateTime ngaysinh, string diachi, string email, string sodienthoai, string macv, int luong, string tk, string matkhau, DateTime ngayvaolam)
        {
            if (KTNhanVien(sodienthoai,tk) > 0)
            {
                NhanVien nv = qlDoitac.NhanViens.Single(n => n.MaNV == manv);
                nv.MaNV = manv;
                nv.TenNV = tennv;
                nv.GioiTinh = gioitinh;
                nv.NgaySinh = ngaysinh;
                nv.DiaChi = diachi;
                nv.Email = email;
                nv.SoDienThoai = sodienthoai;
                nv.MaCV = macv;
                nv.Luong = luong;
                nv.TenDN = tk;
                nv.MatKhau = matkhau;
                nv.NgayDK = ngayvaolam;
                qlDoitac.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool UpdateKH(int makh, string tenkh, string gioitinh, DateTime ngaysinh, string diachi, string email, string sodienthoai, string loaikh, int diemthuong, string tk, string matkhau, DateTime ngaydk)
        {
            if (KTKhachHang(sodienthoai,tk) > 0)
            {
                KhachHang kh = qlDoitac.KhachHangs.Single(n => n.MaKH == makh);
                kh.MaKH = makh;
                kh.TenKH = tenkh;
                kh.GioiTinh = gioitinh;
                kh.NgaySinh = ngaysinh;
                kh.DiaChi = diachi;
                kh.Email = email;
                kh.SoDienThoai = sodienthoai;
                kh.LoaiKH = loaikh;
                kh.DiemThuong = diemthuong;
                kh.Taikhoan = tk;
                kh.Matkhau = matkhau;
                kh.NgayDK = ngaydk;
                qlDoitac.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool xoadoitac(string sdt, string tk)
        {
            if (KTKhachHang(sdt,tk) > 0)
            {
                KhachHang kh = new KhachHang();
                kh = qlDoitac.KhachHangs.Single(t => t.Taikhoan == tk || t.SoDienThoai == sdt);
                qlDoitac.KhachHangs.DeleteOnSubmit(kh);
                qlDoitac.SubmitChanges();
                return true;
            }
            if (KTNhanVien(sdt, tk) > 0)
            {
                NhanVien nv = new NhanVien();
                nv = qlDoitac.NhanViens.Single(t => t.TenDN == tk || t.SoDienThoai == sdt);
                qlDoitac.NhanViens.DeleteOnSubmit(nv);
                qlDoitac.SubmitChanges();
                return true;
            }
            return false;
        }

        public int demNV()
        {
            return qlDoitac.NhanViens.Count();
        }

        public int demKH()
        {
            return qlDoitac.KhachHangs.Count();
        }

        public IQueryable loadNhanVien()
        {
            IQueryable nv = from h in qlDoitac.NhanViens select new { h.MaNV, h.TenNV, h.GioiTinh, h.NgaySinh, h.DiaChi, h.Email, h.SoDienThoai, h.ChucVu.MaCV, h.Luong, h.TenDN, h.MatKhau, h.NgayDK };
            return nv;
        }

        public IQueryable loadKhachHang()
        {
            IQueryable kh = from h in qlDoitac.KhachHangs select new {h.MaKH,h.TenKH,h.GioiTinh,h.NgaySinh,h.DiaChi,h.Email,h.SoDienThoai,h.LoaiKhachHang.LoaiKH,h.DiemThuong,h.Taikhoan,h.Matkhau,h.NgayDK };
            return kh;
        }


        public int KTLoaiKhach(string s)
        {
            return qlDoitac.LoaiKhachHangs.Select(d => d).Where(k => k.LoaiKH == s).Count();
        }
        public bool ThemLoaiKhach(string mas, string tens)
        {
            if (KTLoaiKhach(mas) == 0)
            {
                LoaiKhachHang s = new LoaiKhachHang();
                s.LoaiKH = mas;
                s.TenLoai = tens;
                qlDoitac.LoaiKhachHangs.InsertOnSubmit(s);
                qlDoitac.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaLoaiKhach(string ma)
        {
            if (KTLoaiKhach(ma) > 0)
            {
                LoaiKhachHang m = new LoaiKhachHang();
                m = qlDoitac.LoaiKhachHangs.Single(mau => mau.LoaiKH == ma);
                qlDoitac.LoaiKhachHangs.DeleteOnSubmit(m);
                qlDoitac.SubmitChanges();
                return true;
            }
            return false;
        }


        public int KTChucVu(string s)
        {
            return qlDoitac.ChucVus.Select(d => d).Where(k => k.MaCV == s).Count();
        }
        public bool ThemChucVu(string mas, string tens)
        {
            if (KTChucVu(mas) == 0)
            {
                ChucVu s = new ChucVu();
                s.MaCV = mas;
                s.TenCV = tens;
                qlDoitac.ChucVus.InsertOnSubmit(s);
                qlDoitac.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaChucVu(string ma)
        {
            if (KTChucVu(ma) > 0)
            {
                ChucVu m = new ChucVu();
                m = qlDoitac.ChucVus.Single(mau => mau.MaCV == ma);
                qlDoitac.ChucVus.DeleteOnSubmit(m);
                qlDoitac.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
