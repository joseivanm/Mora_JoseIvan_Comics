using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class DetalleOperacionADO : IDisposable
    {
        bool disposed;

        public DetalleOperacionADO()
        {
            disposed = false;
        }

        // Metodo para listar todos los detalles de operaciones en la base de datos
        public IList<DetalleOperacion> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.DetalleOperacions.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de detalles de operaciones", ex);
                }
            }
        }
        // Metodo para listar todos los detalles de una operacion por el ID de la operacion
        public List<DetalleOperacion> ListarPorOperacionId(int operacionId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    // Filtramos los detalles de operación por el operacionId proporcionado
                    return context.DetalleOperacions
                                  .Where(d => d.OperacionId == operacionId)
                                  .ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar detalles de operación por OperacionId", ex);
                }
            }
        }



        // Metodo para listar un detalle de operacion por su ID
        public DetalleOperacion Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int detalleOperacionId))
                    {
                        var detalleOperacion = context.DetalleOperacions.FirstOrDefault(d => d.DetalleOperacionId == detalleOperacionId);
                        return detalleOperacion;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el detalle de operacion con el ID proporcionado", ex);
                }
            }
        }

        // Metodo para insertar un nuevo detalle de operacion en la base de datos
        public DetalleOperacion Insertar(DetalleOperacion nuevoDetalle)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.DetalleOperacions.Add(nuevoDetalle);
                    context.SaveChanges();
                    return nuevoDetalle;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el nuevo detalle de operacion", ex);
                }
            }
        }

        // Metodo para actualizar un detalle de operacion existente
        public void Actualizar(DetalleOperacion detalleOperacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var detalleExistente = context.DetalleOperacions.FirstOrDefault(d => d.DetalleOperacionId == detalleOperacion.DetalleOperacionId);
                    if (detalleExistente != null)
                    {
                        detalleExistente.OperacionId = detalleOperacion.OperacionId;
                        detalleExistente.ComicId = detalleOperacion.ComicId;
                        detalleExistente.Cantidad = detalleOperacion.Cantidad;
                        detalleExistente.Precio = detalleOperacion.Precio;
                        detalleExistente.Descuento = detalleOperacion.Descuento;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El detalle de operacion no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del detalle de operacion", ex);
                }
            }
        }

        // Metodo para eliminar un detalle de operacion existente
        public void Borrar(DetalleOperacion detalleOperacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var detalleExistente = context.DetalleOperacions.FirstOrDefault(d => d.DetalleOperacionId == detalleOperacion.DetalleOperacionId);
                    if (detalleExistente != null)
                    {
                        context.DetalleOperacions.Remove(detalleExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El detalle de operacion no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el detalle de operacion", ex);
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
