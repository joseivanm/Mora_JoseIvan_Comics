using Microsoft.Reporting.WinForms;
using ReportViewer_NET50_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas;

namespace Comics
{
    public partial class FormEmpleado : Form
    {
        private DataTable empleadosDataTable;

        public FormEmpleado()
        {
            InitializeComponent();
            empleadosDataTable = new DataTable();

            using (VentasADO ventasADO = new VentasADO())
            {
                empleadosDataTable = ventasADO.CargarEmpleados();
                dataGridViewResultados.DataSource = empleadosDataTable;
            }

        }
        
        // Filtra los empleados en tiempo real segun el criterio de busqueda

        private void FiltrarEmpleados(object sender, EventArgs e)
        {
            string filtroNombre = textBoxNombre.Text.Trim();
            string filtroApellido = textBoxApellido.Text.Trim();
            string filtroNIF = textBoxNIF.Text.Trim();

            string filtro = "Activo = 'S'"; // Solo mostrar empleados activos

            if (!string.IsNullOrEmpty(filtroNombre))
                filtro += $" AND Nombre LIKE '%{filtroNombre}%'";
            if (!string.IsNullOrEmpty(filtroApellido))
                filtro += $" AND Apellido LIKE '%{filtroApellido}%'";
            if (!string.IsNullOrEmpty(filtroNIF))
                filtro += $" AND NIF LIKE '%{filtroNIF}%'";

            // Aplicar el filtro al DataView del DataTable
            empleadosDataTable.DefaultView.RowFilter = filtro;
        }


        // Metodo para abrir el formulario de edición cuando se hace doble clic en un empleado
        private void dataGridViewResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView filaSeleccionada = (DataRowView)dataGridViewResultados.Rows[e.RowIndex].DataBoundItem;
                AbrirFormularioEdicion(filaSeleccionada);
            }
        }

        // Metodo para abrir el formulario de edicion cuando se selecciona un empleado
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewResultados.CurrentRow != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dataGridViewResultados.CurrentRow.DataBoundItem;
                AbrirFormularioEdicion(filaSeleccionada);
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para editar.");
            }
        }




        // Abre el formulario de edicion y carga los datos del empleado seleccionado
        private void AbrirFormularioEdicion(DataRowView empleado)
        {
            int empleadoId = (int)empleado["ID"]; // Obtener el ID del empleado seleccionado

            // Crear una instancia del formulario de edicion y pasarle el ID del empleado
            AltaEmpleado formEditar = new AltaEmpleado(empleadoId);
            formEditar.ShowDialog();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewResultados.CurrentRow != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dataGridViewResultados.CurrentRow.DataBoundItem;

                // Obtener el ID del empleado seleccionado
                //int empleadoId = (int)filaSeleccionada["EmpleadoId"];
                int empleadoId = (int)filaSeleccionada["ID"]; // Obtener el ID del empleado seleccionado

                // Confirmación de baja
                DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea dar de baja a este empleado?", "Confirmar baja", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar a la capa de negocio para dar de baja
                        using (VentasADO ventas = new VentasADO())
                        {
                            ventas.BorrarEmpleado(empleadoId);
                        }

                        MessageBox.Show("El empleado ha sido dado de baja correctamente.");

                        using (VentasADO ventasADO = new VentasADO())
                        {
                            empleadosDataTable = ventasADO.CargarEmpleados();
                            dataGridViewResultados.DataSource = empleadosDataTable;
                        }

                        // Actualizar la visualización en el DataGridView
                        // (Puedes refrescar los datos aquí si es necesario)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al dar de baja al empleado: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para dar de baja.");
            }
        }
    }
}
