﻿// <auto-generated />
using System;
using MegaDeskWeb_Farrwest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskWeb_Farrwest.Migrations
{
    [DbContext(typeof(MegaDeskWeb_FarrwestContext))]
    partial class MegaDeskWeb_FarrwestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskWeb_Farrwest.Model.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("customerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateDisplayString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deliveryOptions")
                        .HasColumnType("int");

                    b.Property<int>("depth")
                        .HasColumnType("int");

                    b.Property<int>("desktopMaterial")
                        .HasColumnType("int");

                    b.Property<int>("numOfDrawers")
                        .HasColumnType("int");

                    b.Property<DateTime>("quoteDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalPrice")
                        .HasColumnType("float");

                    b.Property<int>("width")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Quote");
                });
#pragma warning restore 612, 618
        }
    }
}
