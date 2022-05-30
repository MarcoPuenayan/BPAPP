using BPAPP.Data;
using BPAPP.Interfaces;
using BPAPP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BPAPP.Services
{
    public class ClientesServices : IClientes
    {
        #region : Campos

        private readonly ILogger _logger;
        private ApplicationDbContext ctx;
        public IConfiguration Configuration { get; }

        #endregion : Campos

        #region : Constructor

        public ClientesServices(ILogger<ClientesServices> logger, ApplicationDbContext ctx, IConfiguration Configuration)
        {
            this.ctx = ctx;
            _logger = logger;
            this.Configuration = Configuration;
        }

        #endregion : Constructor

        #region : Metodos

        public async Task<Cliente> DeleteClientes(Guid id)
        {
            try
            {
                var dataCliente = await ctx.Clientes.Where(x => x.IdCliente == id).SingleOrDefaultAsync();
                dataCliente.Estado = false;
                await ctx.SaveChangesAsync();
                return dataCliente;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cliente> GetCliente(Guid id)
        {
            try
            {
                var cliente = await ctx.Clientes.Where(x => x.IdCliente == id).FirstOrDefaultAsync();
                return cliente;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Cliente>> GetClientes()
        {
            try
            {
                var clientes = await ctx.Clientes.ToListAsync();
                return clientes;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cliente> PostClientes(ClienteViewModel cliente)
        {
            try
            {
                Cliente _cliente = new Cliente();

                _cliente.IdCliente = Guid.NewGuid();
                _cliente.IdPersona = Guid.NewGuid();
                _cliente.Telefono = cliente.Telefono;
                _cliente.Estado = cliente.Estado;
                _cliente.Identificacion = cliente.Identificacion;
                _cliente.Edad = cliente.Edad;
                _cliente.Contraseña = cliente.Contraseña;
                _cliente.Direccion = cliente.Direccion;
                _cliente.Genero = cliente.Genero;
                _cliente.Nombre = cliente.Nombre;

                ctx.Clientes.Add(_cliente);
                await ctx.SaveChangesAsync();

                return _cliente;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cliente> PutClientes(ClienteViewModel cliente, Guid id)
        {
            try
            {
                var dataCliente = await ctx.Clientes.Where(x => x.IdCliente == id).SingleOrDefaultAsync();
                dataCliente.Nombre = cliente.Nombre;
                dataCliente.Identificacion = cliente.Identificacion;
                dataCliente.Edad = cliente.Edad;
                dataCliente.Contraseña = cliente.Contraseña;
                dataCliente.Direccion = cliente.Direccion;
                dataCliente.Telefono = cliente.Telefono;
                dataCliente.Genero = cliente.Genero;

                await ctx.SaveChangesAsync();
                return dataCliente;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<StatusViewModel> ExistCliente(ClienteViewModel cliente)
        {
            try
            {
                StatusViewModel status = new StatusViewModel();

                var data = await ctx.Clientes.Where(x => x.Identificacion == cliente.Identificacion).AnyAsync();

                if (data)
                {
                    status.IsSuccess = false;
                    status.Message = "Cliente ya existe..";
                }

                return status;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("Concurrencia : " + ((SqlException)ex.InnerException).Number + "" + ex.InnerException.Message);
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("Actualizar:" + ((SqlException)ex.InnerException).Number + " " + ex.InnerException.Message);
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                _logger.LogInformation("Conexión : " + ex.Number + " " + ex.Message);
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion : Metodos
    }
}