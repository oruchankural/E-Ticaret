using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Gönderen { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alıcı { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Mesaj { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }


    }
}