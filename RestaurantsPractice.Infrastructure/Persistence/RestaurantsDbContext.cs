using Microsoft.EntityFrameworkCore;
using RestaurantsPractice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsPractice.Infrastructure.Persistence;

// primary constructor
internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address); // Entity Framework now thinks Address does not need PK. It belongs to Restaurant.

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes) // one to many relationship
            .WithOne() // one restaurant
            .HasForeignKey(d => d.RestaurantId);
    }
}
