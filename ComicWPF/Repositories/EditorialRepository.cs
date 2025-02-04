using Entidades;
using Ventas;
using System;
using System.Collections.Generic;
using ComicWPF.Models;

namespace ComicWPF.Repositories
{
    public class EditorialRepository : IEditorialRepository
    {
        public List<Editorial> ObtenerEditoriales()
        {
            throw new NotImplementedException();
        }

        public List<Editorial> ObtenerEditorialesPorEmpleado(int empleadoId)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                LocalEmpleado localEmpleado = ventasADO.LocalEmpleado(Convert.ToString(empleadoId));

                Local nombreLocal = ventasADO.ObtenerLocalPorId(Convert.ToString(localEmpleado.LocalId));

                var editorialesDeTienda = ventasADO.ListarEditorialesPorTienda(nombreLocal.LocalId);

                return editorialesDeTienda;
            }
        }
    }
}
