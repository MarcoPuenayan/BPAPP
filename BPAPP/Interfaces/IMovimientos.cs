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

        public Task<StatusViewModel> ValidacaionesMovimiento(MovimientoViewModel movimiento);

        public Task<StatusViewModel> GetReporteMovimientos(ReporteMovimientosViewModel movimiento);
    }
}