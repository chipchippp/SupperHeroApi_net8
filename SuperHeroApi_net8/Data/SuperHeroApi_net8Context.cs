using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi_net8.Entities;

namespace SuperHeroApi_net8.Data
{
    public class SuperHeroApi_net8Context : DbContext
    {
        public SuperHeroApi_net8Context (DbContextOptions<SuperHeroApi_net8Context> options)
            : base(options)
        {
        }

        public DbSet<SuperHeroApi_net8.Entities.SuperHero> SuperHero { get; set; } = default!;
    }
}
