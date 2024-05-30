using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosTiposDeNueces : IServiciosTiposDeNueces
    {
        private readonly IRepositorioTiposDeNueces _repositorio;
        private readonly IDbConnectionFactory _dbConnectionFactory;


        public ServiciosTiposDeNueces(IRepositorioTiposDeNueces repositorio,
            IDbConnectionFactory dbConnectionFactory)
        {
            _repositorio = repositorio;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public bool EstaRelacionado(int tipoDeNuezId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.EstaRelacionado(conn, tran, tipoDeNuezId);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Borrar(int tipoDeNuezId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        _repositorio.Borrar(conn, tran, tipoDeNuezId);
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

        public List<TipoDeNuez> GetLista()
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

        public bool Existe(TipoDeNuez tipoDeNuez)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.Existe(conn, tran, tipoDeNuez);      // Le pide al método Existe de Datos si el pais existe

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Guardar(TipoDeNuez tipoDeNuez)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (tran = conn.BeginTransaction())
                    {
                        if (tipoDeNuez.TipoDeNuezId == 0)
                        {
                            _repositorio.Agregar(conn, tran, tipoDeNuez);
                        }
                        else
                        {
                            // Si tiene un id, entonces ha que editar el país existente
                            _repositorio.Editar(conn, tran, tipoDeNuez);
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
