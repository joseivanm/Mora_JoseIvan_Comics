using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Comic")]
public partial class Comic
{
    [Key]
    [Column("ComicID")]
    public int ComicId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("AutorID")]
    public int? AutorId { get; set; }

    [Column("EditorialID")]
    public int? EditorialId { get; set; }

    [Column("Precio_Compra", TypeName = "decimal(10, 2)")]
    public decimal? PrecioCompra { get; set; }

    [Column("Precio_Venta", TypeName = "decimal(10, 2)")]
    public decimal? PrecioVenta { get; set; }

    [ForeignKey("AutorId")]
    [InverseProperty("Comics")]
    public virtual Autor? Autor { get; set; }

    [InverseProperty("Comic")]
    public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; } = new List<DetalleOperacion>();

    [ForeignKey("EditorialId")]
    [InverseProperty("Comics")]
    public virtual Editorial? Editorial { get; set; }

    [InverseProperty("Comic")]
    public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();

    [InverseProperty("Comic")]
    public virtual ICollection<StockComic> StockComics { get; set; } = new List<StockComic>();

    public static explicit operator List<object>(Comic v)
    {
        throw new NotImplementedException();
    }
}
