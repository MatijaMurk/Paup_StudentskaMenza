using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Paup_StudentskaMenza.Models
{
    [Table("narudzba")]
    public class Narudzba
    {
        [Key]
        [Column("idnarudzbe")]
        [Display(Name = "ID narudžbe")]
        public int NarudzbaId { get; set; }


        [Column("korisnik")]
        [Display(Name = "Korisničko ime")]
        public string Korisnik { get; set; }


        [Column("ukupnacijena")]
        [Display(Name = "Ukupna Cijena")]
        public decimal Total { get; set; }

        [Column("datum")]
        [Display(Name = "Datum Narudzbe")]
        public System.DateTime DatumNarudzbe { get; set; }
        public List<DetaljiNarudzbe> OrderDetails { get; set; }
    }
}