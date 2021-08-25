using System;

namespace Paup_StudentskaMenza.Controllers
{
    internal class FormAuthenticationTicket
    {
        public FormAuthenticationTicket(int v1, string name, DateTime now, DateTime dateTime, bool v2, string korisnickiPodaci)
        {
            V1 = v1;
            Name = name;
            Now = now;
            DateTime = dateTime;
            V2 = v2;
            KorisnickiPodaci = korisnickiPodaci;
        }

        public int V1 { get; }
        public string Name { get; }
        public DateTime Now { get; }
        public DateTime DateTime { get; }
        public bool V2 { get; }
        public string KorisnickiPodaci { get; }
    }
}