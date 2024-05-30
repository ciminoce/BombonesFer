﻿using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmBombonAE : Form
    {
        private string imagenNoDisponible = Environment.CurrentDirectory + @"\Imágenes\SinImagenDisponible.jpg";
        private string archivoNoEncontrado = Environment.CurrentDirectory + @"\Imágenes\ArchivoNoEncontrado.jpg";
        private string? archivoImagen = string.Empty;
        private string carpetaImagen = Environment.CurrentDirectory + @"\Imágenes\";

        public frmBombonAE()
        {
            InitializeComponent();
        }
        private Bombon? bombon;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboTiposDeChocolate(ref cboChocolates);
            CombosHelper.CargarComboTiposDeRelleno(ref cboRellenos);
            CombosHelper.CargarComboTiposDeNueces(ref cboNueces);
            CombosHelper.CargarComboFabricas(ref cboFabricas);
            if (bombon is not null)
            {
                txtBombon.Text = bombon.Nombre;
                txtDescripcion.Text = bombon.Descripcion;
                cboChocolates.SelectedValue = bombon.TipoDeChocolateId;
                cboRellenos.SelectedValue = bombon.TipoDeRellenoId;
                cboNueces.SelectedValue = bombon.TipoDeNuezId;
                txtPrecioCosto.Text = bombon.PrecioCosto.ToString();
                txtPrecioVta.Text = bombon.PrecioVenta.ToString();
                txtStock.Text = bombon.Stock.ToString();
                txtNivelDeReposicion.Text = bombon.NivelDeReposicion.ToString();
                cboFabricas.SelectedValue = bombon.FabricaId;
                chkSuspendido.Checked = bombon.Suspendido;

                //Veo si el producto tiene alguna imagen asociada
                if (bombon.Imagen != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists($"{carpetaImagen}{bombon.Imagen}"))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        picImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        picImagen.Image = Image.FromFile($"{carpetaImagen}{bombon.Imagen}");
                        archivoImagen = bombon.Imagen;
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    picImagen.Image = Image.FromFile(imagenNoDisponible);
                }

            }

        }
        public Bombon? GetBombon()
        {
            return bombon;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (bombon is null)
                {
                    bombon = new Bombon();
                }
                bombon.Nombre = txtBombon.Text;
                bombon.Descripcion = txtDescripcion.Text;

                bombon.TipoDeChocolateId = (int)cboChocolates.SelectedValue;
                bombon.TipoDeRellenoId = (int)cboRellenos.SelectedValue;
                bombon.TipoDeNuezId = (int)cboNueces.SelectedValue;
                bombon.FabricaId = (int)cboFabricas.SelectedValue;

                bombon.PrecioCosto = decimal.Parse(txtPrecioCosto.Text);
                bombon.PrecioVenta = decimal.Parse(txtPrecioVta.Text);
                bombon.Stock = int.Parse(txtStock.Text);
                bombon.NivelDeReposicion = int.Parse(txtNivelDeReposicion.Text);

                bombon.Suspendido = chkSuspendido.Checked;

                bombon.TipoDeChocolate=(TipoDeChocolate)cboChocolates.SelectedItem;
                bombon.TipoDeNuez=(TipoDeNuez)cboNueces.SelectedItem;
                bombon.TipoDeRelleno= (TipoDeRelleno)cboRellenos.SelectedItem;
                bombon.Fabrica=(Fabrica)cboFabricas.SelectedItem;


                //Veo si el producto tiene alguna imagen asociada
                if (bombon.Imagen != string.Empty)
                {
                    //Me aseguro que esa imagen exista
                    if (!File.Exists($"{carpetaImagen}{bombon.Imagen}"))
                    {
                        //Si no existe, muestro la imagen de archivo no encontrado
                        picImagen.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        //Caso contrario muestro la imagen
                        picImagen.Image = Image.FromFile($"{carpetaImagen}{bombon.Imagen}");
                        archivoImagen = bombon.Imagen;
                    }
                }
                else
                {
                    //Si no tiene imagen muestro Sin Imagen 
                    picImagen.Image = Image.FromFile(imagenNoDisponible);
                }

                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrWhiteSpace(txtBombon.Text))
            {
                valido = false;
                errorProvider1.SetError(txtBombon, "El nombre del bombón es requerido");
            }
            if (cboChocolates.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboChocolates, "Debe seleccionar un tipo de Chocolate");
            }
            if (cboRellenos.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboRellenos, "Debe seleccionar un tipo de Relleno");
            }
            if (cboNueces.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboNueces, "Debe seleccionar un tipo de Nuez");
            }
            if (cboFabricas.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboFabricas, "Debe seleccionar una fábrica");
            }

            
            if (!decimal.TryParse(txtPrecioCosto.Text, out decimal pCosto)
                || pCosto <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtPrecioCosto, "Precio de costo mal ingresado o no válido");
            }

            if (!decimal.TryParse(txtPrecioVta.Text, out decimal pVenta) || 
                pVenta <= 0 || pVenta <= pCosto)
            {
                valido = false;
                errorProvider1.SetError(txtPrecioVta, "Precio de venta mal ingresado o no válido");
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtStock, "Stock mal ingresado o no válido");
            }

            if (!int.TryParse(txtNivelDeReposicion.Text, out int stockMinimo) || stockMinimo <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtStock, "Nivel de Reposición mal ingresado o no válido");
            }


            return valido;

        }

        public void SetBombon(Bombon bombon)
        {
            this.bombon = bombon;
        }

        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            //Seteo del openFileDialog
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + @"\Imágenes\";
            openFileDialog1.Filter = @"Archivos jpg (*.jpg) | *.jpg | 
                Archivos png (*.png)  | *.png | 
                Archivos jfif (*.jfif) | *.jfif | 
                Todos (*.*) | *.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            DialogResult dr = openFileDialog1.ShowDialog(this);//muestro el openFileDialog

            if (dr == DialogResult.OK)
            {
                //Veo si tengo algun imagen seleccionada
                if (openFileDialog1.FileName == null)
                {
                    return;//sino me voy
                }
                //Tomo el nombre del archivo de imagen con su ruta
                //archivoNombreConRuta = openFileDialog1.FileName;
                picImagen.Image = Image.FromFile(openFileDialog1.FileName);
                archivoImagen = openFileDialog1.FileName;//Tomo la ruta y el nombre del archivo
            }

        }
    }
}
