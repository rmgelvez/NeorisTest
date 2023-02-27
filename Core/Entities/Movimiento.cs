using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Movimiento: BaseEntity 
    {
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set;}
        public Cuenta Cuenta { get; set; }
        public int CuentaId { get; set;}
    }
}
