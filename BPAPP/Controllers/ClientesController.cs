using BPAPP.Interfaces;
using BPAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPAPP.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        #region : Campos

        private readonly ILogger<ClientesController> _logger;
        private readonly IClientes _clientes;

        #endregion : Campos

        #region : Constructor

        public ClientesController(ILogger<ClientesController> logger, IClientes clientes)
        {
            this._logger = logger;
            this._clientes = clientes;
        }

        #endregion : Constructor

        #region : Metodos

        /// <summary>
        /// Listado de Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<StatusViewModel>> GetClientes()
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _clientes.GetClientes();

                status.ObjetoADeserializar = clientes;

                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;

                return status;
            }
        }

        /// <summary>
        /// Detalle de Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusViewModel>> GetCliente(Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _clientes.GetCliente(id);

                status.ObjetoADeserializar = clientes;

                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;

                return status;
            }
        }

        /// <summary>
        /// Registro de Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<StatusViewModel>> PostClientes([FromBody] ClienteViewModel cliente)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var validacionCliente = await _clientes.ExistCliente(cliente);
                if (!validacionCliente.IsSuccess) return validacionCliente;

                var clientes = await _clientes.PostClientes(cliente);

                status.ObjetoADeserializar = clientes;

                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;

                return status;
            }
        }

        /// <summary>
        /// Actualizacion de datos del cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<StatusViewModel>> PutClientes([FromBody] ClienteViewModel cliente, Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _clientes.PutClientes(cliente, id);

                status.ObjetoADeserializar = clientes;

                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;

                return status;
            }
        }

        /// <summary>
        /// Inactivar a Clientes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusViewModel>> DeleteClientes(Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _clientes.DeleteClientes(id);

                status.ObjetoADeserializar = clientes;

                return status;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;

                return status;
            }
        }

        #endregion : Metodos
    }
}