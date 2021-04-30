using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Siniflar
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffName { get; set; }
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffSurname { get; set; }
        [Display(Name = "Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string StaffImage { get; set; }
        public ICollection<Sale> Sale { get; set; }
        public int Departmentid { get; set; }
        [Display(Name = "Departman")]
        public virtual Department Department { get; set; }

    }
}