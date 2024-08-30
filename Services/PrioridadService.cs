using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
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
    }
}
