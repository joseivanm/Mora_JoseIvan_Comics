using ComicADO;
using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entidades;
using System.Security.Cryptography;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure;
using Ventas;

namespace Comics
{
    //<author>Jose Ivan Mora Gonzaga</author>
    public partial class AltaEmpleado : Form
    {
        public byte[] imagenBytes;
        bool edicion = false;
        int empleadoIDactualizar;

        public AltaEmpleado()
        {
            InitializeComponent();
            CargarLocales();
        }

        public AltaEmpleado(int idEmpleado)
        {
            InitializeComponent();
            CargarLocales();
            using (VentasADO ventasADO = new VentasADO())
            {
                Empleado empleado = ventasADO.ListarEmpleado(Convert.ToString(idEmpleado));



                textBoxNombre.Text = empleado.Nombre;
                textBoxApellido.Text = empleado.Apellido; ;
                textBoxEmail.Text = empleado.Email;
                textBoxNIF.Text = empleado.Nif;
                textBoxDireccion.Text = empleado.Direccion;
                dtAlta.Value = (DateTime)empleado.Fecha_alta;
                dtAlta.Enabled = false;
                imagenBytes = empleado.Fotografia;
                btnAddEmp.Text = "Editar";
                lbTitle.Text = "Editar Usuario";
                label10.Visible = true;
                lbActivo.Visible = true;
                lbActivo.Text = empleado.Activo;
                label12.Visible = true;
                lbID.Visible = true;
                lbID.Text = Convert.ToString(empleado.EmpleadoId);
                empleadoIDactualizar = empleado.EmpleadoId;
                label11.Visible = true;
                dtBaja.Visible = true;
                dtBaja.Enabled = false;


            }
            edicion = true;


        }

        private void CargarLocales()
        {
            using (var localAdo = new LocalADO())
            {
                try
                {
                    var locales = localAdo.ListarLocales();
                    cboxTienda.DataSource = locales;
                    cboxTienda.DisplayMember = "Nombre";
                    cboxTienda.ValueMember = "LocalID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar locales: " + ex.Message);
                }
            }
        }



        private int ValidaString(string cadena, int longitudMaxima, bool nulo)
        {
            if (cadena.Length > longitudMaxima) return 1;
            if (string.IsNullOrEmpty(cadena) && !nulo) return 2;
            return 0;
        }

        private bool EsNIFValido(string nif)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                // Obtener la lista de empleados de la base de datos
                List<Empleado> empleados = ventasADO.ListarEmpleados();

                // Validar el formato del NIF con una expresión regular
                Regex regex = new Regex(@"^[0-9]{8}[A-Za-z]$");
                if (!regex.IsMatch(nif))
                {
                    return false; // El formato del NIF no es válido
                }

                // Verificar si el NIF ya existe en la lista de empleados
                foreach (var empleado in empleados)
                {
                    if (empleado.Nif.Equals(nif, StringComparison.OrdinalIgnoreCase))
                    {
                        return false; // El NIF ya está en la base de datos
                    }
                }

                return true; // El NIF es válido y no está duplicado
            }
        }


        private bool EsDireccionValida(string direccion)
        {
            Regex regex = new Regex(@"^[A-Za-z\s]+[0-9]+$");
            return regex.IsMatch(direccion);
        }

        private bool EsEmailValido(string email, int longitudMaximo, bool nulo)
        {
            if (email.Length > longitudMaximo) return false;
            Regex regex = new Regex(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,6}$");
            return regex.IsMatch(email);
        }

        private bool EsFechaAltaValida(DateTime fechaAlta)
        {
            DateTime hoy = DateTime.Today;
            return fechaAlta >= hoy.AddDays(-7) && fechaAlta <= hoy.AddDays(7);
        }

        private bool EsContrasenyaValida(string passwd, int longitudMaximo)
        {
            return !string.IsNullOrEmpty(passwd) && passwd.Length <= longitudMaximo;
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Seleccionar una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    imagenBytes = File.ReadAllBytes(filePath);

                    string extension = Path.GetExtension(filePath).ToLower();
                    if (extension != ".jpg" && extension != ".png")
                    {
                        MessageBox.Show("La imagen debe estar en formato .jpg o .png.");
                        imagenBytes = null;
                    }
                }
            }
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            string cadenaErrores = "";
            ToolTip TTIP = new ToolTip();
            bool valido = true;

            using (VentasADO ventasADO = new VentasADO())
            {
                //List <Empleado> empleados = ventasADO.ListarEmpleados();
                // Validar Nombre (obligatorio)
                int resultado = ValidaString(textBoxNombre.Text, 60, false);
                if (resultado > 0)
                {
                    cadenaErrores += resultado == 1 ? "El campo Nombre no permite más de 60 caracteres.\n" : "El campo Nombre no puede estar vacío.\n";
                    textBoxNombre.BackColor = Color.LightCoral;
                    TTIP.SetToolTip(textBoxNombre, cadenaErrores);
                    errorProvider3.SetError(textBoxNombre, "El campo Nombre no permite más de 60 caracteres.\\n\" : \"El campo Nombre no puede estar vacío.\\n");
                    valido = false;
                }
                else
                {
                    textBoxNombre.BackColor = Color.LightGreen;
                    TTIP.SetToolTip(textBoxNombre, "");
                    errorProvider3.SetError(textBoxNombre, "");
                }

                // Validar Apellido (opcional)
                resultado = ValidaString(textBoxApellido.Text, 100, true);
                if (resultado == 1)
                {
                    cadenaErrores += "El campo Apellido no permite más de 100 caracteres.\n";
                    textBoxApellido.BackColor = Color.LightCoral;
                    TTIP.SetToolTip(textBoxApellido, cadenaErrores);
                    errorProvider4.SetError(textBoxApellido, "El campo Apellido no permite más de 100 caracteres.");
                    valido = false;
                }
                else
                {
                    textBoxApellido.BackColor = Color.LightGreen;
                    TTIP.SetToolTip(textBoxApellido, "");
                    errorProvider4.SetError(textBoxApellido, "");
                }

                // Validar NIF
                if (!EsNIFValido(textBoxNIF.Text))
                {
                    cadenaErrores += "El NIF debe ser único y estar bien formado.\n";
                    textBoxNIF.BackColor = Color.LightCoral;
                    TTIP.SetToolTip(textBoxNIF, cadenaErrores);
                    errorProvider5.SetError(textBoxNIF, "El NIF debe ser único y estar bien formado.");
                    valido = false;
                }
                else
                {
                    textBoxNIF.BackColor = Color.LightGreen;
                    TTIP.SetToolTip(textBoxNIF, "");
                    errorProvider5.SetError(textBoxNIF, "");
                }

                // Validar Dirección (opcional)
                if (!string.IsNullOrEmpty(textBoxDireccion.Text) && !EsDireccionValida(textBoxDireccion.Text))
                {
                    cadenaErrores += "La dirección debe contener letras y terminar con un número.\n";
                    textBoxDireccion.BackColor = Color.LightCoral;
                    TTIP.SetToolTip(textBoxDireccion, cadenaErrores);
                    errorProvider5.SetError(textBoxDireccion, "La dirección debe contener letras y terminar con un número.");
                    valido = false;
                }
                else
                {
                    textBoxDireccion.BackColor = Color.LightGreen;
                    TTIP.SetToolTip(textBoxDireccion, "");
                    errorProvider5.SetError(textBoxDireccion, "");
                }

                // Validar Email (opcional)
                if (!string.IsNullOrEmpty(textBoxEmail.Text) && !EsEmailValido(textBoxEmail.Text, 60, true))
                {
                    cadenaErrores += "El email debe tener un formato válido.\n";
                    textBoxEmail.BackColor = Color.LightCoral;
                    TTIP.SetToolTip(textBoxEmail, "Formato de email no válido.");
                    errorProvider6.SetError(textBoxEmail, "El email debe tener un formato válido.");
                    valido = false;
                }
                else
                {
                    textBoxEmail.BackColor = Color.LightGreen;
                    TTIP.SetToolTip(textBoxEmail, "");
                    errorProvider6.SetError(textBoxEmail, "");
                }

                // Validar Fecha de Alta
                if (!EsFechaAltaValida(dtAlta.Value) && edicion == false)
                {
                    cadenaErrores += "La fecha de alta debe estar dentro de +/- 7 días de la fecha actual.\n";
                    dtAlta.BackColor = Color.LightCoral;
                    TTIP.SetToolTip(dtAlta, cadenaErrores);
                    errorProvider1.SetError(dtAlta, "Fecha inválida. Debe estar dentro de +/- 7 días de la fecha actual.");
                    valido = false;
                }
                else
                {
                    dtAlta.BackColor = Color.LightGreen;
                    errorProvider1.SetError(dtAlta, "");
                    TTIP.SetToolTip(dtAlta, "");
                }

                // Validar Contraseña (obligatorio)
                if (edicion == false && !EsContrasenyaValida(textBoxPass.Text, 64))
                {
                    cadenaErrores += "Contraseña muy larga o vacía.\n";
                    textBoxPass.BackColor = Color.LightCoral;
                    TTIP.SetToolTip(textBoxPass, cadenaErrores);
                    errorProvider7.SetError(textBoxPass, "Contraseña muy larga o vacía.");
                    valido = false;
                }
                else
                {
                    textBoxPass.BackColor = Color.LightGreen;
                    TTIP.SetToolTip(textBoxPass, "");
                    errorProvider7.SetError(textBoxPass, "");
                }
 

                string apellido = string.IsNullOrEmpty(textBoxApellido.Text) ? null : textBoxApellido.Text;
                string direccion = string.IsNullOrEmpty(textBoxDireccion.Text) ? null : textBoxDireccion.Text;
                string email = string.IsNullOrEmpty(textBoxEmail.Text) ? null : textBoxEmail.Text;


                // Validar Imagen
                if (imagenBytes == null)
                {
                    cadenaErrores += "Debe seleccionar una imagen en formato .jpg o .png.\n";
                    errorProvider1.SetError(btnImg, "Selecciona una imagen válida.");
                    valido = false;
                }
                else
                {
                    errorProvider1.SetError(btnImg, "");
                }

                if (valido)
                {
                    try
                    {
                        using (SHA256 mySHA256 = SHA256.Create())
                        {
                            byte[] passwordBytes = Encoding.UTF8.GetBytes(textBoxPass.Text);
                            string hashPasswordIngresada = BitConverter.ToString(mySHA256.ComputeHash(passwordBytes)).Replace("-", "").ToLower();




                                if (edicion == false) ventasADO.IngresarUsuario(textBoxNombre.Text, apellido, textBoxPass.Text, textBoxNIF.Text, direccion, hashPasswordIngresada, email, dtAlta.Value, imagenBytes, (int)cboxTienda.SelectedValue);
                                else { ventasADO.EditarUsuario(textBoxNombre.Text, apellido, textBoxPass.Text, textBoxNIF.Text, direccion, hashPasswordIngresada, email, imagenBytes, (int)cboxTienda.SelectedValue, empleadoIDactualizar); }
                            

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar el empleado: {ex.Message}");
                    }
                }


                else
                {
                    MessageBox.Show("El formulario contiene errores:\n" + cadenaErrores);
                }
            }
        }

        

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
