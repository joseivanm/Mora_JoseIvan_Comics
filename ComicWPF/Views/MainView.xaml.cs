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
        }

    
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
