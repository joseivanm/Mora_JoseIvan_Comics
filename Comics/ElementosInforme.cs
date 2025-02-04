using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportViewer_NET50_
{
	public class ElementosInforme
	{
        //<author>Jose Ivan Mora Gonzaga</author>
        public int DetalleOperacionId { get; set; }   
        public int OperacionId { get; set; }          
        public int ComicId { get; set; }            
        public int? Cantidad { get; set; }            
        public decimal? Precio { get; set; }          
        public decimal? Descuento { get; set; }        
        public decimal Total => (Precio ?? 0) * (Cantidad ?? 0);

        public decimal totalOperacion { get; set; }

        public required string nombreComic { get; set; }

        public int TiendaId { get; set; }

        public string nombreTienda { get; set; }

        public DateTime fechaOperacion  { get; set; }

        public string nombreEmpleado { get; set; }

        public string nombrePago { get; set; }

        public decimal PrecioBruto => (Precio ?? 0) * (Cantidad ?? 0);

        public decimal Iva => PrecioBruto * 0.21m;
        public decimal PrecioTotal { get; set; }



    }
}
