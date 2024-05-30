using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows
{
    public partial class frmChocolates : Form
    {
        private readonly IServiciosTiposDeChocolates _servicios;
        public frmChocolates(IServiciosTiposDeChocolates servicios)
        {
            InitializeComponent();
            _servicios = servicios;      // instancia e inicializa el objeto _servicios
        }

        private List<TipoDeChocolate>? lista;      // Se agrega la REFERENCIA a Bombones.Entidades.Entidades
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChocolates_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios.GetLista();      // la lista guarda el listado de los registros con los tipos de chocolate
                GridHelper.MostrarDatosEnGrilla<TipoDeChocolate>(lista, dgvDatos);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            // se declara a frm como un objeto de tipo frmChocolates
            frmChocolatesAE frm = new frmChocolatesAE() { Text = "Nuevo chocolate" };
            // se declara dr como objeto DialogResult y se le asigna el resultado de frm.ShowDialog
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;     // Si se presiona Cancelar, salir del DialogResult sin hacer nada
            }

            try
            {
                // le asigna el resultado de frm.GetTipo (objeto de tipo frmChocolates) a tipoDeChocolate,
                // que viene del formulario frmChocolatesAE
                TipoDeChocolate tipoDeChocolate = frm.GetTipo();

                if (!_servicios.Existe(tipoDeChocolate))
                {
                    _servicios.Guardar(tipoDeChocolate);      // Método del servicio que guarda el tipo de chocolate EN LA GRILLA
                    var r = GridHelper.ConstruirFila(dgvDatos);       // Construye la fila y la guarda en r, variable del tipo GridViewRow
                    GridHelper.SetearFila(r, tipoDeChocolate);      // Setea la fila r con los datos de objeto tipoDeChocolate
                    GridHelper.AgregarFila(dgvDatos , r);     // Agregar la fila r a dgvDatos
                    MessageBox.Show("Registro agregado",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);       // Ventana emergente con un mensaje 
                }
                else
                {
                    MessageBox.Show("Registro existente\nAlta denegada",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
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
                var chocolate = (TipoDeChocolate)r.Tag;

                try
                {       // Ventana modal pidiendo confirmación para borrar
                    DialogResult dr = MessageBox.Show($"¿Desea dar de baja al chocolate {chocolate.Descripcion}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.No)
                    {
                        return;     // Si se presiona No, cancelar
                    }
                    if (!_servicios.EstaRelacionado(chocolate.TipoDeChocolateId))  // Si el chocolate no está relacionado, borrar
                    {
                        _servicios.Borrar(chocolate.TipoDeChocolateId);
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
                var r = dgvDatos.SelectedRows[0];   // r = la primera (y única) fila seleccionada
                
                if (r.Tag is not null)
                {                                       // Chocolate recibe una copia del objeto completo desde la Tag. Castea de object a TipoDeChocolate
                    var chocolate = (TipoDeChocolate)r.Tag;
                    frmChocolatesAE frm = new frmChocolatesAE { Text = "Editar chocolate" };  // Crea un formulario frm del tipo frmChocolatesAE
                                                                                              // Toma los datos chocolate (que a su vez lo toma de la Tag) y completa el frm
                    frm.SetTipo(chocolate);
                    // Ventana modal. El resultado de la interacción se guarda en dr.                
                    DialogResult dr = frm.ShowDialog(this);

                    if (dr == DialogResult.Cancel)       // Si presionan cancelar, no hace nada
                    {
                        return;
                    }
                    chocolate = frm.GetTipo();        // Ahora chocolate toma los datos nuevos

                    if (!_servicios.Existe(chocolate))       // Si no existe el chocolate, lo edita
                    {
                        // Servicios ordena a Datos que guarde la edición en la BASE DE DATOS
                        _servicios.Guardar(chocolate);
                        GridHelper.SetearFila(r, chocolate);    // Agrega los datos en las celdas de una la fila que YA ESTÁ CREADA.
                        MessageBox.Show("Chocolate editado satisfactoriamente",
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
            catch (Exception)
            {

            }
        }       
    }
}
