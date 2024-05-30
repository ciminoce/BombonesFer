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

namespace Bombones.Windows
{
    public partial class frmFiltrarPorPais : Form
    {
        private Pais? pais;
        public frmFiltrarPorPais()
        {
            InitializeComponent();
        }

        public Pais? GetPais()
        {
            return pais;
        }

        private void frmFiltrarPorPais_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboPaises.SelectedIndex == 0)   // Si se eligió la primera posición
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país.");
            }
            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPaises.SelectedIndex < 0)
            {
                pais = (Pais) cboPaises.SelectedItem;   // Devuelve un object y lo castea a Pais
            }
            else
            {
                pais = null; 
            }
        }
    }
}
