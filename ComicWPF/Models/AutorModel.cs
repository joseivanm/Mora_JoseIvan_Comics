using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicWPF.Models
{
    public class AutorModel
    { 
        public int AutorId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Pais { get; set; }

        public virtual ICollection<Comic> Comics { get; set; } = new List<Comic>();
    }


}
