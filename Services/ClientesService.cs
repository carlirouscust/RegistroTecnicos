using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;


namespace RegistroTecnicos.Services;

public class ClientesService
{
    private readonly Contexto _context;
    public ClientesService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Existe(int clientesID)
    {
        return await _context.Clientes
            .AnyAsync(T => T.ClientesID == clientesID);
    }

    public async Task<bool> NombreExiste(string? Nombre = null)
    {
        return await _context.Clientes
            .AnyAsync(T => T.Nombre == Nombre);
    }


    public async Task<bool> Insertar(Clientes clientes)
    {
        _context.Clientes.Add(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Clientes clientes)
    {
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
        var clientes = await _context.Clientes.
            Where(T => T.ClientesID == id).ExecuteDeleteAsync();
        return clientes > 0;
    }

    public async Task<Clientes?> Buscar(int id)
    {
        return await _context.Clientes.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.ClientesID == id);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        return _context.Clientes.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }

}
