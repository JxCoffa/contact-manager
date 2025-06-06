﻿// <auto-generated />
using System;
using ContactManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactManagerAPI.Migrations
{
    [DbContext(typeof(ContactDbContext))]
    [Migration("20250520202916_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactManagerAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Family"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Friend"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Work"
                        });
                });

            modelBuilder.Entity("ContactManagerAPI.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            DateAdded = new DateTime(2022, 9, 27, 13, 20, 0, 0, DateTimeKind.Unspecified),
                            Email = "delores@hotmail.com",
                            FirstName = "Delores",
                            LastName = "Del Rio",
                            Phone = "555-987-6543"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            DateAdded = new DateTime(2025, 5, 10, 22, 29, 13, 993, DateTimeKind.Local).AddTicks(9796),
                            Email = "efren@aol.com",
                            FirstName = "Efren",
                            LastName = "Herrera",
                            Phone = "555-456-7890"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            DateAdded = new DateTime(2025, 5, 15, 22, 29, 13, 996, DateTimeKind.Local).AddTicks(3903),
                            Email = "MaryEllen@yahoo.com",
                            FirstName = "Mary Ellen",
                            LastName = "Walton",
                            Phone = "555-123-4567"
                        });
                });

            modelBuilder.Entity("ContactManagerAPI.Models.Contact", b =>
                {
                    b.HasOne("ContactManagerAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
