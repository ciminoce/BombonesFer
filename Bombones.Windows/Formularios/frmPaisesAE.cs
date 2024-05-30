using Bombones.Entidades.Entidades;

namespace Bombones.Windows
{
    public partial class frmPaisesAE : Form
    {
        public frmPaisesAE()
        {
            InitializeComponent();
        }

        private Pais pais;      // variable de tipo Pais
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Dado que Cancel es una propiedad estática de la enumeración DialogResult
            //(pertenece a la clase, no a los objetos) no es necesario utilizar el operador
            //de asignación (=) para asignarle un valor.
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                // Significa que el objeto es nuevo. Se crea una instancia pais de la clase Pais
                if (pais == null)
                {
                    pais = new Pais();
                }
                pais.NombrePais = txtPais.Text;      // la propiedad NombrePais toma el texto del textbox txtPais

                DialogResult = DialogResult.OK;     // Indica que el usuario presionó Ok
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;     // se declara e inicializa valido en true
            errorProvider1.Clear();     // Se limpia el formulario de cualquier tipo de error

            // Si el texto dentro del textbox txtPais no es vacío ni nulo
            if (string.IsNullOrEmpty(txtPais.Text))
            {
                valido = false;     // valido ahora es false
                // El textbox txtRelleno muestra el error correspondiente
                errorProvider1.SetError(txtPais, "El país es requerido");
            }
            return valido;      // devuelve válido
        }

        public Pais GetPais()
        {
            return pais;     // Retorna el tipo de relleno
        }

        public void SetPais(Pais? paisEnGrilla)
        {
            // El objeto pais de frmPaisesAE toma los datos nuevos que le pasó el usuario
            pais = paisEnGrilla;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Si el objeto ya está en la grilla, toma los datos de ahí y los muestra en frmPaisesAE
            if (pais != null)
            {
                txtPais.Text = pais.NombrePais;
            }
        }
    }
}
