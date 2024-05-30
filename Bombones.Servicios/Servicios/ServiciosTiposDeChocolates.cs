using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using System.Data;


namespace Bombones.Servicios.Servicios
{
    // Se encarga de comunicar la GUI con las Entidades
    // Tiene como dependencias a Entidades y Datos
    public class ServiciosTiposDeChocolates : IServiciosTiposDeChocolates
    {
        private readonly IRepositorioTiposDeChocolates _repositorio;
        private readonly IDbConnectionFactory _dbConnectionFactory;


        public ServiciosTiposDeChocolates(IRepositorioTiposDeChocolates repositorio,
            IDbConnectionFactory dbConnectionFactory)
        {
            _repositorio = repositorio;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public bool EstaRelacionado(int tipoDeChocolateId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.EstaRelacionado(conn, tran, tipoDeChocolateId);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Borrar(int tipoDeChocolateId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        _repositorio.Borrar(conn, tran, tipoDeChocolateId);
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

        public List<TipoDeChocolate> GetLista()
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

        public bool Existe(TipoDeChocolate tipoDeChocolate)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.Existe(conn, tran, tipoDeChocolate);      // Le pide al método Existe de Datos si el pais existe

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Guardar(TipoDeChocolate tipoDeChocolate)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (tran = conn.BeginTransaction())
                    {
                        if (tipoDeChocolate.TipoDeChocolateId == 0)
                        {
                            _repositorio.Agregar(conn, tran, tipoDeChocolate);
                        }
                        else
                        {
                            // Si tiene un id, entonces ha que editar el país existente
                            _repositorio.Editar(conn, tran, tipoDeChocolate);
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
