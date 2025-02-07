using System;
using System.Windows;
using ComicWPF.Models;
using ComicWPF.ViewModels;
using Entidades;
using System.Windows.Controls;
using ComicWPF.Repositories;
using ComicADO;


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

            // Crea las instancias de los repositorios
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


        private void btnLoadComics_Click(object sender, RoutedEventArgs e)
        {
            var model = (ComicFormModel)this.DataContext;
            int editorialId = (int)cmbEditorial.SelectedValue;
            int localId = 1; // TO-DO NEED CHANGE

            model.ListarComicsEditorialyLocal(editorialId, localId);
        }

        // Método para el botón Guardar (Insertar o Modificar cómic)
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!edicion)
            {
                var model = (ComicFormModel)this.DataContext;
                int editorialId = (int)cmbEditorial.SelectedValue;
                int metodoPago = (int)cmbMetodoPagoAdd.SelectedValue;
                int clientId = (int)ClientNameTextBox.SelectedValue;
                int localId = 1; // TO-DO NEED CHANGE
                int empleadoId = 1; //CHANGE
                int precioCompra = 0;
                int cantidad = 0;
                bool rbCliente = false;
                rbCliente = rcCliente.IsChecked == true;
                int comicId = Convert.ToInt32(ComicNameTextBox.SelectedValue);


                if (int.TryParse(BuyPriceTextBox.Text, out precioCompra))
                {

                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un valor numérico válido para el precio de compra.");
                }


                if (int.TryParse(texboxCantidad.Text, out cantidad))
                {
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un valor numérico válido para la cantidad.");
                }



                model.btnCreateComic_Click(editorialId, localId, metodoPago, clientId, comicId, empleadoId, precioCompra, cantidad, rbCliente);
            }
            else
            {
                var model = (ComicFormModel)this.DataContext;
                int editorialId = (int)cmbEditorial.SelectedValue;
                int autor = (int)cmbAutores.SelectedValue;
                int comicId = Convert.ToInt32(ComicNameTextBox.SelectedValue);
                string nombreComic = texboxCantidad.Text;

                model.btnEditComic_Click(comicId, nombreComic, editorialId, autor);
            }

        }

        // Método para el botón Cancelar
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Puedes realizar cualquier acción de cancelación, como limpiar el formulario o cerrar el UserControl
            _viewModel.OperationMessage = "Operación cancelada.";
        }

        // Método para el botón Eliminar (si es necesario)
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Confirmación de eliminación
            var confirmResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este cómic?", "Confirmar Eliminación", MessageBoxButton.YesNo);
            if (confirmResult == MessageBoxResult.Yes)
            {
                bool result = await _comicRepository.EliminarComic(_viewModel.Comic.ComicId);
                _viewModel.OperationMessage = result ? "Cómic eliminado correctamente." : "Error al eliminar el cómic.";
            }
        }
    }
}
