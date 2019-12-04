using SlugClub.Data.Implementations;
using SlugClub.Models.Models;
using SlugClub.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlugClub.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UrunService urunService = new UrunService();
            var urunList = urunService.YakindakileriGetir(HttpContext.User.Identity.Name).ToList();
            return View(urunList.ToList());
        }
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UrunEkle(UrunVm urunvm)
        {
            if (ModelState.IsValid)
            {
                KullaniciService kullaniciService = new KullaniciService();
                UrunService urunService = new UrunService();
                Urun urun = new Urun();
                urun.Fiyat = urunvm.Fiyat;
                urun.Aciklama = urunvm.Aciklama;
                urun.UrunAdi = urunvm.UrunAdi;
                KategoriService kategoriService = new KategoriService();
                urun.KategoriId = kategoriService.GetAll().Where(s => s.KategoriAdi == urunvm.KategoriAdi).FirstOrDefault().Id;
                var user = kullaniciService.GetAll().Where(s => s.KullaniciAdi == HttpContext.User.Identity.Name).FirstOrDefault();
                urun.Latitude = user.Latitude;
                urun.Longitude = user.Longitude;
                urun.KullaniciId = kullaniciService.GetAll().Where(s => s.KullaniciAdi == HttpContext.User.Identity.Name).FirstOrDefault().Id;
                urunService.Ekle(urun);
                return RedirectToAction("Urunlerim");
            }
            return View(urunvm);
        }
        public ActionResult Urunlerim()
        {
            string username = HttpContext.User.Identity.Name;
            UrunService urunService = new UrunService();
            var urunList = urunService.SattigimUrun(username).ToList();
            return View(urunList);
        }
        public ActionResult SatinAl(Urun urun)
        {
            if (ModelState.IsValid)
            {
                SatinAlmaService satinAlmaService = new SatinAlmaService();
                SatinAlma satinAlma = new SatinAlma();
                KullaniciService kullaniciService = new KullaniciService();
                satinAlma.KullaniciId = urun.KullaniciId;
                satinAlma.UrunAdi = urun.UrunAdi;
                satinAlma.urunId = urun.Id;
                satinAlma.Tarih = DateTime.Now;
                satinAlmaService.Ekle(satinAlma);
                return RedirectToAction("SatinAlinan");
            }
            else
                return RedirectToAction("Index");
        }
        public ActionResult SatinAlinan()
        {
            SatinAlmaService satinAlmaService = new SatinAlmaService();
            KullaniciService kullaniciService = new KullaniciService();
            var kullaniciId = kullaniciService.GetAll().Where(s => s.KullaniciAdi == HttpContext.User.Identity.Name).FirstOrDefault().Id;
            var tempList=satinAlmaService.GetAll().Where(s => s.KullaniciId==kullaniciId).ToList();
            return View(tempList.ToList());
        }
    }
}