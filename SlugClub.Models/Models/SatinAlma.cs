using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Models.Models
{
    public class SatinAlma
    {
        public int Id { get; set; }
        public int urunId { get; set; }
        public string UrunAdi { get; set; }
        public int KullaniciId { get; set; }
        public DateTime Tarih { get; set; }
    }
}
