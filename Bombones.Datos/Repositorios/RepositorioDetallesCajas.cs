using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioDetallesCajas : IRepositorioDetallesCajas
    {
        private readonly IDbCommandFactory _commandFactory;

        public RepositorioDetallesCajas(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Agregar(IDbConnection conn, IDbTransaction tran, DetalleCaja detalleCaja)
        {
            int primaryKey = -1;
            string insertQuery = @"INSERT INTO DetallesCajas (CajaId, BombonId, Cantidad) 
                VALUES (@CajaId, @BombonId, @Cantidad); SELECT @@IDENTITY";
            using (var cmd=_commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = insertQuery;

                _commandFactory.AddParameter(cmd,"@CajaId",detalleCaja.CajaId);
                _commandFactory.AddParameter(cmd, "@BombonId", detalleCaja.BombonId);
                _commandFactory.AddParameter(cmd, "@Cantidad", detalleCaja.Cantidad);

                var result=cmd.ExecuteScalar();
                if (result!=null)
                {
                    primaryKey = Convert.ToInt32(result);
                    detalleCaja.DetalleCajaId = primaryKey;
                }
                else
                {
                    throw new Exception("Error al intentar agregar un detalle de caja");
                }


            }
        }

        public void EliminarPorCaja(IDbConnection conn, IDbTransaction tran, int cajaId)
        {
            string deleteQuery = "DELETE FROM DetallesCajas WHERE CajaId = @CajaId";

            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.CommandText = deleteQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@CajaId", cajaId);

                int registrosAfectados = cmd.ExecuteNonQuery();
                if (registrosAfectados == 0)
                {
                    throw new Exception("No se pudieron eliminar los Detalles de Caja");
                }
            }
        }

        public List<DetalleCajaBombonDto> GetDetalleCajas(IDbConnection conn, IDbTransaction tran, int cajaId)
        {
            List<DetalleCajaBombonDto> lista=new List<DetalleCajaBombonDto>();
            string selectQuery = @"SELECT b.BombonId, b.NombreBombon, dc.Cantidad 
                        FROM DetallesCajas dc 
                        INNER JOIN Bombones b ON dc.BombonId=b.BombonId 
                        WHERE CajaId=@CajaId";
            using (var cmd=_commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = selectQuery;

                _commandFactory.AddParameter(cmd,"@CajaId",cajaId);

                using (var reader=cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DetalleCajaBombonDto detalleDto = ConstruirDetalleCajaDto(reader);
                        lista.Add(detalleDto);
                    }
                }
            }
            return lista;
        }

        private DetalleCajaBombonDto ConstruirDetalleCajaDto(IDataReader reader)
        {
            return new DetalleCajaBombonDto
            {
                BombonId = reader.GetInt32(0),
                NombreBombon = reader.GetString(1),
                Cantidad = reader.GetInt32(2)
            };
        }
    }
}
