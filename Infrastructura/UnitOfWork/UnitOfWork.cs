using Core.Entities;
using Core.Interfaces;
using Infrastructura.Data;
using Infrastructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BancoContext _context;
        private IClientesRepository _clientes;
        private ICuentasRepository _cuentas;
        private IMovimientosRepository _movimientos;
        private IPersonaRepository _persona;
        
        public UnitOfWork(BancoContext context)
        {
            _context = context;
        }

        public IMovimientosRepository Movimientos
        {
            get
            {
                if (_movimientos == null)
                {
                    _movimientos = new MovimientoRepository(_context);
                }
                return _movimientos;
            }
        }

        public ICuentasRepository Cuentas
        {
            get
            {
                if (_cuentas == null)
                {
                    _cuentas = new CuentaRepository(_context);
                }
                return _cuentas;
            }
        }

        public IClientesRepository Clientes
        {
            get
            {
                if (_clientes == null)
                {
                    _clientes = new ClienteRepository(_context);
                }
                return _clientes;
            }
        }
        public IPersonaRepository Personas
        {
            get
            {
                if (_persona == null)
                {
                    _persona = new PersonaRepository(_context);
                }
                return _persona;
            }
        }

        public async Task<int> saveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
