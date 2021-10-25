﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Data.ItemPhotoPropertySet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemPhotoId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ItemPhotoId");

                    b.HasIndex("PropertyId");

                    b.ToTable("ItemPhotoPropertySets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemPhotoId = 1,
                            PropertyId = 1,
                            Value = "Yellow Gold"
                        },
                        new
                        {
                            Id = 2,
                            ItemPhotoId = 1,
                            PropertyId = 2,
                            Value = "Round"
                        },
                        new
                        {
                            Id = 3,
                            ItemPhotoId = 2,
                            PropertyId = 1,
                            Value = "Yellow Gold"
                        },
                        new
                        {
                            Id = 4,
                            ItemPhotoId = 2,
                            PropertyId = 2,
                            Value = "Cushion"
                        },
                        new
                        {
                            Id = 5,
                            ItemPhotoId = 3,
                            PropertyId = 1,
                            Value = "Rose Gold"
                        },
                        new
                        {
                            Id = 6,
                            ItemPhotoId = 3,
                            PropertyId = 2,
                            Value = "Round"
                        },
                        new
                        {
                            Id = 7,
                            ItemPhotoId = 4,
                            PropertyId = 1,
                            Value = "Rose Gold"
                        },
                        new
                        {
                            Id = 8,
                            ItemPhotoId = 4,
                            PropertyId = 2,
                            Value = "Cushion"
                        });
                });

            modelBuilder.Entity("DataAccess.Data.ItemPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("TypeId");

                    b.ToTable("ItemPhotos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 10, 25, 10, 2, 29, 13, DateTimeKind.Local).AddTicks(1170),
                            FileName = "Photo1.jpg",
                            IsActive = true,
                            ItemId = 1,
                            Position = 1,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 10, 25, 10, 2, 29, 16, DateTimeKind.Local).AddTicks(2625),
                            FileName = "Photo2.jpg",
                            IsActive = true,
                            ItemId = 1,
                            Position = 2,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 10, 25, 10, 2, 29, 16, DateTimeKind.Local).AddTicks(2667),
                            FileName = "Thumb1.jpg",
                            IsActive = true,
                            ItemId = 1,
                            Position = 1,
                            TypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 10, 25, 10, 2, 29, 16, DateTimeKind.Local).AddTicks(2673),
                            FileName = "Thumb2.jpg",
                            IsActive = true,
                            ItemId = 1,
                            Position = 2,
                            TypeId = 2
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Engagment ring"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Wedding ring"
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Metal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shape"
                        });
                });

            modelBuilder.Entity("DataAccess.Data.TypePropertySet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MediaTypeId");

                    b.HasIndex("PropertyId");

                    b.ToTable("TypePropertySets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MediaTypeId = 1,
                            PropertyId = 1
                        },
                        new
                        {
                            Id = 2,
                            MediaTypeId = 1,
                            PropertyId = 2
                        },
                        new
                        {
                            Id = 3,
                            MediaTypeId = 2,
                            PropertyId = 1
                        },
                        new
                        {
                            Id = 4,
                            MediaTypeId = 2,
                            PropertyId = 2
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Types", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Photo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Thumb"
                        });
                });

            modelBuilder.Entity("DataAccess.Data.ItemPhotoPropertySet", b =>
                {
                    b.HasOne("DataAccess.Data.ItemPhotos", "ItemPhotos")
                        .WithMany()
                        .HasForeignKey("ItemPhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Properties", "Properties")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemPhotos");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("DataAccess.Data.ItemPhotos", b =>
                {
                    b.HasOne("DataAccess.Data.Items", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("DataAccess.Data.Types", "Types")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("DataAccess.Data.TypePropertySet", b =>
                {
                    b.HasOne("DataAccess.Data.Types", "Types")
                        .WithMany()
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Properties", "Properties")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Properties");

                    b.Navigation("Types");
                });
#pragma warning restore 612, 618
        }
    }
}
