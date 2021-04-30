using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class Sale
    {
        [Key]
        public int SalesID { get; set; }
        //Prodcut
        //Customer
        //Staff
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Productid { get; set; }
        public int Customerid { get; set; }
        public int Staffid { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
    }
}