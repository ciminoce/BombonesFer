using Bombones.Comun.IServicios;
using Bombones.Entidades.Classes;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.IoC;
using Bombones.Windows.Helpers;
using System.Collections.Generic;

namespace Bombones.Windows.Formularios
{
    public partial class frmCajasAE : Form
    {
        private string imagenNoDisponible = Environment.CurrentDirectory + @"\Imágenes\SinImagenDisponible.jpg";
        private string archivoNoEncontrado = Environment.CurrentDirectory + @"\Imágenes\ArchivoNoEncontrado.jpg";
        private string? archivoImagen = string.Empty;
        private string carpetaImagen = Environment.CurrentDirectory + @"\Imágenes\";

        private readonly IServiciosProductos _servicio;
        private List<DetalleCajaBombonDto>? detalle;

        private Caja? caja;
        public frmCajasAE()
        {
            InitializeComponent();
            _servicio = DI.Create<IServiciosProductos>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (caja != null)
            {

                txtCaja.Text = caja.Nombre;
                txtDescripcion.Text = caja.Descripcion;
                txtPrecioCosto.Text = caja.PrecioCosto.ToString();
                txtPrecioVta.Text = caja.PrecioVenta.ToString();
                txtStock.Text = caja.Stock.ToString();
                txtNivel.Text = caja.NivelDeReposicion.ToString();
                chkSuspendido.Checked = caja.Suspendido;

                //Veo si el producto tiene alguna imagen asociada
                if (caja.Imagen != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists($"{carpetaImagen}{caja.Imagen}"))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        picImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        picImagen.Image = Image.FromFile($"{carpetaImagen}{caja.Imagen}");
                        archivoImagen = caja.Imagen;
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    picImagen.Image = Image.FromFile(imagenNoDisponible);
                }

                detalle = _servicio.GetCajaDetallePorId(caja.ProductoId);
                CargarDetallesEnCarrito();
                GridHelper.MostrarDatosEnGrilla<DetalleCajaBombonDto>(detalle, dgvDatos);
            }
        }

        private void CargarDetallesEnCarrito()
        {
            if (detalle is not null)
            {
                foreach (var item in detalle)
                {
                    CarritoDetalleBombones.AgregarBombonEnCaja(item);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAgregarBombon_Click(object sender, EventArgs e)
        {
            frmCajaBombonAE frm = new frmCajaBombonAE() { Text = "Agregar Bombón a Caja" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            DetalleCajaBombonDto detalleBombonCaja = frm.GetBombon();
            if (!CarritoDetalleBombones.ExisteBombonEnCaja(detalleBombonCaja))
            {
                CarritoDetalleBombones.AgregarBombonEnCaja(detalleBombonCaja);

            }
            else
            {
                DialogResult drDetalle = MessageBox.Show($"El bombón {detalleBombonCaja.NombreBombon} ya existe en el detalle\n" +
                    $"¿Desea agregar la cantidad?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (drDetalle == DialogResult.No)
                {
                    return;
                }
                //todo hacer algo!!!
                CarritoDetalleBombones.ModificarBombonEnCaja(detalleBombonCaja);
            }
            GridHelper.MostrarDatosEnGrilla<DetalleCajaBombonDto>(
                CarritoDetalleBombones.GetItems(), dgvDatos
                );
            MessageBox.Show("Bombón agregado al detalle de caja",
                "Mensaje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (caja == null)
                {
                    caja = new Caja();
                }
                caja.Nombre = txtCaja.Text;
                caja.Descripcion = txtDescripcion.Text;
                caja.PrecioCosto = decimal.Parse(txtPrecioCosto.Text);
                caja.PrecioVenta = decimal.Parse(txtPrecioVta.Text);
                caja.Stock = int.Parse(txtStock.Text);
                caja.NivelDeReposicion = int.Parse(txtNivel.Text);
                caja.Suspendido = chkSuspendido.Checked;

                //Veo si el producto tiene alguna imagen asociada
                if (caja.Imagen != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists($"{carpetaImagen}{caja.Imagen}"))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        picImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        picImagen.Image = Image.FromFile($"{carpetaImagen}{caja.Imagen}");
                        archivoImagen = caja.Imagen;
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    picImagen.Image = Image.FromFile(imagenNoDisponible);
                }

                caja.Detalles = CargarDetalles();
                CarritoDetalleBombones.LimpiarCarrito();

                DialogResult = DialogResult.OK;
            }
        }

        private List<DetalleCaja> CargarDetalles()
        {
            List<DetalleCaja> lista = new List<DetalleCaja>();
            foreach (var bombon in CarritoDetalleBombones.GetItems())
            {
                DetalleCaja detalleCaja = new DetalleCaja
                {
                    BombonId = bombon.BombonId,
                    Cantidad = bombon.Cantidad
                };
                lista.Add(detalleCaja);
            }
            return lista;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (string.IsNullOrEmpty(txtCaja.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCaja, "Nombre de Caja requerido");
            }

            if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioCosto, "Precio de costo no válido");
            }
            else if (precioCosto <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtPrecioCosto, "Precio de costo menor o igual");
            }

            if (!decimal.TryParse(txtPrecioVta.Text, out decimal precioVenta))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioCosto, "Precio de venta no válido");
            }
            else if (precioVenta <= 0 || precioVenta <= precioCosto)
            {
                valido = false;
                errorProvider1.SetError(txtPrecioVta, "Precio de venta mal ingresado");
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                valido = false;
                errorProvider1.SetError(txtStock, "Stock no válido");
            }
            else if (stock <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtStock, "Stock mal ingresado");
            }

            if (!int.TryParse(txtNivel.Text, out int nivel))
            {
                valido = false;
                errorProvider1.SetError(txtNivel, "Nivel no válido");
            }
            else if (nivel <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtNivel, "Nivel mal ingresado");
            }
            if (CarritoDetalleBombones.GetCantidad() == 0)
            {
                valido = false;
                errorProvider1.SetError(dgvDatos, "Debe ingresar al menos un detalle");
            }

            return valido;
        }

        public Caja? GetCaja()
        {
            return caja;
        }

        private void btnBorrarBombon_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is not null)
            {
                DetalleCajaBombonDto detalleBombon = (DetalleCajaBombonDto)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja el bombón {detalleBombon.NombreBombon}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                CarritoDetalleBombones.EliminarBombonEnCaja(detalleBombon);
                GridHelper.MostrarDatosEnGrilla<DetalleCajaBombonDto>(
                        CarritoDetalleBombones.GetItems(), dgvDatos
                        );
                MessageBox.Show("Bombón eliminado del detalle de caja",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
        }

        private void btnEditarBombon_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is not null)
            {
                DetalleCajaBombonDto detalleBombon = (DetalleCajaBombonDto)r.Tag;
                frmCajaBombonAE frm = new frmCajaBombonAE() { Text = "Editar un Detalle" };
                frm.SetBombon(detalleBombon);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }
                detalleBombon = frm.GetBombon();
                CarritoDetalleBombones.ModificarCantidadEnCaja(detalleBombon);
                GridHelper.MostrarDatosEnGrilla<DetalleCajaBombonDto>(
                        CarritoDetalleBombones.GetItems(), dgvDatos
                        );
                MessageBox.Show("Cantidad de Bombón modificada!!",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


            }
        }

        public void SetCaja(Caja? caja)
        {
            this.caja = caja;
        }
    }
}
