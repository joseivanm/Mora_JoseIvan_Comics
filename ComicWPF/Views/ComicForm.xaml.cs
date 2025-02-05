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

            // Asigna _viewModel y DataContext en un solo paso
            _viewModel = new ComicFormModel(medioDePagoRepository, clienteJIMRepository, editorialRepository, user, comicRepository, stockComicRepository);
            this.DataContext = _viewModel;  // Usa _viewModel para DataContext
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
            // Validación de campos
            /*if (string.IsNullOrEmpty(_viewModel.Comic.Nombre) ||
                string.IsNullOrEmpty(_viewModel.Comic.Autor) ||
                string.IsNullOrEmpty(_viewModel.Comic.Editorial))
            {
                _viewModel.OperationMessage = "Todos los campos son obligatorios.";
                return;
            }

            bool result = false;

            // Si el cómic tiene un Id (es decir, es una modificación)
            if (_viewModel.Comic.ComicId > 0)
            {
                result = await _comicRepository.ModificarComic(_viewModel.Comic);
                _viewModel.OperationMessage = result ? "Cómic modificado correctamente." : "Error al modificar el cómic.";
            }
            else
            {
                // Si no tiene Id (es un nuevo cómic)
                result = await _comicRepository.InsertarComic(_viewModel.Comic);
                _viewModel.OperationMessage = result ? "Cómic insertado correctamente." : "Error al insertar el cómic.";
            }

            // Mostrar mensaje de operación
            _viewModel.OperationMessage = result ? "Operación exitosa." : "Hubo un error en la operación.";*/
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
