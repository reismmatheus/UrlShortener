using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Repositories.Model;

namespace UrlShortener.Context
{
    public class ShortenerContext : DbContext
    {
        public ShortenerContext(DbContextOptions<ShortenerContext> options) : base(options) { }

        public DbSet<Shortener> Shorteners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shortener>(x => {
                x.HasIndex(y => y.Shortened).IsUnique();
            });
        }
    }
}
