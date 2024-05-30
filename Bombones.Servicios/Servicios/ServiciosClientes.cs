using Bombones.Comun.Interfaces;
using Bombones.Comun;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using Bombones.Comun.IRepositorios;
using Bombones.Datos.Repositorios;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repositorio;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ServiciosClientes(IDbConnectionFactory dbConnectionFactory, IRepositorioClientes repositorio)
        {
            _repositorio = repositorio;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public List<Cliente> GetLista()
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.GetLista(conn, tran);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }
    }
}
