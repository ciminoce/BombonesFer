using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Entidades.Extensions;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmCajas : Form
    {
        private readonly IServiciosProductos _servicios;
        private readonly TipoProducto tipoProducto = TipoProducto.Caja;
        private List<ProductoListDto>? lista;
        public frmCajas(IServiciosProductos serviciosCajas)
        {
            InitializeComponent();
            _servicios = serviciosCajas;
        }

        private void frmCajas_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios.GetLista(tipoProducto);
                GridHelper.MostrarDatosEnGrilla<ProductoListDto>(lista, dgvDatos);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCajasAE frm = new frmCajasAE() { Text = "Nueva Caja" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Caja? caja = frm.GetCaja();
                if (caja is not null)
                {
                    if (!_servicios.Existe(caja))
                    {
                        _servicios.Guardar(caja);

                        var r = GridHelper.ConstruirFila(dgvDatos);       // Construye la fila y la guarda en r, variable del tipo GridViewRow
                        GridHelper.SetearFila(r, CajasExtensions.ToCajaListDto(caja));      // Setea la fila r con los datos de objeto tipoDeChocolate
                        GridHelper.AgregarFila(dgvDatos, r);     // Agregar la fila r a dgvDatos
                        MessageBox.Show("Registro agregado",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);       // Ventana emergente con un mensaje 

                    }

                } 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
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
                CajaListDto cajaListDto = (CajaListDto)r.Tag;
                CajaDetalleDto cajaDetalleDto = _servicios.GetCajaDetalle(cajaListDto.ProductoId);
                frmCajaDetalle frm = new frmCajaDetalle() { Text = "Detalle de la Caja" };
                frm.SetDetalle(cajaDetalleDto);
                frm.ShowDialog(this);

            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if(r.Tag is not null)
            {
                CajaListDto cajaListDto = (CajaListDto)r.Tag;
                Caja? caja = (Caja?)_servicios.GetProductoPorId(tipoProducto,
                    cajaListDto.ProductoId);
                try
                {
                    frmCajasAE frm = new frmCajasAE() { Text = "Editar Caja" };
                    frm.SetCaja(caja);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.Cancel) { return; }
                    caja = frm.GetCaja();
                    if (caja is not null)
                    {
                        if (!_servicios.Existe(caja))
                        {
                            _servicios.Guardar(caja);
                            GridHelper.SetearFila(r, CajasExtensions.ToCajaListDto(caja));      // Setea la fila r con los datos de objeto tipoDeChocolate
                            MessageBox.Show("Registro editado",
                                            "Mensaje",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);       // Ventana emergente con un mensaje 

                        }
                        else
                        {
                            MessageBox.Show("Registro duplicado,\nedición denegada",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                        }

                    }                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if(r.Tag is not null)
            {
                CajaListDto cajaListDto = (CajaListDto)r.Tag;
                try
                {       // Ventana modal pidiendo confirmación para borrar
                    DialogResult dr = MessageBox.Show($"¿Desea dar de baja la caja {cajaListDto.Nombre}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.No)
                    {
                        return;     // Si se presiona No, cancelar
                    }
                    if (!_servicios.EstaRelacionado(tipoProducto, cajaListDto.ProductoId))  // Si el chocolate no está relacionado, borrar
                    {
                        _servicios.Borrar(tipoProducto, cajaListDto.ProductoId);
                        dgvDatos.Rows.Remove(r);    // Elimina la fila de la GRILLA
                        MessageBox.Show("Registro eliminado satisfactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro relacionado,\neliminación denegada",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)    // objeto Exception ex
                {
                    MessageBox.Show(ex.Message,     // Muestro el mensaje del objeto ex
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
        }
    }
}
