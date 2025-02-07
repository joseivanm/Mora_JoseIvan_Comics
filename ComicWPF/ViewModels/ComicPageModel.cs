using System.Collections.ObjectModel;  // Necesario para ObservableCollection
using System.ComponentModel;
using System.Linq;
using System.Text;
using ComicWPF.Models;
using ComicWPF.Repositories;
using Entidades;
using System.Windows;
using System.Windows.Controls;
using ComicWPF.Views;

namespace ComicWPF.ViewModels
{
    public class ComicPageModel : INotifyPropertyChanged
    {
        private readonly ComicRepository _comicRepository;

        private ObservableCollection<ComicModel> _comics;
        public ObservableCollection<ComicDisplayModel> Comics { get; set; }


        private ComicModel _selectedComic; 
        public ComicModel SelectedComic
        {
            get { return _selectedComic; }
            set
            {
                if (_selectedComic != value)
                {
                    _selectedComic = value;
                    OnPropertyChanged(nameof(SelectedComic)); // Notificar cambios a la interfaz
                }
            }
        }
        private ObservableCollection<StockComic> _stockOtrasTiendas;
        public ObservableCollection<StockComic> StockOtrasTiendas
        {
            get { return _stockOtrasTiendas; }
            set
            {
                if (_stockOtrasTiendas != value)
                {
                    _stockOtrasTiendas = value;
                    OnPropertyChanged(nameof(StockOtrasTiendas));
                }
            }
        }
        private StockComic _stockTiendaActual;
        public StockComic StockTiendaActual
        {
            get { return _stockTiendaActual; }
            set
            {
                if (_stockTiendaActual != value)
                {
                    _stockTiendaActual = value;
                    OnPropertyChanged(nameof(StockTiendaActual));
                }
            }
        }
        private UserControl _currentUserControl;
        public UserControl CurrentUserControl
        {
            get { return _currentUserControl; }
            set
            {
                _currentUserControl = value;
                OnPropertyChanged(nameof(CurrentUserControl));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ComicPageModel()
        {
            _comicRepository = new ComicRepository();
            Comics = new ObservableCollection<ComicDisplayModel>();
            StockOtrasTiendas = new ObservableCollection<StockComic>();
            CurrentUserControl = null;
            LoadComics();
        }
        public void ShowInsertForm()
        {
            var comicForm = new ComicForm(_comicRepository);
            CurrentUserControl = comicForm;
        }
        public void ShowEditForm(int comicId)
        {
            var comicForm = new ComicForm(comicId);

            CurrentUserControl = comicForm;
        }

        public void ShowDeleteForm(ComicModel selectedComic)
        {
            var comicForm = new ComicForm(_comicRepository);

            CurrentUserControl = comicForm;
        }
        public void LoadComicDetails(int comicId, int tiendaId)
        {
            var (comic, stockOtrasTiendas, stockTiendaActual) = _comicRepository.obtenerDetallesComic(comicId, tiendaId);

            if (comic != null)
            {
                SelectedComic = new ComicModel
                {
                    ComicId = comic.ComicId,
                    Nombre = comic.Nombre,
                    Autor = comic.Autor?.Nombre,
                    Editorial = comic.Editorial?.Nombre,
                    PrecioVenta = comic.PrecioVenta ?? 0,
                    PrecioCompra = comic.PrecioCompra ?? 0
                };
                StockOtrasTiendas.Clear();
                foreach (var stock in stockOtrasTiendas)
                {
                    StockOtrasTiendas.Add(stock);
                }

                StockTiendaActual = stockTiendaActual;
            }
        }

            // Método para convertir un objeto Entidades.Comic a ComicModel
            private ComicModel ConvertToComicModel(Entidades.Comic comic)
        {
            return new ComicModel
            {
                ComicId = comic.ComicId,
                Nombre = comic.Nombre,
                Autor = comic.Autor?.Nombre,
                Editorial = comic.Editorial?.Nombre,
                PrecioVenta = comic.PrecioVenta ?? 0,
                PrecioCompra = comic.PrecioCompra ?? 0,
                StockTiendaActual = comic.StockComics?.Sum(sc => sc.Cantidad) ?? 0 
            };
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void FilterComics(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            var filteredComics = _comicRepository.LoadComics()
                .Where(c => (c.Nombre.ToLower().Contains(searchTerm)) ||
                            (c.Autor?.Nombre?.ToLower() ?? "").Contains(searchTerm) ||
                            (c.Editorial?.Nombre?.ToLower() ?? "").Contains(searchTerm))
                .Select(c => new ComicDisplayModel
                {
                    Nombre = c.Nombre,
                    Autor = c.Autor?.Nombre,
                    Editorial = c.Editorial?.Nombre,
                    PrecioVenta = c.PrecioVenta ?? 0
                }).ToList();
            Comics.Clear();
            foreach (var comic in filteredComics)
            {
                Comics.Add(comic);
            }
        }

        public void LoadComics()
        {
            var comics = _comicRepository.LoadComics(); 

            Comics.Clear();

            var comicsDisplay = comics.Select(c => new ComicDisplayModel
            {
                ComicId = c.ComicId,
                Nombre = c.Nombre,
                Autor = c.Autor?.Nombre,
                Editorial = c.Editorial?.Nombre,
                PrecioVenta = c.PrecioVenta ?? 0
            }).ToList();

            foreach (var comic in comicsDisplay)
            {
                Comics.Add(comic); 
            }
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComic = (ComicModel)((DataGrid)sender).SelectedItem;
            if (selectedComic != null)
            {
                SelectedComic = selectedComic;
            }
        }
    }
}
