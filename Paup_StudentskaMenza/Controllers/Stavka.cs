using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Paup_StudentskaMenza.Models;

namespace Paup_StudentskaMenza.Controllers
{
    public class Stavka
    {
        private Jela jelo = new Jela();
        private int kolicina;

        public Stavka(Jela jelo,int kolicina)
        {
            this.Jelo = jelo;
            this.Kolicina = kolicina;
        }

        public Jela Jelo { get => jelo; set => jelo = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
    }
}