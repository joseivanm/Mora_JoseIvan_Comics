using ComicADO;
using Entidades;
using Ventas;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Comics
{
    //<author>Jose Ivan Mora Gonzaga</author>
    public partial class Form1 : Form

    {
        private string nombreUsuario;
        private byte[] imagUsuario;
        private Empleado empleadoActual;

        bool Editar = true;

        public Form1(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;

            // Asignar el nombre del empleado al label
            lbUsuario.Text = empleadoActual.Nombre;

            // Verificar si el arreglo de bytes contiene datos
            if (empleadoActual.Fotografia != null && empleadoActual.Fotografia.Length > 0)
            {
                try
                {
                    // Validar si los bytes son suficientes para una imagen
                    if (empleadoActual.Fotografia.Length > 100)
                    {

                        using (var ms = new MemoryStream(empleadoActual.Fotografia))
                        {
                            // Convertir los bytes en imagen
                            picUser.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La imagen es demasiado pequeña o no es válida.");
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("El empleado no tiene una imagen asociada.");
            }
        }

        public Form1()
        {
        }

        /*private string? GetId()
        {
            try
            {
                string? id = dgvAutores.Rows[dgvAutores.CurrentRow.Index].Cells[0].Value.ToString();
                return id;
            }
            catch (Exception)
            {
                return null;
            }
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {

            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los comics: {ex.Message}");
                }
            }
        }


        private void dgvAutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btListarOperaciones_Click(object sender, EventArgs e)
        {

            int localId = int.Parse(txtLocalId.Text); // TextBox donde se introduce el ID del local
            DateTime fechaInicio = dtpFechaInicio.Value; //  Seleccionar la fecha de inicio
            DateTime fechaFinal = dtpFechaFinal.Value; // Seleccionar la fecha final

        }

        private void btVerDetalles_Click(object sender, EventArgs e)
        {

        }

        private void btCargarDetallesOperacion_Click(object sender, EventArgs e)
        {
            // Comprobar que el campo OperacionId no este vacio
            if (string.IsNullOrWhiteSpace(txtOperacionId.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID de Operación valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertir el ID de operación a entero
            if (!int.TryParse(txtOperacionId.Text, out int operacionId))
            {
                MessageBox.Show("El ID de Operación debe ser un numero valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void altaEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaEmpleado formAltaEmpleado = new AltaEmpleado();

            formAltaEmpleado.MdiParent = this;

            formAltaEmpleado.Show();

            formAltaEmpleado.BringToFront();
        }

        private void modificarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmpleado formEmpleadoMR = new FormEmpleado();

            formEmpleadoMR.MdiParent = this;

            formEmpleadoMR.Show();

            formEmpleadoMR.BringToFront();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btOpAdd_Click(object sender, EventArgs e)
        {

        }

        private void btOpMv_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picUser_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOperacion formOperacion = new FormOperacion(empleadoActual);

            formOperacion.MdiParent = this;

            formOperacion.Show();

            formOperacion.BringToFront();
        }
    }
}
