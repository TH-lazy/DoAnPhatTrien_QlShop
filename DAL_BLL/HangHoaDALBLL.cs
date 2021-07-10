using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HangHoaDALBLL
    {
        QLShopDataContext qlhanghoa = new QLShopDataContext();

        public HangHoaDALBLL()
        {

        }

        //public IQueryable<HangHoa> loadHangHoa()
        //{
        //    return qlhanghoa.HangHoas.Select(h => h);
        //}

        //public IQueryable<ChiTietHangHoa> loadChiTietHangHoa(string mahh)
        //{
        //    return qlhanghoa.ChiTietHangHoas.Select(ct => ct).Where(c => c.MaHang == mahh);
        //}

        public IQueryable<DonViTinh> loadDonViTinh()
        {
            return qlhanghoa.DonViTinhs.Select(dvt => dvt);
        }

        public IQueryable<LoHang> loadLoHang()
        {
            return qlhanghoa.LoHangs.Select(lo => lo);
        }

        public IQueryable<MauSac> loadMauSac()
        {
            return qlhanghoa.MauSacs.Select(m => m);
        }

        public int KTHangHoa(string mahang)
        {
            return qlhanghoa.HangHoas.Select(h => h).Where(m => m.MaHang == mahang).Count();
        }

        public int KTCTHangHoa(string mahang)
        {
            return qlhanghoa.ChiTietHangHoas.Select(h => h).Where(m => m.MaHang == mahang).Count();
        }


        public bool ThemHH(string mahang, string tenhang, int soluong, string madvt, string malo, string makho, string maloai, string kieudang, string xuatxu, string nhasx, DateTime namsx, float giamua, float giabanle, float giabansi, int trongluong, int chieudai, int chieurong, string quycach, string mota, string danhcho)
        {
            if (KTHangHoa(mahang) == 0)
            {
                HangHoa hh = new HangHoa();
                hh.MaHang = mahang;
                hh.TenHang = tenhang;
                hh.SoLuongTon = soluong;
                hh.MaDVT = madvt;
                hh.MaLo = malo;
                hh.MaKho = makho;
                hh.MaLoai = maloai;
                hh.KieuDang = kieudang;
                hh.XuatXu = xuatxu;
                hh.NhaSanXuat = nhasx;
                hh.NamSanXuat = namsx;
                hh.GiaMua = giamua;
                hh.GiaBanLe = giabanle;
                hh.GiaBanSi = giabansi;
                hh.TrongLuong = trongluong;
                hh.ChieuDai = chieudai;
                hh.ChieuRong = chieurong;
                hh.QuyCach = quycach;
                hh.MoTa = mota;
                hh.DanhCho = danhcho;
                qlhanghoa.HangHoas.InsertOnSubmit(hh);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public string maHHMax()
        {
            return qlhanghoa.HangHoas.Select(h => h).Max(m => m.MaHang);
        }

        public bool ThemCTHH(string mahang, string mamau, string masize, int soluong, string hdd, string h1, string h2, string h3)
        {
            if (KTHangHoa(mahang) == 1)
            {
                ChiTietHangHoa ct = new ChiTietHangHoa();
                ct.MaHang = mahang;
                ct.MaMau = mamau;
                ct.MaSize = masize;
                ct.SoLuong = soluong;
                ct.Hinhdaidien = hdd;
                ct.Hinh1 = h1;
                ct.Hinh2 = h2;
                ct.Hinh3 = h3;
                qlhanghoa.ChiTietHangHoas.InsertOnSubmit(ct);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public int KTDVT(string madvt)
        {
            return qlhanghoa.DonViTinhs.Select(d => d).Where(k => k.MaDVT == madvt).Count();
        }
        public bool ThemDVT(string madvt, string tendvt)
        {
            if (KTDVT(madvt) == 0)
            {
                DonViTinh dvt = new DonViTinh();
                dvt.MaDVT = madvt;
                dvt.TenDVT = tendvt;
                qlhanghoa.DonViTinhs.InsertOnSubmit(dvt);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }


        public int KTMau(string mau)
        {
            return qlhanghoa.MauSacs.Select(d => d).Where(k => k.MaMau == mau).Count();
        }
        public bool ThemMau(string mamau, string tenmau)
        {
            if (KTDVT(mamau) == 0)
            {
                MauSac m = new MauSac();
                m.MaMau = mamau;
                m.TenMau = tenmau;
                qlhanghoa.MauSacs.InsertOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public IQueryable<KichThuoc> loadKichThuoc()
        {
            return qlhanghoa.KichThuocs.Select(k => k);
        }

        public int KTSize(string s)
        {
            return qlhanghoa.KichThuocs.Select(d => d).Where(k => k.MaSize == s).Count();
        }
        public bool ThemSize(string mas, string tens)
        {
            if (KTDVT(mas) == 0)
            {
                KichThuoc s = new KichThuoc();
                s.MaSize = mas;
                s.TenSize = tens;
                qlhanghoa.KichThuocs.InsertOnSubmit(s);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaSize(string ma)
        {
            if (KTSize(ma) > 0)
            {
                KichThuoc m = new KichThuoc();
                m = qlhanghoa.KichThuocs.Single(mau => mau.MaSize == ma);
                qlhanghoa.KichThuocs.DeleteOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool XoaMau(string ma)
        {
            if (KTMau(ma) > 0)
            {
                MauSac m = new MauSac();
                m = qlhanghoa.MauSacs.Single(mau => mau.MaMau == ma);
                qlhanghoa.MauSacs.DeleteOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool XoaDVT(string ma)
        {
            if (KTDVT(ma) > 0)
            {
                DonViTinh m = new DonViTinh();
                m = qlhanghoa.DonViTinhs.Single(mau => mau.MaDVT == ma);
                qlhanghoa.DonViTinhs.DeleteOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }


        /*public bool XoaHH(string ma)
        {
            if (KTHangHoa(ma) > 0)
            {
                HangHoa hh = new HangHoa();
                hh = qlhanghoa.HangHoas.Single(mh => mh.MaHang == ma);
                qlhanghoa.HangHoas.DeleteOnSubmit(hh);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }*/


        public List<HangHoa> layHangHoa(string mahang)
        { 
            return qlhanghoa.HangHoas.Select(h => h).Where(ma => ma.MaHang == mahang).ToList();
        }

        public List<ChiTietHangHoa> layCTTheoHang(string mahang,int mauhang)
        {
            return qlhanghoa.ChiTietHangHoas.Select(m => m).Where(ma => ma.MaHang == mahang&& ma.MaCTHH == mauhang).ToList();
        }

        //public List<HangHoa> layHangHoa(string mahang)
        //{
        //    var lh = from h in qlhanghoa.HangHoas
        //             join b in qlhanghoa.ChiTietHangHoas on h.MaHang equals b.MaHang
        //             where h.MaHang == mahang
        //             select new {h.MaHang,h.TenHang,h.GiaBanLe,b.MaCTHH,h.SoLuongTon,b.SoLuong };
        //    return lh.ToList();
        //}

        //public IQueryable layHangHoa(string mahang)
        //{

        //    IQueryable lh = from h in qlhanghoa.ChiTietHangHoas
        //             where h.MaHang == mahang
        //             select new {h.MaHang, h.HangHoa.TenHang, h.HangHoa.MaDVT,h.HangHoa.SoLuongTon,h.SoLuong };
        //    return lh;
        //}


        public List<ChiTietHangHoa> layCTHangHoa(int mahang)
        {
            return qlhanghoa.ChiTietHangHoas.Select(m => m).Where(ma => ma.MaCTHH == mahang).ToList();
        }


        public List<ChiTietHangHoa> loadCTHangHoa()
        {
            return qlhanghoa.ChiTietHangHoas.Select(m => m).ToList();
        }

        //public IQueryable loadTong()
        //{
        //    IQueryable hh = from h in qlhanghoa.HangHoas select new { h.MaHang, h.TenHang,h.SoLuong ,h.MaDVT, h.GiaBanLe, h.GiaBanSi, h.GiaMua, h.LoHang.MaLo, h.Kho.MaKho, h.MoTa, h.ChiTietHangHoa.KieuDang, h.ChiTietHangHoa.XuatXu, h.ChiTietHangHoa.NhaSanXuat, h.ChiTietHangHoa.NamSanXuat,h.ChiTietHangHoa.QuyCach, h.ChiTietHangHoa.KichThuoc.MaSize,h.ChiTietHangHoa.TrongLuong,h.ChiTietHangHoa.MauSac.MaMau, h.ChiTietHangHoa.ChieuDai, h.ChiTietHangHoa.ChieuRong, h.ChiTietHangHoa.Hinhdaidien, h.ChiTietHangHoa.Hinh1,h.ChiTietHangHoa.Hinh2,h.ChiTietHangHoa.Hinh3,h.ChiTietHangHoa.MoTaCT};
        //    return hh;
        //}

        public int demHH()
        {
            return qlhanghoa.HangHoas.Count();
        }

        public bool xoaHH(string mahh)
        {
            if (KTHangHoa(mahh) > 0)
            {
                if (KTCTHangHoa(mahh) > 0)
                {
                    ChiTietHangHoa ct = new ChiTietHangHoa();
                    ct = qlhanghoa.ChiTietHangHoas.Single(m => m.MaHang == mahh);
                    qlhanghoa.ChiTietHangHoas.DeleteOnSubmit(ct);
                }

                HangHoa hh = new HangHoa();
                hh = qlhanghoa.HangHoas.Single(m => m.MaHang == mahh);
                qlhanghoa.HangHoas.DeleteOnSubmit(hh);

                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public int KTCTHH(int macthh)
        {
            return qlhanghoa.ChiTietHangHoas.Select(m => m).Where(ma => ma.MaCTHH == macthh).Count();
        }
        public bool UpdateHH(string mahang, string tenhang, int soluong, string madvt, string malo, string makho, string maloai, string kieudang, string xuatxu, string nhasx, DateTime namsx, float giamua, float giabanle, float giabansi, int trongluong, int chieudai, int chieurong, string quycach, string mota)
        {
            if (KTHangHoa(mahang) > 0)
            {

                HangHoa hh = qlhanghoa.HangHoas.Single(ma => ma.MaHang == mahang);
                hh.MaHang = mahang;
                hh.TenHang = tenhang;
                hh.SoLuongTon = soluong;
                hh.MaDVT = madvt;
                hh.GiaBanLe = giabanle;
                hh.GiaBanSi = giabansi;
                hh.GiaMua = giamua;
                hh.MaLo = malo;
                hh.MaKho = makho;
                hh.MoTa = mota;
                hh.MaLoai = maloai;
                hh.KieuDang = kieudang;
                hh.XuatXu = xuatxu;
                hh.NhaSanXuat = nhasx;
                hh.NamSanXuat = namsx;
                hh.QuyCach = quycach;
                hh.TrongLuong = trongluong;
                hh.ChieuDai = chieudai;
                hh.ChieuRong = chieurong;

                qlhanghoa.SubmitChanges();
                return true;

            }
            return false;
        }

        public bool UpdateCTHH(string mahang,int macthh, string mamau, string masize, int soluong, string hdd, string h1, string h2, string h3)
        {
            if (KTHangHoa(mahang)>0)
            {
                if (KTCTHH(macthh) == 1)
                {
                    ChiTietHangHoa ct = qlhanghoa.ChiTietHangHoas.Single(ma => ma.MaHang == mahang&& ma.MaCTHH == macthh);
                    ct.MaSize = masize;
                    ct.MaMau = mamau;
                    ct.SoLuong = soluong;
                    ct.Hinhdaidien = hdd;
                    ct.Hinh1 = h1;
                    ct.Hinh2 = h2;
                    ct.Hinh3 = h3;
                    qlhanghoa.SubmitChanges();
                    return true;
                }
            }
            return false;
        }


        public IQueryable<LoaiPhi> loadPhi()
        {
            return qlhanghoa.LoaiPhis.Select(k => k);
        }

        public int KTPhi(string s)
        {
            return qlhanghoa.LoaiPhis.Select(d => d).Where(k => k.MaPhi == s).Count();
        }
        public bool ThemPhi(string mas, string tens)
        {
            if (KTPhi(mas) == 0)
            {
                LoaiPhi s = new LoaiPhi();
                s.MaPhi = mas;
                s.TenPhi = tens;
                qlhanghoa.LoaiPhis.InsertOnSubmit(s);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaPhi(string ma)
        {
            if (KTPhi(ma) > 0)
            {
                LoaiPhi m = new LoaiPhi();
                m = qlhanghoa.LoaiPhis.Single(mau => mau.MaPhi == ma);
                qlhanghoa.LoaiPhis.DeleteOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public IQueryable<LoaiThue> loadThue()
        {
            return qlhanghoa.LoaiThues.Select(k => k);
        }

        public int KTThue(string s)
        {
            return qlhanghoa.LoaiThues.Select(d => d).Where(k => k.MaThue == s).Count();
        }
        public bool ThemThue(string mas, string tens)
        {
            if (KTThue(mas) == 0)
            {
                LoaiThue s = new LoaiThue();
                s.MaThue = mas;
                s.TenThue = tens;
                qlhanghoa.LoaiThues.InsertOnSubmit(s);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaThue(string ma)
        {
            if (KTThue(ma) > 0)
            {
                LoaiThue m = new LoaiThue();
                m = qlhanghoa.LoaiThues.Single(mau => mau.MaThue == ma);
                qlhanghoa.LoaiThues.DeleteOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }


        public IQueryable<LoaiHang> loadLoaiHang()
        {
            return qlhanghoa.LoaiHangs.Select(k => k);
        }

        public int KTLoaiHang(string s)
        {
            return qlhanghoa.LoaiHangs.Select(d => d).Where(k => k.MaLoai == s).Count();
        }
        public bool ThemLoaiHang(string mas, string tens)
        {
            if (KTLoaiHang(mas) == 0)
            {
                LoaiHang s = new LoaiHang();
                s.MaLoai = mas;
                s.TenLoai = tens;
                qlhanghoa.LoaiHangs.InsertOnSubmit(s);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaLoaiHang(string ma)
        {
            if (KTLoaiHang(ma) > 0)
            {
                LoaiHang m = new LoaiHang();
                m = qlhanghoa.LoaiHangs.Single(mau => mau.MaLoai == ma);
                qlhanghoa.LoaiHangs.DeleteOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }


        public IQueryable<HinhThuc> loadHinhThuc()
        {
            return qlhanghoa.HinhThucs.Select(k => k);
        }

        public int KTHinhThuc(string s)
        {
            return qlhanghoa.HinhThucs.Select(d => d).Where(k => k.MaHT == s).Count();
        }
        public bool ThemHinhThuc(string mas, string tens)
        {
            if (KTHinhThuc(mas) == 0)
            {
                HinhThuc s = new HinhThuc();
                s.MaHT = mas;
                s.TenHT = tens;
                qlhanghoa.HinhThucs.InsertOnSubmit(s);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool XoaHinhThuc(string ma)
        {
            if (KTHinhThuc(ma) > 0)
            {
                HinhThuc m = new HinhThuc();
                m = qlhanghoa.HinhThucs.Single(mau => mau.MaHT == ma);
                qlhanghoa.HinhThucs.DeleteOnSubmit(m);
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateSLHH(string mahh, int sl)
        {
            if (KTHangHoa(mahh) > 0)
            {
                HangHoa hh = qlhanghoa.HangHoas.Single(ma => ma.MaHang == mahh);
                hh.SoLuongTon = sl;
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public List<HangHoa> layTenHH(string mah)
        {
            return qlhanghoa.HangHoas.Select(m => m).Where(ma => ma.MaHang == mah).ToList();
        }

        //public IQueryable laySizeHang(string mahang)
        //{
        //    IQueryable hs = (from h in qlhanghoa.ChiTietHangHoas where h.MaHang == mahang select new { h.MaCTHH, h.KichThuoc.MaSize, h.MauSac.MaMau, h.MauSac.TenMau }).Distinct();
        //    return hs;
        //}
        public IQueryable laySizeHang(string mahang)
        {
            IQueryable hs = (from h in qlhanghoa.ChiTietHangHoas where h.MaHang == mahang select new { h.KichThuoc.MaSize }).Distinct();
            return hs;
        }

        public IQueryable layMauHang(string size)
        {
            IQueryable hs = (from h in qlhanghoa.ChiTietHangHoas where h.MaSize == size select new { h.MaCTHH, h.KichThuoc.MaSize, h.MauSac.MaMau, h.MauSac.TenMau }).Distinct();
            return hs;
        }

        public IQueryable layKhoHang(string mahang)
        {
            IQueryable k = from h in qlhanghoa.HangHoas where h.MaHang == mahang select new { h.MaKho, h.Kho.TenKho };
            return k;
        }

        public string layTenMau(string mam)
        {
            string ma = "";
            //IQueryable chuoi = from h in qlhanghoa.MauSacs where h.MaMau == mam select new { h.TenMau };
            List<MauSac> chuoi = new List<MauSac>();
            chuoi = qlhanghoa.MauSacs.Select(m => m).Where(l => l.MaMau == mam).ToList();
            foreach (var item in chuoi)
            {
                ma = item.TenMau;
            }
            return ma;
        }


        public string layTenDVT(string mam)
        {
            string ma = "";
            //IQueryable chuoi = from h in qlhanghoa.MauSacs where h.MaMau == mam select new { h.TenMau };
            List<DonViTinh> chuoi = new List<DonViTinh>();
            chuoi = qlhanghoa.DonViTinhs.Select(m => m).Where(l => l.MaDVT == mam).ToList();
            foreach (var item in chuoi)
            {
                ma = item.TenDVT;
            }
            return ma;
        }

        public string layTenLo(string mam)
        {
            string ma = "";
            //IQueryable chuoi = from h in qlhanghoa.MauSacs where h.MaMau == mam select new { h.TenMau };
            List<LoHang> chuoi = new List<LoHang>();
            chuoi = qlhanghoa.LoHangs.Select(m => m).Where(l => l.MaLo == mam).ToList();
            foreach (var item in chuoi)
            {
                ma = item.TenLo;
            }
            return ma;
        }

        public string layTenKho(string mam)
        {
            string ma = "";
            //IQueryable chuoi = from h in qlhanghoa.MauSacs where h.MaMau == mam select new { h.TenMau };
            List<Kho> chuoi = new List<Kho>();
            chuoi = qlhanghoa.Khos.Select(m => m).Where(l => l.MaKho == mam).ToList();
            foreach (var item in chuoi)
            {
                ma = item.TenKho;
            }
            return ma;
        }


        public string layTenLoai(string mam)
        {
            string ma = "";
            //IQueryable chuoi = from h in qlhanghoa.MauSacs where h.MaMau == mam select new { h.TenMau };
            List<LoaiHang> chuoi = new List<LoaiHang>();
            chuoi = qlhanghoa.LoaiHangs.Select(m => m).Where(l => l.MaLoai == mam).ToList();
            foreach (var item in chuoi)
            {
                ma = item.MaLoai;
            }
            return ma;
        }

        public int layMauHang(string mahang ,string masize, string mamau)
        {
            int mau = 0;
            List<ChiTietHangHoa> l = new List<ChiTietHangHoa>();
            l = qlhanghoa.ChiTietHangHoas.Select(m => m).Where(ma => ma.MaHang == mahang && ma.MaSize == masize && ma.MaMau == mamau).ToList();
            foreach (var item in l)
            {
                mau = int.Parse(item.MaCTHH.ToString());
            }
            return mau;
        }

        public List<HangHoa> layallhh()
        {
            return qlhanghoa.HangHoas.Select(m => m).ToList();
        }

        public int tongTonKho(string mahang)
        {
            var items = (from h in qlhanghoa.ChiTietHangHoas
                               where h.MaHang == mahang
                          select new { h.SoLuong}).ToList();
            var sum = items.Select(c => c.SoLuong).Sum();
            return int.Parse(sum.ToString());
        }

        public List<ChiTietHangHoa> layCTHangHoa1(string mahang)
        {
            return qlhanghoa.ChiTietHangHoas.Select(m => m).Where(ma => ma.MaHang == mahang).ToList();
        }

        public void capnhatkho()
        {
            List<HangHoa> l = new List<HangHoa>();
            l = layallhh();
                      
            foreach (var item in l)
            {
                int tongsl = 0;
                List<ChiTietHangHoa> lct = new List<ChiTietHangHoa>();
                lct = layCTHangHoa1(item.MaHang);
                foreach (var item1 in lct)
                {
                    tongsl = tongsl + int.Parse(item1.SoLuong.ToString());
                }
                UpdateSLHH(item.MaHang,tongsl);
            }
        }


        public bool UpdateSLHHCT(string mahh,int mauhang, int sl)
        {
            if (KTHangHoa(mahh) > 0)
            {
                ChiTietHangHoa hh = qlhanghoa.ChiTietHangHoas.Single(ma => ma.MaHang == mahh && ma.MaCTHH == mauhang);
                hh.SoLuong = sl;
                qlhanghoa.SubmitChanges();
                return true;
            }
            return false;
        }

        public IQueryable loadHangHoa()
        {
            IQueryable l = (from h in qlhanghoa.HangHoas 
                           join b in qlhanghoa.DonViTinhs on h.MaDVT equals b.MaDVT
                           join d in qlhanghoa.LoHangs on h.MaLo equals d.MaLo
                           join c in qlhanghoa.Khos on h.MaKho equals c.MaKho
                           join e in qlhanghoa.LoaiHangs on h.MaLoai equals e.MaLoai
                           join f in qlhanghoa.ChiTietHangHoas on h.MaHang equals f.MaHang
                           select new { 
                                          h.MaHang, h.TenHang,h.SoLuongTon,b.TenDVT,d.TenLo,
                                          c.TenKho, e.TenLoai, h.KieuDang,h.XuatXu,h.NhaSanXuat,
                                          h.NamSanXuat,h.GiaMua,h.GiaBanLe,h.GiaBanSi,h.TrongLuong,
                                          h.ChieuDai,h.ChieuRong,h.QuyCach,h.MoTa
                                        }).Distinct();
            return l;
        }

        public IQueryable loadChiTietHangHoa(string mahh)
        {
            IQueryable l = from h in qlhanghoa.ChiTietHangHoas
                           join b in qlhanghoa.KichThuocs on h.MaSize equals b.MaSize
                           join c in qlhanghoa.MauSacs on h.MaMau equals c.MaMau

                           where h.MaHang == mahh
                           select new { 
                           h.MaCTHH,h.HangHoa.TenHang,b.TenSize,c.TenMau,h.SoLuong,h.Hinhdaidien,h.Hinh1,h.Hinh2,h.Hinh3
                           };
            return l;
        }
    } 
}
