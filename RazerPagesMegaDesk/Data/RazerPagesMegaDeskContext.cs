using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazerPagesMegaDesk.Model;

namespace RazerPagesMegaDesk.Data
{
    public class RazerPagesMegaDeskContext : DbContext
    {
        public RazerPagesMegaDeskContext (DbContextOptions<RazerPagesMegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<Shipping> Shipping { get; set; }

        public DbSet<Desk> Desk { get; set; }

        public DbSet<DeskQuote> DeskQuote { get; set; }

        public DbSet<SurfaceMaterial> SurfaceMaterial { get; set; }
    }
}
