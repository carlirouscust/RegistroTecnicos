﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;
using RegistroTecnicos.Services;


namespace RegistroTecnicos.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
    : base(options) { }

    public DbSet<Tecnicos> Tecnicos { get; set; }

    public DbSet<TiposTecnicos> TiposTecnicos { get; set; }

    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Trabajos> Trabajos { get; set; }

    public DbSet<Prioridades> Prioridades { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Tecnicos>()
            .HasOne(tt => tt.tiposTecnicos)
            .WithMany(t => t.Tecnicos)
            .HasForeignKey(t => t.TiposTecnicosID);

        base.OnModelCreating(modelBuilder);
    }
}
