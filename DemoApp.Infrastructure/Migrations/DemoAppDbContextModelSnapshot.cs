﻿// <auto-generated />
using System;
using DemoApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoApp.Infrastructure.Migrations
{
    [DbContext(typeof(DemoAppDbContext))]
    partial class DemoAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoApp.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("tblEmployees");
                });

            modelBuilder.Entity("DemoApp.Domain.Entities.IdName", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblTypes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdName");
                });

            modelBuilder.Entity("DemoApp.Domain.Entities.Department", b =>
                {
                    b.HasBaseType("DemoApp.Domain.Entities.IdName");

                    b.HasDiscriminator().HasValue("Department");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Accounts"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Human resource"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Document control"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Security"
                        });
                });

            modelBuilder.Entity("DemoApp.Domain.Entities.Employee", b =>
                {
                    b.HasOne("DemoApp.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
