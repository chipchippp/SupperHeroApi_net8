using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi_net8.Entities;
using SuperHeroApi_net8.Entity;

namespace SuperHeroApi_net8.Data
{
    public class SuperHeroApi_net8Context : DbContext
    {
        public SuperHeroApi_net8Context (DbContextOptions<SuperHeroApi_net8Context> options)
            : base(options)
        {
        }

        public DbSet<SuperHeroApi_net8.Entities.SuperHero> SuperHero { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Employee> Employee { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Student> Student { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Users> Users { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Crud> Crud { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Category> Category { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Enrollment> Enrollment { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Department> Department { get; set; } = default!;
        public DbSet<SuperHeroApi_net8.Entity.Course> Course { get; set; } = default!;

        public DbSet<SuperHeroApi_net8.Entity.Shops> Shops { get; set; } = default!;


    }
}
