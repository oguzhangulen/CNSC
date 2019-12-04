using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SlugClub.UI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz..")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        [MinLength(5, ErrorMessage = "Kullanici Adi en az 5 karakterden oluşmalıdır."), MaxLength(20, ErrorMessage = "Kullanıcı Adı en fazla 20 karakterden oluşmalıdır.")]
        public string KullaniciAdi { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}