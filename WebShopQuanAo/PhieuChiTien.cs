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
    
    public partial class PhieuChiTien
    {
        public int MaPhieuChi { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public string MaChungTu { get; set; }
        public Nullable<int> MaNV { get; set; }
        public string MaPhi { get; set; }
        public Nullable<double> SoTien { get; set; }
        public string MaHT { get; set; }
    
        public virtual HinhThuc HinhThuc { get; set; }
        public virtual LoaiPhi LoaiPhi { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
