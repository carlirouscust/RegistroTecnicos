using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosService
{
    private readonly Contexto _context;
    public TiposTecnicosService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Existe(int tiposTecnicosID)
    {
        return await _context.TiposTecnicos
            .AnyAsync(T => T.TiposTecnicosID == tiposTecnicosID);
    }

    public async Task<bool> DescripcionExiste(string? Descripcion = null)
    {
        return await _context.TiposTecnicos
            .AnyAsync(T => T.Descripcion == Descripcion);
    }


    public async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        _context.TiposTecnicos.Add(tiposTecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
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
        var tiposTecnicos = await _context.TiposTecnicos.
            Where(T => T.TiposTecnicosID == id).ExecuteDeleteAsync();
        return tiposTecnicos > 0;
    }

    public async Task<TiposTecnicos?> Buscar(int id)
    {
        return await _context.TiposTecnicos.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.TiposTecnicosID == id);
    }

    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        return _context.TiposTecnicos.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
