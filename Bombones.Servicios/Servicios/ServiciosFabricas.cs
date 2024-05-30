using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosFabricas : IServiciosFabricas
    // Comunica la GUI con la capa Datos
    {
        private readonly IRepositorioFabricas _repositorioFabrica;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public ServiciosFabricas(IDbConnectionFactory dbConnectionFactory, IRepositorioFabricas repositorioFabrica)
        {
            _repositorioFabrica = repositorioFabrica;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void Borrar(int fabricaId)
        {
            IDbTransaction tran = null!;
            using (var conn=_dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran=conn.BeginTransaction())
                {
                    try
                    {
                        _repositorioFabrica.Borrar(conn, tran, fabricaId);
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

        public bool EstaRelacionado(int fabricaId)
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioFabrica.EstaRelacionado(conn, tran, fabricaId);
                        

                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }

        public bool Existe(Fabrica fabrica)
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioFabrica.Existe(conn, tran, fabrica);


                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }

        }

        public FabricaListDto GetFabricaListDtoPorId(int fabricaId)
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioFabrica.GetFabricaListDtoPorId(conn, tran, fabricaId);


                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }

        public Fabrica GetFabricaPorId(int fabricaId)
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioFabrica.GetFabricaPorId(conn, tran, fabricaId);


                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }

        public List<Fabrica> GetFabricas()
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioFabrica.GetFabricas(conn, tran);


                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }

        public List<FabricaListDto> GetLista(Pais? pais = null) // Si pais es null devuelve la lista completa
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioFabrica.GetLista(conn, tran, pais);


                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }

        public List<FabricaComboDto> GetListaCombo()
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        return _repositorioFabrica.GetListaCombo(conn, tran);


                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }
        }

        public void Guardar(Fabrica fabrica)
        {
            IDbTransaction tran = null!;
            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                conn.Open();
                using (tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (fabrica.FabricaId == 0)  // La fábrica es nueva
                        {
                            _repositorioFabrica.Agregar(conn, tran, fabrica);    // La capa datos agrega la fábrica a la base de datos
                        }
                        else
                        {
                            _repositorioFabrica.Editar(conn, tran, fabrica); // La fábrica ya existe, entonces la edita
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
