using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace E_Ticaret.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Categories.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriSil(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Categories.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(Category k)
        {
            var ktgr = c.Categories.Find(k.CategoryID);
            ktgr.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme ()
        {
            Class2 cs = new Class2();
            cs.Kategoriler = new SelectList(c.Categories, "CategoryID", "CategoryName");
            cs.Urunler = new SelectList(c.Products, "ProductID", "ProductName");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urun = (from x in c.Products

                        join y in c.Categories

                        on x.Category.CategoryID equals y.CategoryID
                        where x.Category.CategoryID == p
                        select new
                        {
                            Text = x.ProductName,
                            Value = x.ProductID.ToString()

                        }).ToList();

            return Json(urun, JsonRequestBehavior.AllowGet);
        }
            
    }
}