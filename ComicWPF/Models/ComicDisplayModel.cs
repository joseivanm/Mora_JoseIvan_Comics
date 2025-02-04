using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public class ComicDisplayModel
    {
        public int ComicId { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public decimal PrecioVenta { get; set; }
    }

}
