//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShopQuanAo
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonBanLe
    {
        public HoaDonBanLe()
        {
            this.ChiTietHoaDonBanLes = new HashSet<ChiTietHoaDonBanLe>();
        }
    
        public int MaHDL { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public Nullable<System.DateTime> NgayHT { get; set; }
        public Nullable<int> MaKH { get; set; }
        public Nullable<int> MaNV { get; set; }
        public string MaThue { get; set; }
        public Nullable<int> SoThue { get; set; }
        public Nullable<double> SoTienThue { get; set; }
        public Nullable<double> GiamGia { get; set; }
        public Nullable<double> SoTienGiam { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string GhiChu { get; set; }
    
        public virtual ICollection<ChiTietHoaDonBanLe> ChiTietHoaDonBanLes { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual LoaiThue LoaiThue { get; set; }
    }
}