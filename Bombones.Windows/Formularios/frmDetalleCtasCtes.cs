using Bombones.Entidades.Entidades;
using Bombones.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones.Windows.Formularios
{
    public partial class frmDetalleCtasCtes : Form
    {
        private Cliente? cliente;
        private List<CtaCte>? movimientos;
        public frmDetalleCtasCtes()
        {
            InitializeComponent();
        }

        public void SetCliente(Cliente? cliente)
        {
            this.cliente = cliente;
        }

        public void SetDetalle(List<CtaCte> listaMovimientosCtaCte)
        {
            movimientos=listaMovimientosCtaCte;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MostrarDatosCliente(cliente);
            GridHelper.MostrarDatosEnGrilla<CtaCte>(movimientos,dgvDatos);
            txtSaldo.Text = movimientos?.Sum(cc => cc.Debe - cc.Haber).ToString("C");
        }

        private void MostrarDatosCliente(Cliente? cliente)
        {
            txtCliente.Text = cliente?.ApeNombre??string.Empty;
            txtDireccion.Text=cliente?.Direccion;
            txtLocalidad.Text=cliente?.Localidad;
            txtCodPostal.Text=cliente?.CodigoPostal.ToString();
            txtTelefono.Text=cliente?.Telefono;
        }

        private void txtSaldo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
