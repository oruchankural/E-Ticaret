using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Urunad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string Urunbildi { get; set; }
    }
}