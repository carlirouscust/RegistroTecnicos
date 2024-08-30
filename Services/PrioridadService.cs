using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class PrioridadService
    {
        private readonly Contexto _context;
        public PrioridadService(Contexto contexto)
        {
            _context = contexto;
        }

        public async Task<bool> Existe(int prioridadID)
        {
            return await _context.prioridades
                .AnyAsync(p => p.prioridadID == prioridadID);
        }

        public async Task<bool> Insertar(Prioridades prioridades)
        {
            _context.prioridades .Add(prioridades);
            return await _context.SaveChangesAsync() > 0; 
        }

        public async Task<bool> Modificar(Prioridades prioridades)
        {
            _context.Update(prioridades);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Prioridades prioridad)
        {
            if (!await Existe(prioridad.prioridadID))
                return await Insertar(prioridad);
            else
                return await Modificar(prioridad);
        }

        public async Task<bool> Eliminar(int id)
        {
            var prioridades = await _context.prioridades.
                Where(P => P.prioridadID == id).ExecuteDeleteAsync();
            return prioridades > 0;
        }

        public async Task<Prioridades?> Buscar(int id)
        {
            return await _context.prioridades.
                AsNoTracking()
                .FirstOrDefaultAsync(P => P.prioridadID == id);
        }

        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return _context.prioridades.
                AsNoTracking()
                .Where(criterio)
                .ToList();
        }

    }
}
