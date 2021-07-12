using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopQuanAo.Models
{
    [Serializable]
    public class User
    {
        public string login { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}