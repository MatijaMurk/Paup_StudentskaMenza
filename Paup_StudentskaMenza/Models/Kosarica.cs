using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Paup_StudentskaMenza.Models
{
    [Table("kosarica")]
    public class Kosarica
    {
        [Key]
        [Column("stavkaid")]
        [Display(Name = "ID Stavke")]
        public int StavkaId { get; set; }

        [Column("kosaricaid")]
        [Display(Name = "ID kosarice")]
        public string KosaricaId { get; set; }
       
        [Column("jelo_id")]
        [Display(Name = "ID Jela")]
        [ForeignKey("Jelo")]
        public int JeloId { get; set; }
        public virtual Jela Jelo { get; set; }

        [Column("broj")]
        [Display(Name = "Broj")]
        public int Broj { get; set; }

        [Column("kreiranodatuma")]
        [Display(Name = "KreiranoDatuma")]
        public System.DateTime KreiranoDatuma { get; set; }
      
    }
}