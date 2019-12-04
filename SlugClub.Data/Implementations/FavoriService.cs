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
    public class FavoriService
    {
        public bool Ekle(Favori favori)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    context.Favori.Add(favori);
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
        public bool Delete(Favori favori)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    context.Entry(favori).State = EntityState.Deleted;
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
        public List<Favori> GetAll(Kullanici kullanici)
        {
            var context = new CodeNightContext();
            try
            {
                var tempList = context.Database.SqlQuery<Favori>("exec KullaniciFAvori @KullaniciId",kullanici.Id);
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
