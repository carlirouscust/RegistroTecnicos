﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("RegistroTecnicos.Models.Articulos", b =>
                {
                    b.Property<int>("articuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("costo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("existencia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("precio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("articuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            articuloId = 1,
                            costo = 1200.00m,
                            descripcion = "Bocina",
                            existencia = 50m,
                            precio = 3000.00m
                        },
                        new
                        {
                            articuloId = 2,
                            costo = 35.00m,
                            descripcion = "Taza",
                            existencia = 200m,
                            precio = 70.00m
                        },
                        new
                        {
                            articuloId = 3,
                            costo = 15000.00m,
                            descripcion = "Laptop",
                            existencia = 100m,
                            precio = 35000.00m
                        });
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClientesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientesID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Property<int>("cotizacionesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientesID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int?>("monto")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("observacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("cotizacionesId");

                    b.HasIndex("ClientesID");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalles", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("CotizacionId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("CotizacionId");

                    b.ToTable("CotizacionesDetalles");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Property<int>("PrioridadesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Tiempo")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("PrioridadesID");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SueldoHora")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int>("TiposTecnicosID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TecnicosID");

                    b.HasIndex("TiposTecnicosID");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("TiposTecnicosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TiposTecnicosID");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientesID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Monto")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrioridadesID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TecnicosID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajosID");

                    b.HasIndex("ClientesID");

                    b.HasIndex("PrioridadesID");

                    b.HasIndex("TecnicosID");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalles", b =>
                {
                    b.Property<int>("detalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ArticulosarticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TrabajosID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("articuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("costo")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("precio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("trabajoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("detalleId");

                    b.HasIndex("ArticulosarticuloId");

                    b.HasIndex("TrabajosID");

                    b.ToTable("TrabajosDetalles");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "clientes")
                        .WithMany()
                        .HasForeignKey("ClientesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalles", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Cotizaciones", "cotizaciones")
                        .WithMany("CotizacionesDetalles")
                        .HasForeignKey("CotizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.TiposTecnicos", "tiposTecnicos")
                        .WithMany("Tecnicos")
                        .HasForeignKey("TiposTecnicosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "clientes")
                        .WithMany()
                        .HasForeignKey("ClientesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Prioridades", "prioridades")
                        .WithMany("Trabajos")
                        .HasForeignKey("PrioridadesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Tecnicos", "tecnicos")
                        .WithMany()
                        .HasForeignKey("TecnicosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clientes");

                    b.Navigation("prioridades");

                    b.Navigation("tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalles", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticulosarticuloId");

                    b.HasOne("RegistroTecnicos.Models.Trabajos", "Trabajos")
                        .WithMany("TrabajosDetalles")
                        .HasForeignKey("TrabajosID");

                    b.Navigation("Articulos");

                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Navigation("CotizacionesDetalles");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TiposTecnicos", b =>
                {
                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Navigation("TrabajosDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
