using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Models.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Kullanici Adi en az 5 karakterden oluşmalıdır."), MaxLength(20, ErrorMessage = "Kullanıcı Adı en fazla 20 karakterden oluşmalıdır.")]
        public string KullaniciAdi { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Adınız en fazla 30 karakterden oluşmalıdır.")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public string Adres { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
