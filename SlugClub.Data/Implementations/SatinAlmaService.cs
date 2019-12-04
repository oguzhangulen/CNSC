using SlugClub.Data.Context;
using SlugClub.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Data.Implementations
{
    public class SatinAlmaService
    {
        public bool Ekle(SatinAlma satinAlma)
        {
            using (var context = new CodeNightContext())
            {
                try
                {
                    context.SatinAlma.Add(satinAlma);
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
        public List<SatinAlma> GetAll()
        {
            var context = new CodeNightContext();
            try
            {
                var tempList = context.SatinAlma.ToList();
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
