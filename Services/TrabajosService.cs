using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TrabajosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int trabajosID)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Trabajos
            .AnyAsync(T => T.TrabajosID == trabajosID);
    }

    public async Task<bool> Insertar(Trabajos trabajos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Trabajos.Add(trabajos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Trabajos trabajos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Trabajos.Update(trabajos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Trabajos trabajos)
    {
        if (await Existe(trabajos.TrabajosID))
            return await Insertar(trabajos);
        else
            return await Modificar(trabajos);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var trabajos = await _context.Trabajos.
            Where(T => T.TrabajosID == id).ExecuteDeleteAsync();
        return trabajos > 0;
    }

    public async Task<Trabajos?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Trabajos.
            AsNoTracking()
            .Include(T => T.tecnicos)
            .Include(T => T.clientes)
            .Include(T => T.prioridades)
            .Include(T => T.TrabajosDetalles)
            .FirstOrDefaultAsync(T => T.TrabajosID == id);
    }

    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos,bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Trabajos.
            AsNoTracking()
            .Include(T => T.tecnicos)
            .Include(T => T.clientes)
            .Include(T => T.prioridades)
            .Include(T => T.TrabajosDetalles)
            .Where(criterio)
            .OrderBy(T => T.prioridades.PrioridadesID)
            .ToList();    // CAmbios aquio
    }
    public async Task<List<Clientes>> ObtenerClientes()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes.ToListAsync();
    }

    public async Task<List<Tecnicos>> ObtenerTecnicos()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Tecnicos.Include(T => T.tiposTecnicos).ToListAsync();
    }

    public async Task<List<Prioridades>> ObtenerPrioridades()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades.ToListAsync();
    }

    public async Task<List<TrabajosDetalles>> ObtenerDetalles()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TrabajosDetalles.ToListAsync();
    }
    public async Task<List<Articulos>> ObtenerArticulos()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Articulos.ToListAsync();
    }
    
    public async Task<List<TrabajosDetalles>> ObtenerDetallesTrabajoId(int trabajosID)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var detalles = await _context.TrabajosDetalles
            .Where(t => t.Trabajos.TrabajosID == trabajosID)
            .ToListAsync();

        return detalles;
    }

    public async Task<bool> GuardarDetalles(TrabajosDetalles detalle)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.TrabajosDetalles.Add(detalle);
        
            var result = await _context.SaveChangesAsync();
           
            return true;       
    }

}