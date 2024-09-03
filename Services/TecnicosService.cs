using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TecnicosService
{
    private readonly Contexto _context;
    public TecnicosService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Existe(int tecnicosID, string? Nombre = null)
    {
        return await _context.Tecnicos
            .AnyAsync(p => p.TecnicosId == tecnicosID);
    }

    public async Task<bool> NombreExiste(string? Nombre = null)
    {
        return await _context.Tecnicos
            .AnyAsync(p => p.Nombre == Nombre);
    }


    public async Task<bool> Insertar(Tecnicos tecnicos)
    {
        _context.Tecnicos .Add(tecnicos);
        return await _context.SaveChangesAsync() > 0; 
    }

    public async Task<bool> Modificar(Tecnicos tecnicos)
    {
        _context.Tecnicos.Update(tecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tecnicos tecnicos)
    {
        if (!await Existe(tecnicos.TecnicosId, tecnicos.Nombre))
            return await Insertar(tecnicos);
        else
            return await Modificar(tecnicos);
    }

    public async Task<bool> Eliminar(int id)
    {
        var tecnicos = await _context.Tecnicos.
            Where(P => P.TecnicosId == id).ExecuteDeleteAsync();
        return tecnicos > 0;
    }

    public async Task<Tecnicos?> Buscar(int id)
    {
        return await _context.Tecnicos.
            AsNoTracking()
            .FirstOrDefaultAsync(P => P.TecnicosId == id);
    }

    public List<Tecnicos> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        return _context.Tecnicos.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
     //COmentario

}
