using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class KhoDALBLL
    {
        QLShopDataContext qlkho = new QLShopDataContext();

        public KhoDALBLL()
        { }

        public IQueryable<Kho> LoadKho()
        {
            return qlkho.Khos.Select(k => k);
        }

        public int KTKho(string makho)
        {
            return qlkho.Khos.Select(k => k).Where(t => t.MaKho == makho).Count();
        }
        public bool Them(string makho, string tenkho, string nhomkho, bool trangthai, string diadiem)
        {
            
            if (KTKho(makho)==0)
            {
                Kho k = new Kho();
                k.MaKho = makho;
                k.TenKho = tenkho;
                k.NhomKho = nhomkho;
                k.TrangThai = trangthai;
                k.DiaDiem = diadiem;
                qlkho.Khos.InsertOnSubmit(k);
                qlkho.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaKho(string makho)
        {
            if (KTKho(makho) > 0)
            {
                Kho k = new Kho();
                k = qlkho.Khos.Single(m => m.MaKho == makho);
                qlkho.Khos.DeleteOnSubmit(k);
                qlkho.SubmitChanges();
                return true;
            }
            return false;
        }

        public IQueryable<Kho> TimKho(string makho)
        {
            return qlkho.Khos.Select(m => m).Where(ma => ma.MaKho == makho || ma.TenKho == makho);
        }
    }
}
