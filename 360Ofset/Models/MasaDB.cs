using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _360Ofset.Models
{
    public class MasaDB
    {
        public int ID { get; set; }
        [DisplayName("Resim 200x200 Olalıdır.")]
        public string MasaResim { get; set; }
        [DisplayName("Resim Başlığı")]
        public string MasaBaslik { get; set; }
        [DisplayName("Resim İçeriği")]
        public string MasaAciklama { get; set; }
    }
}