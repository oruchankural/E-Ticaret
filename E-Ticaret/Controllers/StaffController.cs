using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context c = new Context();
        public ActionResult Index()
        {
            var degeler = c.Staffs.ToList();
            return View(degeler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Staff s)
        {
            if(Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                s.StaffImage = "/Image/" + dosyaadi + uzanti;
            }
            c.Staffs.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Staffs.Find(id);
                return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Staff p )
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.StaffImage = "/Image/" + dosyaadi + uzanti;
            }
            var prsn = c.Staffs.Find(p.StaffID);
            prsn.StaffName = p.StaffName;
            prsn.StaffSurname = p.StaffSurname;
            prsn.StaffImage = p.StaffImage;
            prsn.Departmentid = p.Departmentid;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult PersonalList()
        {
            var sorgu = c.Staffs.ToList();
            return View(sorgu);
        }
    }
}