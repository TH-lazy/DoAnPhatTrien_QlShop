using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopQuanAo.Models
{
    public class SanPhamModel
    {
        public IEnumerable<HangHoa> hangHoas { get; set; }
        public IEnumerable<ChiTietHangHoa> chiTietHangHoas { get; set; }
    }
}