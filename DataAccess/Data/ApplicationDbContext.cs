using Microsoft.EntityFrameworkCore;
using System;

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
            #region Set max lengths and default values

            /*Item - Set max length for Name property*/
            modelBuilder.Entity<Items>()
                .Property(p => p.Name)
                .HasMaxLength(100);

            /*Types - Set max length for Name property*/
            modelBuilder.Entity<Types>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            /*Properties - Set max length for Name property*/
            modelBuilder.Entity<Properties>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            /*ItemPhotos - Set max length for FileName and Alt properties.
                           Set IsActive default value as "true" */
            modelBuilder.Entity<ItemPhotos>()
                .Property(p => p.FileName)
                .HasMaxLength(50);

            modelBuilder.Entity<ItemPhotos>()
                .Property(p => p.Alt)
                .HasMaxLength(500);

            modelBuilder.Entity<ItemPhotos>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            /*ItemPhotoPropertySet - Set max length for Value property*/
            modelBuilder.Entity<ItemPhotoPropertySet>()
                .Property(p => p.Value)
                .HasMaxLength(50);

            #endregion

            #region Populate database

            modelBuilder.Entity<Items>()
                .HasData(
                    new Items { Name = "Engagment ring" },
                    new Items { Name = "Wedding ring" }
                );

            modelBuilder.Entity<Types>()
                .HasData(
                    new Types { Name = "Photo" },
                    new Types { Name = "Thumb" }
                );

            modelBuilder.Entity<Properties>()
                .HasData(
                    new Properties { Name = "Metal" },
                    new Properties { Name = "Shape" }
                );

            modelBuilder.Entity<TypePropertySet>()
                .HasData(
                    new TypePropertySet { MediaTypeId = 1, PropertyId = 1},
                    new TypePropertySet { MediaTypeId = 1, PropertyId = 2},
                    new TypePropertySet { MediaTypeId = 2, PropertyId = 1 },
                    new TypePropertySet { MediaTypeId = 2, PropertyId = 2 }
                );

            modelBuilder.Entity<ItemPhotos>()
                .HasData(
                    new ItemPhotos { ItemId = 1, TypeId = 1, FileName = "Photo1.jpg", Position = 1, CreatedAt = DateTime.Now, IsActive = true },
                    new ItemPhotos { ItemId = 1, TypeId = 1, FileName = "Photo2.jpg", Position = 2, CreatedAt = DateTime.Now, IsActive = true },
                    new ItemPhotos { ItemId = 1, TypeId = 2, FileName = "Thumb1.jpg", Position = 1, CreatedAt = DateTime.Now, IsActive = true },
                    new ItemPhotos { ItemId = 1, TypeId = 2, FileName = "Thumb2.jpg", Position = 2, CreatedAt = DateTime.Now, IsActive = true }
                );

            modelBuilder.Entity<ItemPhotoPropertySet>()
                .HasData(
                    new ItemPhotoPropertySet { ItemPhotoId = 1, PropertyId = 1, Value = "Yellow Gold"},
                    new ItemPhotoPropertySet { ItemPhotoId = 1, PropertyId = 2, Value = "Round" },
                    new ItemPhotoPropertySet { ItemPhotoId = 2, PropertyId = 1, Value = "Yellow Gold" },
                    new ItemPhotoPropertySet { ItemPhotoId = 2, PropertyId = 2, Value = "Cushion" },
                    new ItemPhotoPropertySet { ItemPhotoId = 3, PropertyId = 1, Value = "Rose Gold" },
                    new ItemPhotoPropertySet { ItemPhotoId = 3, PropertyId = 2, Value = "Round" },
                    new ItemPhotoPropertySet { ItemPhotoId = 4, PropertyId = 1, Value = "Rose Gold" },
                    new ItemPhotoPropertySet { ItemPhotoId = 4, PropertyId = 2, Value = "Cushion" }
                );

            #endregion

        }
    }
}