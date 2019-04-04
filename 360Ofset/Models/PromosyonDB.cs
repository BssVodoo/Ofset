using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _360Ofset.Models
{
    public class PromosyonDB
    {
        public int ID { get; set; }
        [DisplayName("Resim 200x200 Olalıdır.")]
        public string PResim { get; set; }
        [DisplayName("Resim Başlığı")]
        public string PBaslik { get; set; }
        [DisplayName("Resim İçeriği")]
        public string PAciklama { get; set; }
    }
}