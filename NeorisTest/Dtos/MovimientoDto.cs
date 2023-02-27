using Core.Entities;

namespace NeorisTest.Dtos
{
    public class MovimientoDto
    {
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public CuentaDto Cuenta { get; set; }
    }
}
