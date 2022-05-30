namespace BPAPP.Models
{
    public class CuentaViewModel
    {
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public Guid IdCliente { get; set; }
    }
}