using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int tiposTecnicosID)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TiposTecnicos
            .AnyAsync(T => T.TiposTecnicosID == tiposTecnicosID);
    }

    public async Task<bool> DescripcionExiste(string? Descripcion = null)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TiposTecnicos
            .AnyAsync(T => T.Descripcion == Descripcion);
    }


    public async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.TiposTecnicos.Add(tiposTecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.TiposTecnicos.Update(tiposTecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TiposTecnicos tiposTecnicos)
    {
        if (!await DescripcionExiste(tiposTecnicos.Descripcion))
            return await Insertar(tiposTecnicos);
        else
            return await Modificar(tiposTecnicos);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var tiposTecnicos = await _context.TiposTecnicos.
            Where(T => T.TiposTecnicosID == id).ExecuteDeleteAsync();
        return tiposTecnicos > 0;
    }

    public async Task<TiposTecnicos?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.TiposTecnicos.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.TiposTecnicosID == id);
    }

    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.TiposTecnicos.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
