using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Models.Models
{
    public class Favori
    {
        public int Id { get; set; }
        public Kullanici Kullanici { get; set; }
        public Urun Urun { get; set; }
    }
}
