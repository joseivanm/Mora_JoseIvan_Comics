using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entidades;
using System.Windows.Forms;

namespace ComicADO
{
    //<author>Jose Ivan Mora Gonzaga</author>

    public class OperacionADO : IDisposable
    {
        bool disposed;

        public OperacionADO()
        {
            disposed = false;
        }

        // Metodo para listar todas las operaciones
        public IList<Operacion> Listar()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var data = context.Operacions.ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la lista de operaciones", ex);
                }
            }
        }
        public List<int> GetPedidosPorEmpleadoUltimoAno()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var empleadosPedidos = context.Operacions
                        .Where(o => o.FechaOperacion >= DateTime.Now.AddYears(-1)) 
                        .GroupBy(o => new { o.EmpleadoId, o.FechaOperacion.Month }) 
                        .Select(group => new
                        {
                            EmpleadoId = group.Key.EmpleadoId,
                            Mes = group.Key.Month,
                            TotalPedidos = group.Count()
                        })
                        .ToList();

                    
                    var pedidosPorMes = new List<int>();
                    foreach (var empleado in empleadosPedidos.OrderBy(e => e.EmpleadoId).ThenBy(e => e.Mes))
                    {
                        pedidosPorMes.Add(empleado.TotalPedidos); 
                    }

                    return pedidosPorMes;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los pedidos por empleado del último año", ex);
                }
            }
        }
        public List<KeyValuePair<string, double>> GetVentasPorEditorial()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var ventasPorEditorial = context.Operacions
                        .SelectMany(o => o.DetalleOperacions)
                        .GroupBy(d => d.Comic.Editorial.Nombre) // Agrupar por el nombre de la editorial
                        .Select(group => new
                        {
                            Editorial = group.Key,
                            TotalVentas = group.Sum(d => (d.Precio ?? 0) * (d.Cantidad ?? 0)) // decimal?
                        })
                        .ToList();

                    // Conviértelo a decimal para evitar mezclarlo con double
                    decimal totalVentas = ventasPorEditorial.Sum(v => v.TotalVentas);

                    // Calculamos el porcentaje de ventas por cada editorial
                    var porcentajeVentas = ventasPorEditorial
                        .Select(v =>
                        {
                            // Conviértelo a decimal para que coincida con totalVentas
                            decimal ventas = v.TotalVentas;
                            // Evita la división por cero
                            decimal porcentaje = totalVentas == 0 ? 0 : (ventas / totalVentas) * 100m;

                            return new KeyValuePair<string, double>(
                                v.Editorial,
                                (double)porcentaje // Convertimos a double para LiveCharts (si lo necesitas como double)
                            );
                        })
                        .ToList();

                    return porcentajeVentas;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las ventas por editorial", ex);
                }
            }
        }

        public List<Operacion> ListarPorComic(int comicId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var operaciones = context.Operacions
                        .Where(o => o.ComicId == comicId)
                        .ToList();

                    return operaciones;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener las operaciones del cómic con ID {comicId}", ex);
                }
            }
        }




        // Metodo para listar una operacion por ID
        public Operacion Listar(int operacionId)
        {
            using (var context = new ComicsContext())
            {
                try
                {

                        var operacion = context.Operacions.FirstOrDefault(o => o.OperacionId == operacionId);
                        return operacion;

                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar la operacion con el ID proporcionado", ex);
                }
            }
        }
        /* public int GetTotalPedidosUltimoMes(int usuarioId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    // Filtrar las operaciones realizadas en el último mes para el usuario específico
                    var totalPedidos = context.Operacions
                        .Where(o => o.FechaOperacion >= DateTime.Now.AddMonths(-1) &&
                                    o.EmpleadoId == usuarioId &&
                                    context.OperacionClientesJIM.Any(oc => oc.OperacionId == o.OperacionId && oc.ClienteId == usuarioId)) // Relación con el cliente
                        .Count();

                    return totalPedidos;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el total de pedidos del último mes1", ex);
                }
            }
        }*/
        public int GetTotalPedidosUltimoMes(int usuarioId)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var totalPedidos = context.Operacions
                        .Where(o => o.FechaOperacion >= DateTime.Now.AddMonths(-1) &&
                                    o.EmpleadoId == usuarioId)
                        .Count();
                    return totalPedidos;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el total de pedidos del último mes", ex);
                }
            }
        }




        // Método para obtener el número total de productos con menos de 10 unidades en stock
        public int GetProductosConStockBajo()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var productosBajoStock = context.StockComics
                        .Where(s => s.Cantidad < 10)
                        .Count();

                    return productosBajoStock;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los productos con stock bajo", ex);
                }
            }
        }

        // Método para obtener el importe de los pedidos realizados hoy
        public decimal GetImportePedidosHoy()
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var operacionesHoy = context.Operacions
                        .Where(o => o.FechaOperacion.Date == DateTime.Today)
                        .ToList();

                    decimal importeHoy = 0;

                    foreach (var operacion in operacionesHoy)
                    {
                        var detallesOperacion = context.DetalleOperacions
                            .Where(d => d.OperacionId == operacion.OperacionId)
                            .ToList();

                        foreach (var detalle in detallesOperacion)
                        {
                            decimal precio = detalle.Precio ?? 0;
                            int cantidad = detalle.Cantidad ?? 0;
                            importeHoy += precio * cantidad;
                        }
                    }

                    return importeHoy;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el importe de los pedidos realizados hoy", ex);
                }
            }
        }




        // Método para obtener el importe de los pedidos realizados hoy por un usuario específico
        public decimal GetImportePedidosHoyUsuario(int usuarioId)
        {
            using (var context = new ComicsContext())
            {

                try
                {
                    decimal importeHoyUsuario = 0;

                    // Filtramos las operaciones por fecha de hoy y el EmpleadoId
                    var operacionesHoy = context.Operacions
                        .Where(o => o.FechaOperacion.Date == DateTime.Today && o.EmpleadoId == usuarioId)
                        .ToList(); // Obtenemos las operaciones de hoy para el usuario

                    // Iteramos sobre cada operación
                    foreach (var operacion in operacionesHoy)
                    {
                        // Obtenemos los detalles de la operación
                        var detallesOperacion = context.DetalleOperacions
                            .Where(d => d.OperacionId == operacion.OperacionId)
                            .ToList();

                        // Iteramos sobre cada detalle de la operación y sumamos el importe
                        foreach (var detalle in detallesOperacion)
                        {
                            decimal precio = detalle.Precio ?? 0;
                            int cantidad = detalle.Cantidad ?? 0;
                            importeHoyUsuario += precio * cantidad;
                        }
                    }

                    return importeHoyUsuario;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el importe de los pedidos realizados hoy por el usuario", ex);
                }
            }
        }


        // Metodo para insertar una nueva operacion
        public Operacion Insertar(Operacion nuevaOperacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.Operacions.Add(nuevaOperacion);
                    context.SaveChanges();
                    return nuevaOperacion;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"Error al insertar la nueva operación: {ex.Message} - Inner Exception: {ex.InnerException.Message}");
                    }
                    else
                    {
                        MessageBox.Show($"Error al insertar la nueva operación: {ex.Message}");
                    }
                    throw new Exception("Error al insertar la nueva operación", ex);
                }
            }
        }


        // Metodo para actualizar una operacion existente
        public void Actualizar(Operacion operacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var operacionExistente = context.Operacions.FirstOrDefault(o => o.OperacionId == operacion.OperacionId);
                    if (operacionExistente != null)
                    {
                        operacionExistente.MedioDePagoId = operacion.MedioDePagoId;
                        operacionExistente.TipoOperacionId = operacion.TipoOperacionId;
                        operacionExistente.ComicId = operacion.ComicId;
                        operacionExistente.LocalId = operacion.LocalId;
                        operacionExistente.FechaOperacion = operacion.FechaOperacion;
                        operacionExistente.EmpleadoId = operacion.EmpleadoId;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("La operacion no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar los datos de la operacion", ex);
                }
            }
        }

        // Metodo para eliminar una operacion existente
        public void Borrar(Operacion operacion)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    if (operacion == null)
                    {
                        throw new ArgumentNullException(nameof(operacion), "La operación proporcionada es nula.");
                    }

               
                    var operacionExistente = context.Operacions.FirstOrDefault(o => o.OperacionId == operacion.OperacionId);

                    if (operacionExistente == null)
                    {
                        throw new KeyNotFoundException($"La operación con ID {operacion.OperacionId} no existe en la base de datos.");
                    }

    
                    var detallesOperacion = context.DetalleOperacions.Where(d => d.OperacionId == operacion.OperacionId).ToList();
                    if (detallesOperacion.Any())
                    {
                        context.DetalleOperacions.RemoveRange(detallesOperacion);
                        context.SaveChanges();
                    }

                    
                    context.Operacions.Remove(operacionExistente);
                    int registrosAfectados = context.SaveChanges();

                    if (registrosAfectados == 0)
                    {
                        throw new Exception($"No se pudo eliminar la operación con ID {operacion.OperacionId}. No se afectaron filas.");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    throw new Exception("Error: La operación es nula.", ex);
                }
                catch (KeyNotFoundException ex)
                {
                    throw new Exception("Error: La operación no existe en la base de datos.", ex);
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception($"Error al actualizar la base de datos al eliminar la operación (ID {operacion?.OperacionId}): {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error inesperado al eliminar la operación con ID {operacion?.OperacionId}: {ex.Message}", ex);
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
