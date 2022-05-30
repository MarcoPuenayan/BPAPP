using BPAPP.Commons;
using BPAPP.Data;
using BPAPP.Interfaces;
using BPAPP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BPAPP.Services
{
    public class MovimientosServices : IMovimientos
    {
        #region : Campos

        private readonly ILogger _logger;
        private ApplicationDbContext ctx;
        public IConfiguration Configuration { get; }

        #endregion : Campos

        #region : Constructor

        public MovimientosServices(ILogger<MovimientosServices> logger, ApplicationDbContext ctx, IConfiguration Configuration)
        {
            this.ctx = ctx;
            _logger = logger;
            this.Configuration = Configuration;
        }

        #endregion : Constructor

        #region : Metodos

        public Task<Movimiento> DeleteMovimiento(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Movimiento> GetMovimiento(Guid id)
        {
            try
            {
                var movimiento = await ctx.Movimientos.Where(x => x.IdMovimiento == id).FirstOrDefaultAsync();
                return movimiento;
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

        public async Task<List<Movimiento>> GetMovimientos()
        {
            try
            {
                var movimiento = await ctx.Movimientos.ToListAsync();
                return movimiento;
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

        /// <summary>
        /// Resgistro de movimientos de cuentas
        /// </summary>
        /// <param name="movimiento"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Movimiento> PostMovimiento(MovimientoViewModel movimiento)
        {
            try
            {
                var dataCuenta = await ctx.Cuentas.Where(x => x.IdCuenta == movimiento.IdCuenta).FirstOrDefaultAsync();

                var saldoActual = dataCuenta.SaldoInicial;
                var saldo = saldoActual + movimiento.Valor;

                //Registrar movimiento
                Movimiento _movimiento = new Movimiento();
                _movimiento.IdMovimiento = Guid.NewGuid();
                _movimiento.Fecha = DateTime.Now;
                _movimiento.Tipo = movimiento.Valor > 0 ? Constantes.DEPOSITO : Constantes.RETIRO;
                _movimiento.Movimientos = $"{_movimiento.Tipo} {movimiento.Valor}";
                _movimiento.Valor = movimiento.Valor;
                _movimiento.Saldo = saldo;
                _movimiento.SaldoInicial = saldoActual;
                _movimiento.IdCuenta = movimiento.IdCuenta;

                ctx.Movimientos.Add(_movimiento);
                await ctx.SaveChangesAsync();

                //Actualizar valor de cuenta
                Cuenta cuenta = await ctx.Cuentas.Where(x => x.IdCuenta == movimiento.IdCuenta).FirstOrDefaultAsync();
                if (cuenta != null)
                {
                    cuenta.SaldoInicial = _movimiento.Saldo;
                    await ctx.SaveChangesAsync();
                }

                return _movimiento;
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

        public Task<Movimiento> PutMovimiento(Movimiento cliente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validaciones de movimientos y saldo
        /// </summary>
        /// <param name="movimiento"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<StatusViewModel> ValidacaionesMovimiento(MovimientoViewModel movimiento)
        {
            try
            {
                StatusViewModel status = new StatusViewModel();

                var fechaActual = DateTime.Today;
                //Datos de movimientos de retiro diarios
                var dataMovimiento = await ctx.Movimientos.Where(x => x.Fecha.Date == fechaActual && x.IdCuenta == movimiento.IdCuenta && x.Tipo == Constantes.RETIRO).ToListAsync();
                //Datos de cuenta
                var datosCuenta = await ctx.Cuentas.Where(x => x.IdCuenta == movimiento.IdCuenta).FirstOrDefaultAsync();

                if (movimiento.Valor < 0)
                {
                    //Concepto de retiro
                    if (dataMovimiento.Count() > 0)
                    {
                        var sumaValoresMovimientos = Math.Abs(dataMovimiento.Sum(x => x.Valor) + movimiento.Valor);
                        if (sumaValoresMovimientos > datosCuenta.LimiteDiario)
                        {
                            status.IsSuccess = false;
                            status.Message = "Cupo diario Excedido.";
                            return status;
                        }
                    }

                    //Saldo Disponible
                    var valorSaldoDisponible = datosCuenta.SaldoInicial + movimiento.Valor;

                    if (valorSaldoDisponible < 0)
                    {
                        status.IsSuccess = false;

                        status.Message = "Saldo no disponible";
                        return status;
                    }
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

        /// <summary>
        /// Reporte de movimientos por rango de fechas y cliente
        /// </summary>
        /// <param name="movimiento"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<StatusViewModel> GetReporteMovimientos(ReporteMovimientosViewModel movimiento)
        {
            try
            {
                var dataReporteMovimientos = await (from cli in ctx.Clientes
                                                    join cue in ctx.Cuentas on cli.IdCliente equals cue.IdCliente
                                                    join mov in ctx.Movimientos on cue.IdCuenta equals mov.IdCuenta
                                                    where cli.IdCliente == movimiento.IdCliente
                                                    && (mov.Fecha.Date >= movimiento.FechaInicio.Date && mov.Fecha.Date <= movimiento.FechaFin)
                                                    select new
                                                    {
                                                        Fecha = mov.Fecha,
                                                        Cliente = cli.Nombre,
                                                        NumeroCuenta = cue.NumeroCuenta,
                                                        Tipo = cue.TipoCuenta,
                                                        SaldoInicial = mov.SaldoInicial,
                                                        Estado = cue.Estado,
                                                        Movimiento = mov.Valor,
                                                        SaldoDisponible = mov.Saldo
                                                    }

                                                    ).ToListAsync();

                return new StatusViewModel(isSuccess: true, message: "OK", objetoDeserealizar: dataReporteMovimientos);
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