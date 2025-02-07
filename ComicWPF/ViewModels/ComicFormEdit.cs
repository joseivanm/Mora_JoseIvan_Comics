using ComicADO;
using ComicWPF.Models;
using ComicWPF.Repositories;
using Entidades;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Ventas;

namespace ComicWPF.ViewModels
{
    public class ComicFormEdit : INotifyPropertyChanged
    {
        private readonly IMedioDePagoRepository _medioDePagoRepository;
        private readonly IClienteJIMRepository _clienteJIMRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IAutorRepository _autorRepository;
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

        public ComicFormEdit(IMedioDePagoRepository medioDePagoRepository,
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
            MessageBox.Show("Adios");
            LoadMediosDePago();
            LoadClientes();
            LoadEditoriales();
            LoadAutores();
            MessageBox.Show("hola");
 

            Comic = new ComicModel();
        }

        public ComicFormEdit(int comicId)
        {
            _medioDePagoRepository = new MedioDePagoRepository();
            _clienteJIMRepository = new ClienteJIMRepository();
            _editorialRepository = new EditorialRepository();
            _autorRepository = new AutorRepository();
            _comicRepository = new ComicRepository();
            MessageBox.Show("Adios");
            //LoadEditoriales();
            LoadAutores();
            LoadComic(comicId);
            MessageBox.Show("Adios");
            //LoadEditorialesPorEmpleado(user.Id);

            Comic = new ComicModel();

        }
        public void LoadComic(int comicId)
        {

            var comic = _comicRepository.obtenerComic(comicId);



            Comic = new ComicModel
            {
                ComicId = comic.ComicId,
                Autor = comic.Autor.Nombre,
                AutorId = comic.Autor.AutorId,
                Editorial = comic.Editorial.Nombre,
                EditorialId = comic.Editorial.EditorialId,
                Nombre = comic.Nombre, };
            MessageBox.Show(Comic.Nombre);
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

        public void LoadAutores()
        {


            var autores = _autorRepository.ObtenerAutores();

            if (autores == null || !autores.Any())
            {
                MessageBox.Show("No se encontraron autores .", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Autores = autores.Select(e => new AutorModel
            {
                AutorId = e.AutorId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Pais= e.Pais,

            }).ToList();

        }
        public void btnCreateComic_Click(int editorial, int local, int metodoPago, int clienteId, int comicId, int empleadoId, int precioCompra, int cantidad, bool rbCliente)
        {


            try
            {
                _comicRepository.EditarStockComic(editorial, local, metodoPago, clienteId, comicId, empleadoId, precioCompra, cantidad, rbCliente);

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
