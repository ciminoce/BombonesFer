using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmCtasCtes : Form
    {
        private readonly IServiciosCtasCtes? _servicios;
        private readonly IServiciosClientes? _serviciosClientes;
        private List<CtaCteListDto>? lista;
        public frmCtasCtes(IServiciosCtasCtes servicios, IServiciosClientes? serviciosClientes)
        {
            InitializeComponent();
            _servicios = servicios;
            _serviciosClientes = serviciosClientes;
        }
        private void frmCtasCtes_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios?.GetLista();
                GridHelper.MostrarDatosEnGrilla<CtaCteListDto>(lista, dgvDatos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];

            if (r.Tag is not null)
            {
                CtaCteListDto ctaDto=(CtaCteListDto)r.Tag;
                try
                {
                    var cliente = _serviciosClientes?
                        .GetClientePorId(ctaDto.ClienteId);
                    List<CtaCte> listaMovimientosCtaCte=_servicios.GetDetalle(ctaDto.ClienteId);
                    frmDetalleCtasCtes frm = new frmDetalleCtasCtes() { Text = "Detalle de Cta. Cte." };
                    frm.SetCliente(cliente);
                    frm.SetDetalle(listaMovimientosCtaCte);
                    frm.ShowDialog(this);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}
