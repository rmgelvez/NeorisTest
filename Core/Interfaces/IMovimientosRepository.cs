using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMovimientosRepository: IGenericRepository<Movimiento>
    {
        Task<IEnumerable<Movimiento>> GetMovimientosBetweenDates(int clienteId, DateTime fechaInicial, DateTime fechaFinal);
    }
}
