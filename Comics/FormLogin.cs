using ComicADO;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas;

namespace Comics
{
    public partial class FormLogin : Form
    {

        private Empleado empleado1;
        public FormLogin()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passwordIngresada = txtPassword.Text;
            string palabra = "y";


            // Hasheamos la contraseña que ingresa el usuario
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] hashValue;
                byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordIngresada);

                // Hasheamos la contraseña ingresada
                hashValue = mySHA256.ComputeHash(passwordBytes);

                // Convertimos el hash a formato hexadecimal
                string hashPasswordIngresada = BitConverter.ToString(hashValue).Replace("-", "").ToLower();

                // Abrimos el acceso a la base de datos
                using (VentasADO ventasADO = new VentasADO())
                {
                    try
                    {
                        // Obtenemos la lista de empleados desde la base de datos
                        List<Empleado> empleados = ventasADO.ListarEmpleados();

                        bool loginExitoso = false;

                        // Iteramos sobre la lista de empleados
                        foreach (Empleado empleado in empleados)
                        {
                            // Hasheamos la contraseña almacenada en la base de datos para este empleado
                            string hashPasswordAlmacenada = empleado.Password;  // Contraseña almacenada en la DB
                            if (empleado.Nif == txtUserName.Text) { palabra = hashPasswordIngresada; }

                            // Verificamos si el nombre de usuario y la contraseña coinciden
                            if (empleado.Nif == txtUserName.Text && hashPasswordIngresada == hashPasswordAlmacenada)
                            {
                                loginExitoso = true;
                                empleado1 = empleado;



                                new Form1(empleado).Show();
                                this.Hide();
                                break; // Salimos del bucle si encontramos un login exitoso
                            }
                        }

                        // Si el login es exitoso, mostramos el siguiente formulario
                        if (loginExitoso)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos" + palabra);
                            txtUserName.Clear();
                            txtPassword.Clear();
                            txtUserName.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al listar los empleados: {ex.Message}");
                    }

                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void foto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Seleccionar una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta de la imagen seleccionada
                    string filePath = openFileDialog.FileName;

                    // Leer la imagen como bytes
                    byte[] imagenBytes = File.ReadAllBytes(filePath);

                    // Guardar la imagen en la base de datos (suponiendo que el ID del empleado se conoce)
                    int empleadoId = 1; // Cambia esto por el ID del empleado correspondiente
                    using (EmpleadoADO empleadoADO = new EmpleadoADO())
                    {
                        try
                        {
                            empleadoADO.ActualizarFotografia(empleadoId, imagenBytes);
                            MessageBox.Show("Imagen guardada exitosamente.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al guardar la imagen: {ex.Message}");
                        }
                    }
                }
            }
        }*/

    }
}
