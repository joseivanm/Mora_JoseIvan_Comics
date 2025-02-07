using System;
using System.ComponentModel;

namespace ComicWPF.Models
{
    public class ComicModel : INotifyPropertyChanged
    {
        private int _comicId;
        private string _nombre;
        private string _autor;
        private int _autorId;
        private string _editorial;
        private int _editorialId;
        private decimal _precioVenta;
        private decimal _precioCompra;
        private decimal _stockTiendaActual;
        private decimal _stockOtrasTiendas;

        public int ComicId
        {
            get { return _comicId; }
            set { _comicId = value; OnPropertyChanged(); }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(); }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; OnPropertyChanged(); }
        }

        public int AutorId
        {
            get { return _autorId; }
            set { _autorId = value; OnPropertyChanged(); }
        }

        public string Editorial
        {
            get { return _editorial; }
            set { _editorial = value; OnPropertyChanged(); }
        }

        public int EditorialId
        {
            get { return _editorialId; }
            set { _editorialId = value; OnPropertyChanged(); }
        }

        public decimal PrecioVenta
        {
            get { return _precioVenta; }
            set { _precioVenta = value; OnPropertyChanged(); }
        }

        public decimal PrecioCompra
        {
            get { return _precioCompra; }
            set { _precioCompra = value; OnPropertyChanged(); }
        }

        public decimal StockTiendaActual
        {
            get { return _stockTiendaActual; }
            set { _stockTiendaActual = value; OnPropertyChanged(); }
        }

        public decimal StockOtrasTiendas
        {
            get { return _stockOtrasTiendas; }
            set { _stockOtrasTiendas = value; OnPropertyChanged(); }
        }

        // Evento necesario para notificar a la UI cuando una propiedad cambia
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
