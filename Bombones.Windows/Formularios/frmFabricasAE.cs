using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows
{
    public partial class frmFabricasAE : Form
    {
        public frmFabricasAE()
        {
            InitializeComponent();
        }

        private Fabrica fabrica;    // Crea un objeto fabrica de tipo Fabrica
        public Fabrica GetFabrica()
        {
            return fabrica;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);  // Carga el cboPaises
            if (fabrica != null)
            {
                // Quiere decir que el formulario AE está completo con los datos de una 
                // fábrica ya existente, entonces completa sus campos según cada método getter
                txtFabrica.Text = fabrica.NombreFabrica;
                txtDireccion.Text = fabrica.Direccion;
                cboPaises.SelectedValue = fabrica.PaisId;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Enumeración 2 = salir
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fabrica == null) // La fábrica es nueva
                {
                    fabrica = new Fabrica();
                }
                // Asigna a través de sus propieades el contenido de cada campo o combobox
                fabrica.NombreFabrica = txtFabrica.Text;
                fabrica.Direccion = txtDireccion.Text;
                fabrica.PaisId = (int)cboPaises.SelectedValue;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtFabrica.Text))
            {
                valido = false;
                errorProvider1.SetError(txtFabrica, "El nombre es requerido");
            }
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }
            return valido;
        }

        public void SetFabrica(Fabrica fabrica)
        {
            this.fabrica = fabrica;
        }
    }
}
