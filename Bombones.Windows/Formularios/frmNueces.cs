﻿using Bombones.Comun.IServicios;
using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows
{
    public partial class frmNueces : Form // Agrega como REFERENCIA a Entidades.Entidades
    {
        private List<TipoDeNuez> lista;      // Se agrega la REFERENCIA a Bombones.Entidades.Entidades
        private readonly IServiciosTiposDeNueces _servicios;      // Declaración de un objeto _servicios del tipo ServiciosTipoDeNuez
        public frmNueces(IServiciosTiposDeNueces servicios)
        {
            InitializeComponent();
            _servicios = servicios;      // instancia e inicializa el objeto _servicios
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNueces_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios.GetLista();      // la lista guarda el listado de los registros con los tipos de nuez
                GridHelper.MostrarDatosEnGrilla<TipoDeNuez>(lista,dgvDatos);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            // se declara a frm como un objeto de tipo frmNueces
            frmNuecesAE frm = new frmNuecesAE() { Text = "Nueva nuez" };
            // se declara dr como objeto DialogResult y se le asigna el resultado de frm.ShowDialog
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;     // Si se presiona Cancelar, salir del DialogResult sin hacer nada
            }

            try
            {
                // le asigna el resultado de frm.GetTipo (objeto de tipo frmNueces) a tipoDeNuez,
                // que viene del formulario frmNuecesAE
                TipoDeNuez tipoDeNuez = frm.GetTipo();

                if (!_servicios.Existe(tipoDeNuez))
                {
                    _servicios.Guardar(tipoDeNuez);      // Método del servicio que guarda el tipo de nuez EN LA GRILLA
                    var r = GridHelper.ConstruirFila(dgvDatos);       // Construye la fila y la guarda en r, variable del tipo GridViewRow
                    GridHelper.SetearFila(r, tipoDeNuez);      // Setea la fila r con los datos de objeto tipoDeNuez
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
            // Tag contiene el objeto completo. Hay una tag por fila. Object se castea a TipoDeNuez
            var nuez = (TipoDeNuez)r.Tag;

            try
            {       // Ventana modal pidiendo confirmación para borrar
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al nuez {nuez.Descripcion}?",
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
                // de borrar el nuez de la BASE DE DATOS
                if (!_servicios.EstaRelacionado(nuez.TipoDeNuezId))  // Si la nuez no está relacionada, borrar
                {
                    _servicios.Borrar(nuez.TipoDeNuezId);
                    // Si se pudo borrar la nuez de la base de datos...
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
                // nuez recibe una copia del objeto completo desde la Tag. Castea de object a TipoDeNuez
                var nuez = (TipoDeNuez)r.Tag;
                frmNuecesAE frm = new frmNuecesAE { Text = "Editar nuez" };  // Crea un formulario frm del tipo frmNuecesAE
                // Toma los datos nuez (que a su vez lo toma de la Tag) y completa el frm
                frm.SetTipo(nuez);
                // Ventana modal. El resultado de la interacción se guarda en dr.                
                DialogResult dr = frm.ShowDialog(this);

                if (dr == DialogResult.Cancel)       // Si presionan cancelar, no hace nada
                {
                    return;
                }
                nuez = frm.GetTipo();        // Ahora nuez toma los datos nuevos

                if (!_servicios.Existe(nuez))       // Si no existe la nuez, la edita
                {
                    // Servicios ordena a Datos que guarde la edición en la BASE DE DATOS
                    _servicios.Guardar(nuez);
                    GridHelper.SetearFila(r, nuez);    // Agrega los datos en las celdas de una la fila que YA ESTÁ CREADA.
                    MessageBox.Show("Nuez editada satisfactoriamente",
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
