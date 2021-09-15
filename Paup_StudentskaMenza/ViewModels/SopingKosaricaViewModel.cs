using Paup_StudentskaMenza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paup_StudentskaMenza.ViewModels
{
    public class SopingKosaricaViewModel
    {
        public List<Kosarica> CartItems { get; set; }
        public decimal KosaricaUkupno { get; set; }
    }
}