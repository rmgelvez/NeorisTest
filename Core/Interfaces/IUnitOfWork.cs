using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IClientesRepository Clientes { get; }
        ICuentasRepository Cuentas { get; }
        IMovimientosRepository Movimientos { get; }
        IPersonaRepository Personas { get; }
        Task<int> saveAsync();
    }
}
