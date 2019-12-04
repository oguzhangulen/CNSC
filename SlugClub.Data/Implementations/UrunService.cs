using SlugClub.Data.Context;
using SlugClub.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Data.Implementations
{
    public class UrunService
    {
        public bool Ekle(Urun urun)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    urun.Durum = true;
                    context.Urun.Add(urun);
                    if (context.SaveChanges() > 0)
                        return false;
                    else
                        return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        public bool Update(Urun urun)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    urun.Durum = false;
                    context.Entry(urun).State = EntityState.Modified;
                    if (context.SaveChanges() > 0)
                        return false;
                    else
                        return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        public List<Urun> YakindakileriGetir(string username)
        {
            var context = new CodeNightContext();
            try
            {
                var asd = context.Kullanici.Where(s => s.KullaniciAdi == username).FirstOrDefault();
                var tempList = context.Urun.Where(s => s.Latitude >= asd.Latitude - 3 && s.Latitude <= asd.Latitude + 3 && s.Longitude >= asd.Longitude - 3 && s.Longitude <= asd.Longitude + 3).ToList();
                //var tempList = context.Database.SqlQuery<Urun>("exec sp_YakinUrunListele @Latitude @Longitude",asd.Latitude,asd.Longitude).ToList();
                return tempList.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public List<Urun> GetAll()
        {
            var context = new CodeNightContext();
            try
            {
                var tempList = context.Database.SqlQuery<Urun>("SELECT * FROM vw_SatistakiUrunler").ToList();
                return tempList.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public List<Urun> SattigimUrun(string username)
        {
            var context = new CodeNightContext();
            try
            {
                var kullaniciId = context.Kullanici.Where(s => s.KullaniciAdi == username).FirstOrDefault().Id;
                var tempList = context.Urun.Where(s => s.KullaniciId == kullaniciId && s.Durum == true).ToList();
                //var tempList = context.Database.SqlQuery<Urun>("exec sp_SattigimUrunleriListele @'username'", username).ToList();
                return tempList.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
