﻿using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Paup_StudentskaMenza.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BazaDbContext : DbContext
    {
        public DbSet<Jela> PopisJela { get; set; }
        public DbSet<Meni> PopisMeni { get; set; }
        public DbSet<Korisnik> PopisKorisnika { get; set; }
        public DbSet<Ovlast> PopisOvlasti { get; set; }
    }
}