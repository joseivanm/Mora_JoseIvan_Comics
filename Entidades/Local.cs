using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Local")]
public partial class Local
{
    [Key]
    [Column("LocalID")]
    public int LocalId { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column(TypeName = "decimal(9, 6)")]
    public decimal Latitud { get; set; }

    [Column(TypeName = "decimal(9, 6)")]
    public decimal Longitud { get; set; }

    [InverseProperty("Local")]
    public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();

    [InverseProperty("Local")]
    public virtual ICollection<StockComic> StockComics { get; set; } = new List<StockComic>();

    [ForeignKey("LocalId")]
    [InverseProperty("Locals")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

}
