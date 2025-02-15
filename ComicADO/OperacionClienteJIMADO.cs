using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicADO
{
    public class OperacionClienteJIMADO : IDisposable
    {
        bool disposed;
        private readonly ComicsContext _context;

        public OperacionClienteJIMADO()
        {
            disposed = false;
        }


        public OperacionClienteJIMADO(ComicsContext context)
        {
            _context = context;
        }

        // Metodo para insertar un nuevo detalle de operacion en la base de datos
        public void EliminarPorOperacion(int operacionId)
        {
            using (var context = new ComicsContext())
            {
                try
                {

                    var registros = context.OperacionClientesJIM
                        .Where(oc => oc.OperacionId == operacionId)
                .ToList();


            if (registros.Any())
                    {
                        _context.OperacionClientesJIM.RemoveRange(registros);
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el nuevo detalle de operacion", ex);
                }
            }
            
        }


        public OperacionClienteJIM Insertar(OperacionClienteJIM nuevoDetalle)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.OperacionClientesJIM.Add(nuevoDetalle);
                    context.SaveChanges();
                    return nuevoDetalle;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el nuevo detalle de operacion", ex);
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
