using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Models.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public int? KategoriId { get; set; }
        [Required]
        public string UrunAdi { get; set; }
        [Required]
        public decimal Fiyat { get; set; }
        public bool Durum { get; set; }
        public int KullaniciId { get; set; }
        public string Aciklama { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
