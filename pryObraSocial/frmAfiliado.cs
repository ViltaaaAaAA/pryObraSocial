using System;
using System.Windows.Forms;

namespace pryObraSocial
{
    public partial class frmAfiliado : Form
    {
        public frmAfiliado()
        {
            InitializeComponent();

            
            txtDni.MaxLength = 8;
            txtNroAfiliado.MaxLength = 10;
            txtTelefono.MaxLength = 15;

            
            txtNroAfiliado.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
            txtDni.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
            txtTelefono.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
        }

        
        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlan.SelectedItem != null)
            {
                switch (cmbPlan.SelectedItem.ToString())
                {
                    case "Plan Básico":
                        txtCosto.Text = "15000";
                        break;
                    case "Plan Joven":
                        txtCosto.Text = "22000";
                        break;
                    case "Plan Familiar":
                        txtCosto.Text = "35000";
                        break;
                    case "Plan Integral":
                        txtCosto.Text = "50000";
                        break;
                    case "Plan Premium":
                        txtCosto.Text = "75000";
                        break;
                    default:
                        txtCosto.Text = "0";
                        break;
                }
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtNroAfiliado.Text))
            {
                MessageBox.Show("Por favor, complete el número de afiliado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroAfiliado.Focus();
                return;
            }

            
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Por favor, complete el apellido.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

           
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, complete el nombre.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Por favor, complete el DNI.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            if (txtDni.Text.Length != 8 || !int.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe tener exactamente 8 números.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, complete el teléfono.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            
            if (dtpFechaNacimiento.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser posterior al día de hoy.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaNacimiento.Focus();
                return;
            }

            
            if (cmbPlan.SelectedIndex == -1 || cmbPlan.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un plan de cobertura.", "Falta el plan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPlan.Focus();
                return;
            }

            
            MessageBox.Show("¡Afiliado registrado con éxito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            LimpiarFormulario();
        }

        
        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            MessageBox.Show("Se ha limpiado el formulario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
        private void LimpiarFormulario()
        {
            txtNroAfiliado.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            cmbPlan.SelectedIndex = -1;
            txtCosto.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtNroAfiliado.Focus();
        }

        
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}