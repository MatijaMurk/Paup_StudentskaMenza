using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Paup_StudentskaMenza.Models
{
    [Table("jelo")]
    public class Meni
    {
        [Key]
        [Column("idjela")]
        [Display(Name = "ID jela")] //Sadržaj HTML helpera Label
        public int Id { get; set; }

        [Column("naziv")]
        [Display(Name = "Naziv")]
        [Required(ErrorMessage = "{0} je obavezno")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} mora biti duljine minimalno {2} a maksimalno {1} znakova")]
        public string Naziv { get; set; }

        [Column("opis")]
        [Display(Name = "Opis")]
        [Required(ErrorMessage = "{0} je obavezno")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} mora biti duljine minimalno {2} a maksimalno {1} znakova")]
        public string Opis { get; set; }

        [Column("cijena")]
        [Display(Name = "Cijena")]
        public int Cijena { get; set; }

        

        [Column("vegetarijansko")]
        [Display(Name = "Vegetarijansko")]
        public bool vege { get; set; }

      
    }
}
