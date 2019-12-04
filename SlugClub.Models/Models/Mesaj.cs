using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Models.Models
{
    public class Mesaj
    {
        public int Id { get; set; }
        public Kullanici GonderenId { get; set; }
        public Kullanici AlanId { get; set; }
        public string Message { get; set; }
        public Urun Urun { get; set; }
        public DateTime GondermeZamani { get; set; }
    }
}
