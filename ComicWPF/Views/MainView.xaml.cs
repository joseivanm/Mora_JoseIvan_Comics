using System;
using System.Windows;
using ComicWPF.ViewModels;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveCharts;
using LiveCharts.Wpf;
using ComicWPF.Repositories;
using ComicWPF.Models;
using System.Text;
using Entidades;

namespace ComicWPF.Views
{
    public partial class MainView : Window
    {
        //<author>Jose Ivan Mora Gonzaga</author>
        private const int UpdateIntervalSeconds = 60;
        public List<ISeries> PedidosSeries { get; set; }
        public List<ISeries> VentasPorEditorialSeries { get; set; }
        private IPedidoRepository pedidoRepository;

        public MainView()
        {
            InitializeComponent();
           // StartDataUpdate();
           // LoadPedidosData();
            // LoadVentasPorEditorialData();
            //PedidosPorEmpleadoUltimoAno();


            

        }

        /*private void PedidosPorEmpleadoUltimoAno()
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
        }*/

       /* private void LoadPedidosData()
        {



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
        }*/
        private void Home_Click(object sender, RoutedEventArgs e) {
            MainContent.Content = new HomePage();
        }
        private void Comics_Click(object sender, RoutedEventArgs e) {
           MainContent.Content = new ComicsPage();
        }
        private void Operaciones_Click(object sender, RoutedEventArgs e) {
            MainContent.Content = new OperacionPage();
        }
        private void Stock_Click(object sender, RoutedEventArgs e) { }
        private void Clientes_Click(object sender, RoutedEventArgs e) {  }
        private void Estadisticas_Click(object sender, RoutedEventArgs e) {  }

        private void Minimize_Click(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }
        private void Maximize_Click(object sender, RoutedEventArgs e) { WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized; }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
 
            MessageBoxResult result = MessageBox.Show("¿Seguro que deseas salir?", "Confirmar salida", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; 
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {

            var confirmExit = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButton.YesNo);
            if (confirmExit == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
