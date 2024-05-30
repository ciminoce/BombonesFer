using Bombones.Entidades.Dtos;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmDetalleVenta : Form
    {
        private VentaDetalleDto ventaDto;
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        public void SetVenta(VentaDetalleDto ventaDetalleDto)
        {
            ventaDto = ventaDetalleDto;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtVentaNro.Text = ventaDto.Venta.VentaId.ToString();
            txtCliente.Text = ventaDto.Venta.Cliente;
            txtEstado.Text = ventaDto.Venta.EstadoVenta.ToString();
            txtFecha.Text = ventaDto.Venta.FechaVenta.ToShortDateString();
            chkRegalo.Checked = ventaDto.Venta.Regalo;
            txtTotal.Text = ventaDto.Venta.Total.ToString("C");
            GridHelper.MostrarDatosEnGrilla<DetalleVentaDto>(ventaDto.Detalles,
                dgvDatos);
        }
    }
}
