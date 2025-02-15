using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class StockComicADO : IDisposable
    {
        bool disposed;

        public StockComicADO()
        {
            disposed = false;
        }

        // Método para listar todos los stocks de cómics
        public IList<StockComic> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.StockComics.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de stocks de comics", ex);
                }
            }
        }
        public List<StockComic> ListarComicsPorTiendaExcluyendoLocal(int comicId, int tiendaId)
        {
            try
            {
                using (var context = new ComicsContext())
                {
                    return context.StockComics
                        .Where(sc => sc.ComicId == comicId && sc.LocalId != tiendaId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los stock en otras tiendas: {ex.Message}");
                return new List<StockComic>();
            }
        }


        // Método para listar un stock de cómic por ID
        public StockComic Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int stockComicId))
                    {
                        var stockComic = context.StockComics.FirstOrDefault(s => s.StockComicId == stockComicId);
                        return stockComic;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el stock de comic con el ID proporcionado", ex);
                }
            }
        }
        public StockComic ListarporComic(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int comicId)) 
                    {
                        var stockComic = context.StockComics.FirstOrDefault(s => s.ComicId == comicId);
                        return stockComic;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es válido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el stock del cómic con el ID proporcionado.", ex);
                }
            }
        }


        // Método para listar un stock de cómic por ComicId
        public StockComic ListarPorComicId(int comicId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var stockComic = context.StockComics.FirstOrDefault(s => s.ComicId == comicId);
                    return stockComic;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el stock de comic con el ID proporcionado", ex);
                }
            }
        }

        // Método para insertar un nuevo stock de cómic
        public StockComic Insertar(StockComic nuevoStockComic)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.StockComics.Add(nuevoStockComic);
                    context.SaveChanges();
                    return nuevoStockComic;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el nuevo stock de comic", ex);
                }
            }
        }

        // Método para actualizar un stock de cómic existente
        public void Actualizar(StockComic stockComic)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var stockComicExistente = context.StockComics.FirstOrDefault(s => s.StockComicId == stockComic.StockComicId);
                    if (stockComicExistente != null)
                    {
                        stockComicExistente.ComicId = stockComic.ComicId;
                        stockComicExistente.LocalId = stockComic.LocalId;
                        stockComicExistente.Cantidad = stockComic.Cantidad;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El stock de comic no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del stock de comic", ex);
                }
            }
        }

        // Método para eliminar un stock de cómic existente
        public void Borrar(StockComic stockComic)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (stockComic == null)
                    {
                        throw new ArgumentNullException(nameof(stockComic), "El objeto stockComic no puede ser nulo.");
                    }

                    // Buscar si el stock realmente existe
                    var stockComicExistente = context.StockComics.FirstOrDefault(s => s.StockComicId == stockComic.StockComicId);

                    if (stockComicExistente != null)
                    {
                        context.StockComics.Remove(stockComicExistente);
                        int registrosAfectados = context.SaveChanges();

                        if (registrosAfectados == 0)
                        {
                            throw new Exception("No se pudo eliminar el stock del cómic. La operación no afectó ninguna fila.");
                        }
                    }
                    else
                    {
                        throw new KeyNotFoundException($"El stock del cómic con ID {stockComic.StockComicId} no existe en la base de datos.");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    throw new Exception("Error: Se intentó eliminar un stock nulo.", ex);
                }
                catch (KeyNotFoundException ex)
                {
                    throw new Exception("Error: No se encontró el stock del cómic en la base de datos.", ex);
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception("Error al actualizar la base de datos al eliminar el stock del cómic. Puede haber restricciones de claves foráneas.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado al eliminar el stock del cómic.", ex);
                }
            }
        }


        // Método para listar las editoriales por tienda
        public List<Editorial> ListarEditorialesPorTienda(int tiendaId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var editoriales = context.StockComics
                        .Where(sc => sc.LocalId == tiendaId)
                        .Join(context.Comics, sc => sc.ComicId, c => c.ComicId, (sc, c) => c.Editorial)
                        .Distinct()
                        .ToList();

                    return editoriales;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las editoriales para la tienda seleccionada", ex);
                }
            }
        }

        // Método para listar los cómics de una tienda y editorial
        public List<Comic> ListarComicsPorTiendaYEditorial(int tiendaId, int editorialId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var comics = context.StockComics
                        .Where(sc => sc.LocalId == tiendaId && sc.Comic.EditorialId == editorialId)
                        .Select(sc => sc.Comic)
                        .ToList();

                    return comics;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los cómics de la tienda y editorial seleccionadas", ex);
                }
            }
        }

        // Método para listar el stock de un cómic en una tienda
        public StockComic ListarPorComicYTienda(int comicId, int tiendaId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var stockComic = context.StockComics
                        .FirstOrDefault(sc => sc.ComicId == comicId && sc.LocalId == tiendaId);

                    return stockComic;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el stock de comic para la tienda y cómic seleccionados", ex);
                }
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
                // Dispose of any resources
            }

            disposed = true;
        }
    }
}
