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
    
    public partial class PhieuNhapKho
    {
        public PhieuNhapKho()
        {
            this.ChiTiet_PhieuNhapKho = new HashSet<ChiTiet_PhieuNhapKho>();
        }
    
        public string MaPhieuNhap { get; set; }
        public Nullable<System.DateTime> NgayLapPhieu { get; set; }
        public Nullable<int> MaNV { get; set; }
        public string MaLo { get; set; }
        public string MaNCC { get; set; }
        public string MoTa { get; set; }
    
        public virtual ICollection<ChiTiet_PhieuNhapKho> ChiTiet_PhieuNhapKho { get; set; }
        public virtual LoHang LoHang { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
