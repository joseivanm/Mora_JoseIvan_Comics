using ComicADO;
using ComicWPF.Models;
using ComicWPF.Repositories;
using Entidades;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
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
                OnPropertyChanged(nameof(Comicss));  // Notificar el cambio
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
            LoadEditorialesPorEmpleado();
            //LoadEditorialesPorEmpleado(user.Id);

            Comic = new ComicModel();
        }

        public ComicFormModel()
        {
            _medioDePagoRepository = new MedioDePagoRepository();
            _clienteJIMRepository = new ClienteJIMRepository();
            _editorialRepository = new EditorialRepository();
            LoadMediosDePago();
            LoadClientes();
            LoadEditorialesPorEmpleado();
            //LoadEditorialesPorEmpleado(user.Id);

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
        public void btnCreateComic_Click(int editorial, int local, int metodoPago, int clienteId, int comicId,int empleadoId, int precioCompra, int cantidad, bool rbCliente)
        {


            try
            {         _comicRepository.EditarStockComic(editorial, local, metodoPago, clienteId, comicId, empleadoId, precioCompra, cantidad, rbCliente);
                                   
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
    }
}
