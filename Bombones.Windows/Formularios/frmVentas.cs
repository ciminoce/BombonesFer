using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Extensions;
using Bombones.IoC;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmVentas : Form
    {
        private readonly IServiciosVentas _servicios;
        private List<VentaListDto>? lista;
        public frmVentas(IServiciosVentas servicios)
        {
            InitializeComponent();
            _servicios = servicios;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios.GetLista();
                GridHelper.MostrarDatosEnGrilla<VentaListDto>(lista, dgvDatos);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];

            if (r.Tag is not null)
            {
                VentaListDto ventaDto = (VentaListDto)r.Tag;
                try
                {
                    VentaDetalleDto ventaDetalleDto = _servicios
                        .GetVentaConDetalle(ventaDto.VentaId);
                    frmDetalleVenta frm = new frmDetalleVenta() { Text = "Detalle de la Venta" };
                    frm.SetVenta(ventaDetalleDto);
                    frm.ShowDialog(this);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmVentasAE frm = new frmVentasAE(DI.Create<IServiciosVentas>(), DI.Create<IServiciosProductos>());
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Venta? venta = frm.GetVenta();
                if (venta is null) return;
                _servicios.Guardar(venta);
                VentaListDto ventaDto = VentasExtensions.ToVentaListDto(venta);
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, ventaDto);
                GridHelper.AgregarFila(dgvDatos, r);
                MessageBox.Show("Venta agregada!!", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
