using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhieuChiTienDALBLL
    {
        QLShopDataContext qlphieuchi = new QLShopDataContext();

        public IQueryable loadPhieuChiTien()
        {
            IQueryable pc = from h in qlphieuchi.PhieuChiTiens select new { h.MaPhieuChi, h.NgayLap, h.MaChungTu, h.NhanVien.TenNV, h.LoaiPhi.TenPhi, h.SoTien, h.HinhThuc.TenHT };
            return pc;
        }

        public List<PhieuChiTien> layPhieuChiTien(int pct)
        {
            return qlphieuchi.PhieuChiTiens.Select(m => m).Where(ma => ma.MaPhieuChi == pct).ToList();
        }

        public int KTPhieuChiTien(int pct)
        {
            return qlphieuchi.PhieuChiTiens.Select(m => m).Where(ma => ma.MaPhieuChi == pct).Count();
        }

        public bool themPhieuChi(DateTime ngaylap, string machungtu, int nv, string phi, float sotien, string ht)
        {
            PhieuChiTien pc = new PhieuChiTien();
            pc.NgayLap = ngaylap;
            pc.MaChungTu = machungtu;
            pc.MaNV = nv;
            pc.MaPhi = phi;
            pc.SoTien = sotien;
            pc.MaHT = ht;
            qlphieuchi.PhieuChiTiens.InsertOnSubmit(pc);
            qlphieuchi.SubmitChanges();
            return true;
        }


        public bool suaPhieuChi(int ma, DateTime ngaylap, string machungtu, int nv, string phi, float sotien, string ht)
        {
            if (KTPhieuChiTien(ma) > 0)
            {
                PhieuChiTien pc = qlphieuchi.PhieuChiTiens.Single(map => map.MaPhieuChi == ma);
                pc.NgayLap = ngaylap;
                pc.MaChungTu = machungtu;
                pc.MaNV = nv;
                pc.MaPhi = phi;
                pc.SoTien = sotien;
                pc.MaHT = ht;
                qlphieuchi.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool xoaPhieuChi(int ma)
        {
            if (KTPhieuChiTien(ma) > 0)
            {
                PhieuChiTien pc = qlphieuchi.PhieuChiTiens.Single(map => map.MaPhieuChi == ma);
                qlphieuchi.PhieuChiTiens.DeleteOnSubmit(pc);
                qlphieuchi.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
