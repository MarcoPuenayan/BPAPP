using BPAPP.Commons;
using BPAPP.Data;
using BPAPP.Interfaces;
using BPAPP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BPAPP.Services
{
    public class CuentasServices : ICuentas
    {
        #region : Campos

        private readonly ILogger _logger;
        private ApplicationDbContext ctx;
        public IConfiguration Configuration { get; }

        #endregion : Campos

        #region : Constructor

        public CuentasServices(ILogger<CuentasServices> logger, ApplicationDbContext ctx, IConfiguration Configuration)
        {
            this.ctx = ctx;
            _logger = logger;
            this.Configuration = Configuration;
        }

        #endregion : Constructor

        #region : Metodos

        public async Task<Cuenta> DeleteCuentas(Guid id)
        {
            try
            {
                var dataCuentas = await ctx.Cuentas.Where(x => x.IdCuenta == id).SingleOrDefaultAsync();
                dataCuentas.Estado = false;
                await ctx.SaveChangesAsync();
                return dataCuentas;
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

        public async Task<Cuenta> GetCuenta(Guid id)
        {
            try
            {
                var dataCuentas = await ctx.Cuentas.Where(x => x.IdCuenta == id).SingleOrDefaultAsync();
                return dataCuentas;
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

        public async Task<List<Cuenta>> GetCuentas()
        {
            try
            {
                var dataCuentas = await ctx.Cuentas.ToListAsync();
                return dataCuentas;
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
        /// Creacion de cuenta, primer movimiento
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        public async Task<Cuenta> PostCuentas(CuentaViewModel cuenta)
        {
            try
            {
                //Creacion de cuenta
                Cuenta _cuenta = new Cuenta();

                _cuenta.IdCuenta = Guid.NewGuid();
                _cuenta.NumeroCuenta = cuenta.NumeroCuenta;
                _cuenta.TipoCuenta = cuenta.TipoCuenta;
                _cuenta.SaldoInicial = cuenta.SaldoInicial;
                _cuenta.Estado = cuenta.Estado;
                _cuenta.IdCliente = cuenta.IdCliente;
                _cuenta.LimiteDiario = 1000;
                ctx.Cuentas.Add(_cuenta);
                await ctx.SaveChangesAsync();

                //Primer movimiento de cuenta
                Movimiento _movimiento = new Movimiento();
                _movimiento.IdMovimiento = Guid.NewGuid();
                _movimiento.Fecha = DateTime.Now;
                _movimiento.Tipo = Constantes.CREACION;
                _movimiento.Movimientos = Constantes.CREACIONCUENTA;
                _movimiento.Valor = 0;
                _movimiento.Saldo = cuenta.SaldoInicial;
                _movimiento.SaldoInicial = cuenta.SaldoInicial;
                _movimiento.IdCuenta = _cuenta.IdCuenta;

                ctx.Movimientos.Add(_movimiento);
                await ctx.SaveChangesAsync();

                return _cuenta;
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

        public async Task<Cuenta> PutCuentas(CuentaViewModel cuenta, Guid id)
        {
            try
            {
                var dataCuenta = await ctx.Cuentas.Where(x => x.IdCliente == id).SingleOrDefaultAsync();
                dataCuenta.NumeroCuenta = cuenta.NumeroCuenta;
                dataCuenta.TipoCuenta = cuenta.TipoCuenta;

                await ctx.SaveChangesAsync();
                return dataCuenta;
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

        public async Task<StatusViewModel> ExistCuentas(CuentaViewModel cuenta)
        {
            try
            {
                StatusViewModel status = new StatusViewModel();

                var data = await ctx.Cuentas.Where(x => x.IdCliente == cuenta.IdCliente && x.NumeroCuenta == cuenta.NumeroCuenta).AnyAsync();

                if (data)
                {
                    status.IsSuccess = false;
                    status.Message = "Cuenta ya existe..";
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