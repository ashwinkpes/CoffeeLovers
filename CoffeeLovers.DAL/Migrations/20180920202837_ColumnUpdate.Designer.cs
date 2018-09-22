﻿// <auto-generated />
using System;
using CoffeeLovers.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeLovers.DAL.Migrations
{
    [DbContext(typeof(CoffeeDbContext))]
    [Migration("20180920202837_ColumnUpdate")]
    partial class ColumnUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Area", b =>
                {
                    b.Property<Guid>("AreaId");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<int>("PinCode")
                        .HasMaxLength(6);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.HasKey("AreaId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.AreaOwner", b =>
                {
                    b.Property<Guid>("AreaOwnerId");

                    b.Property<int>("AreaId");

                    b.Property<Guid>("AreaId1");

                    b.Property<Guid?>("CoffeeId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<int>("OwnerId");

                    b.Property<Guid>("OwnerId1");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.Property<DateTime>("validFrom");

                    b.Property<DateTime>("validTo");

                    b.HasKey("AreaOwnerId");

                    b.HasIndex("AreaId1");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("OwnerId1");

                    b.ToTable("AreaOwner");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Coffee", b =>
                {
                    b.Property<Guid>("CoffeeId");

                    b.Property<string>("CoffeeName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.Property<DateTime>("validFrom");

                    b.Property<DateTime>("validTo");

                    b.HasKey("CoffeeId");

                    b.ToTable("Coffee");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.CoffeeArea", b =>
                {
                    b.Property<Guid>("CoffeeAreaId");

                    b.Property<int>("AreaId");

                    b.Property<Guid?>("AreaId1");

                    b.Property<int>("CoffeeId");

                    b.Property<Guid>("CoffeeId1");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.Property<DateTime>("validFrom");

                    b.Property<DateTime>("validTo");

                    b.HasKey("CoffeeAreaId");

                    b.HasIndex("AreaId1");

                    b.HasIndex("CoffeeId1");

                    b.ToTable("CoffeeAreas");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Owner", b =>
                {
                    b.Property<Guid>("OwnerId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.HasKey("OwnerId");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.AreaOwner", b =>
                {
                    b.HasOne("CoffeeLovers.DomainModels.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoffeeLovers.DomainModels.Models.Coffee")
                        .WithMany("AreaOwners")
                        .HasForeignKey("CoffeeId");

                    b.HasOne("CoffeeLovers.DomainModels.Models.Owner", "Owner")
                        .WithMany("AreaOwners")
                        .HasForeignKey("OwnerId1")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.CoffeeArea", b =>
                {
                    b.HasOne("CoffeeLovers.DomainModels.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId1");

                    b.HasOne("CoffeeLovers.DomainModels.Models.Coffee", "Coffee")
                        .WithMany("CoffeeAreas")
                        .HasForeignKey("CoffeeId1")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}