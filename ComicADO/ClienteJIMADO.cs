using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>José Iván Mora Gonzaga</author>

    public class ClienteJIMADO : IDisposable
    {
        bool disposed;

        public ClienteJIMADO()
        {
            disposed = false;
        }

        // Metodo para listar todos los clientes en la base de datos
        public IList<ClienteJIM> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.Clientes.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de clientes", ex);
                }
            }
        }

        // Metodo para listar un cliente por su ID
        public ClienteJIM Listar(int id)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var cliente = context.Clientes.FirstOrDefault(c => c.ClienteID == id);
                    return cliente;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el cliente con el ID proporcionado", ex);
                }
            }
        }

        // Metodo para insertar un nuevo cliente en la base de datos
        public ClienteJIM Insertar(ClienteJIM nuevoCliente)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.Clientes.Add(nuevoCliente);
                    context.SaveChanges();
                    return nuevoCliente;
                }
                catch (Exception ex)
                {
                    string clienteInfo = nuevoCliente.Nombre;
                    string innerErrorMessage = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales";
                    string errorMessage = $"Error al insertar el nuevo cliente: {clienteInfo}. Detalles: {ex.Message}. Inner exception: {innerErrorMessage}";
                    throw new Exception(errorMessage, ex);
                }
            }
        }

        // Metodo para actualizar un cliente existente
        public void Actualizar(ClienteJIM cliente)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var clienteExistente = context.Clientes.FirstOrDefault(c => c.ClienteID == cliente.ClienteID);
                    if (clienteExistente != null)
                    {
                        clienteExistente.Nombre = cliente.Nombre;
                        clienteExistente.Apellido = cliente.Apellido;
                        clienteExistente.Direccion = cliente.Direccion;
                        clienteExistente.Email = cliente.Email;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El cliente no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del cliente", ex);
                }
            }
        }

        // Metodo para eliminar un cliente existente
        public void Borrar(ClienteJIM cliente)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var clienteExistente = context.Clientes.FirstOrDefault(c => c.ClienteID == cliente.ClienteID);
                    if (clienteExistente != null)
                    {
                        context.Clientes.Remove(clienteExistente);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El cliente no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el cliente", ex);
                }
            }
        }


        // Metodo para poner un cliente como inactivo
        public void Inactivo(ClienteJIM cliente)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var clienteExistente = context.Clientes.FirstOrDefault(c => c.ClienteID == cliente.ClienteID);
                    if (clienteExistente != null)
                    {
                        clienteExistente.Activo = cliente.Activo;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("El cliente no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos del cliente", ex);
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
