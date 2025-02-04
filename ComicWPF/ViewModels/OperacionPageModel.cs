using ComicWPF.Models;
using Entidades;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace ComicWPF.ViewModels
{
    public class OperacionPageModel : INotifyPropertyChanged
    {
        private readonly IMedioDePagoRepository _medioDePagoRepository;
        private readonly IClienteJIMRepository _clienteJIMRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IComicRepository _comicRepository;
        private readonly IStockComicRepository _stockComicRepository;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<EditorialModel> Editoriales { get; set; }
        public List<MedioDePago> MediosDePagoList { get; set; }
        public List<ClienteJimModel> ClientesList { get; set; }
        private List<ComicModel> _comicss;

        public List<ComicModel> Comicss
        {
            get { return _comicss; }
            set
            {
                _comicss = value;
                OnPropertyChanged(nameof(Comicss));  // Notificar el cambio
            }
        }

        public OperacionPageModel(IMedioDePagoRepository medioDePagoRepository,
                                   IClienteJIMRepository clienteJIMRepository,
                                   IEditorialRepository editorialRepository,
                                   UserModel user,
                                   IComicRepository comicRepository,
                                   IStockComicRepository stockComicRepository)
        {
            _medioDePagoRepository = medioDePagoRepository;
            _clienteJIMRepository = clienteJIMRepository;
            _editorialRepository = editorialRepository;
            _comicRepository = comicRepository;
            _stockComicRepository = stockComicRepository;

            LoadMediosDePago();
            LoadClientes();
            LoadEditorialesPorEmpleado(user.Id);
        }
        public void AddComic(ComicModel comicSelected)
        {
            /* if (comicSelected == null)
             {
                 MessageBox.Show("Por favor, selecciona un cómic.");
                 return;
             }

             bool comicExists = false;

             // Verificar si el cómic ya existe en la lista
             foreach (var item in Comicss)
             {
                 if (item.Nombre == comicSelected.Nombre)
                 {
                     int cantidadActual = (int)item.StockTiendaActual;

                     // Verificar si se supera el stock
                     var stockComic = _stockComicRepository.ListarPorComicId(comicSelected); // Deberías pasar el ComicId directamente
                     if (cantidadActual + 1 > stockComic.Cantidad)
                     {
                         MessageBox.Show("No puedes agregar más unidades. Se ha alcanzado el límite de stock.");
                         return;
                     }

                     // Incrementar la cantidad y recalcular el subtotal
                     item.Cantidad++;
                     decimal subtotal = (item.Cantidad * item.PrecioVenta) - ((item.Cantidad * item.PrecioVenta) * (item.Descuento / 100));
                     item.Subtotal = subtotal;
                     item.Stock = stockComic.Cantidad;

                     comicExists = true;
                     break;
                 }
             }

             // Si no existe, crear una nueva fila
             if (!comicExists)
             {
                 var stockComic = _stockComicRepository.ListarPorComicId(comicSelected);

                 var newComic = new OperacionModel
                 {
                     Nombre = comicSelected.Nombre,
                     ComicId = comicSelected.ComicId,
                     Cantidad = 1,
                     PrecioVenta = comicSelected.PrecioVenta,
                     Descuento = 0,
                     Subtotal = comicSelected.PrecioVenta,
                     Stock = stockComic.Cantidad
                 };

                 // Añadir el nuevo cómic a la lista
                 Comicss.Add(newComic);
             }

             // Calcular totales (este método debe estar implementado)
             // CalcularTotales();*/
        }


        public void ListarComicsEditorialyLocal(int editorialId, int localId)
        {
            if (_comicRepository == null)
            {
                MessageBox.Show("El repositorio de cómics no está inicializado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (editorialId <= 0 || localId <= 0)
            {
                MessageBox.Show("El ID de la editorial o del local no es válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var comics = _comicRepository.ListarComicsEditorialyLocal(editorialId, localId);

            Comicss = comics.Select(c => new ComicModel
            {
                ComicId = c.ComicId,
                Nombre = c.Nombre
            }).ToList();

            if (Comicss != null && Comicss.Any())
            {
                StringBuilder sb = new StringBuilder("Cómmics encontrados:\n");

                foreach (var comic in Comicss)
                {
                    sb.AppendLine($"ID: {comic.ComicId}, Nombre: {comic.Nombre}");
                }

                MessageBox.Show(sb.ToString(), "Cómics Encontrados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se encontraron cómics.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        public void LoadEditorialesPorEmpleado(string empleadoId)
        {
            int idEmpleado = Convert.ToInt32(empleadoId);
            var editoriales = _editorialRepository.ObtenerEditorialesPorEmpleado(idEmpleado);

            Editoriales = editoriales.Select(e => new EditorialModel
            {
                EditorialId = e.EditorialId,
                Nombre = e.Nombre
            }).ToList();
        }

        private void LoadMediosDePago()
        {
            try
            {
                MediosDePagoList = _medioDePagoRepository.MediosDePago();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los medios de pago: {ex.Message}");
            }
        }

        private void LoadClientes()
        {
            try
            {
                var clientes = _clienteJIMRepository.ListarClientes();

                ClientesList = clientes.Select(c => new ClienteJimModel
                {
                    ClienteID = c.ClienteID,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
