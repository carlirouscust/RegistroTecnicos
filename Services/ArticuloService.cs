using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class ArticuloService
{
    private readonly Contexto _contexto;

    public ArticuloService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Articulos>> ListarArticulos()
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .ToListAsync();
    }

    
    public async Task<Articulos?> ObtenerArticuloPorId(int id)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.articuloId == id);
    }

   
    public async Task ActualizarExistencia(int articuloId, decimal cantidad)
    {
        var articulo = await _contexto.Articulos.FindAsync(articuloId);
        if (articulo != null)
        {
            articulo.existencia -= cantidad; 
            _contexto.Articulos.Update(articulo);
            await _contexto.SaveChangesAsync();
        }
    }

    public async Task AgregarCantidad(int articuloId, int cantidad)
    {
        
        var articulo = await _contexto.Articulos.FindAsync(articuloId);

        if (articulo != null)
        {
           
            articulo.existencia += cantidad;

           
            await _contexto.SaveChangesAsync();
        }
    }
}
