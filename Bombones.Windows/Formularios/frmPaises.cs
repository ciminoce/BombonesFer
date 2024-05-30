using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows
{
    public partial class frmPaises : Form // Agrega como REFERENCIA a Entidades.Entidades
    {
        private List<Pais>? lista;      // Se agrega la REFERENCIA a Bombones.Entidades.Entidades
        private readonly IServiciosPaises _servicios;      // Declaración de un objeto _servicios del tipo IServiciosPais
        public frmPaises(IServiciosPaises servicios)
        {
            InitializeComponent();
            _servicios = servicios;      // asigna el servicio pasado como parámetro al constructor
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPaises_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios.GetLista();      // la lista guarda el listado de los registros con los países
                GridHelper.MostrarDatosEnGrilla<Pais>(lista, dgvDatos);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            // se declara a frm como un objeto de tipo frmPaises
            frmPaisesAE frm = new frmPaisesAE() { Text = "Nuevo país" };
            // se declara dr como objeto DialogResult y se le asigna el resultado de frm.ShowDialog
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;     // Si se presiona Cancelar, salir del DialogResult sin hacer nada
            }

            try
            {
                // le asigna el resultado de frm.GetTipo (objeto de tipo frmPaises) a pais,
                // que viene del formulario frmPaisesAE
                Pais pais = frm.GetPais();

                if (!_servicios.Existe(pais))
                {
                    _servicios.Guardar(pais);      // Método del servicio que guarda el tipo de pais EN LA GRILLA
                    var r = GridHelper.ConstruirFila(dgvDatos);       // Construye la fila y la guarda en r, variable del tipo GridViewRow
                    GridHelper.SetearFila(r, pais);      // Setea la fila r con los datos de objeto pais
                    GridHelper.AgregarFila(dgvDatos, r);     // Agregar la fila r a dgvDatos
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
            // Tag contiene el objeto completo. Hay una tag por fila. Object se castea a Pais
            var pais = (Pais)r.Tag;

            try
            {       // Ventana modal pidiendo confirmación para borrar
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al país {pais.NombrePais}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.No)
                {
                    return;     // Si se presiona No, cancelar
                }
                // Si se presiona Sí:
                // le pido al método Borrar del objeto _servicios que transmita a la capa Datos la orden 
                // de borrar el país de la BASE DE DATOS
                if (!_servicios.EstaRelacionado(pais.PaisId))  // Si el país no está relacionado, borrar
                {
                    _servicios.Borrar(pais.PaisId);
                    // Si se pudo borrar el pais de la base de datos...
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)   // Si no hay filas seleccionadas, salgo
            {
                return;
            }
            try
            {
                var r = dgvDatos.SelectedRows[0];   // r = la primera (y única) fila seleccionada
                // pais recibe una copia del objeto completo desde la Tag. Castea de object a Pais
                var pais = (Pais)r.Tag;
                frmPaisesAE frm = new frmPaisesAE { Text = "Editar país" };  // Crea un formulario frm del tipo frmPaisesAE
                // Toma los datos pais (que a su vez lo toma de la Tag) y completa el frm
                frm.SetPais(pais);
                // Ventana modal. El resultado de la interacción se guarda en dr.                
                DialogResult dr = frm.ShowDialog(this);

                if (dr == DialogResult.Cancel)       // Si presionan cancelar, no hace nada
                {
                    return;
                }
                pais = frm.GetPais();        // Ahora pais toma los datos nuevos

                if (!_servicios.Existe(pais))       // Si no existe el pais, lo edita
                {
                    // Servicios ordena a Datos que guarde la edición en la BASE DE DATOS
                    _servicios.Guardar(pais);
                    GridHelper.SetearFila(r, pais);    // Agrega los datos en las celdas de una la fila que YA ESTÁ CREADA.
                    MessageBox.Show("País editado satisfactoriamente",
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
            catch (Exception)
            {

            }
        }
    }
}
