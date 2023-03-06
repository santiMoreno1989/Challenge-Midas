﻿// <auto-generated />
using System;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Habitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal");

                    b.Property<int>("TipoHabitacionEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Habitacion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacidad = 2,
                            Precio = 10.500m,
                            TipoHabitacionEnum = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacidad = 3,
                            Precio = 14.900m,
                            TipoHabitacionEnum = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacidad = 2,
                            Precio = 18.900m,
                            TipoHabitacionEnum = 3
                        },
                        new
                        {
                            Id = 4,
                            Capacidad = 3,
                            Precio = 26.500m,
                            TipoHabitacionEnum = 4
                        });
                });

            modelBuilder.Entity("Domain.Entities.Huesped", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("HabitacionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitacionId");

                    b.HasIndex("ReservaId")
                        .IsUnique()
                        .HasFilter("[ReservaId] IS NOT NULL");

                    b.ToTable("Huesped");
                });

            modelBuilder.Entity("Domain.Entities.Recepcionista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Recepcionista");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Moreno",
                            Legajo = 13417,
                            Nombre = "Santiago"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Iglesias",
                            Legajo = 13419,
                            Nombre = "Gala"
                        },
                        new
                        {
                            Id = 3,
                            Apellido = "Olivier",
                            Legajo = 13717,
                            Nombre = "Osvaldo"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Duracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("HabitacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitacionId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Domain.Entities.Huesped", b =>
                {
                    b.HasOne("Domain.Entities.Habitacion", "Habitacion")
                        .WithMany("Huespedes")
                        .HasForeignKey("HabitacionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Reserva", "Reserva")
                        .WithOne("Huesped")
                        .HasForeignKey("Domain.Entities.Huesped", "ReservaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Habitacion");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.HasOne("Domain.Entities.Habitacion", "Habitacion")
                        .WithMany("Reservas")
                        .HasForeignKey("HabitacionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("Domain.Entities.Habitacion", b =>
                {
                    b.Navigation("Huespedes");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.Navigation("Huesped")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
