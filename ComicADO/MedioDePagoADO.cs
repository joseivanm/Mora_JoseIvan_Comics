using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class MedioDePagoADO : IDisposable
    {
        bool disposed;

        public MedioDePagoADO()
        {
            disposed = false;
        }

        // Metodo para listar todos los medios de pago
        public IList<MedioDePago> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.MedioDePagos.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de medios de pago", ex);
                }
            }
        }

        // Metodo para listar un medio de pago por ID
        public MedioDePago Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int medioDePagoId))
                    {
                        var medioDePago = context.MedioDePagos.FirstOrDefault(mp => mp.MedioDePagoId == medioDePagoId);
                        return medioDePago;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el medio de pago con el ID proporcionado", ex);
                }
            }
        }

        // Metodo para insertar un nuevo medio de pago
        public MedioDePago Insertar(MedioDePago nuevoMedioDePago)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.MedioDePagos.Add(nuevoMedioDePago);
                    context.SaveChanges();
                    return nuevoMedioDePago;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el nuevo medio de pago", ex);
                }
            }
        }

        // Metodo para actualizar un medio de pago existente
        public void Actualizar(MedioDePago medioDePago)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var medioDePagoExistente = context.MedioDePagos.FirstOrDefault(mp => mp.MedioDePagoId == medioDePago.MedioDePagoId);
                    if (medioDePagoExistente != null)
                    {
                        medioDePagoExistente.Descripcion = medioDePago.Descripcion;
                        medioDePagoExistente.NombreCorto = medioDePago.NombreCorto;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El medio de pago no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del medio de pago", ex);
                }
            }
        }

        // Metodo para eliminar un medio de pago existente
        public void Borrar(MedioDePago medioDePago)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var medioDePagoExistente = context.MedioDePagos.FirstOrDefault(mp => mp.MedioDePagoId == medioDePago.MedioDePagoId);
                    if (medioDePagoExistente != null)
                    {
                        context.MedioDePagos.Remove(medioDePagoExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El medio de pago no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el medio de pago", ex);
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
