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
    public class MesajService
    {
        public bool Ekle(Mesaj mesaj)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    mesaj.GondermeZamani = DateTime.Now;
                    context.Mesaj.Add(mesaj);
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
        public bool Delete(Mesaj mesaj)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    context.Database.SqlQuery<Mesaj>("exec sp_MesajSil @GonderenId @AlanId @UrunId", mesaj.GonderenId, mesaj.AlanId, mesaj.Urun.Id).ToList();
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
        public List<Mesaj> GetAll(Kullanici kullanici)
        {
            var context = new CodeNightContext();
            try
            {
                var tempList = context.Database.SqlQuery<Mesaj>("exec sp_MesajGoruntule @KullaniciId",kullanici.Id).ToList();
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
