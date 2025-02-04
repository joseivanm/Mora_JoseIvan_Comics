using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Autor")]
public partial class Autor
{
    [Key]
    [Column("AutorID")]
    public int AutorId { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Apellido { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Pais { get; set; }

    [InverseProperty("Autor")]
    public virtual ICollection<Comic> Comics { get; set; } = new List<Comic>();
}
