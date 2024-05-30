using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosPaises : IServiciosPaises
    {
        // Variable privada de sólo lectura del tipo IRepositorioPais
        private readonly IRepositorioPaises _repositorio;
        private readonly IDbConnectionFactory _dbConnectionFactory;
        // Constructor de la clase que recibe como parámetro un objeto IRepositorioPais
        public ServiciosPaises(IDbConnectionFactory dbConnectionFactory, IRepositorioPaises repositorio)
        {
            _repositorio = repositorio; // Ambos objetos IRepositorioPais
            _dbConnectionFactory = dbConnectionFactory;
        }


        public bool EstaRelacionado(int paisId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.EstaRelacionado(conn, tran, paisId);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        // Informa el resultado del método del mismo nombre en la capa Datos

        public void Borrar(int paisId)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        _repositorio.Borrar(conn, tran, paisId);   // Le ordena al repositorio borrar el país de la base de datos
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

        public List<Pais> GetLista()
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.GetLista(conn, tran);        // Muestra la lista de registros del objeto _repositorio

                    }
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Existe(Pais pais)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                try
                {
                    conn.Open();
                    using (tran = conn.BeginTransaction())
                    {
                        return _repositorio.Existe(conn, tran, pais);      // Le pide al método Existe de Datos si el pais existe

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public void Guardar(Pais pais)
        {
            IDbTransaction? tran = null;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (tran = conn.BeginTransaction())
                    {
                        if (pais.PaisId == 0)
                        {
                            _repositorio.Agregar(conn, tran, pais);
                        }
                        else
                        {
                            // Si tiene un id, entonces ha que editar el país existente
                            _repositorio.Editar(conn, tran, pais);
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
