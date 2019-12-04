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
    public class KullaniciService
    {
        public bool Ekle(Kullanici kullanici)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    if (context.Kullanici.Where(s => s.KullaniciAdi == kullanici.KullaniciAdi).ToList().Count() > 0)
                        return false;
                    else
                        context.Kullanici.Add(kullanici);
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
        public bool Update(Kullanici kullanici)
        {
            var context = new CodeNightContext();
            try
            {
                foreach (var item in context.Kullanici.Where(s=>s.KullaniciAdi==kullanici.KullaniciAdi).ToList())
                {
                    item.Latitude = kullanici.Latitude;
                    item.Longitude = kullanici.Longitude;
                }
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
        public bool Delete(Kullanici kullanici)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    context.Entry(kullanici).State = EntityState.Deleted;
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
        public List<Kullanici> GetAll()
        {
            var context = new CodeNightContext();
            try
            {
                var tempList = context.Database.SqlQuery<Kullanici>("Select * from Kullanicis").ToList();
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
