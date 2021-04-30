using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Customers.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Customer cu)
        {
            cu.Durum = true;
            c.Customers.Add(cu);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id )
        {
            var cr = c.Customers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir (int id)
        {
            var cari = c.Customers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Customer p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Customers.Find(p.CustomerID);
            cari.CustomerName = p.CustomerName;
            cari.CustomerSurname = p.CustomerSurname;
            cari.CustomerCity = p.CustomerCity;
            cari.CustoemrMail = p.CustoemrMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id )
        {
            var degerler = c.Sales.Where(x => x.Customerid == id).ToList();
            var cr = c.Customers.Where(x => x.CustomerID == id).Select(y => y.CustomerName + "" + y.CustomerSurname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}