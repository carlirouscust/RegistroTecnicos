 using Microsoft.EntityFrameworkCore;
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

    public DbSet<Articulos> Articulos { get; set; }

    public DbSet<TrabajosDetalles> TrabajosDetalles { get; set; }
    public DbSet<Cotizaciones> Cotizaciones { get; set; }
    public DbSet<CotizacionesDetalles> CotizacionesDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tecnicos>()
            .HasOne(tt => tt.tiposTecnicos)
            .WithMany(t => t.Tecnicos)
            .HasForeignKey(t => t.TiposTecnicosID);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
            new Articulos 
            {
                articuloId = 1, 
                descripcion = "Bocina", 
                costo = 1200.00m, 
                precio = 3000.00m, 
                existencia = 50 
            },
            new Articulos 
            { 
                articuloId = 2, 
                descripcion = "Taza", 
                costo = 35.00m, 
                precio = 70.00m, 
                existencia = 200 
            },
            new Articulos 
            { 
                articuloId = 3, 
                descripcion = "Laptop", 
                costo = 15000.00m, 
                precio = 35000.00m, 
                existencia = 100 
            }
            
        });
    }
}
