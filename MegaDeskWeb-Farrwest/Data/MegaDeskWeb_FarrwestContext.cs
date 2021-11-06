using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_Farrwest.Model;

namespace MegaDeskWeb_Farrwest.Data
{
    public class MegaDeskWeb_FarrwestContext : DbContext
    {
        public MegaDeskWeb_FarrwestContext (DbContextOptions<MegaDeskWeb_FarrwestContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWeb_Farrwest.Model.Quote> Quote { get; set; }
    }
}
