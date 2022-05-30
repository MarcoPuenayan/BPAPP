using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPAPP.Data
{
    public class Cuenta
    {
        [Key]
        public Guid IdCuenta { get; set; }

        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LimiteDiario { get; set; }

        public bool Estado { get; set; }

        [ForeignKey("IdCuenta")]
        public ICollection<Movimiento> Movimientos { get; set; } = new HashSet<Movimiento>();

        //Foreign key
        public Guid? IdCliente { get; set; }

        public Cliente? Clientes { get; set; }
    }
}