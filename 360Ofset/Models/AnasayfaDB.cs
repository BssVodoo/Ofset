using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _360Ofset.Models
{
    public class AnasayfaDB
    {
        public int ID { get; set; }
        [DisplayName("Resim 200x200 Olalıdır.")]
        public string Aresim { get; set; }
        [DisplayName("Resim Başlığı")]
        public string ABaslik { get; set; }
    }
}