using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _360Ofset.Models
{
    public class AmbalajDB
    {
        public int ID { get; set; }
        [DisplayName("Resim 200x200 Olalıdır.")]
        public string AResim { get; set; }
        [DisplayName("Resim Başlığı")]
        public string AAciklama { get; set; }
        [DisplayName("Resim İçeriği")]
        public string ABaslik { get; set; }
    }
}