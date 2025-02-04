using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas;
using System.Windows;
using Entidades;
using ComicWPF.Models;
using ComicWPF.ViewModels;

namespace ComicWPF.Repositories
{
    public class ComicRepository : RepositoryBase, IComicRepository
    {
        public Task<List<ComicPageModel>> BuscarComics(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public List<Comic> ListarComicsEditorialyLocal(int editorialId, int localId)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                // Llamar al metodo que filtra por editorial y local
                List<Comic> comics = ventasADO.ListarPorEditorialYLocal(editorialId.ToString(), localId);

                if (comics == null || comics.Count == 0)
                {
                    MessageBox.Show("No se encontraron cómics en la base de datos para los parámetros proporcionados.");
                    return new List<Comic>(); // Retorna una lista vacía en vez de null
                }

                List<Comic> comicsConStock = new List<Comic>();

                foreach (var comic in comics)
                {
                    // Obtener el stock para el cómic actual
                    var stockComic = ventasADO.ListarPorComicId(comic);

                    if (stockComic != null && stockComic.Cantidad > 0) // Verificar si hay stock
                    {
                        comicsConStock.Add(comic); // Añadir a la lista si tiene stock > 0
                    }
                }

                // Mostrar detalles de los cómics con stock
                StringBuilder sb = new StringBuilder("Cómmics con stock:\n");


                return comicsConStock;
            }
        }



        public Task<bool> EliminarComic(int comicId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertarComic(ComicPageModel comicPageModel)
        {
            throw new NotImplementedException();
        }
        // Dentro de ComicRepository
        public async Task<List<Comic>> CargarComics()
        {
            try
            {
                using (VentasADO ventasADO = new VentasADO()) // Asegúrate de que esta clase esté correctamente configurada para acceder a los cómics
                {
                    // Llamada asincrónica para cargar los cómics desde la base de datos (ajusta según tu implementación)
                    var comics = await Task.Run(() => ventasADO.CargarComics()); // Suponiendo que este método existe y retorna una lista de cómics
                    return comics;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cómics1: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<Comic>();
            }
        }
        //EL correcto
        public List<Comic> ObtenerComics()
        {
            try
            {
                using (VentasADO ventasADO = new VentasADO()) // Asegúrate de que esta clase esté correctamente configurada para acceder a los cómics
                {
                    var comics =  ventasADO.CargarComics(); // Suponiendo que este método existe y retorna una lista de cómics
                    return comics;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cómics1: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<Comic>();
            }
        }


        public List<Comic> LoadComics()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    var comics = ventasADO.CargarComics(); 

                    return comics;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos de cómics2: {ex.Message}");
                    return new List<Comic>();
                }
            }
        }

        public (Comic, List<StockComic>, StockComic) obtenerDetallesComic(int idComic, int tiendaId)
        {
            try
            {
                using (VentasADO ventasADO = new VentasADO())
                {
                    var comic = ventasADO.obtenerDetallesComic(Convert.ToString(idComic));

                    var stockTiendaActual = ventasADO.ListarPorComicYTienda(idComic, tiendaId);


                    var stockOtrasTiendas = ventasADO.ObtenerStockEnOtrasTiendas(idComic, tiendaId);


                    return (comic, stockOtrasTiendas, stockTiendaActual);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del cómic: {ex.Message}");
                return (null, new List<StockComic>(), null);
            }
        }



        public Task<bool> ModificarComic(ComicPageModel comicPageModel)
        {
            throw new NotImplementedException();
        }

        Task<List<ComicPageModel>> IComicRepository.CargarComics()
        {
            throw new NotImplementedException();
        }

        public Task<List<ComicPageModel>> CargarComicsConDetalles()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertarComic(ComicModel comicViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModificarComic(ComicModel comicViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
