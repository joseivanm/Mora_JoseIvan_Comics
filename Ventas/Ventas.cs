using System;
using System.Data;
using System.Linq;
using Entidades;
using ComicADO;
using Microsoft.EntityFrameworkCore;
using Comics;
using System.Windows.Forms;
using System.Collections.Generic;
using Azure;


namespace Ventas
{
    //<author>Jose Ivan Mora Gonzaga</author>


    public class VentasADO : IDisposable
    {



        private DataTable empleadosDataTable;

        private DataTable operacionesDataTable;

        bool disposed;

        public VentasADO()
        {
            disposed = false;
        }

        public int OperacionId { get; set; }
        public int LocalId { get; set; }
        public DateTime FechaOperacion { get; set; }




        public VentasADO(int operacionId, int localId, DateTime fechaOperacion)
        {
            OperacionId = operacionId;
            LocalId = localId;
            FechaOperacion = fechaOperacion;
        }

        public void IngresarUsuario(string nombre, string apellido, string password, string nif, string direccion, string hashPassword, string email, DateTime dtAlta, byte[] imagen, int idTienda)
        {
            using (EmpleadoADO empleadoADO = new EmpleadoADO())
            {
                // Crear el objeto empleado
                Empleado empleado = new Empleado()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Nif = nif,
                    Direccion = direccion,
                    Password = hashPassword,
                    Email = email,
                    Fecha_alta = dtAlta,
                    Activo = "S",
                    Fotografia = imagen
                };

                // Insertar el empleado en la base de datos y obtener el ID
                empleadoADO.Insertar(empleado);

                // Obtener el ID del empleado insertado
                int empleadoId = empleado.EmpleadoId;
                string idTienda1 = Convert.ToString(idTienda);
                int idEmple = (int)empleadoId;

                // Ahora buscar el local usando el idTienda
                using (LocalADO localADO = new LocalADO())
                {
                    Local local = localADO.ObtenerLocalPorId(idTienda1);
                    if (local != null)
                    {
                        // Si se encontró el local, insertar en la tabla LocalEmpleado
                        using (var context = new ComicsContext())
                        {

                            try
                            {
                                using (LocalEmpleadoADO localEmpleadoADO = new LocalEmpleadoADO())
                                {
                                    LocalEmpleado localEmpleado = new LocalEmpleado()
                                    {
                                        EmpleadoId = idEmple,
                                        LocalId = local.LocalId // Asumiendo que LocalId es el ID del local
                                    };
                                    localEmpleadoADO.Insertar(localEmpleado);
                                }
                                //context.LocalEmpleados.Add(localEmpleado);
                                //context.SaveChanges();
                            }
                            catch (DbUpdateException dbEx)
                            {
                                string innerExceptionMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : "No hay detalles adicionales.";
                                MessageBox.Show($"Error al insertar LocalEmpleado: {innerExceptionMessage}");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error inesperado: {ex.Message}");
                            }
                        }
                        MessageBox.Show("Usuario insertado con exito.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el local con el ID proporcionado.");
                    }
                }
            }
        }

        public int? BuscarComicPorNombreYEditorial(string nombreComic, int editorialId)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {
                    int? idComic = comicADO.BuscarComicPorNombreYEditorial(nombreComic, editorialId);

                    return idComic;
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                    return null;
                }
            }

        }

        public void EditarUsuario(string nombre, string apellido, string password, string nif, string direccion, string hashPassword, string email, byte[] imagen, int idTienda, int empleadoIdActualizar)
        {
            using (EmpleadoADO empleadoADO = new EmpleadoADO())
            {
                // Crear el objeto empleado
                Empleado empleado = new Empleado()
                {
                    EmpleadoId = empleadoIdActualizar,
                    Nombre = nombre,
                    Apellido = apellido,
                    Nif = nif,
                    Direccion = direccion,
                    Password = hashPassword,
                    Email = email,
                    Activo = "S",
                    Fotografia = imagen
                };

                // Insertar el empleado en la base de datos y obtener el ID

                if(hashPassword != null)empleadoADO.Actualizar(empleado);
                else { empleadoADO.ActualizarSinPass(empleado); }

                // Obtener el ID del empleado insertado
                int empleadoId = empleado.EmpleadoId;
                string idTienda1 = Convert.ToString(idTienda);
                int idEmple = (int)empleadoId;

                // Ahora buscar el local usando el idTienda
                using (LocalADO localADO = new LocalADO())
                {
                    Local local = localADO.ObtenerLocalPorId(idTienda1);
                    if (local != null)
                    {
                        // Si se encontró el local, insertar en la tabla LocalEmpleado
                        using (var context = new ComicsContext())
                        {

                            try
                            {
                                using (LocalEmpleadoADO localEmpleadoADO = new LocalEmpleadoADO())
                                {
                                    LocalEmpleado localEmpleado = new LocalEmpleado()
                                    {
                                        EmpleadoId = idEmple,
                                        LocalId = local.LocalId // Asumiendo que LocalId es el ID del local
                                    };
                                    localEmpleadoADO.Actualizar(localEmpleado);
                                }
                                //context.LocalEmpleados.Add(localEmpleado);
                                context.SaveChanges();
                                MessageBox.Show("Empleado Editado Correctamente");
                            }
                            catch (DbUpdateException dbEx)
                            {
                                string innerExceptionMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : "No hay detalles adicionales.";
                                MessageBox.Show($"Error al insertar LocalEmpleado: {innerExceptionMessage}");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error inesperado: {ex.Message}");
                            }
                        }
                        MessageBox.Show("Usuario editado con éxito.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el local con el ID proporcionado.");
                    }
                }
            }
        }

        public Empleado ListarEmpleado(string idEmpleado)
        {
            try
            {
                using (EmpleadoADO empleadoADO = new EmpleadoADO())
                {
                    return empleadoADO.Listar(idEmpleado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            try
            {
                using (EmpleadoADO empleadoADO = new EmpleadoADO())
                {
                    // Intentamos obtener la lista de empleados
                    var empleados = empleadoADO.Listar(); // Devuelve una lista de empleados
                    if (empleados == null || !empleados.Any())
                    {
                        MessageBox.Show("No se encontraron empleados en la base de datos.", "Información");
                    }
                    return (List<Empleado>)empleados; // Retorna la lista de empleados
                }
            }
            catch (Exception ex)
            {
                // Mostramos el error con detalles adicionales
                MessageBox.Show($"Error al obtener los empleados: {ex.Message}\nDetalles de la excepción: {ex.ToString()}", "Error");
                return null;
            }
        }


        public DataTable CargarEmpleados()
        {
            try
            {
                using (EmpleadoADO empleadoADO = new EmpleadoADO())
                {
                    List<Empleado> listaEmpleados = empleadoADO.Listar().ToList();
                    empleadosDataTable = ConvertirListaADataTable(listaEmpleados);
                    return empleadosDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
                return null;
            }
        }

        public void BorrarComic(int comicId)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {
                    string idComic = Convert.ToString(comicId);
                    if (comicId <= 0)
                    {
                        throw new ArgumentException("ComicId debe ser un número válido.");
                    }
                    using (DetalleOperacionADO detalleOperacionADO = new DetalleOperacionADO())
                    {
                        detalleOperacionADO.EliminarDetallesPorComic(comicId);
                        
                    }

                    using (OperacionClienteJIMADO operacionClienteADO = new OperacionClienteJIMADO())
                    {

                        using (OperacionADO operacionADO = new OperacionADO())
                        {
                            var operacionesRelacionadas = operacionADO.ListarPorComic(comicId);
                            if (operacionesRelacionadas.Any())
                            {
                                foreach (var operacion in operacionesRelacionadas)
                                {
                                    operacionClienteADO.EliminarPorOperacion(operacion.OperacionId);
                                    operacionADO.Borrar(operacion);
                                }
                            }
                        }
                    }
                    using (StockComicADO stockComicADO = new StockComicADO())
                    {
                        var stockComics = stockComicADO.ListarporComic(idComic);
                        if (stockComics != null)
                        {
                            stockComicADO.Borrar(stockComics);
                        }
                    }

                    // 2️⃣ Eliminar registros en `DetalleOperacion`
                    /*using (DetalleOperacionADO detalleOperacionADO = new DetalleOperacionADO())
                    {
                        var detallesOperacion = detalleOperacionADO.ListarPorComic(comicId);
                        if (detallesOperacion.Any())
                        {
                            foreach (var detalle in detallesOperacion)
                            {
                                detalleOperacionADO.Borrar(detalle);
                            }
                        }
                    }*/

                    comicADO.Borrar(comicId);

                    MessageBox.Show($"Cómic con ID {comicId} eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el cómic (ID {comicId}): {ex.Message}\n\n{ex.StackTrace}");
                }
            }
        }





        public void EditarStockComic(int? comicId, int editorial , int local , decimal precioCompra, int cantidad, int metodoPago, int empleadoId, string comicNombre, int autor)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {   if (comicId != null)
                    {
                        int comicIdSeguro = comicId ?? 0;


                        // Insertar en StockComic
                        using (StockComicADO stockComicADO = new StockComicADO())
                        {
                            var stockComic = stockComicADO.ListarPorComicYTienda(comicIdSeguro, local);
                            stockComic.Cantidad += cantidad;
                            stockComicADO.Actualizar(stockComic);
                        }
                        using (OperacionADO operacionADO = new OperacionADO())
                        {
                            Operacion operacion = new Operacion()
                            {
                                MedioDePagoId = metodoPago,
                                TipoOperacionId = 1,
                                ComicId = comicIdSeguro,
                                LocalId = local,
                                FechaOperacion = DateTime.Now,
                                EmpleadoId = empleadoId,

                            };
                            Operacion operacionInsertada = operacionADO.Insertar(operacion);
                            using (DetalleOperacionADO detalleOperacionADO = new DetalleOperacionADO())
                            {
                                DetalleOperacion detalleOperacion = new DetalleOperacion()
                                {
                                    OperacionId = operacionInsertada.OperacionId,
                                    ComicId = comicIdSeguro,
                                    Cantidad = cantidad,
                                    Precio = precioCompra,

                                };
                                detalleOperacionADO.Insertar(detalleOperacion);
                            }
                        }

                        MessageBox.Show("Comic y stock insertados correctamente.");
                    }
                    else
                    {
                        

                            Comic comic = new Comic()
                            {
                                PrecioCompra = precioCompra,
                                EditorialId = editorial,
                                AutorId = autor,
                                Nombre = comicNombre,
                            };
                        var comicInsertado = comicADO.Insertar(comic);
                        // Insertar en StockComic
                        using (StockComicADO stockComicADO = new StockComicADO())
                        {
                            StockComic stockComic = new StockComic()
                            {
                                ComicId = comicInsertado.ComicId,
                                LocalId = local,
                                Cantidad = cantidad,

                            };
                            stockComicADO.Insertar(stockComic);
                        }
                        using (OperacionADO operacionADO = new OperacionADO())
                        {
                            Operacion operacion = new Operacion()
                            {
                                MedioDePagoId = metodoPago,
                                TipoOperacionId = 1,
                                ComicId = comicInsertado.ComicId,
                                LocalId = local,
                                FechaOperacion = DateTime.Now,
                                EmpleadoId = empleadoId,

                            };
                            Operacion operacionInsertada = operacionADO.Insertar(operacion);
                            using (DetalleOperacionADO detalleOperacionADO = new DetalleOperacionADO())
                            {
                                DetalleOperacion detalleOperacion = new DetalleOperacion()
                                {
                                    OperacionId = operacionInsertada.OperacionId,
                                    ComicId = comicInsertado.ComicId,
                                    Cantidad = cantidad,
                                    Precio = precioCompra,

                                };
                                detalleOperacionADO.Insertar(detalleOperacion);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                }
            }
        }

        
        public void EditarStockComic(int? comicId, int editorial, int local, decimal precioCompra, int cantidad, int metodoPago, int emppleadoId, int clienteId)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {   // Insertar en StockComic
                    if (comicId != null)
                    {
                        int comicIdSeguro = comicId ?? 0;
                        using (StockComicADO stockComicADO = new StockComicADO())
                        {
                            var stockComic = stockComicADO.ListarPorComicYTienda(comicIdSeguro, local);
                            stockComic.Cantidad += cantidad;
                            stockComicADO.Actualizar(stockComic);
                        }
                        using (OperacionADO operacionADO = new OperacionADO())
                        using (OperacionClienteJIMADO operacionCliente = new OperacionClienteJIMADO())
                        {

                            Operacion operacion = new Operacion()
                            {
                                MedioDePagoId = metodoPago,
                                TipoOperacionId = 1,
                                ComicId = comicIdSeguro,
                                LocalId = local,
                                FechaOperacion = DateTime.Now,
                                EmpleadoId = emppleadoId,

                            };
                            Operacion operacionInsertada = operacionADO.Insertar(operacion);
                            using (DetalleOperacionADO detalleOperacionADO = new DetalleOperacionADO())
                            {
                                DetalleOperacion detalleOperacion = new DetalleOperacion()
                                {
                                    OperacionId = operacionInsertada.OperacionId,
                                    ComicId = comicIdSeguro,
                                    Cantidad = cantidad,
                                    Precio = precioCompra,

                                };
                                detalleOperacionADO.Insertar(detalleOperacion);

                                OperacionClienteJIM operacionCli = new OperacionClienteJIM
                                {
                                    ClienteId = clienteId,
                                    OperacionId = operacionInsertada.OperacionId
                                };
                                OperacionClienteJIM operacion1 = operacionCliente.Insertar(operacionCli);
                            }
                        }

                        MessageBox.Show("Comic y stock insertados correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                }
            }
        }


        public string obtenerNombreComic(int comicId)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {
                    string nombreComic = comicADO.ObtenerNombreComic(comicId);

                    return nombreComic;
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                    return null;
                }
            }
        }
        public void EditarComic(int comicId, string nombreComic, int editorialId, int autor)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {
                    string idcomic = Convert.ToString(comicId);
                    Comic comic = obtenerDetallesComic(idcomic);

                    if (comic != null)
                    {
 
                        comic.Nombre = nombreComic;
                        comic.EditorialId = editorialId;
                        comic.AutorId = autor;

                        
                        comicADO.Actualizar(comic);
                    }
                    else
                    {
                        MessageBox.Show("El cómic no se encontró.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el cómic: {ex.Message}");
                }
            }
        }




        public List <Comic> CargarComics()
        {
            try
            {
                int localId = 1; // El ID de la tienda que se puede obtener al inicio de sesión (por ahora, se usa 1)

                using (ComicsADO comicsADO = new ComicsADO())
                using (StockComicADO stockADO = new StockComicADO())
                {
                    var comics = comicsADO.Listar(); // Cargamos todos los comics

             

                    return (List<Comic>)comics;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los comics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Comic> { };
  
            }
        }
        public Comic obtenerDetallesComic(string idComic)
        {
            try
            {
   

                using (ComicsADO comicsADO = new ComicsADO())
 
                {
                    var comic = comicsADO.Listar(idComic);



                    return comic;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los comics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Comic{ };

            }
        }

        public StockComic ListarPorIdComic(int comic)
        {
            if (comic == null)
            {
                MessageBox.Show("El comic no puede ser nulo.");
                return null;
            }
            try
            {
                using (StockComicADO stockADO = new StockComicADO())
                {
                    return stockADO.ListarPorComicId(comic);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public StockComic ListarPorComicId(Comic comic)
        {
            if (comic == null)
            {
                MessageBox.Show("El comic no puede ser nulo.");
                return null;
            }
            try
            {
                using (StockComicADO stockADO = new StockComicADO())
                {
                    return stockADO.ListarPorComicId(comic.ComicId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public StockComic ListarPorComicYTienda(int comicId, int tiendaId)
        {
            try
            {
                using (StockComicADO stockADO = new StockComicADO())
                {
                    return stockADO.ListarPorComicYTienda(comicId, tiendaId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }
        public List<StockComic> ObtenerStockEnOtrasTiendas(int comicId, int tiendaId)
        {
            try
            {
                using (StockComicADO stockADO = new StockComicADO())
                {

                    var stocksEnOtrasTiendas = stockADO.ListarComicsPorTiendaExcluyendoLocal(comicId, tiendaId);
                    return stocksEnOtrasTiendas; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el stock en otras tiendas: {ex.Message}");
                return new List<StockComic>(); 
            }
        }


        public List <Comic> ListarComicsPorTiendaYEditorial(int tiendaId, int editorialId)
        {
            try
            {
                using (StockComicADO stockADO = new StockComicADO())
                {
                    return stockADO.ListarComicsPorTiendaYEditorial(tiendaId, editorialId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public List<Editorial> ListarEditorialesPorTienda(int localSeleccionado)
        {
            try
            {
                using (StockComicADO stockADO = new StockComicADO())
                {
                    return stockADO.ListarEditorialesPorTienda(localSeleccionado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public Local ObtenerLocalPorId( string localId)
        {
            try
            {
                using (LocalADO localADO = new LocalADO())
                {
                    return localADO.ObtenerLocalPorId(localId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public MedioDePago ObtenerMedioPagoPorId(string localId)
        {
            try
            {
                using (MedioDePagoADO medioDePago = new MedioDePagoADO())
                {
                    return medioDePago.Listar(localId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public LocalEmpleado LocalEmpleado( string empleadoId)
        {
            try
            {
                using (LocalEmpleadoADO localADO = new LocalEmpleadoADO())
                {
                    return localADO.Listar(empleadoId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el comic: {ex.Message}");
                return null;
            }
        }

        public Operacion VenderComicOperacion(int medioPago, int localID, int empleadoId, int clienteId)
        {
            using (OperacionADO operacionADO = new OperacionADO())
            using (OperacionClienteJIMADO operacionCliente = new OperacionClienteJIMADO())
            {
                try
                {
                    // Crear la nueva operación
                    Operacion operacionCompletada = new Operacion();
                    Operacion operacion = new Operacion
                    {
                        MedioDePagoId = medioPago,
                        TipoOperacionId = 2,
                        LocalId = localID,
                        FechaOperacion = DateTime.Now,
                        EmpleadoId = empleadoId,
                        ComicId = 2,
                    };

                    operacionCompletada = operacionADO.Insertar(operacion);

                    if (operacionCompletada == null)
                        throw new Exception("No se pudo insertar la operacion.");

                    OperacionClienteJIM operacionCli = new OperacionClienteJIM
                    {
                        ClienteId = clienteId,
                        OperacionId = operacionCompletada.OperacionId
                    };
                    OperacionClienteJIM operacion1 = operacionCliente.Insertar(operacionCli);
                    if (operacionCli != null)
                    {
                        // Si la inserción fue exitosa, operacionCli contendrá el objeto insertado
                        return operacionCompletada;
                    }
                    else
                    {
                        throw new Exception("No se pudo insertar la relación OperacionClienteJIM.");
                    }

                    return operacionCompletada;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                    return null;
                }
            }
        }

        public Operacion ComprarComicOperacion(int medioPago, int localID, int empleadoId, int clienteId)
        {
            using (OperacionADO operacionADO = new OperacionADO())
            using (OperacionClienteJIMADO operacionCliente = new OperacionClienteJIMADO())
            {
                try
                {
                    // Crear la nueva operación
                    Operacion operacionCompletada = new Operacion();
                    Operacion operacion = new Operacion
                    {
                        MedioDePagoId = medioPago,
                        TipoOperacionId = 1,
                        LocalId = localID,
                        FechaOperacion = DateTime.Now,
                        EmpleadoId = empleadoId,
                        ComicId = 2,
                    };

                    operacionCompletada = operacionADO.Insertar(operacion);

                    if (operacionCompletada == null)
                        throw new Exception("No se pudo insertar la operacion.");

                    OperacionClienteJIM operacionCli = new OperacionClienteJIM
                    {
                        ClienteId = clienteId,
                        OperacionId = operacionCompletada.OperacionId
                    };
                    OperacionClienteJIM operacion1 = operacionCliente.Insertar(operacionCli);
                    if (operacionCli != null)
                    {
                        // Si la inserción fue exitosa, operacionCli contendrá el objeto insertado
                        return operacionCompletada;
                    }
                    else
                    {
                        throw new Exception("No se pudo insertar la relación OperacionClienteJIM.");
                    }

                    return operacionCompletada;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                    return null;
                }
            }
        }

        //Aqui para WPF
        public List<KeyValuePair<string, double>> GetVentasPorEditorial()
        {
            using (OperacionADO operacionADO = new OperacionADO())
            {
                try
                {

                    return operacionADO.GetVentasPorEditorial();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener totalpedidos mes: {ex.Message}");
                    return null;
                }
            }

        }

        public List<int> GetPedidosPorEmpleadoUltimoAno() 
        {
            using (OperacionADO operacionADO = new OperacionADO())
            {
                try
                {

                    return operacionADO.GetPedidosPorEmpleadoUltimoAno();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener totalpedidos mes: {ex.Message}");
                    return null;
                }
            }
        }
        public int GetTotalPedidosUltimoMes(int usuarioId)
        {
            using (OperacionADO operacionADO = new OperacionADO())
            {
                try
                {

                    return operacionADO.GetTotalPedidosUltimoMes(usuarioId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener totalpedidos mes: {ex.Message}");
                    return 0;
                }
            }
        }

        public int GetProductosConStockBajo()
        {
            using (OperacionADO operacionADO = new OperacionADO())
            {
                try
                {

                    return operacionADO.GetProductosConStockBajo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener totalpedidos mes: {ex.Message}");
                    return 0;
                }
            }
        }

        public decimal GetImportePedidosHoy()
        {
            using (OperacionADO operacionADO = new OperacionADO())
            {
                try
                {

                    return operacionADO.GetImportePedidosHoy();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener totalpedidos mes: {ex.Message}");
                    return 0;
                }
            }
        }

        public decimal GetImportePedidosHoyUsuario(int usuarioId)
        {
            using (OperacionADO operacionADO = new OperacionADO())
            {
                try
                {

                    return operacionADO.GetImportePedidosHoyUsuario(usuarioId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener totalpedidos mes: {ex.Message}");
                    return 0;
                }
            }

        }
        public Operacion datosOperacion(int operacion)
        {
            using (OperacionADO operacionADO = new OperacionADO())
            {
                try
                {
                                      
                    return (Operacion)operacionADO.Listar(operacion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                    return null;
                }
            }
        }

        public DataTable CargarOperaciones()
        {
            try
            {
                using (OperacionADO operacionADO = new OperacionADO())
                {
                    List<Operacion> listaOperaciones = operacionADO.Listar().ToList();
                    operacionesDataTable = ConvertirListaOperacionADataTable(listaOperaciones);
                    return operacionesDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar operaciones: " + ex.Message);
                return null;
            }
        }
        public void VenderComicDetalles(int comicId, int cantidad, decimal precio, decimal descuento, int operacionId)
        {
            using (DetalleOperacionADO detalleADO = new DetalleOperacionADO())
            using (StockComicADO stockADO = new StockComicADO())
            {
                try
                {
                    DetalleOperacion detalle = new DetalleOperacion
                    {
                        OperacionId = operacionId,
                        ComicId = comicId,
                        Cantidad = cantidad,
                        Precio = precio,
                        Descuento = descuento
                    };

                    // Insertar el detalle
                    detalleADO.Insertar(detalle);

  

                    // Actualizar stock
                    var stockComic = stockADO.ListarPorComicId(comicId);
                    stockComic.Cantidad -= cantidad;
                    stockADO.Actualizar(stockComic);

                    MessageBox.Show("Orden y stock insertados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                }
            }
        }

        public void ComprarComicDetalles(int comicId, int cantidad, decimal precio, decimal descuento, int operacionId)
        {
            using (DetalleOperacionADO detalleADO = new DetalleOperacionADO())
            using (StockComicADO stockADO = new StockComicADO())
            {
                try
                {
                    DetalleOperacion detalle = new DetalleOperacion
                    {
                        OperacionId = operacionId,
                        ComicId = comicId,
                        Cantidad = cantidad,
                        Precio = precio,
                        Descuento = descuento
                    };

                    // Insertar el detalle
                    detalleADO.Insertar(detalle);



                    // Actualizar stock
                    var stockComic = stockADO.ListarPorComicId(comicId);
                    stockComic.Cantidad += cantidad;
                    stockADO.Actualizar(stockComic);

                    MessageBox.Show("Orden y stock insertados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el comic: {ex.Message}");
                }
            }
        }

        public List<DetalleOperacion> ListaComicsDetallesOperacion(int operacionId)
        {
            using (DetalleOperacionADO detalleADO = new DetalleOperacionADO())
            {
                try
                {
                    return detalleADO.ListarPorOperacionId(operacionId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al consultar cómics: {ex.Message}");
                    return new List<DetalleOperacion>();
                }
            }
        }



        public void IngresarCliente(string nombre, string apellido, string email, string nif, string direccion, int telefono)
        {
            using (ClienteJIMADO clienteJIMADO = new ClienteJIMADO())
            {
                ClienteJIM clienteJIM = new ClienteJIM()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Email = email,
                    Nif = nif,
                    Activo = "S",
                    Direccion = direccion,
                    Telefono = telefono,
                    FechaRegistro = DateTime.Now,
                };
                clienteJIMADO.Insertar(clienteJIM);

                MessageBox.Show("Cliente insertado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<ClienteJIM> ListarClientes()
        {
            using (ClienteJIMADO clienteJIMADO = new ClienteJIMADO())
            {
                try
                {
                    return (List<ClienteJIM>)clienteJIMADO.Listar();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los clientes.", ex);
                }
            }
        }

        public List<MedioDePago> ListarMediosDePago()
        {
            using (MedioDePagoADO medioDePagoADO = new MedioDePagoADO())
            {
                try
                {
                    return (List<MedioDePago>)medioDePagoADO.Listar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los medios de pago.", ex);
                }
            }
        }

        public List<Editorial> ListarEditoriales()
        {
            using (EditorialADO editorialADO = new EditorialADO())
            {
                try
                {
                    return (List<Editorial>)editorialADO.Listar();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los clientes.", ex);
                }
            }
        }

        public List<Local> ListarLocales()
        {
            using (LocalADO localADO = new LocalADO())
            {
                try
                {
                    return (List<Local>)localADO.Listar();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los clientes.", ex);
                }
            }
        }

        public List<Autor> ListarAutores()
        {
            using (AutorADO autorADO = new AutorADO())
            {
                try
                {
                    return (List<Autor>)autorADO.Listar();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los clientes.", ex);
                }
            }
        }

        public List<Comic> ListarPorEditorial(string editorialId)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {
                    return comicADO.ListarPorEditorial(editorialId);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los clientes.", ex);
                }
            }
        }

        public List<Comic> ListarPorEditorialYLocal(string editorialId, int localId)
        {
            using (ComicsADO comicADO = new ComicsADO())
            {
                try
                {
                    return comicADO.ListarPorEditorialYLocal(editorialId, localId);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los cómics por editorial y tienda.", ex);
                }
            }
        }

        public DataTable ConvertirListaADataTable(List<Empleado> listaEmpleados)
        {
            DataTable dataTable = new DataTable();

            // Definir las columnas, incluyendo la columna "Activo"
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));
            dataTable.Columns.Add("NIF", typeof(string));
            dataTable.Columns.Add("FechaAlta", typeof(DateTime));
            dataTable.Columns.Add("Activo", typeof(string)); // Agregar la columna Activo

            // Llena el DataTable con los datos de la lista de empleados
            foreach (Empleado empleado in listaEmpleados)
            {
                // Solo empleados activos
                if (empleado.Activo == "S")
                {
                    dataTable.Rows.Add(
                        empleado.EmpleadoId,
                        empleado.Nombre,
                        empleado.Apellido,
                        empleado.Nif,
                        empleado.Fecha_alta,
                        empleado.Activo  // Asegúrate de incluir esta columna
                    );
                }
            }

            return dataTable;
        }

        public DataTable ConvertirListaOperacionADataTable(List<Operacion> listaOperaciones)
        {
            DataTable dataTable = new DataTable();

            // Definir las columnas correspondientes a la entidad Operacion
            dataTable.Columns.Add("OperacionID", typeof(int));
            dataTable.Columns.Add("Medio_De_Pago", typeof(string));
            dataTable.Columns.Add("Tipo_Operacion", typeof(string));
            dataTable.Columns.Add("ComicID", typeof(int));
            dataTable.Columns.Add("LocalID", typeof(int));
            dataTable.Columns.Add("Fecha_Operacion", typeof(DateTime));
            dataTable.Columns.Add("EmpleadoID", typeof(int));

            // Llena el DataTable con los datos de la lista de operaciones
            foreach (Operacion operacion in listaOperaciones)
            {
                dataTable.Rows.Add(
                    operacion.OperacionId,
                    operacion.MedioDePagoId,
                    operacion.TipoOperacionId,
                    operacion.ComicId,
                    operacion.LocalId,
                    operacion.FechaOperacion,
                    operacion.EmpleadoId
                );
            }

            return dataTable;
        }



        public DataTable DatosOrden(int operacionId)
        {
            using (var context = new ComicsContext())
            {

                var dataTable = new DataTable();

                dataTable.Columns.Add("OperacionId", typeof(int));
                dataTable.Columns.Add("FechaOperacion", typeof(DateTime));
                dataTable.Columns.Add("MedioDePago", typeof(string));
                dataTable.Columns.Add("Local", typeof(string));

                dataTable.Columns.Add("ComicId", typeof(int));
                dataTable.Columns.Add("NombreComic", typeof(string));
                dataTable.Columns.Add("Cantidad", typeof(int));
                dataTable.Columns.Add("PrecioCompra", typeof(decimal));
                dataTable.Columns.Add("PrecioVenta", typeof(decimal));
                dataTable.Columns.Add("Descuento", typeof(decimal));

                var operacion = context.Operacions
                    .Include(o => o.DetalleOperacions)
                        .ThenInclude(d => d.Comic)
                    .Include(o => o.MedioDePago)
                    .Include(o => o.Local)
                    .FirstOrDefault(o => o.OperacionId == operacionId);


                if (operacion != null)
                {

                    if (operacion.DetalleOperacions != null && operacion.DetalleOperacions.Any())
                    {
                        foreach (var detalle in operacion.DetalleOperacions)
                        {
                            var row = dataTable.NewRow();


                            row["OperacionId"] = operacion.OperacionId;
                            row["FechaOperacion"] = operacion.FechaOperacion;
                            row["MedioDePago"] = operacion.MedioDePago.Descripcion;
                            row["Local"] = operacion.Local.Nombre;


                            row["ComicId"] = detalle.Comic.ComicId;
                            row["NombreComic"] = detalle.Comic.Nombre;
                            row["Cantidad"] = detalle.Cantidad ?? 0;
                            row["PrecioCompra"] = detalle.Comic.PrecioCompra;
                            row["PrecioVenta"] = detalle.Comic.PrecioVenta;
                            row["Descuento"] = detalle.Descuento ?? 0;


                            dataTable.Rows.Add(row);
                        }
                    }
                }

                return dataTable;
            }
        }




        public DataTable ListarOperacionLocal(int localId, DateTime fechaInicio, DateTime fechaFinal)
        {
            using (var context = new ComicsContext())
            {
                var dataTable = new DataTable();

                dataTable.Columns.Add("OperacionId", typeof(int));
                dataTable.Columns.Add("LocalId", typeof(int));
                dataTable.Columns.Add("FechaOperacion", typeof(DateTime));

                var operaciones = context.Operacions
                    .Where(o => o.LocalId == localId && o.FechaOperacion >= fechaInicio && o.FechaOperacion <= fechaFinal)
                    .ToList();

                foreach (var operacion in operaciones)
                {
                    var row = dataTable.NewRow();
                    row["OperacionId"] = operacion.OperacionId;
                    row["LocalId"] = operacion.LocalId;
                    row["FechaOperacion"] = operacion.FechaOperacion;
                    dataTable.Rows.Add(row);


                    DataTable detalles = DatosOrden(operacion.OperacionId);
                    foreach (DataRow detalleRow in detalles.Rows)
                    {
                        dataTable.ImportRow(detalleRow);
                    }
                }

                return dataTable;
            }
        }

        public void BorrarEmpleado(int empleadoId)
        {
            using (var context = new ComicsContext())
            {
                try
                {

                    using (EmpleadoADO empleadoADO = new EmpleadoADO())
                    {
                        Empleado empleado = new Empleado()
                        {
                            EmpleadoId = empleadoId,
                            Activo = "N",
                            Fecha_baja = DateTime.Now,

                        };

                        using (LocalEmpleadoADO localEmpleadoADO = new LocalEmpleadoADO())
                        {
                            LocalEmpleado localEmpleado = new LocalEmpleado()
                            {
                                EmpleadoId = empleadoId,

                            };
                            localEmpleadoADO.EliminarRelacion(localEmpleado);
                        }

                        empleadoADO.Inactivo(empleado);


                    }



                }
                catch (Exception ex)
                {
                    throw new Exception("Error al dar de baja al empleado", ex);
                }
            }
        }


        // Lista todos los comics de una editorial que tienen stock menor a 2
        public DataTable ListarComprasEditorial(int editorialId)
        {
            using (var context = new ComicsContext())
            {
                var dataTable = new DataTable();

                // Definición de las columnas del DataTable
                dataTable.Columns.Add("ComicId", typeof(int));
                dataTable.Columns.Add("Nombre", typeof(string));
                dataTable.Columns.Add("StockTotal", typeof(int));


                var comics = context.Comics
                    .Where(c => c.EditorialId == editorialId)
                    .Select(c => new
                    {
                        c.ComicId,
                        c.Nombre,
                        StockTotal = c.StockComics.Sum(s => (int?)s.Cantidad) ?? 0 // Sumar las cantidades de stock
                    })
                    .Where(c => c.StockTotal < 2) // Filtrar cómics con stock total menor a 2
                    .ToList();

                // Llenar el DataTable con los resultados
                foreach (var comic in comics)
                {
                    var row = dataTable.NewRow();
                    row["ComicId"] = comic.ComicId;
                    row["Nombre"] = comic.Nombre;
                    row["StockTotal"] = comic.StockTotal;
                    dataTable.Rows.Add(row);
                }

                return dataTable; // Devolver el DataTable con los cómics seleccionados
            }
        }



        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {

            }

            disposed = true;
        }
    }
}
