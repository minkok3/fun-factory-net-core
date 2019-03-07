using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain;

namespace WebApp.Data
{
    public class FunFactoryDbContext : DbContext
    {
        public FunFactoryDbContext(DbContextOptions<FunFactoryDbContext> options)
            : base(options)
        { }

        public DbSet<Component> Products { get; set; }
        public DbSet<KitComponent> Components { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>().HasMany(c => c.KitComponents)
                                            .WithOne(k => k.Component);
            modelBuilder.Entity<KitComponent>().HasOne(c => c.Kit);
        }
    }
}
