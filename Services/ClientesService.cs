using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;


namespace RegistroTecnicos.Services;

public class ClientesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int clientesID)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes
            .AnyAsync(T => T.ClientesID == clientesID);
    }

    public async Task<bool> NombreExiste(string? Nombre = null)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes
            .AnyAsync(T => T.Nombre == Nombre);
    }


    public async Task<bool> Insertar(Clientes clientes)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Clientes.Add(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Clientes clientes)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Clientes.Update(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Clientes clientes)
    {
        if (!await NombreExiste(clientes.Nombre))
            return await Insertar(clientes);
        else
            return await Modificar(clientes);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var clientes = await _context.Clientes.
            Where(T => T.ClientesID == id).ExecuteDeleteAsync();
        return clientes > 0;
    }

    public async Task<Clientes?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.ClientesID == id);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Clientes.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }

}
