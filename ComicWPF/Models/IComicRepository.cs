using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicWPF.ViewModels;
using Entidades;

namespace ComicWPF.Models
{
    public interface IComicRepository
    {
        Task<List<ComicPageModel>> CargarComicsConDetalles();

        // Buscar cómics por nombre, autor o editorial
        Task<List<ComicPageModel>> BuscarComics(string searchTerm);

        // Insertar un nuevo cómic
        Task<bool> InsertarComic(ComicModel comicViewModel);

        // Modificar un cómic existente
        Task<bool> ModificarComic(ComicModel comicViewModel);

        // Eliminar un cómic por su ID
        Task<bool> EliminarComic(int comicId);

        // Cargar todos los cómics sin detalles
        Task<List<ComicPageModel>> CargarComics();
        List<Comic> ListarComicsEditorialyLocal(int editorialId, int localId);
    }
}
