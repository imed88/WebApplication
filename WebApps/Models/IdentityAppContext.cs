using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Models
{
    public class IdentityAppContext : DbContext
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
        {
        }

        public DbSet<doctors> doctors { get; set; }
        public DbSet<nurses> nurses { get; set; }
        public DbSet<patients> patients { get; set; }
        public DbSet<Admins> admins { get; set; }

    }
}
