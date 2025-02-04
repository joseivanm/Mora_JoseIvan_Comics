using ComicADO;
using ComicWPF.Models;
using Entidades;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ventas;
using LiveChartsCore.SkiaSharpView.WPF;
using LiveChartsCore.Kernel;

namespace ComicWPF.Repositories
{
    //<author>Jose Ivan Mora Gonzaga</author>
    public class PedidoRepository : RepositoryBase, IPedidoRepository
    {
        private void LoadPedidosPorEmpleadoData()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    var pedidosPorEmpleado = ventasADO.GetPedidosPorEmpleadoUltimoAno();


                    var chartPedidosPorEmpleado = new CartesianChart();
                    chartPedidosPorEmpleado.Series = new List<ISeries>
                    {new ColumnSeries<int> { Values = new List<int>(pedidosPorEmpleado) }
                };

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos de pedidos por empleado: {ex.Message}");
                }
            }
        }
        private void LoadVentasPorEditorialData()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    var ventasPorEditorial = ventasADO.GetVentasPorEditorial();

                    var chartVentasPorEditorial = new PieChart();

                    chartVentasPorEditorial.Series = new List<ISeries>
            {
                new PieSeries<double>
                {
                    Values = new List<double>(ventasPorEditorial.Select(v => v.Value)),
                    Name = "Ventas por Editorial",
                    ToolTipLabelFormatter = new Func<ChartPoint, string>(point => $"{ventasPorEditorial.ElementAt(point.Index).Key}: {point.Coordinate} ventas")
                }
            };

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos de ventas por editorial: {ex.Message}");
                }
            }
        }




        public decimal GetImportePedidosHoy()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    return ventasADO.GetImportePedidosHoy();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener el importe de los pedidos de hoy1: {ex.Message}");
                }
            }
        }

        public decimal GetImportePedidosHoyUsuario(int usuarioId)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    return ventasADO.GetImportePedidosHoyUsuario(usuarioId);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener el importe de los pedidos de hoy para el usuario: {ex.Message}");
                }
            }
        }

        public int GetProductosConStockBajo()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    var productosConStockBajo = ventasADO.GetProductosConStockBajo();
                    return productosConStockBajo;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener los productos con stock bajo: {ex.Message}");
                }
            }
        }
        public List<KeyValuePair<string, double>> GetVentasPorEditorial()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    
                    var ventasPorEditorial = ventasADO.GetVentasPorEditorial();
                    return ventasPorEditorial;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener las ventas por editorial: {ex.Message}");
                }
            }
        }

        public List<int> GetPedidosPorEmpleadoUltimoAno()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {

                    var ventasPorEditorial = ventasADO.GetPedidosPorEmpleadoUltimoAno();
                    return ventasPorEditorial;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener las ventas por editorial: {ex.Message}");
                }
            }
        }


        public int GetTotalPedidosUltimoMes(int usuarioId)

        {
            
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    return ventasADO.GetTotalPedidosUltimoMes(usuarioId);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener los pedidos del último mes para el usuario: {ex.Message}");
                }
            }
        }

        public string GetTotalPedidosUltimoMes(string id)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    int devuelto = ventasADO.GetTotalPedidosUltimoMes(Convert.ToInt32(id));
                    return Convert.ToString(devuelto);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener los pedidos del último mes para el usuario: {ex.Message}");
                }
            }
        }
    }
}
