using ComicWPF.Models;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ventas;

namespace ComicWPF.Repositories
{
    public class StockComicRepository : RepositoryBase, IStockComicRepository
    {
        public StockComic ListarComicsEditorialyLocal( Comic comic)
        {
            using (VentasADO ventasADO = new VentasADO())
            {

                    // Obtener el stock para el cómic actual
                    var stockComic = ventasADO.ListarPorComicId(comic);
                return stockComic;

            }


        }

        public object ListarPorComicId(ComicModel comicSelected)
        {
            throw new NotImplementedException();
        }
    }
}

