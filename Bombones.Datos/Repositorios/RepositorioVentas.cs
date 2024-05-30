using Bombones.Comun;
using Bombones.Comun.IRepositorios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly IDbCommandFactory _commandFactory;

        // Constructor
        public RepositorioVentas(IDbCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Agregar(IDbConnection conn, IDbTransaction tran, Venta venta)
        {
            string insertQuery = @"INSERT INTO Ventas (ClienteId,
                FechaVenta, Regalo, Total, Estado) VALUES 
                (@ClienteId, @Fecha, @Regalo, @Total, @Estado);
                 SELECT @@IDENTITY";
            using (var cmd=_commandFactory.CreateCommand())
            {
                cmd.CommandText = insertQuery;
                cmd.Connection = conn;
                cmd.Transaction = tran;
                if (venta.ClienteId==999999)
                {
                    _commandFactory.AddParameter(cmd, "@ClienteId", DBNull.Value);
                }
                else
                {
                    _commandFactory.AddParameter(cmd, "@ClienteId",venta.ClienteId);
                }
                _commandFactory.AddParameter(cmd, "@Fecha", venta.FechaVenta);
                _commandFactory.AddParameter(cmd, "@Regalo",venta.Regalo);
                _commandFactory.AddParameter(cmd, "@Total", venta.Total);
                _commandFactory.AddParameter(cmd, "@Estado",venta.EstadoVenta);

                int ventaId=Convert.ToInt32(cmd.ExecuteScalar());
                if (ventaId > 0) { 
                    venta.VentaId = ventaId;
                }
                else
                {
                    throw new Exception("No se pudo agregar la venta");
                }

            }
        }

        public List<VentaListDto> GetLista(IDbConnection conn, IDbTransaction tran)
        {
            List<VentaListDto> lista = new List<VentaListDto>();
            string selectQuery = @"SELECT v.VentaId, 
                       COALESCE(c.Apellido + ' ' + c.Nombre, 'Consumidor Final') AS Cliente,
                       v.FechaVenta, 
                       v.Regalo, 
                       v.Total, 
                       v.Estado
                FROM Ventas v
                LEFT JOIN Clientes c ON v.ClienteId = c.ClienteId";


            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                using (var reader = (SqlDataReader)cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ventaDto = ConstruirVentaDto(reader);
                        lista.Add(ventaDto);
                    }
                }
            }
            return lista;

        }

        public VentaListDto GetVentaPorId(IDbConnection conn,
            IDbTransaction tran, int ventaId)
        {
            VentaListDto ventaDto = null!;
            string selectQuery = @"SELECT v.VentaId, 
                       COALESCE(c.Apellido + ' ' + c.Nombre, 'Consumidor Final') AS Cliente,
                       v.FechaVenta, 
                       v.Regalo, 
                       v.Total, 
                       v.Estado
                    FROM Ventas v
                    LEFT JOIN Clientes c ON v.ClienteId = c.ClienteId
                WHERE v.VentaId=@VentaId";

            using (var cmd = _commandFactory.CreateCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = selectQuery;
                cmd.Transaction = tran;

                _commandFactory.AddParameter(cmd, "@VentaId", ventaId);

                using (var reader = (SqlDataReader)cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ventaDto = ConstruirVentaDto(reader);
                    }
                }
            }
            return ventaDto;
        }

        private VentaListDto ConstruirVentaDto(SqlDataReader reader)
        {
            return new VentaListDto
            {
                VentaId = reader.GetInt32(0),
                Cliente = reader.GetString(1),
                FechaVenta = reader.GetDateTime(2),
                Regalo = reader.GetBoolean(3),
                Total = reader.GetDecimal(4),
                EstadoVenta = (EstadoVenta)reader.GetByte(5)
            };
        }
    }
}
