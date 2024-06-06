using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioCtasCtes : IRepositorioCtasCtes
    {
        private readonly IDbCommandFactory _commandFactory;

        public RepositorioCtasCtes(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Agregar(IDbConnection conn, IDbTransaction tran,CtaCte ctaCte)
        {
            var primaryKey = -1;
            var insertQuery = @"INSERT INTO CtasCtes (ClienteId, FechaMovimiento,
                Movimiento, Debe, Haber, Saldo) VALUES (@ClienteId, @Fecha,
                @Mov, @Debe, @Haber, @Saldo); SELECT CAST(SCOPE_IDENTITY() AS int)";
            using (var _cmd=_commandFactory.CreateCommand())
            {
                _cmd.Connection = conn;
                _cmd.Transaction = tran;
                _cmd.CommandText=insertQuery;

                _commandFactory.AddParameter(_cmd, "@ClienteId",ctaCte.ClienteId);
                _commandFactory.AddParameter(_cmd, "@Fecha",ctaCte.FechaMovimiento);
                _commandFactory.AddParameter(_cmd, "@Mov", ctaCte.Movimiento);
                _commandFactory.AddParameter(_cmd, "@Debe", ctaCte.Debe);
                _commandFactory.AddParameter(_cmd, "@Haber", ctaCte.Haber);
                _commandFactory.AddParameter(_cmd, "@Saldo", ctaCte.Saldo);
                var result = _cmd.ExecuteScalar();
                if (result != null)
                {
                    primaryKey = Convert.ToInt32(result);
                    ctaCte.CtaCteId = primaryKey;
                }
                else
                {
                    throw new Exception("No se pudo agregar el registro");
                }

            }
        }

        public List<CtaCte> GetDetalle(IDbConnection conn, IDbTransaction tran, int clienteId)
        {
            List<CtaCte> lista = new List<CtaCte>();
            var selectQuery = @"SELECT * FROM CtasCtes WHERE ClienteId=@ClienteId"; 
                
            using (var _cmd = _commandFactory.CreateCommand())
            {
                _cmd.Connection = conn;
                _cmd.CommandText = selectQuery;
                _cmd.Transaction = tran;

                _commandFactory.AddParameter(_cmd, "@ClienteId", clienteId);

                using (var reader = _cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        var ctaCte = ConstruirDetalleCtaCte(reader);
                        lista.Add(ctaCte);
                    }
                }
            }
            return lista;

        }

        private CtaCte ConstruirDetalleCtaCte(IDataReader reader)
        {
            return new CtaCte
            {
                CtaCteId = reader.GetInt32(0),
                ClienteId=reader.GetInt32(1),
                FechaMovimiento=reader.GetDateTime(2),
                Movimiento=reader.GetString(3),
                Debe=reader.GetDecimal(4),
                Haber=reader.GetDecimal(5),
                Saldo=reader.GetDecimal(6),
            };

        }

        public List<CtaCteListDto> GetLista(IDbConnection conn, IDbTransaction tran)
        {
            List<CtaCteListDto> lista=new List<CtaCteListDto>();
            var selectQuery = @"SELECT cc.ClienteId, c.Apellido+' '+c.Nombre As Cliente,
                cc.Saldo FROM CtasCtes cc 
                INNER JOIN Clientes c ON cc.ClienteId=c.ClienteId";
            using (var _cmd=_commandFactory.CreateCommand())
            {
                _cmd.Connection = conn;
                _cmd.CommandText = selectQuery;
                _cmd.Transaction = tran;

                using (var reader=_cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ctaCte = ConstruirCtaCte(reader);
                        lista.Add(ctaCte);
                    }
                }
            }
            return lista;
        }

        private CtaCteListDto ConstruirCtaCte(IDataReader reader)
        {
            return new CtaCteListDto
            {
                ClienteId = reader.GetInt32(0),
                Cliente = reader.GetString(1),
                Saldo = reader.GetDecimal(2),
            };
        }
    }
}
