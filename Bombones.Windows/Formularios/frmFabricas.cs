using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows
{
    public partial class frmFabricas : Form
    {
        private readonly IServiciosFabricas _serviciosFabrica; // Declara la variable de sólo lectura del tipo IServiciosFabrica
        private List<FabricaListDto>? lista;  // Declara la variable lista que devuelve una lista de objetos FábricaListDto  
        public frmFabricas(IServiciosFabricas serviciosFabrica)
        {
            InitializeComponent();
            _serviciosFabrica =serviciosFabrica;  // Inicializa la variable
        }
        private bool filterOn = false;

        private void frmFabricas_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _serviciosFabrica.GetLista();
                GridHelper.MostrarDatosEnGrilla<FabricaListDto>(lista,dgvDatos);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmFabricasAE frm = new frmFabricasAE() { Text = "Nueva Fábrica" };  // Crea un formulario de tipo frmFabricaAE
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel) { return; }
            try
            {
                var fabrica = frm.GetFabrica(); // fabrica recibe el resultado del método del objeto frm GetFabrica

                if (!_serviciosFabrica.Existe(fabrica)) // Si no existe la fábrica en la base de datos
                {
                    _serviciosFabrica.Guardar(fabrica);  // Le pide al servicio que guarde la fábrica en la base de datos

                    // Construye un objeto FabricaListDto a través del método del servicio, pasándole el id de la fábrica
                    var fabricaDto = _serviciosFabrica.GetFabricaListDtoPorId(fabrica.FabricaId);
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, fabricaDto);
                    GridHelper.AgregarFila(dgvDatos, r);
                    MessageBox.Show("Registro agregado satisfactoriamente",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente!!!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];   // r toma el valor de la primera fila seleccionada
            var fabricaDto = (FabricaListDto)r.Tag;    // Toma el contenido de la Tag y lo castea a FabricaListDto
            try
            {
                DialogResult dr = MessageBox.Show($"Desea borrar la fábrica {fabricaDto.NombreFabrica}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                if (!_serviciosFabrica.EstaRelacionado(fabricaDto.FabricaId))
                {
                    _serviciosFabrica.Borrar(fabricaDto.FabricaId);
                    GridHelper.BorrarFila(dgvDatos, r);
                    MessageBox.Show("Registro borrado satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro relacionado./l Baja denegada.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];   // r toma el valor de la primera fila seleccionada
            var fabricaListDto = (FabricaListDto)r.Tag;    // Toma el contenido de la Tag y lo castea a FabricaListDto
            // Devuelve un objeto clonado y lo castea a FabricaListDto
            var fabricaListDtoCopia = (FabricaListDto)fabricaListDto.Clone();

            try
            {
                // Obtiene un objeto Fabrica a partir de la id de un objeto fabricaDto
                var fabrica = _serviciosFabrica.GetFabricaPorId(fabricaListDto.FabricaId);
                frmFabricasAE frm = new frmFabricasAE() { Text = "Editar fábrica" };
                frm.SetFabrica(fabrica);
                DialogResult dr = frm.ShowDialog(this);

                if (dr == DialogResult.Cancel) { return; }
                fabrica = frm.GetFabrica();

                if (!_serviciosFabrica.Existe(fabrica))
                {
                    _serviciosFabrica.Guardar(fabrica);
                    fabricaListDto = _serviciosFabrica.GetFabricaListDtoPorId(fabrica.FabricaId);
                    GridHelper.SetearFila(r, fabricaListDto);
                    MessageBox.Show("Registro editado satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    GridHelper.SetearFila(r, fabricaListDtoCopia);  // Si ya existe, restaura los datos originales
                    MessageBox.Show("Registro existente!!!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, fabricaListDtoCopia);  // Si hay un error, restaura los datos originales
                MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            if (filterOn)   // Si filterOn == true, el filtro está puesto
            {
                return;
            }
            frmFiltrarPorPais frm = new frmFiltrarPorPais() { Text = "Seleccionar por país" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            Pais pais = frm.GetPais();
            try
            {
                lista = _serviciosFabrica.GetLista(pais);
                filterOn = true;
                tsbFiltrar.BackColor = Color.Orange; // Cambia el color del botón filtrar
                GridHelper.MostrarDatosEnGrilla<FabricaListDto>(lista,dgvDatos);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                lista = _serviciosFabrica.GetLista(null);   // Trae toda la lista
                GridHelper.MostrarDatosEnGrilla<FabricaListDto>(lista, dgvDatos);
                filterOn = false;
                tsbFiltrar.BackColor = SystemColors.Control;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
