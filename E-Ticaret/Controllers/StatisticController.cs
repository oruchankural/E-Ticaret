using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Staffs.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Products.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Products select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Products.Count(x=>x.Stok<=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Products.Count(x => x.ProductName == "Kurumsal Web Tasarım").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Products.Count(x => x.ProductName == "Kişisel Web Sitesi").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Products.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.Products.Where(u => u.ProductID == (c.Sales.GroupBy(x => x.Productid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.Sales.Sum(x => x.Total).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.Sales.Count(x => x.Date ==bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.Sales.Where(x => x.Date == bugun).Sum(y => (decimal?) y.Total).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Customers
                        group x by x.CustomerCity into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()

                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Staffs
                         group x by x.Department.DepartmentName into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()

                         };
                       
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Customers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Products.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu4 = from x in c.Products
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()

                         };
            return PartialView(sorgu4.ToList());
        }
    }
}