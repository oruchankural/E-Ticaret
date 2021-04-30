using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Products select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.ProductName.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList() select new SelectListItem {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()}).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Products.Find(id);
            deger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Products.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Product p)
        {
            var urn=c.Products.Find(p.ProductID);
            urn.PurchasePrice = p.PurchasePrice;
            urn.Status = p.Status;
            urn.CategoryID = p.CategoryID;
            urn.Marka = p.Marka;
            urn.SalePrice = p.SalePrice;
            urn.Stok = p.Stok;
            urn.ProductImage = p.ProductImage;
            urn.ProductName = p.ProductName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi ()
        {
            var degerler = c.Products.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Products.Find(id);
            ViewBag.dgr1 = deger1.ProductID;
            ViewBag.dgr2 = deger1.SalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(Sale p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Sales.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Sale");
        }
    }
}