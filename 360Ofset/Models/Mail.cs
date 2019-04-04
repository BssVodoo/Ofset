using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _360Ofset.Models
{
    public class Mail
    {
        [DisplayName("İsim Soyisim")]
        public string AdSoyAd { get; set; }
        [DisplayName("Telefon Numarası")]
        public string Tel { get; set; }
        [DisplayName("E Posta")]
        public string Eposta { get; set; }
        [DisplayName("Sipariş Detayı")]
        public string Konu { get; set; }
    }
}