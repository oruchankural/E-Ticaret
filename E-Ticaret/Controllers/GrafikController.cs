using E_Ticaret.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_Ticaret.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
                grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler",
                xValue: new[] { "Logo", "Web", "SEO" }, yValues: new[] { 85, 65, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800).AddTitle("Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Inde4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List <sinif1> Urunlistesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                Urunad = "SEO",
                Stok = 120
            });
            snf.Add(new sinif1() {
                Urunad="Web",
                Stok=18
            });
            snf.Add(new sinif1()
            {
                Urunad = "Logo",
                Stok = 104
            });
            snf.Add(new sinif1()
            {
                Urunad = "Wordpress",
                Stok = 157
            });
            snf.Add(new sinif1()
            {
                Urunad = "Kurumsal Kimlik",
                Stok = 100
            });
            return snf;
        }
        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using (var context=new Context ())
            {
                snf = c.Products.Select(x => new sinif2
                {
                    urunad = x.ProductName,
                    stok = x.Stok
                }).ToList();
            }
            return snf;
        }

        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}