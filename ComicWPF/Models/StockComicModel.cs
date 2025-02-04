using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public class StockComicModel
    {
        public int StockComicId { get; set; }

        public int ComicId { get; set; }

        public int LocalId { get; set; }

        public int? Cantidad { get; set; }
        public virtual Comic Comic { get; set; } = null!;
        public virtual Local Local { get; set; } = null!;
    }
}
