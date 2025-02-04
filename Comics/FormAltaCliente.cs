using ComicADO;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Comics
{
    public partial class FormAltaCliente : Form
    {
        public FormAltaCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                string nombre, apellido, email, nif, direccion;
                int telefono;

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new ArgumentException("El nombre es requerido.");

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                    throw new ArgumentException("El apellido es requerido.");

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                    throw new ArgumentException("El email es requerido.");

                if (string.IsNullOrWhiteSpace(txtNIF.Text))
                    throw new ArgumentException("El NIF es requerido.");

                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                    throw new ArgumentException("La dirección es requerida.");

                if (!int.TryParse(txtTel.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número entero.");
                    return;
                }

                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("El formato del email no es válido.");

                // Validación de longitud del NIF (debe tener 9 caracteres)
                if (txtNIF.Text.Length != 9)
                    throw new ArgumentException("El NIF debe tener 9 caracteres.");

                // Validación del formato del teléfono (solo dígitos)
                if (!Regex.IsMatch(txtTel.Text, @"^\d+$"))
                    throw new ArgumentException("El teléfono debe contener solo números.");

                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                email = txtEmail.Text;
                nif = txtNIF.Text;
                direccion = txtDireccion.Text;
                telefono = Convert.ToInt32(txtTel.Text);

                using (VentasADO ventasADO = new VentasADO())
                {
                    ventasADO.IngresarCliente(nombre , apellido, email, nif, direccion, telefono);
                   

                }
               

                    MessageBox.Show("Cliente insertado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (Application.OpenForms["FormOperacion"] is FormOperacion formOperacion)
                    {
                        formOperacion.RefrescarClientes();
                    }
                    this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el comic: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNIF.Text = "";
        }
    }
}
