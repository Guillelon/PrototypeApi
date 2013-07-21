using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrototypeApi.Models
{
    public class TeamDB : DbContext
    {
        public DbSet<Team> Teams { get; set; }
    }
}