using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Paup_StudentskaMenza.Models
{
    public class KorisnikPrijava
    {
        [Display(Name = "korisnicko ime")]
        [Required]
        public string KorisnickIme { get; set; }
        [Display(Name = "Lozinka")]
        [Required]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
    }
}