using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = c.Departments.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Departmanekle(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(Department p)
        {
            var dpt = c.Departments.Find(p.DepartmentID);
            dpt.DepartmentName = p.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult  DepartmanDetay(int id)
        {
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            var degerler = c.Staffs.Where(x => x.Departmentid == id).ToList();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis (int id)
        {
            var degerler = c.Sales.Where(x => x.Staffid == id).ToList();
            var per = c.Staffs.Where(x => x.StaffID == id).Select(y => y.StaffName + " " + y.StaffSurname).FirstOrDefault();
            ViewBag.dper = per;
            return View(degerler);
        }
    }
}