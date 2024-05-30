using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    // Se encarga de comunicar la GUI con las Entidades
    // Tiene como dependencias a Entidades y Datos
    public class ServiciosTiposDeRellenos : IServiciosTiposDeRellenos
    {
        private readonly IRepositorioTiposDeRellenos _repositorio;
        private readonly IDbConnectionFactory _dbConnectionFactory;


        public ServiciosTiposDeRellenos(IRepositorioTiposDeRellenos repositorio,
            IDbConnectionFactory dbConnectionFactory)
        {
            _repositorio = repositorio;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public bool EstaRelacionado(int tipoDeRellenoId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.EstaRelacionado(conn, tran, tipoDeRellenoId);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Borrar(int tipoDeRellenoId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        _repositorio.Borrar(conn, tran, tipoDeRellenoId);
                        tran.Commit();
                    }
                }
                catch (Exception)
                {
                    tran?.Rollback();
                    throw;
                }
            }

        }

        public List<TipoDeRelleno> GetLista()
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.GetLista(conn, tran);

                    }
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Existe(TipoDeRelleno tipoDeRelleno)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.Existe(conn, tran, tipoDeRelleno);      // Le pide al método Existe de Datos si el pais existe

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Guardar(TipoDeRelleno tipoDeRelleno)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (tran = conn.BeginTransaction())
                    {
                        if (tipoDeRelleno.TipoDeRellenoId == 0)
                        {
                            _repositorio.Agregar(conn, tran, tipoDeRelleno);
                        }
                        else
                        {
                            // Si tiene un id, entonces ha que editar el país existente
                            _repositorio.Editar(conn, tran, tipoDeRelleno);
                        }
                        tran?.Commit();
                    }
                }
                catch (Exception)
                {
                    tran?.Rollback();
                    throw;
                }

            }
        }
    }
}