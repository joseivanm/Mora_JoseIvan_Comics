using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class EditorialADO : IDisposable
    {
        bool disposed;

        public EditorialADO()
        {
            disposed = false;
        }

        // Metodo para listar todas las editoriales en la base de datos
        public IList<Editorial> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.Editorials.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de editoriales", ex);
                }
            }
        }

        // Metodo para listar una editorial por su ID
        public Editorial Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int EditorialId))
                    {
                        var editorial = context.Editorials.FirstOrDefault(e => e.EditorialId == EditorialId);
                        return editorial;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar la editorial con el ID proporcionado", ex);
                }
            }
        }

        public List<Editorial> ListarEditorialesPorTienda(int tiendaId)
        {
            using (var context = new ComicsContext())
            {
                return context.StockComics
                              .Where(sc => sc.LocalId == tiendaId)
                              .Join(context.Comics, sc => sc.ComicId, c => c.ComicId, (sc, c) => c)
                              .GroupBy(c => c.EditorialId)
                              .Select(g => g.First().Editorial)  // Obtener las editoriales únicas
                              .ToList();
            }
        }

        // Metodo para insertar una nueva editorial en la base de datos
        public Editorial Insertar(Editorial nuevaEditorial)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.Editorials.Add(nuevaEditorial);
                    context.SaveChanges();
                    return nuevaEditorial;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar la nueva editorial", ex);
                }
            }
        }

        // Metodo para actualizar una editorial existente
        public void Actualizar(Editorial editorial)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var editorialExistente = context.Editorials.FirstOrDefault(e => e.EditorialId == editorial.EditorialId);
                    if (editorialExistente != null)
                    {
                        editorialExistente.Nombre = editorial.Nombre;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("La editorial no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos de la editorial", ex);
                }
            }
        }

        // Metodo para eliminar una editorial existente
        public void Borrar(Editorial editorial)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var editorialExistente = context.Editorials.FirstOrDefault(e => e.EditorialId == editorial.EditorialId);
                    if (editorialExistente != null)
                    {
                        context.Editorials.Remove(editorialExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("La editorial no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la editorial", ex);
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
            }

            disposed = true;
        }
    }
}
