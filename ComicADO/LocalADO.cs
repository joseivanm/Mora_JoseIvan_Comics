using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class LocalADO : IDisposable
    {
        bool disposed;

        public LocalADO()
        {
            disposed = false;
        }

        // Metodo para listar todos los locales en la base de datos
        public IList<Local> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.Locals.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de locales", ex);
                }
            }
        }

        // Metodo para listar un local por su ID
        public Local Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int localId))
                    {
                        var local = context.Locals.FirstOrDefault(l => l.LocalId == localId);
                        return local;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el local con el ID proporcionado", ex);
                }
            }
        }
        public Local ObtenerLocalPorId(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int localId))
                    {

                        var local = context.Locals.FirstOrDefault(l => l.LocalId == localId);
                        return local; 
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es válido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el local con el ID proporcionado", ex);
                }
            }
        }
        public IList<Local> ListarLocales()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.Locals.ToList(); // Asumiendo que la DbSet se llama Local
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de locales", ex);
                }
            }
        }


        // Metodo para insertar un nuevo local en la base de datos
        public Local Insertar(Local nuevoLocal)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.Locals.Add(nuevoLocal);
                    context.SaveChanges();
                    return nuevoLocal;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el nuevo local", ex);
                }
            }
        }

        // Metodo para actualizar un local existente
        public void Actualizar(Local local)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var localExistente = context.Locals.FirstOrDefault(l => l.LocalId == local.LocalId);
                    if (localExistente != null)
                    {
                        localExistente.Nombre = local.Nombre;
                        localExistente.Direccion = local.Direccion;
                        localExistente.Latitud = local.Latitud;
                        localExistente.Longitud = local.Longitud;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El local no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del local", ex);
                }
            }
        }

        // Metodo para eliminar un local existente
        public void Borrar(Local local)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var localExistente = context.Locals.FirstOrDefault(l => l.LocalId == local.LocalId);
                    if (localExistente != null)
                    {
                        context.Locals.Remove(localExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El local no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el local", ex);
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
