using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    /// <summary>
    /// Representa un empleado en la base de datos.
    /// </summary>
    /// <author>Jose Ivan Mora Gonzaga</author>
    [Table("Empleado")]
    public partial class Empleado
    {
        /// <summary>
        /// Identificador unico del empleado.
        /// </summary>
        [Key]
        [Column("EmpleadoID")]
        public int EmpleadoId { get; set; }

        /// <summary>
        /// Nombre del empleado.
        /// </summary>
        [StringLength(60)]
        [Unicode(false)]
        public string? Nombre { get; set; }

        /// <summary>
        /// Apellido del empleado.
        /// </summary>
        [StringLength(100)]
        [Unicode(false)]
        public string? Apellido { get; set; }

        /// <summary>
        /// Numero de Identificacion Fiscal (NIF) del empleado.
        /// </summary>
        [Column("NIF")]
        [StringLength(10)]
        [Unicode(false)]
        public string Nif { get; set; } = null!;

        /// <summary>
        /// Direccion del empleado.
        /// </summary>
        [StringLength(255)]
        [Unicode(false)]
        public string? Direccion { get; set; }

        /// <summary>
        /// Contrasena del empleado (almacenada de manera segura).
        /// </summary>
        [StringLength(64)]
        [Unicode(false)]
        public string? Password { get; set; }

        /// <summary>
        /// Correo electronico del empleado.
        /// </summary>
        [StringLength(60)]
        [Unicode(false)]
        public string? Email { get; set; }

        /// <summary>
        /// Indica si el empleado esta activo en la empresa ("S" para activo, "N" para inactivo).
        /// </summary>
        [StringLength(1)]
        [Unicode(false)]
        public string? Activo { get; set; }

        /// <summary>
        /// Fecha de alta en la empresa.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? Fecha_alta { get; set; }

        /// <summary>
        /// Fecha de baja del empleado en la empresa.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? Fecha_baja { get; set; }

        /// <summary>
        /// Fotografia del empleado almacenada en formato binario.
        /// </summary>
        [Column(TypeName = "image")]
        public byte[]? Fotografia { get; set; }

        /// <summary>
        /// Lista de operaciones realizadas por el empleado.
        /// </summary>
        [InverseProperty("Empleado")]
        public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();

        /// <summary>
        /// Lista de locales asociados al empleado.
        /// </summary>
        [ForeignKey("EmpleadoId")]
        [InverseProperty("Empleados")]
        public virtual ICollection<Local> Locals { get; set; } = new List<Local>();

        /// <summary>
        /// Lista de relaciones entre empleados y locales.
        /// </summary>
        [InverseProperty("Empleado")]
        public virtual ICollection<LocalEmpleado> LocalEmpleados { get; set; } = new List<LocalEmpleado>();
    }
}
