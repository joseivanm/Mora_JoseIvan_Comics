using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ComicWPF.Models;
using ComicWPF.Repositories;
using LiveCharts;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WPF;
using Ventas;


namespace ComicWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        private IPedidoRepository pedidoRepository;
        private const int UpdateIntervalSeconds = 60;
        public List<ISeries> PedidosSeries { get; set; }
        public List<ISeries> VentasPorEditorialSeries { get; set; }
        
        private DispatcherTimer _timer;

        public int PedidosHoy { get; set; }
        public string ImporteHoy { get; set; }
        public string StockBajo { get; set; }
        public string TotalPedidos { get; set; }

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            pedidoRepository = new PedidoRepository();

            CurrentUserAccount = new UserAccountModel();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(UpdateIntervalSeconds);
            _timer.Tick += (s, e) => UpdateDashboardData();
            _timer.Start();
           
            LoadVentasPorEditorialData();

            LoadDashboardData();
            LoadCurrentUserData();
        }
        public List<KeyValuePair<string, double>> LoadVentasPorEditorialData()
        {
            try
            {
                
                var ventasPorEditorial = pedidoRepository.GetVentasPorEditorial();

               
                return ventasPorEditorial;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las ventas por editorial: {ex.Message}");
                return null;
            }
        }

        public List<int> LoadPedidosPorEmpleadoUltimoAno()
        {
            try
            {
                
                var ventasPorEditorial = pedidoRepository.GetPedidosPorEmpleadoUltimoAno();

                
                return ventasPorEditorial;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las ventas por editorial: {ex.Message}");
                return null;
            }
        }




        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Usuario {user.Name} {user.LastName})"; 
                CurrentUserAccount.ProfilePicture = null; 
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in"; 
            }
        }

        private void LoadDashboardData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            int usuarioId = Convert.ToInt32(user.Id);

            PedidosHoy = (int)pedidoRepository.GetImportePedidosHoyUsuario(usuarioId);
            ImporteHoy = pedidoRepository.GetImportePedidosHoy().ToString("C");
            StockBajo = pedidoRepository.GetProductosConStockBajo().ToString();
            TotalPedidos = pedidoRepository.GetTotalPedidosUltimoMes(usuarioId).ToString();

            LoadChartData();
        }


        public void UpdateDashboardData()
        {
            try
            {
                var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                int usuarioId = Convert.ToInt32(user.Id);
                PedidosHoy = (int)pedidoRepository.GetImportePedidosHoyUsuario(usuarioId);

                ImporteHoy = pedidoRepository.GetImportePedidosHoy().ToString("C");

                StockBajo = pedidoRepository.GetProductosConStockBajo().ToString();

                TotalPedidos = pedidoRepository.GetTotalPedidosUltimoMes(Convert.ToInt32(user.Id)).ToString();

                LoadChartData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los datos del dashboard: {ex.Message}");
            }
        }


        private void LoadChartData()
        {
   
            PedidosSeries = new List<ISeries>
        {
            new ColumnSeries<double> { Values = new List<double> { 10, 25, 30, 50 } }
        };

            VentasPorEditorialSeries = new List<ISeries>
        {
            new PieSeries<double>
            {
                Values = new List<double> { 40, 30, 30 },
                Name = "Editorial A"
            }
        };
        }
    }
}




