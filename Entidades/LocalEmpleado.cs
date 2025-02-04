using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    //<author>Jose Ivan Mora Gonzaga</author>
    public class LocalEmpleado
    {
        [Key, Column(Order = 1)]
        public int EmpleadoId { get; set; }
        public virtual Empleado Empleado { get; set; }

        [Key, Column(Order = 2)]
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }
    }
}
