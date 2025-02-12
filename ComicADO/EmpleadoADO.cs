using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    /// <summary>
    /// Clase que gestiona el acceso a la base de datos para la entidad Empleado.
    /// </summary>
    /// <author>Jose Ivan Mora Gonzaga</author>
    public class EmpleadoADO : IDisposable
    {
        private bool disposed;

        /// <summary>
        /// Constructor de la clase EmpleadoADO.
        /// </summary>
        public EmpleadoADO()
        {
            disposed = false;
        }

        /// <summary>
        /// Obtiene la lista de todos los empleados en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos de tipo <see cref="Empleado"/>.</returns>
        /// <example>
        /// <code>
        /// EmpleadoADO empleadoADO = new EmpleadoADO();
        /// var empleados = empleadoADO.Listar();
        /// </code>
        /// </example>
        public IList<Empleado> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    return context.Empleados.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de empleados", ex);
                }
            }
        }

        /// <summary>
        /// Obtiene un empleado por su ID.
        /// </summary>
        /// <param name="ID">Identificador del empleado.</param>
        /// <returns>Objeto <see cref="Empleado"/> correspondiente al ID proporcionado.</returns>
        /// <exception cref="ArgumentException">Si el ID proporcionado no es valido.</exception>
        /// <example>
        /// <code>
        /// EmpleadoADO empleadoADO = new EmpleadoADO();
        /// var empleado = empleadoADO.Listar("1");
        /// </code>
        /// </example>
        public Empleado Listar(string ID)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (int.TryParse(ID, out int empleadoId))
                    {
                        return context.Empleados.FirstOrDefault(e => e.EmpleadoId == empleadoId);
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es valido.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el empleado con el ID proporcionado", ex);
                }
            }
        }

        /// <summary>
        /// Inserta un nuevo empleado.
        /// </summary>
        /// <param name="nuevoEmpleado">Objeto <see cref="Empleado"/> a insertar.</param>
        /// <returns>El objeto <see cref="Empleado"/> insertado.</returns>
        /// <exception cref="Exception">Si ocurre un error durante la insercion.</exception>
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
                    throw new Exception($"Error al insertar el nuevo empleado: {nuevoEmpleado.Nif}", ex);
                }
            }
        }

        /// <summary>
        /// Actualiza un empleado.
        /// </summary>
        /// <param name="empleado">Objeto <see cref="Empleado"/> con los datos actualizados.</param>
        /// <exception cref="Exception">Si el empleado no existe o hay un error al actualizar.</exception>
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

        /// <summary>
        /// Actualiza solo los datos basicos del empleado sin modificar la contrasenya.
        /// </summary>
        /// <param name="empleado">Objeto <see cref="Empleado"/> con los datos actualizados.</param>
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

        /// <summary>
        /// Metodo para desactivar un empleado sin eliminarlo.
        /// </summary>
        /// <param name="empleado">Objeto <see cref="Empleado"/> con los datos actualizados.</param>
        /// <remarks>
        /// Este metodo actualiza el estado del empleado en la base de datos, 
        /// asignando una fecha de baja y cambiando el estado de "Activo".
        /// </remarks>
        /// <example>
        /// <code>
        /// EmpleadoADO empleadoADO = new EmpleadoADO();
        /// Empleado empleado = new Empleado { EmpleadoId = 1, Activo = "N", Fecha_baja = DateTime.Now };
        /// empleadoADO.Inactivo(empleado);
        /// </code>
        /// </example>
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

        /// <summary>
        /// Elimina un empleado de la base de datos.
        /// </summary>
        /// <param name="empleado">Objeto <see cref="Empleado"/> que se desea eliminar.</param>
        /// <exception cref="Exception">Si el empleado no existe o hay un error al eliminar.</exception>
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

        /// <summary>
        /// Libera los recursos utilizados por la instancia de EmpleadoADO.
        /// </summary>
        
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Metodo para liberar recursos gestionados y no gestionados.
        /// </summary>
        /// <param name="disposing">Indica si se estan liberando recursos.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            disposed = true;
        }
    }
}
