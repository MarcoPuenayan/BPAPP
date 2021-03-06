using BPAPP.Interfaces;
using BPAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPAPP.Controllers
{
    [Route("api/cuentas")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        #region : Campos

        private readonly ILogger<CuentasController> _logger;
        private readonly ICuentas _cuentas;

        #endregion : Campos

        #region : Constructor

        public CuentasController(ILogger<CuentasController> logger, ICuentas _cuentas)
        {
            this._logger = logger;
            this._cuentas = _cuentas;
        }

        #endregion : Constructor

        #region : Metodos

        /// <summary>
        /// Listado de Cuentas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<StatusViewModel>> GetCuentas()
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _cuentas.GetCuentas();

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
        /// Detalle de cuentas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusViewModel>> GetCuenta(Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _cuentas.GetCuenta(id);

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
        /// Registro de cuentas
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<StatusViewModel>> PostCuenta([FromBody] CuentaViewModel cuenta)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var validacionCuenta = await _cuentas.ExistCuentas(cuenta);
                if (!validacionCuenta.IsSuccess) return validacionCuenta;

                var clientes = await _cuentas.PostCuentas(cuenta);

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
        /// Actualizacion de datos de cuenta
        /// </summary>
        /// <param name="cuenta"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<StatusViewModel>> PutCuenta([FromBody] CuentaViewModel cuenta, Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _cuentas.PutCuentas(cuenta, id);

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
        /// Inactivacion de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusViewModel>> DeleteCuenta(Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _cuentas.DeleteCuentas(id);

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