using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Iván Mora Gonzaga</author>

    public class ComicsADO : IDisposable
    {

        bool disposed;


        public ComicsADO()
        {
            disposed = false;
        }

        // Metodo para listar todos los comics de la base de datos
        public IList<Comic> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    // Cargar los cómics incluyendo las relaciones de Autor y Editorial
                    var data = context.Comics
                        .Include(c => c.Autor)      // Incluir Autor relacionado
                        .Include(c => c.Editorial)  // Incluir Editorial relacionado
                        .ToList();

                    // Verifica lo que devuelve
                    /*foreach (var comic in data)
                    {
                        // Muestra los valores de los campos Autor y Editorial
                        MessageBox.Show($"Nombre: {comic.Nombre}, Autor: {comic.Autor?.Nombre}, Editorial: {comic.Editorial?.Nombre}");
                    }*/

                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de comics", ex);
                }
            }
        }


        // Metodo para obtener el nombre del comic por su ID
        public string ObtenerNombreComic(int comicId)
        {
            using (var context = new ComicsContext())
            {
                try
                {

                    var comic = context.Comics
                        .FirstOrDefault(c => c.ComicId == comicId); 


                    if (comic != null)
                    {
                        return comic.Nombre; 
                    }
                    else
                    {
                        throw new Exception($"No se encontró un cómic con ID {comicId}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el nombre del cómic", ex);
                }
            }
        }


        // Metodo para listar un comic por su ID
        public Comic Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int comicId))
                    {
                        var comic = context.Comics
                            .Include(c => c.Autor)
                            .Include(c => c.Editorial)
                            .Include(c => c.DetalleOperacions)
                            .Include(c => c.StockComics)
                            .FirstOrDefault(c => c.ComicId == comicId);

                        if (comic == null)
                        {
                            throw new Exception($"El comic con el ID proporcionado ({ID}) no fue encontrado.");
                        }

                        return comic;
                    }
                    else
                    {
                        throw new ArgumentException($"El ID proporcionado ({ID}) no es válido.");
                    }
                }
                catch (Exception ex)
                {
                    // Incluye el ID en el mensaje de la excepción
                    throw new Exception($"Error al buscar el comic con el ID proporcionado ({ID}).", ex);
                }
            }
        }

        public int? BuscarComicPorNombreYEditorial(string nombreComic, int editorialId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var comic = context.Comics
                        .Where(c => c.Nombre == nombreComic && c.EditorialId == editorialId)
                        .Select(c => c.ComicId)
                        .FirstOrDefault();

                    return comic == 0 ? (int?)null : comic;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al buscar el cómic '{nombreComic}' en la editorial {editorialId}.", ex);
                }
            }
        }
        public List<Comic> ListarComicsPorTiendaYEditorial(int tiendaId, int editorialId)
        {
            using (var context = new ComicsContext())
            {
                return context.StockComics
                              .Where(sc => sc.LocalId == tiendaId && sc.Comic.EditorialId == editorialId)
                              .Select(sc => sc.Comic)
                              .ToList();
            }
        }
        public List<Comic> ListarPorEditorialYLocal(string editorialId, int localId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    return context.Comics
                        .Where(c => c.EditorialId.ToString() == editorialId && c.StockComics.Any(s => s.LocalId == localId))
                        .ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los comics por editorial y tienda.", ex);
                }
            }
        }

        public List<Comic> ListarPorEditorial(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    // Convertir ID de editorial de string a int
                    if (int.TryParse(ID, out int editorialId))
                    {
                        // Obtener la lista de comics de una editorial
                        var comics = context.Comics
                            .Include(c => c.Autor)
                            .Include(c => c.Editorial)
                            .Include(c => c.DetalleOperacions)
                            .Include(c => c.StockComics)
                            .Where(c => c.EditorialId == editorialId) // Filtrar comics por EditorialId
                            .ToList(); 

                        if (comics.Count == 0)
                        {

                            MessageBox.Show("No se encontraron comics para la editorial seleccionada.");
                        }

                        return comics;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es válido.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error al buscar los comics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Comic>(); 
                }
            }
        }



        // Metodo para insertar un nuevo comic en la base de datos
        public Comic Insertar(Comic nuevoComic)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.Comics.Add(nuevoComic);
                    context.SaveChanges();
                    return nuevoComic;
                }
                catch (DbUpdateException dbEx) 
                {
                    var innerMessage = dbEx.InnerException?.Message ?? "Sin detalles internos.";
                    throw new Exception(Convert.ToString(nuevoComic.EditorialId) + $"Error al guardar en la base de datos: {innerMessage}", dbEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al insertar el comic: Nombre={nuevoComic.Nombre}, AutorId={nuevoComic.AutorId}, EditorialId={nuevoComic.EditorialId}, PrecioCompra={nuevoComic.PrecioCompra}, PrecioVenta={nuevoComic.PrecioVenta}", ex);
                }
            }
        }

        // Metodo para actualizar un comic existente
        public void Actualizar(Comic comic)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var comicExistente = context.Comics.FirstOrDefault(c => c.ComicId == comic.ComicId); 
                    if (comicExistente != null)
                    {
                        // Actualiza los datos del comic
                        comicExistente.Nombre = comic.Nombre;
                        comicExistente.AutorId = comic.AutorId;
                        comicExistente.EditorialId = comic.EditorialId;
                        comicExistente.PrecioCompra = comic.PrecioCompra;
                        comicExistente.PrecioVenta = comic.PrecioVenta;

                        context.SaveChanges(); // Guarda los cambios en la base de datos
                    }
                    else
                    {
                        throw new Exception("El comic no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error al actualizar los datos del comic", ex);
                }
            }
        }

        // Metodo para eliminar un comic existente
        public void Borrar(int comicId)
        {
            using (var context = new ComicsContext())
            {
                try
                {                    
                    if (comicId <= 0)
                    {
                        throw new ArgumentException("ComicId debe ser un número válido.");
                    }
                    
                    var comicExistente = context.Comics.FirstOrDefault(c => c.ComicId == comicId);
                    if (comicExistente != null)
                    {
                        context.Comics.Remove(comicExistente); 
                        context.SaveChanges(); 
                    }
                    else
                    {
                        throw new Exception($"El cómic con ID {comicId} no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(comicId+ "Error al eliminar el comic", ex);
                }
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {   if (disposed) return;

            if (disposing)
            {
                
            }

            disposed = true;
        }
    }
}
