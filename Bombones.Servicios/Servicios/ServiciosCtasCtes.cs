using Bombones.Comun.IRepositorios;
using Bombones.Comun;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using System.Data;
using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosCtasCtes : IServiciosCtasCtes
    {
        private readonly IRepositorioCtasCtes _repositorio;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ServiciosCtasCtes(IDbConnectionFactory dbConnectionFactory, 
            IRepositorioCtasCtes repositorio)
        {
            _repositorio = repositorio;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public List<CtaCte> GetDetalle(int clienteId)
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorio.GetDetalle(conn, tran, clienteId);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }

        public List<CtaCteListDto> GetLista()
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
