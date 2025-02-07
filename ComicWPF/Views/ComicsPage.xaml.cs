using ComicWPF.Models;
using ComicWPF.Repositories;
using ComicWPF.ViewModels;
using Entidades;
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
    /// Lógica de interacción para ComicsPage.xaml
    /// </summary>
    public partial class ComicsPage : Page
    {
        int editorialId;
        private IUserRepository userRepository;
        private object _comicRepository;
        private object _stockComicRepository;
        private ComicPageModel _viewModel;
        public ComicsPage()
        {
            InitializeComponent();
            userRepository = new UserRepository();
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

  
            var medioDePagoRepository = new MedioDePagoRepository();
            var clienteJIMRepository = new ClienteJIMRepository();
            var editorialRepository = new EditorialRepository();
            var comicRepository = new ComicRepository();
            var stockComicRepository = new StockComicRepository();
            this.DataContext  = new ComicPageModel();
        }


        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = (ComicPageModel)this.DataContext; 
            var searchTerm = SearchTextBox.Text; 
            viewModel.FilterComics(searchTerm); 
        }



        private void ComicsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        }


        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ComicPageModel)this.DataContext;
            viewModel.ShowInsertForm();
        }



        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComicDisplay = (ComicDisplayModel)((DataGrid)sender).SelectedItem;
            if (selectedComicDisplay != null)
            {
                var viewModel = (ComicPageModel)this.DataContext;
                int localId = 1;
            
                viewModel.LoadComicDetails(selectedComicDisplay.ComicId, localId);
            }
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var dataGrid = ComicsDataGrid;
            var viewModel = (ComicPageModel)this.DataContext;
            var selectedComicDisplay = (ComicDisplayModel)dataGrid.SelectedItem;
            if (selectedComicDisplay != null)
            {
                int comicId = selectedComicDisplay.ComicId;
                viewModel.ShowEditForm(comicId);  
                
            }
        }

 
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedComic = (ComicModel)((DataGrid)sender).SelectedItem;
            _viewModel.ShowDeleteForm(selectedComic);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e) { }

        private async void LoadComics()
        {
            var comicModel = this.DataContext as ComicPageModel;

            if (comicModel != null)
            {

               
            }
        }



 


    }

}
