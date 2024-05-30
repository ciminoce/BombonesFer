using Bombones.Entidades.Entidades;

namespace Bombones.Windows
{
    public partial class frmNuecesAE : Form
    {
        public frmNuecesAE()
        {
            InitializeComponent();
        }

        private TipoDeNuez tipoNuez;      // variable de tipo TipoDeNuez
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
                // Significa que el objeto es nuevo. Se crea una instancia tipoNuez de la clase TipoDeNuez
                if (tipoNuez == null)
                {
                    tipoNuez = new TipoDeNuez();
                }
                tipoNuez.Descripcion = txtNuez.Text;      // la propiedad Descripcion toma el texto del textbox txtNuez
                tipoNuez.Stock = (int)nudStock.Value;       // la propiedad Stock toma el valor decimal del objeto numeric up down y lo convierte a entero

                DialogResult = DialogResult.OK;     // Indica que el usuario presionó Ok
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;     // se declara e inicializa valido en true
            errorProvider1.Clear();     // Se limpia el formulario de cualquier tipo de error

            // Si el texto dentro del textbox txtNuez no es vacío ni nulo
            if (string.IsNullOrEmpty(txtNuez.Text))
            {
                valido = false;     // valido ahora es false
                // El textbox txtNuez muestra el error correspondiente
                errorProvider1.SetError(txtNuez, "La nuez es requerida");
                // No hace falta codificar el stock, porque desde el formulario se establece
                // que como mínimo tendrá el valor 1, con lo cual, nunca será nulo ni vacío
            }
            return valido;      // devuelve válido
        }

        public TipoDeNuez GetTipo()
        {
            return tipoNuez;     // Retorna el tipo de nuez
        }

        public void SetTipo(TipoDeNuez? nuez)
        {
            // El objeto tipoDeNuez de frmNuecesAE toma los datos nuevos que le pasó el usuario
            tipoNuez = nuez;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Si el objeto ya está en la grilla, toma los datos de ahí y los muestra en frmNuecesAE
            if (tipoNuez != null)
            {
                txtNuez.Text = tipoNuez.Descripcion;
                nudStock.Value = tipoNuez.Stock;
            }
        }
    }
}
