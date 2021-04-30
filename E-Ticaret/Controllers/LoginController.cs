using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Customer p)
        {
            c.Customers.Add(p);
            c.SaveChanges();
            return PartialView();

        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Customer ca)
        {
            var bilgiler = c.Customers.FirstOrDefault(x => x.CustoemrMail == ca.CustoemrMail && x.CustomerSifre == ca.CustomerSifre);
                if (bilgiler != null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CustoemrMail, false);
                Session["CustoemrMail"] = bilgiler.CustoemrMail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
                else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if(bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Username, false);
                Session["Username"] = bilgiler.Username.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

          
        }


     
    }
}