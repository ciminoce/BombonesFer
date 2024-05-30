using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Entidades.Extensions;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosProductos : IServiciosProductos
    {
        private readonly IRepositorioProductos _repositorio;
        private readonly IRepositorioDetallesCajas _repositorioDetallesCajas;
        private readonly IDbConnectionFactory _dbConnectionFactory;


        public ServiciosProductos(IRepositorioProductos repositorio,
            IRepositorioDetallesCajas repositorioDetallesCajas,
            IDbConnectionFactory dbConnectionFactory)
        {
            _repositorio = repositorio;
            _repositorioDetallesCajas = repositorioDetallesCajas;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void Borrar(TipoProducto tipo, int productoId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (tipo != TipoProducto.Bombon)
                        {
                            _repositorioDetallesCajas.EliminarPorCaja(conn, tran, productoId);
                        }
                        _repositorio.Borrar(conn, tran, tipo, productoId);
                        tran?.Commit();
                    }
                    catch (Exception)
                    {
                        tran?.Rollback();
                        throw;
                    }

                }
            }

        }

        public bool EstaRelacionado(TipoProducto tipo, int productoId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.EstaRelacionado(conn, tran, tipo, productoId);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public bool Existe(Producto producto)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.Existe(conn, tran, producto);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public List<ProductoComboDto> GetBombonesCombo()
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.GetProductosCombo(conn, tran);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public BombonListDto GetBombonListDtoPorId(int productoId)
        {
            throw new NotImplementedException();
        }

        public Producto? GetProductoPorId(TipoProducto tipo, int productoId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.GetProductoPorId(conn, tran, tipo, productoId);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public List<ProductoListDto> GetLista(TipoProducto tipoProducto)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.GetLista(conn, tran, tipoProducto);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }

        }

        public List<ProductoListDto> GetProductosVenta(TipoProducto tipo)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Producto producto)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (producto.ProductoId == 0)
                        {
                            _repositorio.Agregar(conn, tran, producto);
                        }
                        else
                        {
                            _repositorio.Editar(conn, tran, producto);
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


        public CajaDetalleDto GetCajaDetalle(int productoId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        CajaDetalleDto caja=null!;
                        var producto = _repositorio
                            .GetProductoPorId(conn, tran, TipoProducto.Caja, productoId);
                        if (producto is not null)
                        {
                            caja = ProductoExtensions.FromProductoToCajaDetalleDto(producto);
                            caja.Detalles = _repositorioDetallesCajas.GetDetalleCajas(conn, tran, productoId);

                        }
                        return caja;
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }

        }

        public List<DetalleCajaBombonDto> GetCajaDetallePorId(int cajaId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioDetallesCajas.GetDetalleCajas(conn, tran, cajaId);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }

        }

        public void ActualizarEnPedido(TipoProducto tipoProducto, int productoId, int cantidad)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio.ActualizarEnPedido(conn , tran , tipoProducto, productoId, cantidad);
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
