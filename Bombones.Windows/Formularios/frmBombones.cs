using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Entidades.Extensions;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmBombones : Form
    {
        //private readonly IServiciosBombones _servicio;
        private readonly IServiciosProductos _servicio;
        private List<ProductoListDto>? lista;
        private TipoProducto tipo=TipoProducto.Bombon;//Para saber con que producto trabajo
        public frmBombones(IServiciosProductos servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBombones_Load(object sender, EventArgs e)
        {
            try
            {
                // lista recibe el resultado del método GetLista del objeto
                // serviciosFabrica (una lista de fábricas
                lista = _servicio.GetLista(tipo);
                GridHelper.MostrarDatosEnGrilla<ProductoListDto>(lista,dgvDatos);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmBombonAE frm = new frmBombonAE() { Text = "Nuevo Bombón" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                Bombon? bombon = frm.GetBombon();

                if (bombon is not null)
                {
                    if (!_servicio.Existe(bombon))
                    {
                        _servicio.Guardar(bombon);
                        //var bombonListDto = _servicio.GetBombonListDtoPorId(bombon.BombonId);
                        var r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, ProductoExtensions
                            .FromProductoToBombonListDto(bombon));
                        GridHelper.AgregarFila(dgvDatos, r);
                        MessageBox.Show("Registro Agregado Satisfactoriamente!!",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("Bombon Repetido!!!",
                            "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)    // Si no hay filas seleccionadas en la grilla...
            {
                return;     // no hago nada
            }
            var r = dgvDatos.SelectedRows[0];       // r = la primera (y única) fila seleccionada
                                                    // Tag contiene el objeto completo. Hay una tag por fila. Object se castea a TipoDeChocolate
            if (r.Tag is not null)
            {
                var bombonListDto = (BombonListDto)r.Tag;

                try
                {       // Ventana modal pidiendo confirmación para borrar
                    DialogResult dr = MessageBox.Show($"¿Desea dar de baja al bombon {bombonListDto.Nombre}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.No)
                    {
                        return;     // Si se presiona No, cancelar
                    }
                    if (!_servicio.EstaRelacionado(tipo, bombonListDto.ProductoId))  // Si el chocolate no está relacionado, borrar
                    {
                        _servicio.Borrar(tipo, bombonListDto.ProductoId);
                        // Si se pudo borrar el chocolate de la base de datos...
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)   // Si no hay filas seleccionadas, salgo
            {
                return;
            }
            try
            {
                var r = dgvDatos.SelectedRows[0];

                if (r.Tag is not null)
                {
                    var bombonListDto = (BombonListDto)r.Tag;
                    var bombon = _servicio.GetProductoPorId(tipo, bombonListDto.ProductoId);
                    if (bombon is not null)
                    {
                        frmBombonAE frm = new frmBombonAE { Text = "Editar Bombón" };  // Crea un formulario frm del tipo frmPaisesAE
                                                                                       // Toma los datos pais (que a su vez lo toma de la Tag) y completa el frm
                        frm.SetBombon((Bombon)bombon);
                        // Ventana modal. El resultado de la interacción se guarda en dr.                
                        DialogResult dr = frm.ShowDialog(this);

                        if (dr == DialogResult.Cancel)       // Si presionan cancelar, no hace nada
                        {
                            return;
                        }
                        bombon = frm.GetBombon();        // Ahora pais toma los datos nuevos

                        if (bombon is not null)
                        {
                            if (!_servicio.Existe(bombon))       // Si no existe el pais, lo edita
                            {
                                _servicio.Guardar(bombon);
                                //bombonListDto = _servicio.GetBombonListDtoPorId(bombon.BombonId);
                                GridHelper.SetearFila(r, ProductoExtensions
                                    .FromProductoToBombonListDto((Bombon)bombon));

                                MessageBox.Show("Registro editado satisfactoriamente",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Registro existente\nAlta denegada",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

        }
    }
}
