using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillRownumber { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerialnumber { get; set; }
        public DateTime BillDate { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Tax { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivery { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryArea { get; set; }

        public decimal ToplamTutar { get; set; }

        public ICollection<BillPen> BillPens { get; set; }


    }
}