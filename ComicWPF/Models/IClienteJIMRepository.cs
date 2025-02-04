using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public interface IClienteJIMRepository
    {
        List<ClienteJIM> ListarClientes();
        List<Editorial> ObtenerEditorialesPorEmpleado(int empleadoId);
    }
}
