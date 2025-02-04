using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("Stock_Comic")]
public partial class StockComic
{
    [Key]
    [Column("Stock_ComicID")]
    public int StockComicId { get; set; }

    [Column("ComicID")]
    public int ComicId { get; set; }

    [Column("LocalID")]
    public int LocalId { get; set; }

    public int? Cantidad { get; set; }

    [ForeignKey("ComicId")]
    [InverseProperty("StockComics")]
    public virtual Comic Comic { get; set; } = null!;

    [ForeignKey("LocalId")]
    [InverseProperty("StockComics")]
    public virtual Local Local { get; set; } = null!;
}
