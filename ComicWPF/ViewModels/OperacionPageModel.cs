using ComicADO;
using ComicWPF.Models;
using Entidades;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Ventas;
using MessageBox = System.Windows.Forms.MessageBox;

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
        private List<OperacionModel> _comicss;

        public List<OperacionModel> Comicss
        {
            get { return _comicss; }
            set
            {
                _comicss = value;
                OnPropertyChanged(nameof(Comicss)); 
            }
        }
        private decimal _subtotal;
        public decimal Subtotal
        {
            get { return _subtotal; }
            set
            {
                _subtotal = value;
                OnPropertyChanged(nameof(Subtotal));
            }
        }

        private decimal _iva;
        public decimal IVA
        {
            get { return _iva; }
            set
            {
                _iva = value;
                OnPropertyChanged(nameof(IVA));
            }
        }

        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        private ObservableCollection<OperacionModel> _comicsOrder;

        public ObservableCollection<OperacionModel> ComicsOrder
        {
            get { return _comicsOrder ?? (_comicsOrder = new ObservableCollection<OperacionModel>()); }
            set
            {
                _comicsOrder = value;
                OnPropertyChanged(nameof(ComicsOrder));
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
        public void AddComic(OperacionModel comicSelected)
        {
            if (comicSelected == null)
            {
                MessageBox.Show("Por favor, selecciona un cómic.");
                return;
            }

            var comicDetalles = _comicRepository.obtenerComic(comicSelected.ComicId);

   
            var stockComic = _stockComicRepository.ListarPorComicId(comicSelected.ComicId);


            if (stockComic == null || comicSelected.Cantidad > stockComic.Cantidad)
            {
                MessageBox.Show("No hay suficiente stock para agregar más unidades.");
                return;
            }

            if (comicSelected.Cantidad == 0)
            {
                comicSelected.Cantidad = 1;
            }

            bool comicExists = false;

    
            foreach (var item in ComicsOrder)
            {
                if (item.ComicId == comicSelected.ComicId)
                {

                    if (item.Cantidad + 1 > stockComic.Cantidad)
                    {
                        MessageBox.Show("No puedes agregar más unidades, el stock es insuficiente.");
                        return;
                    }

    
                    item.Cantidad++;
                    item.Subtotal = item.Cantidad * item.PrecioVenta;

                    comicExists = true;
                    break;  
                }
            }


            if (!comicExists)
            {
                if (comicSelected.Cantidad > stockComic.Cantidad)
                {
                    MessageBox.Show("No hay suficiente stock para agregar el cómic.");
                    return;
                }

                var newComic = new OperacionModel
                {
                    Nombre = comicSelected.Nombre,
                    ComicId = comicSelected.ComicId,
                    Cantidad = comicSelected.Cantidad,
                    PrecioVenta = (decimal)comicDetalles.PrecioVenta,
                    Subtotal = comicSelected.Cantidad * (decimal)comicDetalles.PrecioVenta,
                    Stock = (int)stockComic.Cantidad
                };


                ComicsOrder.Add(newComic);
            }


            this.CalcularTotal();
        }



        public void CalcularTotal()
        {
 
            decimal subtotalTotal = ComicsOrder.Sum(c => c.Subtotal);

      
            decimal iva = subtotalTotal * 0.21m; 

    
            decimal total = subtotalTotal + iva;

  

            Subtotal = subtotalTotal;
            IVA = iva;
            Total = total;

            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(IVA));
            OnPropertyChanged(nameof(Total));
        }






        public void ListarComicsEditorialyLocal(int editorialId, int localId)
        {
            if (_comicRepository == null)
            {
                MessageBox.Show("El repositorio de cómics no está inicializado.");
                return;
            }

            if (editorialId <= 0 || localId <= 0)
            {
                MessageBox.Show("El ID de la editorial o del local no es válido.");
                return;
            }

            var comics = _comicRepository.ListarComicsEditorialyLocal(editorialId, localId);
            List<OperacionModel> comicsConStock = new List<OperacionModel>();

            foreach (var comic in comics)
            {
                var stockComic = _stockComicRepository.ListarPorComicId(comic.ComicId);

                if (stockComic != null && stockComic.Cantidad > 0)
                {
                    comicsConStock.Add(new OperacionModel
                    {
                        ComicId = comic.ComicId,
                        Nombre = comic.Nombre,
                        Stock = (int)stockComic.Cantidad 
                    });
                }
            }

 
            Comicss = comicsConStock;

            if (Comicss != null && Comicss.Any())
            {
                StringBuilder sb = new StringBuilder("Cómmics encontrados:\n");

                foreach (var comic in Comicss)
                {
                    sb.AppendLine($"ID: {comic.ComicId}, Nombre: {comic.Nombre}, Stock: {comic.Stock}");
                }


            }
            else
            {
                MessageBox.Show("No se encontraron cómics con stock.");
            }
        }




        public void LoadEditorialesPorEmpleado(string empleadoId)
        {
            MessageBox.Show(empleadoId);
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

        public void Vender(int medioPago, int localID, int clienteId, int empleadoId)
        {
            try
            {
                if (ComicsOrder.Count == 0)
                {
                    MessageBox.Show("No hay cómics en la operación. Agrega al menos uno para realizar la venta.");
                    return;
                }

                using (VentasADO ventasADO = new VentasADO())
                {
                    Operacion detalleOperacion = new Operacion();
                    detalleOperacion = ventasADO.VenderComicOperacion(medioPago, localID, empleadoId, clienteId);

                    int operacionId = detalleOperacion.OperacionId;

                    // Recorrer ComicsOrder para registrar una operación por cada cómic
                    foreach (var item in ComicsOrder)
                    {
                        if (item.ComicId != 0)
                        {
                            int comicId = item.ComicId;
                            int cantidad = item.Cantidad;
                            decimal precio = item.PrecioVenta;
                           decimal descuento = 0;  // Asegúrate de que el descuento esté correctamente calculado

                            // Registrar los detalles de la venta en la base de datos
                            ventasADO.VenderComicDetalles(comicId, cantidad, precio, descuento, operacionId);
                        }
                    }

                    MessageBox.Show("Venta registrada exitosamente.");
                }

                // Limpiar la interfaz después de la venta
                ComicsOrder.Clear();  // Limpiar ComicsOrder ya que la venta se realizó
                Subtotal = 0.00m;
                IVA = 0.00m;
                Total = 0.00m;
                OnPropertyChanged(nameof(Subtotal));
                OnPropertyChanged(nameof(IVA));
                OnPropertyChanged(nameof(Total));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}");
            }
        }


    }
}
