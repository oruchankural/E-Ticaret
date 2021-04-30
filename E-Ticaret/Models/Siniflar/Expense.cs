using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Exp { get; set; }
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
    }
}