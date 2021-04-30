using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CustoemrMail"];
            var degers = c.Mesajlars.Where(x => x.Alıcı == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Customers.Where(x => x.CustoemrMail == mail).Select(y => y.CustomerID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplam = c.Sales.Where(x => x.Customerid == mailid).Count();
            ViewBag.tp = toplam;
            var toplamtutar = c.Sales.Where(x => x.Customerid == mailid).Sum(y => y.Total);
            ViewBag.total = toplamtutar;
            var totalurun = c.Sales.Where(x => x.Customerid == mailid).Sum(y => y.Amount);
            ViewBag.uruns = totalurun;
            var adsoyad = c.Customers.Where(x => x.CustoemrMail == mail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View(degers);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CustoemrMail"];
            var id = c.Customers.Where(x => x.CustoemrMail == mail.ToString()).Select(y => y.CustomerID).FirstOrDefault();
            var degerler = c.Sales.Where(x => x.Customerid == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CustoemrMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alıcı == mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelen = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelen;
            var giden = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = giden;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CustoemrMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gönderen == mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelen = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelen;
            var giden = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = giden;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CustoemrMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alıcı == mail).ToList();
            var gelen = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelen;
            var giden = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = giden;
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CustoemrMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alıcı == mail).ToList();
            var gelen = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelen;
            var giden = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = giden;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CustoemrMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderen = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip (string p )
        {
            var kargo = from x in c.KargoDetays select x;
                kargo = kargo.Where(y => y.Takipkodu.Contains(p));
    
            return View(kargo.ToList());
        }

        public ActionResult CariKargoTakip (string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut ()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Settings ()
        {
            var mail = (string)Session["CustoemrMail"];
            var id = c.Customers.Where(x => x.CustoemrMail == mail).Select(y => y.CustomerID).FirstOrDefault();
            var usersetting = c.Customers.Find(id);
            return PartialView("Settings",usersetting);
        }
        public PartialViewResult Duyuru()
        {
            var veri = c.Mesajlars.Where(x => x.Gönderen == "admin").ToList();
            return PartialView(veri);
        }

        public ActionResult CustomerGuncelle (Customer cr)
        {
            var cari = c.Customers.Find(cr.CustomerID);
            cari.CustomerName = cr.CustomerName;
            cari.CustomerSurname = cr.CustomerSurname;
            cari.CustoemrMail = cr.CustoemrMail;
            cari.CustomerSifre = cr.CustomerSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}