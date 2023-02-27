using Core.Entities;
using Core.Interfaces;
using Infrastructura.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.Repositories
{
    public class MovimientoRepository: GenericRepository<Movimiento>, IMovimientosRepository
    {
        public MovimientoRepository(BancoContext context) : base(context) { }

        public override async Task<Movimiento> GetByIdAsync(int id)
        {
            return await _context.Movimientos
                            .Include(p => p.Cuenta)
                            .FirstOrDefaultAsync(p => p.Id == id);

        }
        public override async Task<IEnumerable<Movimiento>> GetAllAsync()
        {
            return await _context.Movimientos
                                .Include(u => u.Cuenta)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetMovimientosBetweenDates(int clienteId, DateTime inicial, DateTime final) =>
                    await _context.Movimientos
                        .Include(s => s.Cuenta)
                        .Where(o => o.Cuenta.ClienteId == clienteId)
                        .Where(p => p.FechaMovimiento < final && p.FechaMovimiento > inicial)
                        .ToListAsync();
    }
}
