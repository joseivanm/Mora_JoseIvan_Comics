using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Detalle_Operacion")]
public partial class DetalleOperacion
{
    [Key]
    [Column("Detalle_OperacionID")]
    public int DetalleOperacionId { get; set; }

    [Column("OperacionID")]
    public int OperacionId { get; set; }

    [Column("ComicID")]
    public int ComicId { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }

    [Column(TypeName = "decimal(7, 4)")]
    public decimal? Descuento { get; set; }

    [ForeignKey("ComicId")]
    [InverseProperty("DetalleOperacions")]
    public virtual Comic Comic { get; set; } = null!;

    [ForeignKey("OperacionId")]
    [InverseProperty("DetalleOperacions")]
    public virtual Operacion Operacion { get; set; } = null!;
}
