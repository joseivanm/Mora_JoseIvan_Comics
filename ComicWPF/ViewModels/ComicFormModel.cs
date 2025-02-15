using ComicADO;
using ComicWPF.Models;
using ComicWPF.Repositories;
using Entidades;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Ventas;

namespace ComicWPF.ViewModels
{
    public class ComicFormModel : INotifyPropertyChanged
    {
        private readonly IMedioDePagoRepository _medioDePagoRepository;
        private readonly IClienteJIMRepository _clienteJIMRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IComicRepository _comicRepository;
        private readonly IStockComicRepository _stockComicRepository;
        private readonly IAutorRepository _autorRepository;

        public bool edicion = false;
        private string _campoCambiante;

        public string CampoCambiante
        {
            get { return _campoCambiante; }
            set
            {
                _campoCambiante = value;
                OnPropertyChanged(nameof(CampoCambiante));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private List<EditorialModel> _editoriales;
        public List<EditorialModel> Editoriales
        {
            get { return _editoriales; }
            set
            {
                _editoriales = value;
                OnPropertyChanged(nameof(Editoriales));
            }
        }

        public List<MedioDePago> MediosDePagoList { get; set; }
        public List<ClienteJimModel> ClientesList { get; set; }
        private List<ComicModel> _comicss;
        public List<AutorModel> _autores;

        public List<AutorModel> Autores
        {
            get { return _autores; }
            set
            {
                _autores = value;
                OnPropertyChanged(nameof(Autores));
            }
        }

        private ComicModel _comic;
        public ComicModel Comic
        {
            get { return _comic; }
            set
            {
                _comic = value;
                OnPropertyChanged(nameof(Comic));
            }
        }
        public List<ComicModel> Comicss
        {
            get { return _comicss; }
            set
            {
                _comicss = value;
                OnPropertyChanged(nameof(Comicss)); 
            }
        }

        private string _operationMessage;
        public string OperationMessage
        {
            get { return _operationMessage; }
            set
            {
                _operationMessage = value;
                OnPropertyChanged(nameof(OperationMessage));
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                OnPropertyChanged(nameof(Cantidad)); 
            }
        }
        private int _medioDePagoId;
        public int MedioDePagoId
        {
            get { return _medioDePagoId; }
            set
            {
                _medioDePagoId = value;
                OnPropertyChanged(nameof(MedioDePagoId));
            }
        }

        private int _precioCompra;
        public int PrecioCompra
        {
            get { return _precioCompra; }
            set
            {
                _precioCompra = value;
                OnPropertyChanged(nameof(PrecioCompra));
            }
        }

        private int _clienteID;
        public int ClienteID
        {
            get { return _clienteID; }
            set
            {
                _clienteID = value;
                OnPropertyChanged(nameof(ClienteID));
            }
        }
        private bool _esCompraCliente;
        public bool EsCompraCliente
        {
            get { return _esCompraCliente; }
            set
            {
                _esCompraCliente = value;
                OnPropertyChanged(nameof(EsCompraCliente));
            }
        }

        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }
        public ICommand ListarComicsCommand { get; }
        public ICommand ListarEditorialCommand { get; }

        public ComicFormModel(IMedioDePagoRepository medioDePagoRepository,
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
            _autorRepository = new AutorRepository();
            LoadMediosDePago();
            LoadAutores();
            LoadClientes();
            LoadEditorialesPorEmpleado();
            CampoCambiante = "Cantidad";
            //LoadEditorialesPorEmpleado(user.Id);

            Comic = new ComicModel();
            GuardarCommand = new ViewModelCommand(ExecuteGuardarCommand);
            ListarEditorialCommand = new ViewModelCommand(ExecuteListarEditorialCommand);
        }
        public ComicFormModel(IMedioDePagoRepository medioDePagoRepository,
                                   IClienteJIMRepository clienteJIMRepository,
                                   IEditorialRepository editorialRepository,
                                   UserModel user,
                                   int comicId,
                                   IStockComicRepository stockComicRepository)
        {
            _medioDePagoRepository = medioDePagoRepository;
            _clienteJIMRepository = clienteJIMRepository;
            _editorialRepository = editorialRepository;
            _comicRepository = new ComicRepository();
            _stockComicRepository = stockComicRepository;
            _autorRepository = new AutorRepository();
            //LoadMediosDePago();
            //LoadClientes();
            //LoadEditorialesPorEmpleado();
            //LoadEditorialesPorEmpleado(user.Id);
            LoadAutores();
            LoadEditoriales();
            LoadComic(comicId);
            edicion = true;
            CampoCambiante = "Comic Nombre";

            Comic = new ComicModel();
        }
        public ComicFormModel(int comicId)
        {
            
            _comicRepository = new ComicRepository();

            _autorRepository = new AutorRepository();
            LoadAutores();
            LoadEditoriales();
            LoadComic(comicId);
            edicion = true;
            CampoCambiante = "Comic Nombre";

            Comic = new ComicModel();
        }

        public ComicFormModel()
        {
            _medioDePagoRepository = new MedioDePagoRepository();
            _clienteJIMRepository = new ClienteJIMRepository();
            _editorialRepository = new EditorialRepository();
            _autorRepository = new AutorRepository();
            LoadMediosDePago();
            LoadClientes();
            LoadAutores();
            
            LoadEditorialesPorEmpleado();


            Comic = new ComicModel();

        }
        private void ExecuteGuardarCommand(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Comic?.Nombre))
            {
                MessageBox.Show("Por favor, ingresa el nombre del cómic.");
                return;
            }

            if (!edicion || Cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.");
                return;
            }

            if ( Comic?.EditorialId == 0)
            {
                MessageBox.Show("Por favor, selecciona una editorial.");
                return;
            }
            
            if (!edicion || MedioDePagoId == null || MedioDePagoId == 0)
            {
                MessageBox.Show("Por favor, selecciona un método de pago.");
                return;
            }

            if (!edicion || ClienteID == null || ClienteID == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente.");
                return;
            }

            if (Comic?.AutorId == 0)
            {
                MessageBox.Show("Por favor, selecciona un autor.");
                return;
            }

            if (!edicion ||PrecioCompra <= 0)
            {
                MessageBox.Show("El precio de compra debe ser mayor a 0.");
                return;
            }
            string comicNombre = Comic.Nombre;
            int cantidad = Cantidad;
            int editorial = Comic.EditorialId;
            int local = 1;
            int metodoPago = MedioDePagoId;
            int empleadoId = 1;
            int precioCompra = PrecioCompra;
            int clienteId = ClienteID;
            bool rbCliente = true;
            int autor = Comic.AutorId;
            int? idComic = _comicRepository.BuscarComicPorNombreYEditorial(comicNombre, editorial);
            int? comicId = (idComic == null) ? null : idComic;
            if (!edicion)
            {
                btnCreateComic_Click(editorial, local, metodoPago, clienteId, comicId, empleadoId, precioCompra, cantidad, rbCliente, comicNombre, autor);
            }
            else
            {
                btnEditComic_Click(comicId ?? 0, comicNombre, editorial, autor);

            }


            OperationMessage = "Cómic guardado correctamente.";
        }
        private void ExecuteListarEditorialCommand(object parameter)
        {
            int editorial = Comic.EditorialId;
            int localId = 1;
           ListarComicsEditorialyLocal(editorial, localId);
        }
        public void LoadAutores()
        {


            var autores = _autorRepository.ObtenerAutores();

            if (autores == null || !autores.Any())
            {
                return;
            }

            Autores = autores.Select(e => new AutorModel
            {

                AutorId = e.AutorId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Pais = e.Pais,

            }).ToList();

        }
        public void LoadComic(int comicId)
        {
            var comic = _comicRepository.obtenerComic(comicId);

            if (comic != null)
            {
    
                Comic = new ComicModel
                {
                    ComicId = comic.ComicId,
                    Nombre = comic.Nombre,
                    Autor = comic.Autor?.Nombre,
                    AutorId = comic.Autor?.AutorId ?? 0, 
                    Editorial = comic.Editorial?.Nombre,
                    EditorialId = comic.Editorial?.EditorialId ?? 0 
                   
                };

              
                
            }
        }



        public void SaveComic()
        {
           
 
            if (string.IsNullOrEmpty(Comic.Nombre) || string.IsNullOrEmpty(Comic.Autor) || string.IsNullOrEmpty(Comic.Editorial))
            {
                OperationMessage = "Todos los campos son obligatorios.";
                return;
            }

 
            OperationMessage = "Comic guardado correctamente.";
        }

        public void Cancel()
        {
 
            OperationMessage = "Operación cancelada.";
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

                
            }
            else
            {
                MessageBox.Show("No se encontraron cómics.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void LoadEditorialesPorEmpleado()
        {
            string empleadoId = "1";
            int idEmpleado = Convert.ToInt32(empleadoId);
            var editoriales = _editorialRepository.ObtenerEditorialesPorEmpleado(idEmpleado);

            if (editoriales == null || !editoriales.Any())
            {
                MessageBox.Show("No se encontraron editoriales.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Editoriales = editoriales.Select(e => new EditorialModel
            {
                EditorialId = e.EditorialId,
                Nombre = e.Nombre
            }).ToList();

        }
        public void LoadEditoriales()
        {

            var editoriales = _editorialRepository.ObtenerEditoriales();

            if (editoriales == null || !editoriales.Any())
            {
                MessageBox.Show("No se encontraron editoriales.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Editoriales = editoriales.Select(e => new EditorialModel
            {
                EditorialId = e.EditorialId,
                Nombre = e.Nombre
            }).ToList();

        }
        public void btnCreateComic_Click(int editorial, int local, int metodoPago, int clienteId, int? comicId,int empleadoId, int precioCompra, int cantidad, bool rbCliente, string comicNombre, int autor)
        {


            try
            {         _comicRepository.EditarStockComic(editorial, local, metodoPago, clienteId, comicId, empleadoId, precioCompra, cantidad, rbCliente, comicNombre, autor);
                                   
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el comic: {ex.Message}");
            }

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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void btnEditComic_Click(int comicId, string nombreComic, int editorialId, int autor)
        {
            try
            {
                _comicRepository.EditarComic(comicId, nombreComic, editorialId, autor);

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el comic: {ex.Message}");
            }
        }
    }
}
