using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmCajaDetalle : Form
    {
        private string imagenNoDisponible = Environment.CurrentDirectory + @"\Imágenes\SinImagenDisponible.jpg";
        private string archivoNoEncontrado = Environment.CurrentDirectory + @"\Imágenes\ArchivoNoEncontrado.jpg";
        private string archivoImagen = string.Empty;
        private string carpetaImagen = Environment.CurrentDirectory + @"\Imágenes\";

        private CajaDetalleDto cajaDetalleDto;
        public frmCajaDetalle()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cajaDetalleDto!=null)
            {
                txtCaja.Text = cajaDetalleDto.Nombre;
                txtDescripcion.Text = cajaDetalleDto.Descripcion;
                txtStock.Text=cajaDetalleDto.Stock.ToString();
                txtPrecioVta.Text=cajaDetalleDto.Precio.ToString();
                chkSuspendido.Checked = cajaDetalleDto.Suspendido;

                if (cajaDetalleDto.Imagen != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists($"{carpetaImagen}{cajaDetalleDto.Imagen}"))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        picImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        picImagen.Image = Image.FromFile($"{carpetaImagen}{cajaDetalleDto.Imagen}");
                        archivoImagen = cajaDetalleDto.Imagen;
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    picImagen.Image = Image.FromFile(imagenNoDisponible);
                }
                GridHelper.MostrarDatosEnGrilla<DetalleCajaBombonDto>(cajaDetalleDto.Detalles, dgvDatos);
            }
        }

        public void SetDetalle(CajaDetalleDto cajaDetalleDto)
        {
            this.cajaDetalleDto = cajaDetalleDto;
        }
    }
}
