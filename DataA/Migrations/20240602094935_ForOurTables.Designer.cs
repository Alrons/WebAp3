﻿// <auto-generated />
using DataA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataA.Migrations
{
    [DbContext(typeof(DataAContext))]
    [Migration("20240602094935_ForOurTables")]
    partial class ForOurTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("DataA.Models.AddedItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("Place")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XPover")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Сurrency")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AddedItems");
                });

            modelBuilder.Entity("DataA.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("Place")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("XPover")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Сurrency")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DataA.Models.OurTables", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PosX")
                        .HasColumnType("REAL");

                    b.Property<double>("PosY")
                        .HasColumnType("REAL");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("OurTables");
                });

            modelBuilder.Entity("DataA.Models.SizeTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SizeTable");
                });
#pragma warning restore 612, 618
        }
    }
}
