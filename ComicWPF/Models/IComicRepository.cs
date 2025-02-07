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

    
        Task<List<ComicPageModel>> BuscarComics(string searchTerm);

    
        Task<bool> InsertarComic(ComicModel comicViewModel);

        Task<bool> ModificarComic(ComicModel comicViewModel);

 
        Task<bool> EliminarComic(int comicId);

 
        Task<List<ComicPageModel>> CargarComics();
        List<Comic> ListarComicsEditorialyLocal(int editorialId, int localId);
        Comic obtenerComic(int comicId);
        void EditarStockComic(int editorial, int local, int metodoPago, int clienteId, int comicId, int empleadoId, int precioCompra, int cantidad, bool rbCliente);
        void EditarComic(int comicId, string nombreComic, int editorialId, int autor);
    }
}
