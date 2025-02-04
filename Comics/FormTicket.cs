using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;  
using Comics;
using Ventas;
using Entidades;

namespace ReportViewer_NET50_
{
    //<author>Jose Ivan Mora Gonzaga</author>
    public partial class FormTicket : Form
    {
        private readonly ReportViewer reportViewer;
        private int operacionId;
        private Operacion operacion;

        public FormTicket(int operacionId)
        {
            InitializeComponent();
            this.operacionId = operacionId;
            Text = "Report viewer";
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            Controls.Add(reportViewer);
            CargarDatosOperacion(operacionId);
        }

        public FormTicket()
        {
            InitializeComponent();
            Text = "Report viewer";
            WindowState = FormWindowState.Maximized;
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            Controls.Add(reportViewer);
        }

        protected override void OnLoad(EventArgs e)
        {
            Informe.Load(reportViewer.LocalReport, operacion);
            reportViewer.RefreshReport();
            base.OnLoad(e);
        }

        public void CargarDatosOperacion(int operacionId)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                operacion = ventasADO.datosOperacion(operacionId);

            }
            //MessageBox.Show(Convert.ToString(operacion.OperacionId));
        }
    }
}
