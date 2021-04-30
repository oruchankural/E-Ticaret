using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context c = new Context();
        public ActionResult Index()
        {
            var degeler = c.Sales.ToList();
            return View(degeler);
        }
        [HttpGet]
        public ActionResult YeniSatis(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductID.ToString()
                                          }).ToList();
            List<SelectListItem> deger2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName+" "+x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName+" "+x.StaffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;
            var deger4 = c.Products.Find(id);
            ViewBag.dgr4 = deger4.SalePrice;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Sale s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Sales.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;

            var deger = c.Sales.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(Sale p)
        {
            var deger = c.Sales.Find(p.SalesID);
            deger.Customerid = p.Customerid;
            deger.Amount = p.Amount;
            deger.Price = p.Price;
            deger.Staffid = p.Staffid;
            deger.Date = p.Date;
            deger.Total = p.Total;
            deger.Productid = p.Productid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.Sales.Where(x => x.SalesID == id).ToList();
            return View(degerler);
        }
        public ActionResult Mehmet()
        {
            return View();
        }
    }
}