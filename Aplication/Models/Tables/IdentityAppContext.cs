using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class IdentityAppContext : DbContext
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
        {
        }

      

    }
}
