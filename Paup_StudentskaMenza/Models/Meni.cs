using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Paup_StudentskaMenza.Models
{
    [Table("meni")]
    public class Meni
    {
        
        [Key]
        [Column("idmeni")]
        [Display(Name = "ID jela")] //Sadržaj HTML helpera Label
        public int Idmeni { get; set; }


        [Column("danSifra")]
        [Display(Name = "Dan")]
        [Range(1, 7, ErrorMessage = "Vrijednost {0} mora biti između {1} i {2}")]
        public Dani dan { get; set; }

        
        [Column("idjelo")]
        [Display(Name = "Jelo")]
        [ForeignKey("NazivJelo")]
        public int idjelo { get; set; }
        public virtual Jela NazivJelo { get; set; }

      
    }
}