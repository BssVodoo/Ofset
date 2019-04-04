using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _360Ofset.Models
{
    public class StickerDB
    {
        public int ID { get; set; }
        [DisplayName("Resim 200x200 Olalıdır.")]
        public string SResim { get; set; }
        [DisplayName("Resim Başlığı")]
        public string SBaslik { get; set; }
        [DisplayName("Resim İçeriği")]
        public string SAciklama { get; set; }
    }
}