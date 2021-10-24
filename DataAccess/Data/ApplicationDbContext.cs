using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Items> Items { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<TypePropertySet> TypePropertySets { get; set; }
        public DbSet<ItemPhotos> ItemPhotos { get; set; }
        public DbSet<ItemPhotoPropertySet> ItemPhotoPropertySets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPhotos>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);
        }
    }
}
