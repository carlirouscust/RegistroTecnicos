using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class CotizacionesService
{
    private readonly Contexto _context;
    public CotizacionesService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Existe(int cotizacionesId)
    {
        return await _context.Cotizaciones
            .AnyAsync(T => T.cotizacionesId == cotizacionesId);
    }

    public async Task<bool> Insertar(Cotizaciones cotizaciones)
    {
        _context.Cotizaciones.Add(cotizaciones);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cotizaciones cotizaciones)
    {
        _context.Cotizaciones.Update(cotizaciones);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Cotizaciones cotizaciones)
    {
        if (await Existe(cotizaciones.cotizacionesId))
            return await Insertar(cotizaciones);
        else
            return await Modificar(cotizaciones);
    }

    public async Task<bool> Eliminar(int id)
    {
        var trabajos = await _context.Cotizaciones.
            Where(T => T.cotizacionesId == id).ExecuteDeleteAsync();
        return trabajos > 0;
    }

    public async Task<Cotizaciones?> Buscar(int id)
    {
        return await _context.Cotizaciones
            .AsNoTracking()
            .Include(c => c.clientes)
            .Include(c => c.CotizacionesDetalles)
            //.ThenInclude(td => td.Articulos)
            .FirstOrDefaultAsync(c => c.cotizacionesId == id);
    }

    public List<Cotizaciones> Listar(Expression<Func<Cotizaciones, bool>> criterio)
    {
        return _context.Cotizaciones
            .AsNoTracking()
            .Include(c => c.clientes)
            .Include(t => t.CotizacionesDetalles)
            .Where(criterio)
            .ToList();
    }

    public async Task<List<CotizacionesDetalles>> ObtenerDetallesCotizacionId(int cotizacionId)
    {
        var detalles = await _context.CotizacionesDetalles
            .Where(c => c.cotizaciones.cotizacionesId == cotizacionId)
            .ToListAsync();

        return detalles;
    }

    public async Task<List<Clientes>> ObtenerClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<List<Cotizaciones>> ObtenerCotizaciones()
    {
        return await _context.Cotizaciones.ToListAsync();
    }

    public async Task<List<CotizacionesDetalles>> ObtenerDetalle()
    {
        return await _context.CotizacionesDetalles.ToListAsync();

    }
    public async Task<List<Articulos>> ObtenerArticulos()
    {
        return await _context.Articulos.ToListAsync();
    }
}
