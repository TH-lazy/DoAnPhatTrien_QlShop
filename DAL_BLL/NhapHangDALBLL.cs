using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class NhapHangDALBLL
    {
        QLShopDataContext qlpn = new QLShopDataContext();

        public IQueryable loadPhieuNhapHang()
        {
            IQueryable pnh = from h in qlpn.PhieuNhapKhos select new { h.MaPhieuNhap, h.NgayLapPhieu, h.NhanVien.TenNV, h.LoHang.TenLo,h.NhaCungCap.TenNCC,h.MoTa};
            return pnh;
        }

        public IQueryable loadCTPhieuNhapHang(string mapn)
        {
            IQueryable ct = from h in qlpn.ChiTiet_PhieuNhapKhos where h.MaPhieuNhap == mapn 
                            select new {h.MaCTPN,h.PhieuNhapKho.MaPhieuNhap,h.HangHoa.TenHang,h.SoLuong,h.GiaVon,h.ThanhTien,h.MoTa };
            return ct;
        }

        public List<PhieuNhapKho> layPNK()
        {
            return qlpn.PhieuNhapKhos.Select(m => m).ToList();
        }

        public List<PhieuNhapKho> lay_PNK(int manv, string malo, string mancc, DateTime dateStart, DateTime dateEnd)
        {
            // 8 trường hợp vì dateStart và dateEnd luôn có dữ liệu --> luôn where ngày lập phiếu
            // Thay vì viết 8 phương thức khác nhau --> viết chung 1 phương thức gọi 1 lần
            #region --- Các trường hợp ---
            if (malo != "")
            {
                if(mancc != "")
                {
                    if(manv != 0) // where: malo, mancc, manv
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.MaNV == manv).Where(p => p.MaNCC == mancc).Where(p => p.MaLo == malo)
                            .Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                    else // where: malo, mancc
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.MaLo == malo).Where(p => p.MaNCC == mancc)
                            .Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                }
                else
                {
                    if(manv != 0) // where: malo, manv
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.MaLo == malo).Where(p => p.MaNV == manv)
                            .Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                    else // where: malo
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.MaLo == malo)
                            .Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                }
            }
            else
            {
                if (mancc != "")
                {
                    if(manv != 0) // where: mancc, manv
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.MaNCC == mancc).Where(p => p.MaNV == manv)
                            .Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                    else // where: mancc
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.MaNCC == mancc)
                            .Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                }
                else
                {
                    if(manv != 0) // where: manv
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.MaNV == manv)
                            .Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                    else // chỉ where ngày lập phiếu
                    {
                        return qlpn.PhieuNhapKhos.Where(p => p.NgayLapPhieu >= dateStart && p.NgayLapPhieu <= dateEnd).ToList();
                    }
                }
            }
            #endregion
        }

        public List<ChiTiet_PhieuNhapKho> layCTPNK()
        {
            return qlpn.ChiTiet_PhieuNhapKhos.Select(m => m).ToList();
        }

        public List<ChiTiet_PhieuNhapKho> lay_CTPNK(int manv, string malo, string mancc, DateTime dateStart, DateTime dateEnd)
        {
            List<ChiTiet_PhieuNhapKho> list_ctpn = new List<ChiTiet_PhieuNhapKho>();
            // lấy phiếu nhập với các điều kiện như trên
            List<PhieuNhapKho> listpn = lay_PNK(manv, malo, mancc, dateStart, dateEnd);

            // lấy tất cả chi tiết phiếu nhập có cùng mã phiếu nhập
            foreach(PhieuNhapKho pn in listpn)
            {
                list_ctpn.AddRange(qlpn.ChiTiet_PhieuNhapKhos.Where(ctpn => ctpn.MaPhieuNhap == pn.MaPhieuNhap));
            }
            return list_ctpn;
        }
        public int KTPNK(string mpn)
        {
            return qlpn.PhieuNhapKhos.Select(m => m).Where(ma => ma.MaPhieuNhap == mpn).Count();
        }

        public int CTPNK(int ctmpnk)
        {
            return qlpn.ChiTiet_PhieuNhapKhos.Select(m => m).Where(ma => ma.MaCTPN == ctmpnk).Count();
        }

        public bool ThemPNK(string mpn, DateTime ngaylap, int nv, string lo, string ncc, string mota)
        {
            if (KTPNK(mpn) == 0)
            {
                PhieuNhapKho p = new PhieuNhapKho();
                p.MaPhieuNhap = mpn;
                p.NgayLapPhieu = ngaylap;
                p.MaNV = nv;
                p.MaLo = lo;
                p.MaNCC = ncc;
                p.MoTa = mota;
                qlpn.PhieuNhapKhos.InsertOnSubmit(p);
                qlpn.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool ThemCTPNK(string mpn, string mahang, int soluong, float giavon, float thanhtien, string mota)
        {
            if (KTPNK(mpn) == 1)
            {
                ChiTiet_PhieuNhapKho ct = new ChiTiet_PhieuNhapKho();
                ct.MaPhieuNhap = mpn;
                ct.MaHang = mahang;
                ct.SoLuong = soluong;
                ct.GiaVon = giavon;
                ct.ThanhTien = thanhtien;
                ct.MoTa = mota;
                qlpn.ChiTiet_PhieuNhapKhos.InsertOnSubmit(ct);
                qlpn.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool xoaPNK(string mapn)
        {
            if (KTPNK(mapn) == 1)
            {
                PhieuNhapKho p = new PhieuNhapKho();
                p = qlpn.PhieuNhapKhos.Single(m =>m.MaPhieuNhap == mapn);
                qlpn.PhieuNhapKhos.DeleteOnSubmit(p);
                qlpn.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaCTPNK(string mapn, int ctpnk)
        {
            if (CTPNK(ctpnk) == 1)
            {
                ChiTiet_PhieuNhapKho ct = new ChiTiet_PhieuNhapKho();
                ct = qlpn.ChiTiet_PhieuNhapKhos.Single(m => m.MaCTPN == ctpnk);
                qlpn.ChiTiet_PhieuNhapKhos.DeleteOnSubmit(ct);
                qlpn.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
