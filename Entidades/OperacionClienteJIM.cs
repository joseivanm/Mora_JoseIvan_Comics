using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Operacion_ClienteJIM")]
    public partial class OperacionClienteJIM
    {
        /*[Key, Column(Order = 1)]
        public int OperacionId { get; set; }
        public virtual Operacion Operacion { get; set; }

        [Key, Column(Order = 2)]
        public int ClienteID { get; set; }
        public virtual ClienteJIM Cliente { get; set; }*/

        [Key, Column(Order = 0)] // Parte de la clave compuesta
        public int OperacionId { get; set; }

        [Key, Column(Order = 1)] // Parte de la clave compuesta
        public int ClienteId { get; set; }

        // Propiedades de navegación
        public virtual Operacion Operacion { get; set; }
        public virtual ClienteJIM Cliente { get; set; }
    }
}
