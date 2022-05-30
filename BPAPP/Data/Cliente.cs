using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPAPP.Data
{
    public class Cliente : Persona
    {
        [Key]
        public Guid IdCliente { get; set; }

        public string Contraseña { get; set; }
        public bool Estado { get; set; }

        [ForeignKey("IdCliente")]
        public ICollection<Cuenta> Cuentas { get; set; } = new HashSet<Cuenta>();
    }
}