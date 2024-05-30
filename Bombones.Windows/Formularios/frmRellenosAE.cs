using Bombones.Entidades.Entidades;

namespace Bombones.Windows
{
    public partial class frmRellenosAE : Form
    {
        public frmRellenosAE()
        {
            InitializeComponent();
        }

        private TipoDeRelleno tipoRelleno;      // variable de tipo TipoDeRelleno
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
                // Significa que el objeto es nuevo. Se crea una instancia tipoRelleno de la clase TipoDeRelleno
                if (tipoRelleno == null)    
                {   
                    tipoRelleno = new TipoDeRelleno();
                }
                tipoRelleno.Descripcion = txtRelleno.Text;      // la propiedad Descripcion toma el texto del textbox txtRelleno
                tipoRelleno.Stock = (int)nudStock.Value;       // la propiedad Stock toma el valor decimal del objeto numeric up down y lo convierte a entero
                
                DialogResult = DialogResult.OK;     // Indica que el usuario presionó Ok
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;     // se declara e inicializa valido en true
            errorProvider1.Clear();     // Se limpia el formulario de cualquier tipo de error

            // Si el texto dentro del textbox txtRelleno no es vacío ni nulo
            if (string.IsNullOrEmpty(txtRelleno.Text))
            {
                valido = false;     // valido ahora es false
                // El textbox txtRelleno muestra el error correspondiente
                errorProvider1.SetError(txtRelleno, "El relleno es requerido");
                // No hace falta codificar el stock, porque desde el formulario se establece
                // que como mínimo tendrá el valor 1, con lo cual, nunca será nulo ni vacío
            }
            return valido;      // devuelve válido
        }

        public TipoDeRelleno GetTipo()
        {
            return tipoRelleno;     // Retorna el tipo de relleno
        }

        public void SetTipo(TipoDeRelleno? relleno)
        {
            // El objeto tipoDeRelleno de frmRellenosAE toma los datos nuevos que le pasó el usuario
            tipoRelleno = relleno; 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Si el objeto ya está en la grilla, toma los datos de ahí y los muestra en frmRellenosAE
            if (tipoRelleno != null) 
            {
                txtRelleno.Text = tipoRelleno.Descripcion;
                nudStock.Value = tipoRelleno.Stock;
            }
        }
    }
}
