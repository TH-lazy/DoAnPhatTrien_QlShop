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
    
    public partial class NhanVien
    {
        public NhanVien()
        {
            this.HoaDon_BanSi = new HashSet<HoaDon_BanSi>();
            this.HoaDonBanLes = new HashSet<HoaDonBanLe>();
            this.PhieuChiTiens = new HashSet<PhieuChiTien>();
            this.PhieuNhapKhoes = new HashSet<PhieuNhapKho>();
        }
    
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string MaCV { get; set; }
        public Nullable<int> Luong { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public Nullable<System.DateTime> NgayDK { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        public virtual ICollection<HoaDon_BanSi> HoaDon_BanSi { get; set; }
        public virtual ICollection<HoaDonBanLe> HoaDonBanLes { get; set; }
        public virtual ICollection<PhieuChiTien> PhieuChiTiens { get; set; }
        public virtual ICollection<PhieuNhapKho> PhieuNhapKhoes { get; set; }
    }
}
