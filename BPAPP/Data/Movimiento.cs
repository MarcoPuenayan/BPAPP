using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPAPP.Data
{
    public class Movimiento
    {
        [Key]
        public Guid IdMovimiento { get; set; }

        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Movimientos { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }

        //Foreign key
        public Guid? IdCuenta { get; set; }

        public Cuenta? Cuentas { get; set; }
    }
}