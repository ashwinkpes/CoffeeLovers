﻿// <auto-generated />
using System;
using CoffeeLovers.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeLovers.DAL.Migrations
{
    [DbContext(typeof(CoffeeDbContext))]
    partial class CoffeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Area", b =>
                {
                    b.Property<Guid>("AreaId");

                    b.Property<string>("AreaDisplayId")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<int>("PinCode");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.HasKey("AreaId");

                    b.ToTable("Area","dbo");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.AreaOwner", b =>
                {
                    b.Property<Guid>("AreaOwnerId");

                    b.Property<Guid>("AreaId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("OwnerId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.Property<DateTime>("validFrom");

                    b.Property<DateTime>("validTo");

                    b.HasKey("AreaOwnerId");

                    b.HasIndex("AreaId");

                    b.HasIndex("OwnerId");

                    b.ToTable("AreaOwner","dbo");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Coffee", b =>
                {
                    b.Property<Guid>("CoffeeId");

                    b.Property<string>("CoffeeDisplayId")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("CoffeeName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<decimal>("Price");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.Property<DateTime>("validFrom");

                    b.Property<DateTime>("validTo");

                    b.HasKey("CoffeeId");

                    b.ToTable("Coffee","dbo");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.CoffeeArea", b =>
                {
                    b.Property<Guid>("CoffeeAreaId");

                    b.Property<Guid>("AreaId");

                    b.Property<string>("CoffeeAreaDisplayId")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<Guid>("CoffeeId");

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

                    b.HasIndex("AreaId");

                    b.HasIndex("CoffeeId");

                    b.ToTable("CoffeeAreas","dbo");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Owner", b =>
                {
                    b.Property<Guid>("OwnerId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("OwnerDisplayId")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<Guid>("RoleId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.HasKey("OwnerId");

                    b.HasIndex("RoleId");

                    b.ToTable("Owner","dbo");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Createdtime");

                    b.Property<bool>("IsActive");

                    b.Property<string>("RoleDisplayId")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("Updatedtime");

                    b.Property<DateTime>("validFrom");

                    b.Property<DateTime>("validTo");

                    b.HasKey("RoleId");

                    b.ToTable("Role","dbo");
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.AreaOwner", b =>
                {
                    b.HasOne("CoffeeLovers.DomainModels.Models.Area", "Area")
                        .WithMany("AreaOwners")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoffeeLovers.DomainModels.Models.Owner", "Owner")
                        .WithMany("AreaOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.CoffeeArea", b =>
                {
                    b.HasOne("CoffeeLovers.DomainModels.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoffeeLovers.DomainModels.Models.Coffee", "Coffee")
                        .WithMany("CoffeeAreas")
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoffeeLovers.DomainModels.Models.Owner", b =>
                {
                    b.HasOne("CoffeeLovers.DomainModels.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
