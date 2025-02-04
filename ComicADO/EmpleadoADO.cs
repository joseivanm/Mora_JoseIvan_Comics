using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class EmpleadoADO : IDisposable
    {
        bool disposed;

        public EmpleadoADO()
        {
            disposed = false;
        }

        // Metodo para listar todos los empleados en la base de datos
        public IList<Empleado> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.Empleados.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de empleados", ex);
                }
            }
        }

        // Metodo para listar un empleado por su ID
        public Empleado Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int empleadoId))
                    {
                        var empleado = context.Empleados.FirstOrDefault(e => e.EmpleadoId == empleadoId);
                        return empleado;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es válido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el empleado con el ID proporcionado", ex);
                }
            }
        }

        // Metodo para insertar un nuevo empleado en la base de datos
        public Empleado Insertar(Empleado nuevoEmpleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.Empleados.Add(nuevoEmpleado);
                    context.SaveChanges();
                    return nuevoEmpleado;
                }
                catch (Exception ex)
                {
                    string empleadoInfo = nuevoEmpleado.Nif;
                    string innerErrorMessage = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales";
                    string errorMessage = $"Error al insertar el nuevo empleado: {empleadoInfo}. Detalles: {ex.Message}. Inner exception: {innerErrorMessage}";
                    throw new Exception(errorMessage, ex); // Manejo de excepciones
                }
            }
        }
        

        // Metodo para actualizar un empleado existente
        public void Actualizar(Empleado empleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var empleadoExistente = context.Empleados.FirstOrDefault(e => e.EmpleadoId == empleado.EmpleadoId);
                    if (empleadoExistente != null)
                    {
                        empleadoExistente.Nombre = empleado.Nombre;
                        empleadoExistente.Apellido = empleado.Apellido;
                        empleadoExistente.Nif = empleado.Nif;
                        empleadoExistente.Direccion = empleado.Direccion;
                        empleadoExistente.Password = empleado.Password;
                        empleadoExistente.Email = empleado.Email;  
                        empleadoExistente.Fotografia = empleado.Fotografia;
                        
                       
                        

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El empleado no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del empleado", ex);
                }
            }
        }

        public void ActualizarSinPass(Empleado empleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var empleadoExistente = context.Empleados.FirstOrDefault(e => e.EmpleadoId == empleado.EmpleadoId);
                    if (empleadoExistente != null)
                    {
                        empleadoExistente.Nombre = empleado.Nombre;
                        empleadoExistente.Apellido = empleado.Apellido;
                        empleadoExistente.Nif = empleado.Nif;
                        empleadoExistente.Direccion = empleado.Direccion;
                        empleadoExistente.Email = empleado.Email;
                        empleadoExistente.Fotografia = empleado.Fotografia;




                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El empleado no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del empleado", ex);
                }
            }
        }

        // Metodo para actualizar la fotografia de un empleado existente
        public void ActualizarFotografia(int empleadoId, byte[] fotografia)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var empleadoExistente = context.Empleados.FirstOrDefault(e => e.EmpleadoId == empleadoId);
                    if (empleadoExistente != null)
                    {
                        empleadoExistente.Fotografia = fotografia;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El empleado no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la fotografía del empleado", ex);
                }
            }
        }


        // Metodo para eliminar un empleado existente
        public void Borrar(Empleado empleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var empleadoExistente = context.Empleados.FirstOrDefault(e => e.EmpleadoId == empleado.EmpleadoId);
                    if (empleadoExistente != null)
                    {
                        context.Empleados.Remove(empleadoExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El empleado no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el empleado", ex);
                }
            }
        }

        public void Inactivo(Empleado empleado)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var empleadoExistente = context.Empleados.FirstOrDefault(e => e.EmpleadoId == empleado.EmpleadoId);
                    if (empleadoExistente != null)
                    {
                        empleadoExistente.Fecha_baja = empleado.Fecha_baja;
                        empleadoExistente.Activo = empleado.Activo;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El empleado no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del empleado", ex);
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
