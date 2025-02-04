using System;
using System.Collections.Generic;

namespace ComicWPF.Models
{
    public class ComicModel
    {
        public int ComicId { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }

        public decimal StockTiendaActual { get; set; }

        public decimal StockOtrasTiendas {  get; set; }
    }

}
