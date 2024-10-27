using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class CotizacionesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int cotizacionesId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Cotizaciones
            .AnyAsync(T => T.cotizacionesId == cotizacionesId);
    }

    public async Task<bool> Insertar(Cotizaciones cotizaciones)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Cotizaciones.Add(cotizaciones);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cotizaciones cotizaciones)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
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
        await using var _context = await DbFactory.CreateDbContextAsync();
        var trabajos = await _context.Cotizaciones.
            Where(T => T.cotizacionesId == id).ExecuteDeleteAsync();
        return trabajos > 0;
    }

    public async Task<Cotizaciones?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Cotizaciones
            .AsNoTracking()
            .Include(c => c.clientes)
            .Include(c => c.CotizacionesDetalles)
            //.ThenInclude(td => td.Articulos)
            .FirstOrDefaultAsync(c => c.cotizacionesId == id);
    }

    public async Task <List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Cotizaciones
            .AsNoTracking()
            .Include(c => c.clientes)
            .Include(t => t.CotizacionesDetalles)
            .Where(criterio)
            .ToList();
    }

    public async Task<List<CotizacionesDetalles>> ObtenerDetallesCotizacionId(int cotizacionId)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var detalles = await _context.CotizacionesDetalles
            .Where(c => c.cotizaciones.cotizacionesId == cotizacionId)
            .ToListAsync();

        return detalles;
    }

    public async Task<List<Clientes>> ObtenerClientes()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes.ToListAsync();
    }

    public async Task<List<Cotizaciones>> ObtenerCotizaciones()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Cotizaciones.ToListAsync();
    }

    public async Task<List<CotizacionesDetalles>> ObtenerDetalle()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.CotizacionesDetalles.ToListAsync();

    }
    public async Task<List<Articulos>> ObtenerArticulos()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Articulos.ToListAsync();
    }
}
