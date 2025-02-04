using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
//<author>Jose Ivan Mora Gonzaga</author>
{
    [Table("Empleado")]
    public partial class Empleado
    {
        [Key]
        [Column("EmpleadoID")]
        public int EmpleadoId { get; set; }
        [StringLength(60)]
        [Unicode(false)]
        public string? Nombre { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? Apellido { get; set; }

        [Column("NIF")]
        [StringLength(10)]
        [Unicode(false)]
        public string Nif { get; set; } = null!;

        [StringLength(255)]
        [Unicode(false)]
        public string? Direccion { get; set; }

        [StringLength(64)]
        [Unicode(false)]
        public string? Password { get; set; }

        [StringLength(60)]
        [Unicode(false)]
        public string? Email { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        public string? Activo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_alta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_baja { get; set; }

        [Column(TypeName = "image")]
        public byte[]? Fotografia { get; set; }

        [InverseProperty("Empleado")]
        public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();

        [ForeignKey("EmpleadoId")]
        [InverseProperty("Empleados")]
        public virtual ICollection<Local> Locals { get; set; } = new List<Local>();


        [InverseProperty("Empleado")]
        public virtual ICollection<LocalEmpleado> LocalEmpleados { get; set; } = new List<LocalEmpleado>();
    }
}
