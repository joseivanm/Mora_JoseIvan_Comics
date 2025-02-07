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
    public partial class OperacionPage : Page
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

        private void btnLoadComics_Click(object sender, RoutedEventArgs e)
        {
            var model = (OperacionPageModel)this.DataContext;
            int editorialId = (int)cmbEditorial.SelectedValue; 
            int localId = 1; // TO-DO NEED CHANGE

            model.ListarComicsEditorialyLocal(editorialId, localId);
        }

        private void btnAddComic_Click(object sender, RoutedEventArgs e)
        {

            var comicSelected = (OperacionModel)cmbComics.SelectedItem;

            if (comicSelected != null)
            {
   
                var model = (OperacionPageModel)this.DataContext;
                model.AddComic(comicSelected);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cómic.");
            }
        }

        private void buttonVenta_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un método de pago.");
                return;
            }
            if (cmbClientes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un cliente.");
                return;
            }

            int medioPago = ((MedioDePago)cmbMetodoPago.SelectedValue).MedioDePagoId;
            int localID = 1;
            int empleadoId = 1;
            int clienteId = ((ClienteJimModel)cmbClientes.SelectedValue).ClienteID;

            var model = (OperacionPageModel)this.DataContext;
            model.Vender(medioPago, localID, clienteId, empleadoId);
        }
    }

}
