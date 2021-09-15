using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Paup_StudentskaMenza.Models
{

    [Table("detaljinarudzbe")]
    public class DetaljiNarudzbe
    {
        [Key]
        [Column("iddetalja")]
        [Display(Name = "ID narudžbe")]
        public int DetaljiNarudzbeId { get; set; }
        
        [Column("narudzbaid")]
        [Display(Name = "ID narudžbe")]
        [ForeignKey("Narudzba")]
        public int NarudzbaId { get; set; }
        public virtual Narudzba Narudzba { get; set; }
        
        [Column("jeloid")]
        [Display(Name = "ID jela")]
        [ForeignKey("Jelo")]
        public int JeloId { get; set; }
        public virtual Jela Jelo { get; set; }
        [Column("kolicina")]
        [Display(Name = "Kolicina")]
        public int Kolicina { get; set; }
        [Column("cijena")]
        [Display(Name = "Cijena")]
        public decimal Cijena { get; set; }
       
       
    }
}