using Bombones.Entidades.Enumeraciones;

namespace Bombones.Windows.UsersControls
{
    public partial class ucProducto : UserControl
    {
        private string imagenNoDisponible = Environment.CurrentDirectory + @"\Imágenes\SinImagenDisponible.jpg";
        private string archivoNoEncontrado = Environment.CurrentDirectory + @"\Imágenes\ArchivoNoEncontrado.jpg";
        private string archivoImagen = string.Empty;
        private string carpetaImagen = Environment.CurrentDirectory + @"\Imágenes\";

        public ucProducto()
        {
            InitializeComponent();
        }

        private TipoProducto tipoProducto;
        public int ProductoId { get; set; }
        public string Nombre { set => lblProducto.Text = value; }
        public TipoProducto TipoProducto
        {
            get => tipoProducto;
            set
            {
                tipoProducto = value;
                EstablecerColorDeFondo();
            }
        }

        private void EstablecerColorDeFondo()
        {
            if (tipoProducto == TipoProducto.Bombon)
            {
                BackColor = Color.LightPink;
            }
            else if (tipoProducto == TipoProducto.Caja)
            {
                BackColor = Color.LightBlue;
            }
            else
            {
                BackColor = SystemColors.ControlLight;
            }
        }

        public int Stock
        {
            get { return int.Parse(lblStock.Text); }
            set => lblStock.Text = value.ToString();
        }

        public decimal Precio { set => lblPrecio.Text = value.ToString("C"); }
        public bool Suspendido { get; set; }
        public string Imagen
        {
            set
            {
                //Veo si el producto tiene alguna imagen asociada
                if (value != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists($"{carpetaImagen}{value}"))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        picImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        picImagen.Image = Image.FromFile($"{carpetaImagen}{value}");
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    picImagen.Image = Image.FromFile(imagenNoDisponible);
                }

            }
        }

        private void ucProducto_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.Aquamarine;
        }

        private void ucProducto_MouseLeave(object sender, EventArgs e)
        {
            EstablecerColorDeFondo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
        public void ActualizarStock(int cantidad)
        {
            Stock += cantidad;
            if (Stock == 0)
            {
                Enabled = false;
                BackColor = Color.DarkOrange;
            }
            else
            {
                //TODO: se cambió acá
                EstablecerColorDeFondo();
                Enabled = true;
                //BackColor = SystemColors.ControlLight;
            }
        }

        private void ucProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
