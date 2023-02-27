using Core.Entities;

namespace NeorisTest.Dtos
{
    public class CuentaDto
    {
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}
