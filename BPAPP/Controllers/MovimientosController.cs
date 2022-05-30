using BPAPP.Interfaces;
using BPAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPAPP.Controllers
{
    [Route("api/movimientos")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        #region : Campos

        private readonly ILogger<MovimientosController> _logger;
        private readonly IMovimientos _movimientos;

        #endregion : Campos

        #region : Constructor

        public MovimientosController(ILogger<MovimientosController> logger, IMovimientos movimientos)
        {
            this._logger = logger;
            this._movimientos = movimientos;
        }

        #endregion : Constructor

        #region : Metodos

        /// <summary>
        /// Listado de movimientos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<StatusViewModel>> GetMovimiento()
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _movimientos.GetMovimientos();

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
        /// Reporte de Movimientos por cliente
        /// </summary>
        /// <param name="reporte"></param>
        /// <returns></returns>
        [HttpGet("reporte")]
        public async Task<ActionResult<StatusViewModel>> GetReporte([FromQuery] ReporteMovimientosViewModel reporte)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                status = await _movimientos.GetReporteMovimientos(reporte);
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
        /// Registro de movimientos de cuentas
        /// </summary>
        /// <param name="movimiento"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<StatusViewModel>> PostMovimiento([FromBody] MovimientoViewModel movimiento)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                //Validaciones Movimientos
                var validacionesMovientos = await _movimientos.ValidacaionesMovimiento(movimiento);

                if (!validacionesMovientos.IsSuccess) return validacionesMovientos;
                //Regitro de Movimientos
                var clientes = await _movimientos.PostMovimiento(movimiento);

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
        /// Actualizacion de movimientos
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<StatusViewModel>> PutMovimiento([FromBody] ClienteViewModel cliente, Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _movimientos.GetMovimientos();

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
        /// Eliminacion de MOviminietos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusViewModel>> DeleteMovimiento(Guid id)
        {
            StatusViewModel status = new StatusViewModel();
            try
            {
                var clientes = await _movimientos.GetMovimientos();

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