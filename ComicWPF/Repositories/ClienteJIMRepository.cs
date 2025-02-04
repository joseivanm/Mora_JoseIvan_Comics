using ComicWPF.Models;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas;

namespace ComicWPF.Repositories
{
    public class ClienteJIMRepository : IClienteJIMRepository
    {
        public List<ClienteJIM> ListarClientes()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                return ventasADO.ListarClientes();
            }
        }

        public List<Editorial> ObtenerEditorialesPorEmpleado(int empleadoId)
        {
            throw new NotImplementedException();
        }
    }
}
