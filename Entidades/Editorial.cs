using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Editorial")]
public partial class Editorial
{
    [Key]
    [Column("EditorialID")]
    public int EditorialId { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [InverseProperty("Editorial")]
    public virtual ICollection<Comic> Comics { get; set; } = new List<Comic>();
}
