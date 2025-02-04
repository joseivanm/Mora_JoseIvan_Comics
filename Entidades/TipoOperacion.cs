using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Tipo_Operacion")]
public partial class TipoOperacion
{
    [Key]
    [Column("Tipo_OperacionID")]
    public int TipoOperacionId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("TipoOperacion")]
    public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();
}
