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

        /// <summary>
        ///     Lấy các thông tin của Phiếu nhập kho với các điều kiện có thể null.<br/>
        ///     Chỉ dùng để hiển thị lên datagridview.
        /// </summary>
        /// <param name="manv"> mã NV lập của Phiếu nhập</param>
        /// <param name="malo"> mã lô của Phiếu nhập</param>
        /// <param name="mancc"> mã NCC của Phiếu nhập</param>
        /// <param name="dateStart"> ngày đầu của khoảng thời gian </param>
        /// <param name="dateEnd"> ngày cuối của khoảng thời gian </param>
        /// <returns> Danh sách gồm: mã phiếu, ngày lập, mã NV lập, tổng sl, tổng thành tiền, mô tả </returns>
        public IQueryable lay_PNK_DK(int manv, string malo, string mancc, DateTime dateStart, DateTime dateEnd)
        {
            // 8 trường hợp vì dateStart và dateEnd luôn có dữ liệu --> luôn where ngày lập phiếu
            // Viết dạng chaining where clauses
            var list = qlpn.ChiTiet_PhieuNhapKhos.AsQueryable();
            if (manv != 0)
            {
                list = list.Where(pn => pn.PhieuNhapKho.MaNV == manv);
            }
            if (malo != null)
            {
                list = list.Where(pn => pn.PhieuNhapKho.MaLo == malo);
            }
            if (mancc != null)
            {
                list = list.Where(pn => pn.PhieuNhapKho.MaNCC == mancc);
            }
            if(dateStart != DateTime.MinValue && dateEnd != DateTime.MinValue)
            {
                list = list.Where(pn => pn.PhieuNhapKho.NgayLapPhieu >= dateStart && pn.PhieuNhapKho.NgayLapPhieu <= dateEnd);
            }
            return list.GroupBy(pn => new { pn.MaPhieuNhap, pn.PhieuNhapKho.NgayLapPhieu, pn.PhieuNhapKho.MaNV, pn.PhieuNhapKho.MoTa })
                .Select(pn => new { ma = pn.Key, sl = pn.Sum(p => p.SoLuong), tt = pn.Sum(p => p.ThanhTien)});
        }

        public List<ChiTiet_PhieuNhapKho> layCTPNK()
        {
            return qlpn.ChiTiet_PhieuNhapKhos.Select(m => m).ToList();
        }

        /// <summary>
        ///     Lấy thông tin chi tiết Phiếu nhập. Điều kiện có thể null.<br/>
        ///     Chỉ dùng để hiển thị lên datagridview.
        /// </summary>
        /// <param name="manv"> mã NV của Phiếu nhập </param>
        /// <param name="malo"> mã lô của Phiếu nhập </param>
        /// <param name="mancc"> mã NCC của Phiếu nhập </param>
        /// <param name="dateStart"> ngày đầu của khoảng thời gian </param>
        /// <param name="dateEnd"> ngày cuối của khoảng thời gian </param>
        /// <returns> Danh sách gồm rất nhiều thuộc tính. Demo để thấy toàn bộ danh sách.</returns>
        public IQueryable layCTPNK_DK(int manv, string malo, string mancc, string mahang, DateTime dateStart, DateTime dateEnd)
        {
            // viết dạng chaining where clauses
            var ctpn = qlpn.ChiTiet_PhieuNhapKhos.AsQueryable();

            if (manv != 0)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.MaNV == manv);
            }
            if (malo != null)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.MaLo == malo);
            }
            if (mancc != null)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.MaNCC == mancc);
            }
            if (mahang != null)
            {
                ctpn = ctpn.Where(pn => pn.MaHang == mahang);
            }
            if(dateStart != DateTime.MinValue && dateEnd != DateTime.MinValue)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.NgayLapPhieu >= dateStart && pn.PhieuNhapKho.NgayLapPhieu <= dateEnd);
            }

            return ctpn.Select(ct => new { ct.MaPhieuNhap, ct.PhieuNhapKho.NgayLapPhieu, ct.PhieuNhapKho.NhanVien.TenNV, ct.PhieuNhapKho.MaNCC, ct.PhieuNhapKho.NhaCungCap.TenNCC, ct.MaHang, ct.HangHoa.TenHang, ct.HangHoa.MaDVT, ct.SoLuong, ct.GiaVon, ct.ThanhTien, ct.PhieuNhapKho.LoHang.TenLo, ct.MoTa });
        }

        /// <summary>
        ///     Lấy ds Chi tiết PNK dạng List để dữ liệu được chính xác. Điều kiện có thể null.
        /// </summary>
        /// <param name="manv"> mã NV của Phiếu nhập </param>
        /// <param name="malo"> mã lô của Phiếu nhập </param>
        /// <param name="mancc"> mã NCC của Phiếu nhập </param>
        /// <param name="dateStart"> ngày đầu của khoảng thời gian </param>
        /// <param name="dateEnd"> ngày cuối của khoảng thời gian </param>
        /// <returns> List Chi tiết Phiếu nhập </returns>
        public List<ChiTiet_PhieuNhapKho> lay_CTPNK_DK(int manv, string malo, string mancc, string mahang, DateTime dateStart, DateTime dateEnd)
        {
            // viết dạng chaining where clauses
            var ctpn = qlpn.ChiTiet_PhieuNhapKhos.AsQueryable();

            if (manv != 0)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.MaNV == manv);
            }
            if (malo != null)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.MaLo == malo);
            }
            if (mancc != null)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.MaNCC == mancc);
            }
            if (mahang != null)
            {
                ctpn = ctpn.Where(pn => pn.MaHang == mahang);
            }
            if(dateEnd != DateTime.MinValue && dateStart != DateTime.MinValue)
            {
                ctpn = ctpn.Where(pn => pn.PhieuNhapKho.NgayLapPhieu >= dateStart && pn.PhieuNhapKho.NgayLapPhieu <= dateEnd);
            }
            
            return ctpn.ToList();
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
