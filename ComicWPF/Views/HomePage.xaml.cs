using ComicWPF.ViewModels;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Wpf;
using Ventas;

namespace ComicWPF.Views
{
    /// <summary>
    /// Lógica de interacción para HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private const int UpdateIntervalSeconds = 60;
        public HomePage()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            LoadVentasPorEditorialData();
            PedidosPorEmpleadoUltimoAno();
        }
        private void LoadVentasPorEditorialData()
        {
            var ventasPorEditorial = (this.DataContext as MainViewModel)?.LoadVentasPorEditorialData();

            double totalVentas = ventasPorEditorial.Sum(v => v.Value);

            if (ventasPorEditorial != null && ventasPorEditorial.Any())
            {
                SeriesCollection seriesCollection = new SeriesCollection();

                foreach (var venta in ventasPorEditorial)
                {
                    double porcentaje = (venta.Value / totalVentas) * 100;
                    double porcentajeAjustado = porcentaje;
                    porcentajeAjustado = Math.Round(porcentaje, 2);


                    seriesCollection.Add(new LineSeries
                    {
                        Title = venta.Key + " " + porcentajeAjustado + "%",
                        Values = new ChartValues<double> { porcentaje },
                        Stroke = System.Windows.Media.Brushes.HotPink // O cualquier otro color que desees
                    });
                }

                // Asignar las series al gráfico
                grafico1.Series = seriesCollection;
            }
            else
            {
                MessageBox.Show("No hay datos de ventas por editorial.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void PedidosPorEmpleadoUltimoAno()
        {
            var pedidosPorEmpleado = (this.DataContext as MainViewModel)?.LoadPedidosPorEmpleadoUltimoAno();

            if (pedidosPorEmpleado != null && pedidosPorEmpleado.Any())
            {
                double totalPedidos = pedidosPorEmpleado.Sum();

                SeriesCollection seriesCollection = new SeriesCollection();

                foreach (var pedidos in pedidosPorEmpleado)
                {
                    double porcentaje = (pedidos / totalPedidos) * 100;

                    double porcentajeAjustado = Math.Round(porcentaje, 2);

                    seriesCollection.Add(new LineSeries
                    {
                        Title = porcentajeAjustado + "%",
                        Values = new ChartValues<double> { porcentaje },
                        Stroke = System.Windows.Media.Brushes.HotPink
                    });
                }

                grafico2.Series = seriesCollection;
            }
            else
            {
                MessageBox.Show("No hay datos de ventas por empleado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void StartDataUpdate()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += (s, e) => UpdateDashboardData();
            timer.Interval = TimeSpan.FromSeconds(UpdateIntervalSeconds);
            timer.Start();
        }
        private void UpdateDashboardData()
        {
        }

        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateDashboardData();  // Llama al método manualmente
            }
        }
    }
}
