using Newtonsoft.Json;
using SlugClub.Data.Implementations;
using SlugClub.Models.Models;
using SlugClub.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SlugClub.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel customer, string ReturnUrl = "")
        {
            KullaniciService _getService = new KullaniciService();
            var UserExist = _getService.GetAll().Where(s => s.KullaniciAdi == customer.KullaniciAdi).FirstOrDefault();
            if (UserExist != null)
            {
                if (ModelState.IsValid)
                {
                    //TODO : Kontrol Et 
                    if (string.Compare((customer.Password), UserExist.Sifre) == 0)
                    {
                        string userjson = JsonConvert.SerializeObject(UserExist);
                        if (!string.IsNullOrEmpty(ReturnUrl))
                            return Redirect(ReturnUrl);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1, UserExist.KullaniciAdi, DateTime.Now, DateTime.Now.AddMinutes(30), false, userjson
                            );
                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("PortalCookie", enTicket);
                        Response.Cookies.Add(faCookie);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            KullaniciService kullaniciService = new KullaniciService();
                            customer.Latitude= customer.Latitude.Replace('.', ',');
                            customer.Longitude = customer.Longitude.Replace('.', ',');
                            UserExist.Latitude = Convert.ToDecimal(customer.Latitude);
                            UserExist.Longitude = Convert.ToDecimal(customer.Longitude);
                            kullaniciService.Update(UserExist);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                        return View(customer);
                    }
                }
            }
            ModelState.AddModelError("", "Kullanıcı adı veya Şifre Hatalı");
            return View(customer);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            foreach (var cookie in Request.Cookies.AllKeys)
            {
                Request.Cookies.Remove(cookie);
            }
            if (Request.Cookies["PortalCookie"] != null)
            {
                var c = new HttpCookie("PortalCookie");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Kullanici user)
        {
            if (ModelState.IsValid)
            {
                KullaniciService kullaniciService = new KullaniciService();
                Kullanici kullanici = new Kullanici();
                kullanici.FullName = user.FullName;
                kullanici.KullaniciAdi = user.KullaniciAdi;
                kullanici.Sifre = user.Sifre;
                kullanici.Adres = user.Adres;
                if (kullaniciService.Ekle(kullanici) == false)
                {
                    ModelState.AddModelError("", "Bu kullanici adı kullanılmaktadır..");
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Login", user);
                }
            }
            else
            {
                ModelState.AddModelError("", "Alanlar boş geçilemez");
                return View(user);
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
    }
}