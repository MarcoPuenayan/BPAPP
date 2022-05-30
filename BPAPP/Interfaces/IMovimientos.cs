using BPAPP.Data;
using BPAPP.Models;

namespace BPAPP.Interfaces
{
    public interface IMovimientos
    {
        public Task<List<Movimiento>> GetMovimientos();

        public Task<Movimiento> GetMovimiento(Guid id);

        public Task<Movimiento> PostMovimiento(MovimientoViewModel movimiento);

        public Task<Movimiento> PutMovimiento(Movimiento movimiento);

        public Task<Movimiento> DeleteMovimiento(Guid id);

        /// <summary>
        /// Validaciones de Movimientos de cuenta
        /// </summary>
        /// <param name="movimiento"></param>
        /// <returns></returns>
        public Task<StatusViewModel> ValidacaionesMovimiento(MovimientoViewModel movimiento);

        /// <summary>
        ///  reporte de movimientos por cliente y rango de fechas
        /// </summary>
        /// <param name="movimiento"></param>
        /// <returns></returns>
        public Task<StatusViewModel> GetReporteMovimientos(ReporteMovimientosViewModel movimiento);
    }
}