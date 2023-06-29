using FakeXieCheng.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace FakeXieCheng.Database
{
    public class AppDbContext : DbContext
    {
      

        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=localhost;database=FakeXieCheng;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
