using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.Siniflar;

namespace E_Ticaret.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Bills.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Bill f)
        {
            c.Bills.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Bills.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Bill b)
        {
            var bill = c.Bills.Find(b.BillID);
            bill.BillSerialnumber = b.BillSerialnumber;
            bill.BillRownumber = b.BillRownumber;
            bill.BillDate = b.BillDate;
            bill.Time = b.Time;
            bill.Delivery = b.Delivery;
            bill.DeliveryArea = b.DeliveryArea;
            bill.Tax = b.Tax;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult FaturaDetay(int id)
        {
        
            var degerler = c.BillPens.Where(x => x.Billid == id).ToList();
          
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(BillPen p)
        {
            c.BillPens.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class3 cs = new Class3();
            cs.deger1 = c.Bills.ToList();
            cs.deger2 = c.BillPens.ToList();
            return View(cs);
        }

        public ActionResult FaturaKaydet (string BillRownumber , string BillSerialnumber , DateTime BillDate , string Tax , string Time , string Delivery , string DeliveryArea ,string ToplamTutar , BillPen [] kalemler)
        {
            Bill b = new Bill();
            b.BillSerialnumber = BillSerialnumber;
            b.BillRownumber = BillRownumber;
            b.BillDate = BillDate;
            b.Tax = Tax;
            b.Time = Time;
            b.Delivery = Delivery;
            b.DeliveryArea = DeliveryArea;
            b.ToplamTutar = decimal.Parse(ToplamTutar);
            c.Bills.Add(b);
            foreach(var x in kalemler )
            {
                BillPen bp = new BillPen();
                bp.BillPenExp = x.BillPenExp;
                bp.AmountPrice = x.AmountPrice;
                bp.Billid = x.Billid;
                bp.Amount = x.Amount;
                bp.Total = x.Total;
                c.BillPens.Add(bp);
            }
    
            c.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);


        }
    }
}