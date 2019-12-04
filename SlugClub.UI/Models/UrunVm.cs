using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SlugClub.UI.Models
{
    public class UrunVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen bu alanı boş bırakmayınız..")]
        public string KategoriAdi { get; set; }
        [Required(ErrorMessage = "Lütfen bu alanı boş bırakmayınız..")]
        public string UrunAdi { get; set; }
        [Required(ErrorMessage = "Lütfen bu alanı boş bırakmayınız..")]
        public decimal Fiyat { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
    }
}