using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class NhaCC
    {
        QLShopDataContext qlNCC = new QLShopDataContext();

        public NhaCC()
        {

        }

        public IQueryable<NhaCungCap> loadNCC()
        {
            return qlNCC.NhaCungCaps.Select(n => n);
        }

        public int KTNCC(string mancc)
        {
            return qlNCC.NhaCungCaps.Select(n => n).Where(t => t.MaNCC == mancc).Count();
        }

        public bool ThemNCC(string mancc, string tenncc, string diachi, string email, string sdt, string mota)
        {
            if (KTNCC(mancc)==0)
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNCC = mancc;
                ncc.TenNCC = tenncc;
                ncc.DiaChi = diachi;
                ncc.Email = email;
                ncc.SoDienThoai = sdt;
                ncc.MoTa = mota;
                qlNCC.NhaCungCaps.InsertOnSubmit(ncc);
                qlNCC.SubmitChanges();
                return true;
            }
            return false;
        }

        public int demNCC()
        {
            return qlNCC.NhaCungCaps.Count();
        }

        public string maNCCMax()
        {
            return qlNCC.NhaCungCaps.Select(m => m).Max(ma => ma.MaNCC);
        }

        public bool xoaNCC(string mancc)
        {
            if (KTNCC(mancc)>0)
            {
                NhaCungCap ncc = qlNCC.NhaCungCaps.Single(m => m.MaNCC == mancc);
                qlNCC.NhaCungCaps.DeleteOnSubmit(ncc);
                qlNCC.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateNCC(string mancc, string tenncc, string diachi, string email, string sdt, string mota)
        {
            if (KTNCC(mancc)>0)
            {
                NhaCungCap ncc = qlNCC.NhaCungCaps.Single(m => m.MaNCC == mancc);
                ncc.MaNCC = mancc;
                ncc.TenNCC = tenncc;
                ncc.DiaChi = diachi;
                ncc.Email = email;
                ncc.SoDienThoai = sdt;
                ncc.MoTa = mota;
                qlNCC.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
