using BPAPP.Data;
using BPAPP.Models;

namespace BPAPP.Interfaces
{
    public interface ICuentas
    {
        public Task<List<Cuenta>> GetCuentas();

        public Task<Cuenta> GetCuenta(Guid id);

        public Task<Cuenta> PostCuentas(CuentaViewModel cuenta);

        public Task<StatusViewModel> ExistCuentas(CuentaViewModel cuenta);

        public Task<Cuenta> PutCuentas(CuentaViewModel cuenta, Guid id);

        public Task<Cuenta> DeleteCuentas(Guid id);
    }
}