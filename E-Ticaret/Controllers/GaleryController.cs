using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        Context c = new Context();
        public ActionResult Index()
        {
            var degeler = c.Products.ToList();
            return View(degeler);
        }
    }
}