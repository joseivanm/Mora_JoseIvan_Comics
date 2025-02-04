using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;
//<author>Jose Ivan Mora Gonzaga</author>

[Table("Operacion")]
public partial class Operacion
{
    [Key]
    [Column("OperacionID")]
    public int OperacionId { get; set; }

    [Column("Medio_De_PagoID")]
    public int MedioDePagoId { get; set; }

    [Column("Tipo_OperacionID")]
    public int TipoOperacionId { get; set; }

    [Column("ComicID")]
    public int ComicId { get; set; }

    [Column("LocalID")]
    public int LocalId { get; set; }

    [Column("Fecha_Operacion", TypeName = "datetime")]
    public DateTime FechaOperacion { get; set; }

    [Column("EmpleadoID")]
    public int EmpleadoId { get; set; }

    [ForeignKey("ComicId")]
    [InverseProperty("Operacions")]
    public virtual Comic Comic { get; set; } = null!;

    [InverseProperty("Operacion")]
    public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; } = new List<DetalleOperacion>();

    [ForeignKey("EmpleadoId")]
    [InverseProperty("Operacions")]
    public virtual Empleado Empleado { get; set; } = null!;

    [ForeignKey("LocalId")]
    [InverseProperty("Operacions")]
    public virtual Local Local { get; set; } = null!;

    [ForeignKey("MedioDePagoId")]
    [InverseProperty("Operacions")]
    public virtual MedioDePago MedioDePago { get; set; } = null!;

    [ForeignKey("TipoOperacionId")]
    [InverseProperty("Operacions")]
    public virtual TipoOperacion TipoOperacion { get; set; } = null!;


}
