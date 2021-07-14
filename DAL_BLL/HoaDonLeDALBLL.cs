using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDonLeDALBLL
    {
        QLShopDataContext qldhdl = new QLShopDataContext();

        public int layMaMax()
        {
            return qldhdl.HoaDonBanLes.Select(m => m).Max(mm => mm.MaHDL);
        }

        public int KTHoaDon(int mahd)
        {
            return qldhdl.HoaDonBanLes.Select(m => m).Where(ma => ma.MaHDL == mahd).Count();
        }


        public bool themHoaDon(DateTime ngaylap, DateTime ngayht, int kh, int nv, string mathue, int sothue, float tienthue, float giamgia, float sotiengiam, float tongtien, string ghichu, string ht)
        {
            HoaDonBanLe hd = new HoaDonBanLe();
            hd.NgayLap = ngaylap;
            hd.NgayHT = ngayht;
            hd.MaKH = kh;
            hd.MaNV = nv;
            hd.MaThue = mathue;
            hd.SoThue = sothue;
            hd.SoTienThue = tienthue;
            hd.GiamGia = giamgia;
            hd.SoTienGiam = sotiengiam;
            hd.TongTien = tongtien;
            hd.GhiChu = ghichu;
            hd.MaHT = ht;
            qldhdl.HoaDonBanLes.InsertOnSubmit(hd);
            qldhdl.SubmitChanges();
            return true;
        }

        public bool themCTHoaDon(int mahd, string mahang,int mauhang ,int soluong, float giaban, float thanhtien, string ghichu)
        {
            if (KTHoaDon(mahd) > 0)
            {
                ChiTietHoaDonBanLe ct = new ChiTietHoaDonBanLe();
                ct.MaHDL = mahd;
                ct.MaHang = mahang;
                ct.MaCTHH = mauhang;
                ct.SoLuong = soluong;
                ct.GiaBan = giaban;
                ct.ThanhTien = thanhtien;
                ct.GhiChu = ghichu;
                qldhdl.ChiTietHoaDonBanLes.InsertOnSubmit(ct);
                qldhdl.SubmitChanges();
                return true;
            }
            return false;
        }

        public IQueryable loadChiTietHD(int mahdl)
        {
            IQueryable ct = from h in qldhdl.ChiTietHoaDonBanLes where h.MaHDL == mahdl select new { h.MaCTHDL, h.HangHoa.MaHang, h.HangHoa.TenHang,h.MaCTHH ,h.HangHoa.MaDVT, h.HangHoa.GiaBanLe, h.SoLuong, h.ThanhTien, h.GhiChu };
            return ct;
        }



        public List<ChiTietHoaDonBanLe> loadHDCT(int mahdl)
        {
            return qldhdl.ChiTietHoaDonBanLes.Select(m => m).Where(ma => ma.MaHDL == mahdl).ToList();
        }



        public float tongTien(int mahd)
        {
            var itemsInCart = (from h in qldhdl.ChiTietHoaDonBanLes
                               where h.MaHDL == mahd
                               select new { h.HangHoa.MaHang, h.HangHoa.TenHang, h.HangHoa.MaDVT, h.HangHoa, h, h.HangHoa.GiaBanLe, h.SoLuong, h.ThanhTien, h.GhiChu }).ToList();
            var sum = itemsInCart.Select(c => c.ThanhTien).Sum();
            return float.Parse(sum.ToString());
        }


        public List<ChiTietHoaDonBanLe> thanhtien(int mahdl)
        {
            return qldhdl.ChiTietHoaDonBanLes.Select(m => m).Where(ma => ma.MaHDL == mahdl).ToList();
        }


        public bool capNhatHoaDon(int mahdl, int sothue, float tienthue, float giamgia, float sotiengiam, float tongtien)
        {
            if (KTHoaDon(mahdl) > 0)
            {
                HoaDonBanLe hd = qldhdl.HoaDonBanLes.Single(m => m.MaHDL == mahdl);
                hd.SoThue = sothue;
                hd.SoTienThue = tienthue;
                hd.GiamGia = giamgia;
                hd.SoTienGiam = sotiengiam;
                hd.TongTien = tongtien;
                qldhdl.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool xoaHDL(int mahdl)
        {
            if (KTHoaDon(mahdl) > 0)
            {
                if (KTCTHDL(mahdl) > 0)
                {
                    xoaCTHDL(mahdl);
                }
                HoaDonBanLe hd = qldhdl.HoaDonBanLes.Single(ma => ma.MaHDL == mahdl);
                qldhdl.HoaDonBanLes.DeleteOnSubmit(hd);
                qldhdl.SubmitChanges();
                return true;
            }
            return false;
        }


        public int KTCTHDL(int mahdl)
        {
            return qldhdl.ChiTietHoaDonBanLes.Select(m => m).Where(ma => ma.MaHDL == mahdl).Count();
        }
        public bool xoaCTHDL(int mahdl)
        {
            if (KTCTHDL(mahdl) > 0)
            {
                var ct = from h in qldhdl.ChiTietHoaDonBanLes where h.MaHDL == mahdl select h;
                qldhdl.ChiTietHoaDonBanLes.DeleteAllOnSubmit(ct);
                qldhdl.SubmitChanges();
                return true;
            }
            return false;
        }

        public List<ChiTietHoaDonBanLe> lay1CTHDL(int macthdl)
        {
            return qldhdl.ChiTietHoaDonBanLes.Select(ma => ma).Where(m => m.MaCTHDL == macthdl).ToList(); ;
        }

        public int KT1CTHDL(int ma)
        {
            return qldhdl.ChiTietHoaDonBanLes.Select(m => m).Where(mahd => mahd.MaCTHDL == ma).Count();
        }

        public bool xoa1CTHDL(int ma)
        {
            if (KT1CTHDL(ma) > 0)
            {
                ChiTietHoaDonBanLe ct = qldhdl.ChiTietHoaDonBanLes.Single(m => m.MaCTHDL == ma);
                qldhdl.ChiTietHoaDonBanLes.DeleteOnSubmit(ct);
                qldhdl.SubmitChanges();
                return true;
            }
            return false;
        }

        public IQueryable loadHoaDon()
        {
            IQueryable hd = from h in qldhdl.HoaDonBanLes select new { h.MaHDL, h.NgayLap, h.NgayHT, h.KhachHang.TenKH, h.NhanVien.TenNV, h.LoaiThue.TenThue, h.SoThue, h.SoTienThue, h.GiamGia, h.SoTienGiam, h.TongTien };
            return hd;
        }

        public IQueryable loadChiTietHDt(int mahdl)
        {
            IQueryable ct = from h in qldhdl.ChiTietHoaDonBanLes
                            join b in qldhdl.HoaDonBanLes on h.MaHDL equals b.MaHDL
                            join c in qldhdl.HangHoas on h.MaHang equals c.MaHang
                            join d in qldhdl.ChiTietHangHoas on c.MaHang equals d.MaHang
                            join e in qldhdl.ChiTietHangHoas on h.MaHang equals e.MaHang
                            where h.MaHDL == mahdl
                            select new
                            {
                                h.MaCTHDL,
                                h.HangHoa.MaHang,
                                h.HangHoa.TenHang,
                                h.HangHoa.MaDVT,
                                h.MaCTHH,
                                d.MauSac.MaMau,
                                d.KichThuoc.MaSize,                            
                                h.HangHoa.GiaBanLe,
                                h.SoLuong,
                                h.ThanhTien,
                                h.GhiChu
                            };
            return ct;
        }

        public List<HoaDonBanLe> lay()
        {
            return qldhdl.HoaDonBanLes.Select(m => m).ToList();
        }

        public int demCTHDL(int mahdl)
        {
            return qldhdl.ChiTietHoaDonBanLes.Select(m => m).Where(ma => ma.MaHDL == mahdl).Count();
        }


        public bool xoaHDR(int mahdl)
        {
            if (KTHoaDon(mahdl) > 0)
            {
                if (KTCTHDL(mahdl) <= 0)
                {
                    HoaDonBanLe hd = qldhdl.HoaDonBanLes.Single(ma => ma.MaHDL == mahdl);
                    qldhdl.HoaDonBanLes.DeleteOnSubmit(hd);
                    qldhdl.SubmitChanges();
                    return true;
                }              
            }
            return false;
        }


        public IQueryable layHDChuaGiao(string chuoi)
        {
            IQueryable ct = from h in qldhdl.ChiTietHoaDonBanLes where h.GhiChu == chuoi select new { h.MaCTHDL, h.HangHoa.MaHang, h.HangHoa.TenHang, h.MaCTHH, h.HangHoa.MaDVT, h.HangHoa.GiaBanLe, h.SoLuong, h.ThanhTien, h.GhiChu };
            return ct;
        }

        public bool UpdateCTHDL(int ma,string chuoi)
        {
            if (KT1CTHDL(ma)!= 0)
            {
                ChiTietHoaDonBanLe ct = qldhdl.ChiTietHoaDonBanLes.Single(m => m.MaCTHDL == ma);
                ct.GhiChu = chuoi;
                qldhdl.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
