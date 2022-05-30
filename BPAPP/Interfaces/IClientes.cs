using BPAPP.Data;
using BPAPP.Models;

namespace BPAPP.Interfaces
{
    public interface IClientes
    {
        public Task<List<Cliente>> GetClientes();

        public Task<Cliente> GetCliente(Guid id);

        public Task<Cliente> PostClientes(ClienteViewModel cliente);

        public Task<Cliente> PutClientes(ClienteViewModel cliente, Guid id);

        public Task<Cliente> DeleteClientes(Guid id);

        public Task<StatusViewModel> ExistCliente(ClienteViewModel cliente);
    }
}