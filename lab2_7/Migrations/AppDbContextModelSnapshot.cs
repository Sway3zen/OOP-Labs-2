﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab2_7.Data;

#nullable disable

namespace lab2_7.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("lab2_7.Model.FlightsVm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirLines")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("ArrivalDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("ArrivalTime")
                        .HasColumnType("time(6)");

                    b.Property<string>("ArrivalTo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("BusinessClass")
                        .HasColumnType("int");

                    b.Property<int>("BusinessPrice")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<string>("DepartureFrom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<TimeOnly>("DepartureTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("EconomyClass")
                        .HasColumnType("int");

                    b.Property<int>("EconomyPrice")
                        .HasColumnType("int");

                    b.Property<int>("FirstClass")
                        .HasColumnType("int");

                    b.Property<int>("FirstPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("lab2_7.Model.PurchasedFlightVm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TicketsCount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PurchasedFlights");
                });

            modelBuilder.Entity("lab2_7.Model.UserVm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
