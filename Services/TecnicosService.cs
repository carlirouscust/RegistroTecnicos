using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TecnicosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int tecnicosID)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Tecnicos
            .AnyAsync(T => T.TecnicosID == tecnicosID);
    }

    public async Task<bool> NombreExiste(string? Nombre = null)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Tecnicos
            .AnyAsync(T => T.Nombre == Nombre);
    }


    public async Task<bool> Insertar(Tecnicos tecnicos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Tecnicos.Add(tecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Tecnicos tecnicos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Tecnicos.Update(tecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tecnicos tecnicos)
    {
        if (!await Existe(tecnicos.TecnicosID))
            return await Insertar(tecnicos);
        else
            return await Modificar(tecnicos);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var tecnicos = await _context.Tecnicos.
            Where(T => T.TecnicosID == id).ExecuteDeleteAsync();
        return tecnicos > 0;
    }

    public async Task<Tecnicos?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Tecnicos.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.TecnicosID == id);
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Tecnicos.
            AsNoTracking()
            .Include(T => T.tiposTecnicos)
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<List<TiposTecnicos>> ObtenerTiposTecnicos()
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TiposTecnicos.ToListAsync();
    }

}