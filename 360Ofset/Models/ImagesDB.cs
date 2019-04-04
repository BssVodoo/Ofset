using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _360Ofset.Models
{
    public class ImagesDB
    {
        public int ID { get; set; }
        [DisplayName("Resim 940x398 Olalıdır.")]
        public string ResimUrl { get; set; }
        [DisplayName("Resim Başlığı")]
        public string RBaslik { get; set; }
        [DisplayName("Resim Açıklaması")]
        public string RAciklama { get; set; }

    }
}