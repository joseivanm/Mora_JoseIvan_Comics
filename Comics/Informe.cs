using Microsoft.Reporting.WinForms;  
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ventas;
using System.Windows.Forms;
using ReportViewer_NET50_;
using Entidades;

namespace Comics
{
    //<author>Jose Ivan Mora Gonzaga</author>
    public class Informe
    {

        public static void Load(Microsoft.Reporting.WinForms.LocalReport report, Operacion operacion)
        {
            // Lista para los elementos del informe
            List<ElementosInforme> elementos = new List<ElementosInforme>();
            string titulo = string.Empty;
            decimal totalOperacion = 0;
            decimal iva = 0;
            decimal totalConIva = 0;

            using (VentasADO ventasADO = new VentasADO())
            {


                try
                {
                    // Obtener los detalles de la operación
                    var detalles = ventasADO.ListaComicsDetallesOperacion(operacion.OperacionId);

                    if (detalles.Any())
                    {
                        var primeraOperacion = detalles.FirstOrDefault();
                        titulo = $"Ticket - Operación #{primeraOperacion.OperacionId}";
                    }

                    // Convertir los detalles a ElementosInforme
                    elementos = detalles.Select(d => new ElementosInforme
                    {
                        DetalleOperacionId = d.DetalleOperacionId,
                        OperacionId = d.OperacionId,
                        ComicId = d.ComicId,
                        Cantidad = d.Cantidad,
                        Precio = d.Precio,
                        Descuento = d.Descuento,
                        nombreComic = ObtenerNombreComic(d),
                        TiendaId = operacion.LocalId,
                        nombreTienda = ObtenerNombreLocal(operacion.LocalId),
                        fechaOperacion = operacion.FechaOperacion,
                        nombreEmpleado = ObtenerNombreEmpleado(operacion.EmpleadoId),
                        PrecioTotal = (decimal)((d.Cantidad * d.Precio)),
                        nombrePago = ObtenerNombrePago(operacion.MedioDePagoId)

                    }).ToList();
                    totalOperacion = elementos.Sum(e => e.PrecioTotal);
                    iva = totalOperacion * 0.21m;
                    totalConIva = totalOperacion + iva;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los detalles de la operación: {ex.Message}");
                }
            }

            // Cargar el archivo RDLC
            using (var fs = new FileStream("TicketSimple.rdlc", FileMode.Open))
            {
                report.LoadReportDefinition(fs);
            }

            // Establecer los datos y parámetros del informe
            report.DataSources.Add(new ReportDataSource("DatosInforme", elementos));
            report.SetParameters(new[]
    {
        new ReportParameter("Titulo", titulo),
        new ReportParameter("TotalOperacion", totalOperacion.ToString("F2")), // Mostrar con 2 decimales
        new ReportParameter("Iva", iva.ToString("F2")), // Mostrar con 2 decimales
        new ReportParameter("TotalConIva", totalConIva.ToString("F2")) // Mostrar con 2 decimales
    });

            try
            {
                // Opcional: Generar el archivo PDF y guardarlo en disco
                byte[] pdfBytes = report.Render("PDF");
                File.WriteAllBytes("TicketOperacion_" + operacion.OperacionId + ".pdf", pdfBytes);  // Guarda el PDF en un archivo
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}");
            }
        }
        public static string ObtenerNombreComic(DetalleOperacion detalleOperacion)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                return ventasADO.obtenerNombreComic(detalleOperacion.ComicId);
            }

        }
        public static string ObtenerNombreEmpleado(int empleadoId)
        {
            string idEmpleado = Convert.ToString(empleadoId);
            using (VentasADO ventasADO = new VentasADO())
            {
                Empleado empleado = ventasADO.ListarEmpleado(idEmpleado);
                return empleado.Nombre;
            }

        }

        public static string ObtenerNombreLocal(int localId)
        {
            string idLocal = Convert.ToString(localId);
            using (VentasADO ventasADO = new VentasADO())
            {
                Local local = ventasADO.ObtenerLocalPorId(idLocal);
                return local.Nombre;
            }

        }
        public static string ObtenerNombrePago(int pagoId)
        {
            string idPago = Convert.ToString(pagoId);
            using (VentasADO ventasADO = new VentasADO())
            {
                MedioDePago medioDePago = ventasADO.ObtenerMedioPagoPorId(idPago);
                return medioDePago.NombreCorto;
            }

        }

    }
}
