using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Windows.Classes;

namespace Bombones.Windows.Helpers
{
    public static class GridHelper
    {
        public static void MostrarDatosEnGrilla<T>(List<T> ? lista, DataGridView dgvDatos)
        {
            GridHelper.LimpiarGrilla(dgvDatos);  // Limpia la grilla
            
            if (lista != null)
            {
                foreach (var t in lista)
                {
                    if (t != null)
                    {
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);    // La fila r recibe el resultado de ConstruirFila
                        GridHelper.SetearFila(r, t);    // Ubica los datos en los campos correspondientes
                        GridHelper.AgregarFila(dgvDatos, r); // Agregar la fila a la grilla dgvDatos 
                    }
                } 
            }
        }

        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();  // Limpia la grilla dgv
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)    // Método de tipo DataGridViewRow
        {
            var r = new DataGridViewRow();      // declara una fila r del tipo DataGridView
            r.CreateCells(dgv);        // Crea las celdas dentro de la fila r dentro de dgv
            return r;
        }
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);       // Agrega la fila r a la grilla dgvDatos
        }
        public static void SetearFila(DataGridViewRow r, object item)  // item pertenece a objetc, la clase base
        {
            switch (item)
            {
                case TipoDeChocolate chocolate:
                    r.Cells[0].Value = chocolate.Descripcion;   // En la celda 0, guarda el contenido de chocolate.Descripcion
                    r.Cells[1].Value = chocolate.Stock;
                    break;
                case TipoDeNuez nuez:
                    r.Cells[0].Value = nuez.Descripcion;
                    r.Cells[1].Value = nuez.Stock;
                    break;
                case TipoDeRelleno relleno:
                    r.Cells[0].Value = relleno.Descripcion;
                    r.Cells[1].Value = relleno.Stock;
                    break;
                case Pais pais:
                    r.Cells[0].Value = pais.NombrePais;
                    break;
                case FabricaListDto fabricaDto:
                    r.Cells[0].Value = fabricaDto.NombreFabrica;
                    r.Cells[1].Value = fabricaDto.Direccion;
                    r.Cells[2].Value = fabricaDto.Pais;
                    break;
                case BombonListDto bombonDto:
                    r.Cells[0].Value = bombonDto.Nombre;
                    r.Cells[1].Value = bombonDto.TipoDeChocolate;
                    r.Cells[2].Value = bombonDto.TipoDeNuez;
                    r.Cells[3].Value = bombonDto.TipoDeRelleno;
                    r.Cells[4].Value = bombonDto.Fabrica;
                    r.Cells[5].Value = bombonDto.Precio;
                    r.Cells[6].Value = bombonDto.Stock;
                    break;
                case CajaListDto cajaListDto:
                    r.Cells[0].Value = cajaListDto.Nombre;
                    r.Cells[1].Value = cajaListDto.CantidadBombones;
                    r.Cells[2].Value = cajaListDto.Variedades;
                    r.Cells[3].Value = cajaListDto.Stock;
                    r.Cells[4].Value = cajaListDto.Precio;
                    r.Cells[5].Value = cajaListDto.Suspendido;
                    break;
                case DetalleCajaBombonDto detalleCajaDto:
                    r.Cells[0].Value = detalleCajaDto.NombreBombon;
                    r.Cells[1].Value = detalleCajaDto.Cantidad;
                    break;
                case VentaListDto ventaDto:
                    r.Cells[0].Value = ventaDto.VentaId;
                    r.Cells[1].Value = ventaDto.Cliente;
                    r.Cells[2].Value = ventaDto.FechaVenta.ToShortDateString();
                    r.Cells[3].Value = ventaDto.Regalo;
                    r.Cells[4].Value = ventaDto.Total.ToString("C");
                    r.Cells[5].Value = ventaDto.EstadoVenta;
                    break;
                case DetalleVentaDto detalleVentaDto:
                    r.Cells[0].Value = detalleVentaDto.Producto;
                    r.Cells[1].Value = detalleVentaDto.Cantidad;
                    r.Cells[2].Value = detalleVentaDto.Precio;
                    r.Cells[3].Value = detalleVentaDto.Total.ToString("C");
                    break;
                case ItemCarrito itemCarrito:
                    r.Cells[0].Value = itemCarrito.Nombre;
                    r.Cells[1].Value = itemCarrito.Precio;
                    r.Cells[2].Value = itemCarrito.Cantidad;                    
                    r.Cells[3].Value = itemCarrito.Total.ToString("C");
                    break;
                case CtaCteListDto ctaCteListDto:
                    r.Cells[0].Value=ctaCteListDto.Cliente;
                    r.Cells[1].Value=ctaCteListDto.Saldo.ToString("C");
                    break;
                case CtaCte ctacte:
                    r.Cells[0].Value = ctacte.FechaMovimiento.ToShortDateString();
                    r.Cells[1].Value = ctacte.Movimiento;
                    r.Cells[2].Value = ctacte.Debe.ToString("C");
                    r.Cells[3].Value = ctacte.Haber.ToString("C");
                    r.Cells[4].Value=ctacte.Saldo.ToString("C");
                    break;

            }
            r.Tag = item;
        }

        public static void BorrarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);

        }
    }
}
