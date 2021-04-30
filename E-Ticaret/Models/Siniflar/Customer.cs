using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En Fazla 30 Karakter Kullanabilirsiniz")]
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        public string CustomerSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CustomerCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustoemrMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CustomerSifre { get; set; }
        public bool Durum { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}