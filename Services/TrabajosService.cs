using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TrabajosService
{
    private readonly Contexto _context;
    public TrabajosService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Existe(int trabajosID)
    {
        return await _context.Trabajos
            .AnyAsync(T => T.TrabajosID == trabajosID);
    }

    public async Task<bool> Insertar(Trabajos trabajos)
    {
        _context.Trabajos.Add(trabajos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Trabajos trabajos)
    {
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
        var trabajos = await _context.Trabajos.
            Where(T => T.TrabajosID == id).ExecuteDeleteAsync();
        return trabajos > 0;
    }

    public async Task<Trabajos?> Buscar(int id)
    {
        return await _context.Trabajos.
            AsNoTracking()
            .Include(T => T.tecnicos)
            .Include(T => T.clientes)
            .Include(T => T.prioridades)
            .Include(T => T.TrabajosDetalles)
            .FirstOrDefaultAsync(T => T.TrabajosID == id);
    }

    public List<Trabajos> Listar(Expression<Func<Trabajos,bool>> criterio)
    {
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
        return await _context.Clientes.ToListAsync();
    }

    public async Task<List<Tecnicos>> ObtenerTecnicos()
    {
        return await _context.Tecnicos.Include(T => T.tiposTecnicos).ToListAsync();
    }

    public async Task<List<Prioridades>> ObtenerPrioridades()
    {
        return await _context.Prioridades.ToListAsync();
    }

    public async Task<List<TrabajosDetalles>> ObtenerDetalles()
    {
        return await _context.TrabajosDetalles.ToListAsync();
    }
    public async Task<List<Articulos>> ObtenerArticulos()
    {
        return await _context.Articulos.ToListAsync();
    }
    
    public async Task<List<TrabajosDetalles>> ObtenerDetallesTrabajoId(int trabajosID)
    {
        var detalles = await _context.TrabajosDetalles
            .Where(t => t.trabajoId == trabajosID)
            .ToListAsync();

        return detalles;
    }

    public async Task<bool> GuardarDetalles(TrabajosDetalles detalle)
    {      
            // Agregar el detalle a la base de datos
            _context.TrabajosDetalles.Add(detalle);

            // Guardar los cambios en la base de datos
            var result = await _context.SaveChangesAsync();

            // Retornar true si se guardaron los cambios correctamente
            return true;       
    }

}