using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace project4.Models
{
    public class DiscContext : DbContext
    {
        public DbSet<Disc> Discs{ get; set; }
        public DbSet<Artist> Artists{ get; set; }

        public DiscContext(DbContextOptions<DiscContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
