using ComicWPF.Models;
using Entidades;
using System;
using System.ComponentModel;
using System.Windows;

namespace ComicWPF.ViewModels
{
    public class ComicFormModel : INotifyPropertyChanged
    {
        private readonly IMedioDePagoRepository _medioDePagoRepository;
        private readonly IClienteJIMRepository _clienteJIMRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IComicRepository _comicRepository;
        private readonly IStockComicRepository _stockComicRepository;

        public event PropertyChangedEventHandler PropertyChanged;
        public List<EditorialModel> Editoriales { get; set; }
        public List<MedioDePago> MediosDePagoList { get; set; }
        public List<ClienteJimModel> ClientesList { get; set; }
        private List<ComicModel> _comicss;

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

            LoadMediosDePago();
            LoadClientes();
            LoadEditorialesPorEmpleado(user.Id);
            
            Comic = new ComicModel();
        }

        public void SaveComic()
        {
            // Validar los campos
            if (string.IsNullOrEmpty(Comic.Nombre) || string.IsNullOrEmpty(Comic.Autor) || string.IsNullOrEmpty(Comic.Editorial))
            {
                OperationMessage = "Todos los campos son obligatorios.";
                return;
            }

            // Lógica para insertar, modificar o eliminar comic
            // Simulación de inserción
            OperationMessage = "Comic guardado correctamente.";
        }

        public void Cancel()
        {
            // Resetear campos o cerrar el formulario
            OperationMessage = "Operación cancelada.";
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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
