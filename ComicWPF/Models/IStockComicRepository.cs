using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public interface IStockComicRepository
    {
        object ListarPorComicId(ComicModel comicSelected);
    }
}
