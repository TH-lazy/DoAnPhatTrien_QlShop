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

        /// <summary>
        ///     Lấy chi tiết hóa đơn có cùng mã hóa đơn.
        /// </summary>
        /// <param name="mahdl"> mã hóa đơn </param>
        /// <returns>List chi tiết HD</returns>
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


        public bool xoaHoaDonRong(int mahdl)
        {
            if (demCTHDL(mahdl) == 0)
            {
                HoaDonBanLe hd = qldhdl.HoaDonBanLes.Single(m => m.MaHDL == mahdl);
                qldhdl.HoaDonBanLes.DeleteOnSubmit(hd);
                qldhdl.SubmitChanges();
                return true;
            }
            return true;
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


        public bool ghichuhoadon(int mahdl, string ghichu)
        {
            if (KTHoaDon(mahdl) ==1)
            {
                HoaDonBanLe hd = qldhdl.HoaDonBanLes.Single(m => m.MaHDL == mahdl);
                hd.GhiChu = ghichu;
                qldhdl.SubmitChanges();
                return true;
            }
            return false;
        }

        public HoaDonBanLe lay1HDLe(int mahdl)
        {
            return qldhdl.HoaDonBanLes.Single(hd => hd.MaHDL == mahdl);
        }

        /// <summary>
        ///     Lấy danh sách hóa đơn bán lẻ thỏa các điều kiện. Các điều kiện có thể null.<br/>
        ///     Chi dùng để hiển thị lên datagridview.
        /// </summary>
        /// <param name="manv">mã NV trên hóa đơn</param>
        /// <param name="makh">mã KH trên hóa đơn</param>
        /// <param name="maht">mã hình thức tt của hóa đơn</param>
        /// <param name="thue">0: tiền thuế = 0; 1: tiền thuế > 0</param>
        /// <param name="dateStart">ngày bắt đầu khoảng thời gian</param>
        /// <param name="dateEnd">ngày kết thúc khoảng thời gian</param>
        /// <returns></returns>
        public IQueryable load_HoaDon(int manv, int makh, string maht, int thue, DateTime dateStart, DateTime dateEnd)
        {
            // chaining where clauses
            var result = qldhdl.HoaDonBanLes.AsQueryable();

            if (manv != 0)
            {
                result = result.Where(hd => hd.MaNV == manv);
            }
            if (makh != 0)
            {
                result = result.Where(hd => hd.MaKH == makh);
            }
            if (maht != null)
            {
                result = result.Where(hd => hd.MaHT == maht);
            }
            if (thue == 0)
            {
                result = result.Where(hd => hd.SoTienThue == 0);
            }
            else if (thue == 1)
            {
                result = result.Where(hd => hd.SoTienThue > 0);
            }
            if (dateStart != DateTime.MinValue && dateEnd != DateTime.MinValue)
            {
                result = result.Where(hd => hd.NgayLap >= dateStart && hd.NgayLap <= dateEnd);
            }
            return result.Select(h => new { h.MaHDL, h.NgayLap, h.NgayHT, h.KhachHang.TenKH, h.NhanVien.TenNV, h.LoaiThue.TenThue, h.SoThue, h.SoTienThue, h.GiamGia, h.SoTienGiam, h.TongTien });
        }

        /// <summary>
        ///     Lấy danh sách hóa đơn bán lẻ thỏa các điều kiện. Dạng List để dữ liệu chính xác.<br/>
        ///     Các điều kiện này có thể null.
        /// </summary>
        /// <param name="manv">mã NV trên hóa đơn</param>
        /// <param name="makh">mã kh trên hóa đơn</param>
        /// <param name="maht">mã hình thức tt của hóa đơn</param>
        /// <param name="thue">0: tiền thuế = 0; 1: tiền thuế > 0</param>
        /// <param name="dateStart">ngày bắt đầu khoảng thời gian</param>
        /// <param name="dateEnd">ngày kết thúc khoảng thời gian</param>
        /// <returns>List hóa đơn bán lẻ thỏa điều kiện.</returns>
        public List<HoaDonBanLe> layDS_HDLe(int manv, int makh, string maht, int thue, DateTime dateStart, DateTime dateEnd)
        {
            // chaining where clauses
            var result = qldhdl.HoaDonBanLes.AsQueryable();

            if(manv != 0)
            {
                result = result.Where(hd => hd.MaNV == manv);
            }
            if(makh != 0)
            {
                result = result.Where(hd => hd.MaKH == makh);
            }
            if(maht != null)
            {
                result = result.Where(hd => hd.MaHT == maht);
            }
            if(thue == 0)
            {
                result = result.Where(hd => hd.SoTienThue == 0);
            }
            else if(thue == 1)
            {
                result = result.Where(hd => hd.SoTienThue > 0);
            }
            if(dateStart != DateTime.MinValue && dateEnd != DateTime.MinValue)
            {
                result = result.Where(hd => hd.NgayLap >= dateStart && hd.NgayLap <= dateEnd);
            }
            return result.ToList();
        }

        /// <summary>
        ///     Lấy các chi tiết hóa đơn bán lẻ thỏa các điều kiện. Các điều kiện có thể null.<br/>
        ///     Chi dùng để hiển thị lên datagridview.
        /// </summary>
        /// <param name="manv">mã NV trên hóa đơn</param>
        /// <param name="makh">mã KH trên hóa đơn</param>
        /// <param name="maht">mã hình thức tt của hóa đơn</param>
        /// <param name="mahang">mã hàng trên chi tiết hóa đơn</param>
        /// <param name="thue">0: tiền thuế = 0; 1: tiền thuế > 0</param>
        /// <param name="dateStart">ngày bắt đầu khoảng thời gian</param>
        /// <param name="dateEnd">ngày kết thúc khoảng thời gian</param>
        /// <returns>Danh sách chi tiết hóa đơn</returns>
        public IQueryable load_CTHoaDon(int manv, int makh, string maht, string mahang, int thue, DateTime dateStart, DateTime dateEnd)
        {
            var CT = qldhdl.ChiTietHoaDonBanLes.AsQueryable();
            if(manv != 0)
            {
                CT = CT.Where(c => c.HoaDonBanLe.MaNV == manv);
            }
            if(makh != 0)
            {
                CT = CT.Where(c => c.HoaDonBanLe.MaKH == makh);
            }
            if(maht != null)
            {
                CT = CT.Where(c => c.HoaDonBanLe.MaHT == maht);
            }
            if(mahang != null)
            {
                CT = CT.Where(c => c.MaHang == mahang);
            }
            if(thue == 0)
            {
                CT = CT.Where(c => c.HoaDonBanLe.SoTienThue == 0);
            }
            else if(thue == 1)
            {
                CT = CT.Where(c => c.HoaDonBanLe.SoTienThue > 0);
            }
            if(dateStart != DateTime.MinValue && dateEnd != DateTime.MinValue)
            {
                CT = CT.Where(c => c.HoaDonBanLe.NgayLap >= dateStart && c.HoaDonBanLe.NgayLap <= dateEnd);
            }
            return CT.Select(c => new { c.MaHDL, c.HoaDonBanLe.NgayLap, c.HoaDonBanLe.NhanVien.TenNV, c.HoaDonBanLe.MaKH, c.HoaDonBanLe.KhachHang.TenKH, c.MaHang, c.HangHoa.TenHang, c.HangHoa.MaDVT, c.SoLuong, c.ThanhTien, c.GhiChu});
        }

        /// <summary>
        ///     Lấy các chi tiết hóa đơn bán lẻ thỏa các điều kiện. Dạng List để dữ liệu chính xác.<br/>
        ///     Các điều kiện có thể null.
        /// </summary>
        /// <param name="manv">mã NV trên hóa đơn</param>
        /// <param name="makh">mã KH trên hóa đơn</param>
        /// <param name="maht">mã hình thức tt của hóa đơn</param>
        /// <param name="mahang">mã hàng trên chi tiết hóa đơn</param>
        /// <param name="thue">0: tiền thuế = 0; 1: tiền thuế > 0</param>
        /// <param name="dateStart">ngày bắt đầu khoảng thời gian</param>
        /// <param name="dateEnd">ngày kết thúc khoảng thời gian</param>
        /// <returns>List chi tiết hóa đơn</returns>
        public List<ChiTietHoaDonBanLe> LayDS_ChiTietHDLe(int manv, int makh, string maht, string mahang, int thue, DateTime dateStart, DateTime dateEnd)
        {
            var CT = qldhdl.ChiTietHoaDonBanLes.AsQueryable();
            if (manv != 0)
            {
                CT = CT.Where(c => c.HoaDonBanLe.MaNV == manv);
            }
            if (makh != 0)
            {
                CT = CT.Where(c => c.HoaDonBanLe.MaKH == makh);
            }
            if (maht != null)
            {
                CT = CT.Where(c => c.HoaDonBanLe.MaHT == maht);
            }
            if (mahang != null)
            {
                CT = CT.Where(c => c.MaHang == mahang);
            }
            if (thue == 0)
            {
                CT = CT.Where(c => c.HoaDonBanLe.SoTienThue == 0);
            }
            else if (thue == 1)
            {
                CT = CT.Where(c => c.HoaDonBanLe.SoTienThue > 0);
            }
            if (dateStart != DateTime.MinValue && dateEnd != DateTime.MinValue)
            {
                CT = CT.Where(c => c.HoaDonBanLe.NgayLap >= dateStart && c.HoaDonBanLe.NgayLap <= dateEnd);
            }
            return CT.ToList();
        }
    }
}
