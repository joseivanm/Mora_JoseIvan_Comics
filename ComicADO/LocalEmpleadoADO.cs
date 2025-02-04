using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class LocalEmpleadoADO : IDisposable
    {
        bool disposed;

        public LocalEmpleadoADO()
        {
            disposed = false;
        }

        // Metodo para listar todas las relaciones entre empleados y locales
        public IList<LocalEmpleado> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.LocalEmpleados.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    string empleadoInfo = "";
                    string innerErrorMessage = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales";
                    string errorMessage = $"Error al insertar el nuevo empleado: {empleadoInfo}. Detalles: {ex.Message}. Inner exception: {innerErrorMessage}";
                    throw new Exception(errorMessage, ex); // Manejo de excepciones
                }
            }
        }

        // Metodo para listar una relacion por ID de empleado
        public LocalEmpleado Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int empleadoId))
                    {
                        var localEmpleado = context.LocalEmpleados.FirstOrDefault(le => le.EmpleadoId == empleadoId);
                        return localEmpleado;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar la relacion del empleado con el ID proporcionado", ex);
                }
            }
        }

        // Metodo para insertar una nueva relacion entre empleado y local
       public LocalEmpleado Insertar(LocalEmpleado nuevoLocalEmpleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.LocalEmpleados.Add(nuevoLocalEmpleado);
                    context.SaveChanges();
                    return nuevoLocalEmpleado;
                }
                catch (Exception ex)
                {
                    string empleadoInfo = nuevoLocalEmpleado.LocalId.ToString();
                    string innerErrorMessage = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales";
                    string errorMessage = $"Error al insertar el nuevo empleado: {empleadoInfo}. Detalles: {ex.Message}. Inner exception: {innerErrorMessage}";
                    throw new Exception(errorMessage, ex); // Manejo de excepciones
                }
            }
        }
        /*public void Insertar(int empleadoId, int localId)
        {
            using (var context = new ComicsContext())
            {
                // Verifica que los IDs de Empleado y Local existen en la base de datos
                if (context.Empleados.Any(e => e.EmpleadoId == empleadoId) &&
                    context.Locals.Any(l => l.LocalId == localId))
                {
                    // Crea una nueva instancia de LocalEmpleado
                    var localEmpleado = new LocalEmpleado
                    {
                        EmpleadoId = empleadoId,
                        LocalId = localId
                    };

                    try
                    {
                        // Añade la relación a la tabla LocalEmpleado
                        context.LocalEmpleados.Add(localEmpleado);
                        context.SaveChanges(); // Intenta guardar los cambios
                        MessageBox.Show("Relación LocalEmpleado insertada exitosamente.");
                    }
                    catch (DbUpdateException dbEx)
                    {
                        // Maneja las excepciones específicas de la base de datos
                        var innerException = dbEx.InnerException != null ? dbEx.InnerException.Message : "No hay detalles adicionales";
                        MessageBox.Show($"Error al insertar la relación LocalEmpleado: {innerException}");
                    }
                    catch (Exception ex)
                    {
                        // Maneja otras excepciones
                        MessageBox.Show($"Error inesperado: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("El empleado o el local no existen.");
                }
            }*
        }*/

        public void Actualizar(LocalEmpleado localEmpleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    // Buscar la relación actual del empleado en cualquier local
                    var relacionExistente = context.LocalEmpleados
                        .FirstOrDefault(le => le.EmpleadoId == localEmpleado.EmpleadoId);

                    // Si existe, eliminar la relación actual
                    if (relacionExistente != null)
                    {
                        context.LocalEmpleados.Remove(relacionExistente);
                    }

                    // Agregar la nueva relación con el nuevo LocalId
                    context.LocalEmpleados.Add(localEmpleado);

                    // Guardar los cambios
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la relación entre empleado y local", ex);
                }
            }
        }

        public void EliminarRelacion(LocalEmpleado localEmpleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    // Buscar la relacin actual del empleado en cualquier local
                    var relacionExistente = context.LocalEmpleados
                        .FirstOrDefault(le => le.EmpleadoId == localEmpleado.EmpleadoId);

                    // Si existe, eliminar la relacion 
                    if (relacionExistente != null)
                    {
                        context.LocalEmpleados.Remove(relacionExistente);
                    }

                    

                    // Guardar los cambios
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la relación entre empleado y local", ex);
                }
            }
        }




        // Metodo para actualizar una relacion existente
        /*public void Actualizar(LocalEmpleado localEmpleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var localEmpleadoExistente = context.LocalEmpleados.FirstOrDefault(le => le.EmpleadoId == localEmpleado.EmpleadoId && le.LocalId == localEmpleado.LocalId);
                    if (localEmpleadoExistente != null)
                    {
                        localEmpleadoExistente.LocalId = localEmpleado.LocalId;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("La relacion no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la relacion entre empleado y local", ex);
                }
            }
        }*/

        // Metodo para eliminar una relacion existente
        public void Borrar(LocalEmpleado localEmpleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var localEmpleadoExistente = context.LocalEmpleados.FirstOrDefault(le => le.EmpleadoId == localEmpleado.EmpleadoId && le.LocalId == localEmpleado.LocalId);
                    if (localEmpleadoExistente != null)
                    {
                        context.LocalEmpleados.Remove(localEmpleadoExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("La relacion no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la relacion entre empleado y local", ex);
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
