using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class BillPen
    {
        [Key]
        public int BillPenID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string BillPenExp { get; set; }
        public int Amount { get; set; }
        public decimal AmountPrice { get; set; }
        public decimal Total { get; set; }
        public int Billid { get; set; }
        public virtual Bill Bill { get; set; }
    }
}