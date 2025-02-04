using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class TipoOperacionADO : IDisposable
    {
        bool disposed;

        public TipoOperacionADO()
        {
            disposed = false;
        }

        // Metodo para listar todos los tipos de operacion
        public IList<TipoOperacion> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.TipoOperacions.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de tipos de operacion", ex);
                }
            }
        }

        // Metodo para listar un tipo de operacion por ID
        public TipoOperacion Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int tipoOperacionId))
                    {
                        var tipoOperacion = context.TipoOperacions.FirstOrDefault(t => t.TipoOperacionId == tipoOperacionId);
                        return tipoOperacion;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el tipo de operacion con el ID proporcionado", ex);
                }
            }
        }

        // Metodo para insertar un nuevo tipo de operacion
        public TipoOperacion Insertar(TipoOperacion nuevoTipoOperacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.TipoOperacions.Add(nuevoTipoOperacion);
                    context.SaveChanges();
                    return nuevoTipoOperacion;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el nuevo tipo de operacion", ex);
                }
            }
        }

        // Metodo para actualizar un tipo de operacion existente
        public void Actualizar(TipoOperacion tipoOperacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var tipoOperacionExistente = context.TipoOperacions.FirstOrDefault(t => t.TipoOperacionId == tipoOperacion.TipoOperacionId);
                    if (tipoOperacionExistente != null)
                    {
                        tipoOperacionExistente.Descripcion = tipoOperacion.Descripcion;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El tipo de operacion no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del tipo de operacion", ex);
                }
            }
        }

        // Metodo para eliminar un tipo de operacion existente
        public void Borrar(TipoOperacion tipoOperacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var tipoOperacionExistente = context.TipoOperacions.FirstOrDefault(t => t.TipoOperacionId == tipoOperacion.TipoOperacionId);
                    if (tipoOperacionExistente != null)
                    {
                        context.TipoOperacions.Remove(tipoOperacionExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El tipo de operacion no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el tipo de operacion", ex);
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
