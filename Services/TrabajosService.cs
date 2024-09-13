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
        if (!await Existe(trabajos.TrabajosID))
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
            .FirstOrDefaultAsync(T => T.TrabajosID == id);
    }

    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        return await _context.Trabajos.
            AsNoTracking()
            .Include(T => T.tecnicos)
            .Include(T => T.clientes)
            .Where(criterio)
            .ToListAsync();    // CAmbios aquio
    }
    public async Task<List<Clientes>> ObtenerClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<List<Tecnicos>> ObtenerTecnicos()
    {
        return await _context.Tecnicos.ToListAsync(); 
    }

    public async Task<List<TiposTecnicos>> ObtenerTiposTecnicos()
    {
        return await _context.TiposTecnicos.ToListAsync();
    }

}
