using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosVentas : IServiciosVentas
    {
        private readonly IRepositorioVentas _repositorioVentas;
        private readonly IRepositorioDetallesVentas _repositorioDetallesVentas;
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ServiciosVentas(IRepositorioVentas repositorioVentas,
            IRepositorioDetallesVentas repositorioDetallesVentas,
            IRepositorioProductos repositorioProductos,
            IDbConnectionFactory dbConnectionFactory)
        {
            _repositorioVentas = repositorioVentas;
            _repositorioDetallesVentas = repositorioDetallesVentas;
            _repositorioProductos = repositorioProductos;
            _dbConnectionFactory = dbConnectionFactory;
        }


        public List<VentaListDto> GetLista()
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioVentas.GetLista(conn, tran);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }

        }

        public Producto? GetProductoPorId(TipoProducto tipoProducto, int productoId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (tipoProducto == TipoProducto.Bombon)
                        {
                            return _repositorioProductos.GetProductoPorId(conn, tran, TipoProducto.Bombon, productoId);

                        }
                        else
                        {
                            return _repositorioProductos.GetProductoPorId(conn, tran,TipoProducto.Caja, productoId);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public VentaDetalleDto GetVentaConDetalle(int ventaId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return new VentaDetalleDto
                        {
                            Venta = _repositorioVentas
                                .GetVentaPorId(conn, tran, ventaId),
                            Detalles = _repositorioDetallesVentas
                            .GetLista(conn, tran, ventaId)
                        };
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }


        }

        public void Guardar(Venta venta)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorioVentas.Agregar(conn, tran, venta);
                        foreach (var itemVenta in venta.Detalles)
                        {
                            itemVenta.VentaId = venta.VentaId;
                            _repositorioDetallesVentas.Agregar(conn, tran, itemVenta); 
                            _repositorioProductos.ActualizarStock(conn,tran, itemVenta);
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }

                }
            }

        }
    }
}
