using Bombones.Entidades.Dtos;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmCajaBombonAE : Form
    {
        public frmCajaBombonAE()
        {
            InitializeComponent();
        }
        private DetalleCajaBombonDto detalleCajaBombon;
        private ProductoComboDto bombonSeleccionado;
        private void frmCajaBombonAE_Load(object sender, EventArgs e)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboBombones(ref cboBombones);
            if (detalleCajaBombon != null )
            {
                
                cboBombones.SelectedValue = detalleCajaBombon.BombonId;
                nudCantidad.Value=detalleCajaBombon.Cantidad;
                cboBombones.Enabled=false;
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if(detalleCajaBombon==null)
                {
                    detalleCajaBombon=new DetalleCajaBombonDto();
                }
                detalleCajaBombon.BombonId=bombonSeleccionado.BombonId;
                detalleCajaBombon.NombreBombon=bombonSeleccionado.NombreBombon;
                detalleCajaBombon.Cantidad =(int) nudCantidad.Value;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (cboBombones.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboBombones, "Debe seleccionar un bombón");

            }
            return valido;
        }


        private void cboBombones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBombones.SelectedIndex>0)
            {
                bombonSeleccionado = (ProductoComboDto)cboBombones.SelectedItem;
            }
            else
            {
                bombonSeleccionado = null;
            }
        }

        public DetalleCajaBombonDto GetBombon()
        {
            return detalleCajaBombon;
        }

        public void SetBombon(DetalleCajaBombonDto? detalleBombon)
        {
            detalleCajaBombon = detalleBombon;
        }
    }
}
