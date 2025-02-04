using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Medio_De_Pago")]
public partial class MedioDePago
{
    [Key]
    [Column("Medio_De_PagoID")]
    public int MedioDePagoId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("Nombre_Corto")]
    [StringLength(25)]
    [Unicode(false)]
    public string? NombreCorto { get; set; }

    [InverseProperty("MedioDePago")]
    public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();
}
