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
    
    public partial class MauSac
    {
        public MauSac()
        {
            this.ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }
    
        public string MaMau { get; set; }
        public string TenMau { get; set; }
    
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
