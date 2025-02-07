using ComicWPF.Models;
using ComicWPF.Repositories;
using ComicWPF.ViewModels;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace ComicWPF.Views
{
    /// <summary>
    /// Lógica de interacción para ComicFormEditModel.xaml
    /// </summary>
    public partial class ComicFormEditModel : UserControl
    {
        int editorialId;
        private IUserRepository userRepository;
        private object _stockComicRepository;

        private readonly ComicFormEditModel _viewModel;
        private readonly IComicRepository _comicRepository;
        public ComicFormEditModel(int comicId)
        {
            InitializeComponent();
            //_viewModel = new ComicFormModel(comicId);
            this.DataContext = _viewModel;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var model = (ComicFormModel)this.DataContext;
            int editorialId = (int)cmbEditorial.SelectedValue;
            // int metodoPago = (int)cmbMetodoPagoAdd.SelectedValue;
            int clientId = (int)ClientNameTextBox.SelectedValue;
            int localId = 1; // TO-DO NEED CHANGE
            int empleadoId = 1; //CHANGE
            int precioCompra = 0;
            int cantidad = 0;
            bool rbCliente = false;
            rbCliente = rcCliente.IsChecked == true;
           // int comicId = Convert.ToInt32(ComicNameTextBox.SelectedValue);


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



           // model.btnCreateComic_Click(editorialId, localId, metodoPago, clientId, comicId, empleadoId, precioCompra, cantidad, rbCliente);
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
    }

}
