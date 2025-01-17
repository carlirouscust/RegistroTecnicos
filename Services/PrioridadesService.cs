﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int prioridadesID)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades
            .AnyAsync(T => T.PrioridadesID == prioridadesID);
    }

    public async Task<bool> DescripcionExiste(string? descripcion = null)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades
            .AnyAsync(T => T.Descripcion == descripcion);
    }


    public async Task<bool> Insertar(Prioridades prioridades)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Prioridades.Add(prioridades);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prioridades prioridades)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Prioridades.Update(prioridades);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prioridades prioridades)
    {
        if (!await DescripcionExiste(prioridades.Descripcion))
            return await Insertar(prioridades);
        else
            return await Modificar(prioridades);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var prioridades = await _context.Prioridades.
            Where(T => T.PrioridadesID == id).ExecuteDeleteAsync();
        return prioridades > 0;
    }

    public async Task<Prioridades?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Prioridades.
            AsNoTracking()
            .FirstOrDefaultAsync(T => T.PrioridadesID == id);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return _context.Prioridades.
            AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
