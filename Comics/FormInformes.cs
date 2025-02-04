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
    //<author>Jose Ivan Mora Gonzaga</author>
    public partial class FormInformes : Form
    {
        private DataTable ordenesDataTable;
        private bool edicionFecha = false;


        public FormInformes()
        {
            InitializeComponent();
            ordenesDataTable = new DataTable();

            using (VentasADO ventasADO = new VentasADO())
            {
                ordenesDataTable = ventasADO.CargarOperaciones();
                dataGridViewResultados.DataSource = ordenesDataTable;
            }

        }



        // Filtra los empleados en tiempo real segun el criterio de busqueda

        private void FiltrarOperaciones(object sender, EventArgs e)
        {
            // Obtener los valores de los filtros
            int idOperacion = 0;
            int medioPago = 0;
            int tipoOperacion = 0;

            // Intentar convertir los valores de los filtros de forma segura
            int.TryParse(textBoxOperacionID.Text, out idOperacion);
            int.TryParse(textBoxMedioDePago.Text, out medioPago);
            if (rbCompra.Checked) tipoOperacion = 1;
            if (rbVenta.Checked) tipoOperacion = 2;
            //int.TryParse(textBoxTipoOperacion.Text, out tipoOperacion);

            // Filtro base
            string filtro = "1 = 1"; // Esto siempre es verdadero, para que se apliquen los filtros adicionales correctamente

            // Aplicar los filtros según los campos
            if (idOperacion != 0)
                filtro += $" AND OperacionID = {idOperacion}";
            if (medioPago != 0)
                filtro += $" AND Medio_De_Pago = {medioPago}";
            if (tipoOperacion != 0)
                filtro += $" AND Tipo_Operacion = {tipoOperacion}";

            string fechaOperacion = dtOperacion.Value.ToString("dd-MM-yyyy");

            if(edicionFecha == true)
                filtro += $" AND Fecha_Operacion >= '{fechaOperacion} 00:00:00' AND Fecha_Operacion < '{fechaOperacion} 23:59:59'";

            // Aplicar el filtro al DataView del DataTable
            ordenesDataTable.DefaultView.RowFilter = filtro;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada
            if (dataGridViewResultados.SelectedRows.Count > 0)
            {
                // Obtener la ID de la operación de la fila seleccionada
                int operacionId = Convert.ToInt32(dataGridViewResultados.SelectedRows[0].Cells["OperacionID"].Value);

                // Abrir el formulario `FormTicket` pasando la ID de la operación
                FormTicket formEditar = new FormTicket(operacionId);
                formEditar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una operación antes de continuar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                dtOperacion.Enabled = true;
                edicionFecha = true;
                FiltrarOperaciones(sender, e);
            }
            else
            {
                dtOperacion.Enabled = false;
                edicionFecha = false;
                FiltrarOperaciones(sender, e);
            }
        }
    }
}
