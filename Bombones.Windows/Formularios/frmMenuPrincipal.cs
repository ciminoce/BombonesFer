using Bombones.Comun.IServicios;
using Bombones.IoC;
using Bombones.Windows.Formularios;

namespace Bombones.Windows
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void btnRellenos_Click(object sender, EventArgs e)
        {
            var frm = new frmRellenos(DI.Create<IServiciosTiposDeRellenos>());   // Crea frm, un objeto del tipo formulario frmRellenos
            frm.ShowDialog();       // muestra frm de forma modal
        }

        private void btnChocolates_Click(object sender, EventArgs e)
        {
            var frm = new frmChocolates(DI.Create<IServiciosTiposDeChocolates>());   // Crea frm, un objeto del tipo formulario frmChocolates
            frm.ShowDialog();       // muestra frm de forma modal
        }

        private void btnNueces_Click(object sender, EventArgs e)
        {
            var frm = new frmNueces(DI.Create<IServiciosTiposDeNueces>());   // Crea frm, un objeto del tipo formulario frmNueces
            frm.ShowDialog();       // muestra frm de forma modal
        }
        private void btnPaises_Click(object sender, EventArgs e)
        {
            var frm = new frmPaises(DI.Create<IServiciosPaises>());   // Crea frm, un objeto del tipo formulario frmPaises
            frm.ShowDialog();       // muestra frm de forma modal
        }

        private void btnFabricas_Click(object sender, EventArgs e)
        {
            var frm = new frmFabricas(DI.Create<IServiciosFabricas>());   // Crea frm, un objeto del tipo formulario frmFabricas
            frm.ShowDialog();       // muestra frm de forma modal
        }

        private void btnBombones_Click(object sender, EventArgs e)
        {
            var frm = new frmBombones(DI.Create<IServiciosProductos>());
            frm.ShowDialog();
        }

        private void btnCajas_Click(object sender, EventArgs e)
        {
            var frm = new frmCajas(DI.Create<IServiciosProductos>());
            frm.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            var frm = new frmVentas(DI.Create<IServiciosVentas>());
            frm.ShowDialog();
        }
    }
}
