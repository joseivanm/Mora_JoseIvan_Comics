using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public class ClienteJimModel
    {

        public int ClienteID { get; set; }

       public string Nombre { get; set; }

        public string Apellido { get; set; }


        public string Direccion { get; set; }


        public int Telefono { get; set; }


        public string Email { get; set; }


        public DateTime? FechaRegistro { get; set; }


        public string Nif { get; set; }


        public string Activo { get; set; }

        public string NombreConNif
        {
            get { return $"{Nombre} ({Nif})"; }
        }
    }
}
