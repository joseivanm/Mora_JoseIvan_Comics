using ComicWPF.Repositories;
using ComicWPF.ViewModels;
using System.Windows;
using ComicWPF.Models;
using System.Windows.Controls;
using Entidades;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Ventas;
using MessageBox = System.Windows.MessageBox;

namespace ComicWPF.Views
{
    /// <summary>
    /// Lógica de interacción para OperacionPage.xaml
    /// </summary>
    public partial class OperacionPage : Window
    {
        int editorialId;
        private IUserRepository userRepository;
        private object _comicRepository;
        private object _stockComicRepository;

        public OperacionPage()
        {

            InitializeComponent();
            userRepository = new UserRepository();
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

            var medioDePagoRepository = new MedioDePagoRepository();
            var clienteJIMRepository = new ClienteJIMRepository();
            var editorialRepository = new EditorialRepository();
            var comicRepository = new ComicRepository();
            var stockComicRepository = new StockComicRepository();

            this.DataContext = new OperacionPageModel(medioDePagoRepository, clienteJIMRepository, editorialRepository, user, comicRepository, stockComicRepository);
        }
        
    }

}
