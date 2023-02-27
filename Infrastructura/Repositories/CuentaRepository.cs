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
    public class CuentaRepository: GenericRepository<Cuenta>, ICuentasRepository
    {
        public CuentaRepository(BancoContext context) : base(context) { }

        public override async Task<Cuenta> GetByIdAsync(int id)
        {
            return await _context.Cuentas
                            .Include(p => p.Cliente)
                            .FirstOrDefaultAsync(p => p.Id == id);

        }
        public override async Task<IEnumerable<Cuenta>> GetAllAsync()
        {
            return await _context.Cuentas
                                .Include(u => u.Cliente)
                                .ToListAsync();
        }
    }
}
