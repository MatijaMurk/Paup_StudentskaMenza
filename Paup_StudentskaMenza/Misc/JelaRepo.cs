using Paup_StudentskaMenza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paup_StudentskaMenza.Misc
{
    public class JelaRepo
    {
        private BazaDbContext bazapodaci;
        public JelaRepo()
        {
            bazapodaci = new BazaDbContext();
        }

        public IEnumerable<SelectListItem> SvaJela()
        {
            var jelaList = new List<SelectListItem>();

            jelaList = (from jela in bazapodaci.Jelo
                        select new SelectListItem()
                        {
                            Text = jela.Naziv,
                            Value = jela.Id.ToString(),
                            Selected= false
                        }).ToList();

            return jelaList;
        }
    }
}