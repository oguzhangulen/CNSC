using SlugClub.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugClub.Data.Context
{
    public class CodeNightContext:DbContext
    {
        public CodeNightContext():base("name=CodeNightContext")
        {

        }
        public DbSet<Favori> Favori { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Mesaj> Mesaj { get; set; }
        public DbSet<SatinAlma> SatinAlma { get; set; }
        public DbSet<Urun> Urun { get; set; }
    }
}
