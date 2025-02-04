using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Cliente_JIM")]
    public partial class ClienteJIM
    {
        [Key]
        [Column("ClienteId")]
        public int ClienteID { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Apellido { get; set; }

        [StringLength(255)]
        public string Direccion { get; set; }

        [StringLength(15)]
        public int Telefono { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column("FechaRegistro", TypeName = "datetime")]
        public DateTime? FechaRegistro { get; set; }

        [StringLength(9)]
        public string Nif { get; set; }

        [StringLength(1)]
        public string Activo { get; set; }

        public string NombreConNif
        {
            get { return $"{Nombre} ({Nif})"; }
        }



    }
}
