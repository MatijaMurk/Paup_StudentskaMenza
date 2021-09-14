using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Paup_StudentskaMenza.Models
{
    
    public class Meni
    {
        
        [Key]
        [Display(Name = "ID jela")] //Sadržaj HTML helpera Label
        public int Id { get; set; }


        [Column("danSifra")]
        [Display(Name = "Dan")]
        public string dan { get; set; }

        [Display(Name = "Jelo")]
        [Column("idjelo")]
        [ForeignKey("idjela")]
        public string idjelo { get; set; }
        public virtual Jela jelo { get; set; }

      
    }
}