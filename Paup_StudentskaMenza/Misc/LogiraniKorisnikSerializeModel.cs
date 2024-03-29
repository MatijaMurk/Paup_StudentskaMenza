﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Paup_StudentskaMenza.Misc
{
    public class LogiraniKorisnikSerializeModel
    {
        public string KorisnickoIme { get; set; }
        public string PrezimeIme { get; set; }
        public string Email { get; set; }
        public string Ovlast { get; set; }

        public void CopyFromUser(LogiraniKorisnik user)
        {
            this.KorisnickoIme = user.KorisnickoIme;
            this.PrezimeIme = user.PrezimeIme;
            this.Email = user.Email;
            this.Ovlast = user.Ovlast;
        }
    }
}