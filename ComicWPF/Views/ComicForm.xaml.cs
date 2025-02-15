using System;
using System.Windows;
using ComicWPF.Models;
using ComicWPF.ViewModels;
using Entidades;
using System.Windows.Controls;
using ComicWPF.Repositories;
using ComicADO;
using Microsoft.VisualBasic.ApplicationServices;


namespace ComicWPF.Views
{
    public partial class ComicForm : UserControl
    {
        int editorialId;
        private IUserRepository userRepository;
        private object _stockComicRepository;
        private readonly ComicFormModel _viewModel;
        private readonly IComicRepository _comicRepository;
        private bool edicion = false;

        public ComicForm(IComicRepository comicRepository)
        {
            InitializeComponent();
            userRepository = new UserRepository();
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

            var medioDePagoRepository = new MedioDePagoRepository();
            var clienteJIMRepository = new ClienteJIMRepository();
            var editorialRepository = new EditorialRepository();
            var stockComicRepository = new StockComicRepository();
            _viewModel = new ComicFormModel(medioDePagoRepository, clienteJIMRepository, editorialRepository, user, comicRepository, stockComicRepository);
            this.DataContext = _viewModel; 
        }
        public ComicForm(int comicId)
        {
            InitializeComponent();
            userRepository = new UserRepository();
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

       
            var medioDePagoRepository = new MedioDePagoRepository();
            var clienteJIMRepository = new ClienteJIMRepository();
            var editorialRepository = new EditorialRepository();
            var stockComicRepository = new StockComicRepository();

    
            _viewModel = new ComicFormModel(medioDePagoRepository, clienteJIMRepository, editorialRepository, user, comicId, stockComicRepository);
            this.DataContext = _viewModel;
            edicion = true;

            _viewModel.LoadComic(comicId);
        }





        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OperationMessage = "Operación cancelada.";
            var parent = this.Parent as Panel; 


            if (parent != null)
            {
                parent.Children.Remove(this);
            }
        }


        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            var confirmResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este cómic?", "Confirmar Eliminación", MessageBoxButton.YesNo);
            if (confirmResult == MessageBoxResult.Yes)
            {
                bool result = await _comicRepository.EliminarComic(_viewModel.Comic.ComicId);
                _viewModel.OperationMessage = result ? "Cómic eliminado correctamente." : "Error al eliminar el cómic.";
            }
        }
    }
}
