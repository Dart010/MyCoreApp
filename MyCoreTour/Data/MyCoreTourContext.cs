using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCoreTour.Models;

namespace MyCoreTour.Data
{
    public class MyCoreTourContext : DbContext
    {
        public MyCoreTourContext (DbContextOptions<MyCoreTourContext> options)
            : base(options)
        {
        }

        public DbSet<MyCoreTour.Models.Hero> Hero { get; set; }

        public DbSet<MyCoreTour.Models.Master> Master { get; set; }
    }
}
