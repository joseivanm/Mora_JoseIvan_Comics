using ComicADO;
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
    public class AutorRepository : IAutorRepository
    {
        public List<Autor> ObtenerAutores()
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                List<Autor> autores = ventasADO.ListarAutores();



                return autores;
            }
        }

    }
}
