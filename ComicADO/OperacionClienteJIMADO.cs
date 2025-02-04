using Entidades;
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

        public OperacionClienteJIMADO()
        {
            disposed = false;
        }

        // Metodo para insertar un nuevo detalle de operacion en la base de datos
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
