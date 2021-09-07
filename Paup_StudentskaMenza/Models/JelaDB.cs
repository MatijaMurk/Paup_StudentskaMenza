using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paup_StudentskaMenza.Models
{
    public class JelaDB
    {
        private static List<Jela> lista = new List<Jela>();
        private static bool listaInicijalizirana = false;

        public List<Jela> VratiListu()
        {
            return lista;
        }

        public void AzurirajJelo(Jela jelo)
        {
            //Pronalazimo lokaciju studenta u listi
            int jeloIndex = lista.FindIndex(x => x.Id == jelo.Id);
            //Na tu lokaciju u listi stavljamo ažurirani objekt s podacima o studentu
            lista[jeloIndex] = jelo;
        }
    }
}