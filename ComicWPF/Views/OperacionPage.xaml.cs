using ComicWPF.Repositories;
using ComicWPF.ViewModels;
using System.Windows;
using ComicWPF.Models;
using System.Windows.Controls;
using Entidades;
using System.Collections.ObjectModel;

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

            // Crea las instancias de los repositorios
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
            // Obtener el cómic seleccionado desde el ComboBox
            var comicSelected = (ComicModel)cmbComics.SelectedItem;

            // Llamar al método AddComic en el ViewModel
            var model = (OperacionPageModel)this.DataContext;
            model.AddComic(comicSelected);
        }
    }

}
