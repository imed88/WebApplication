using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<doctors> doctors { get; set; }
        public DbSet<nurses> nurses { get; set; }
        public DbSet<patients> patients { get; set; }
        public DbSet<Admins> admins { get; set; }

    }
}
