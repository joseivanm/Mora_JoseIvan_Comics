using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace ComicADO
{
    //<author>Jose Iván Mora Gonzaga</author>

    public class AutorADO : IDisposable
    {
        
        bool disposed;

        

        public AutorADO()
        {
            disposed = false;
        }

       
        public IList<Autor> Listar()
        {
            using (var context = new ComicsContext())  
            {
                try
                {
                    var data = context.Autors.ToList();  
                    return data;
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error al obtener la lista de autores", ex);
                }
            }
        }


       
        public Autor Listar(string ID)
        {
            using (var context = new ComicsContext())  
            {
                try
                {
                    if (int.TryParse(ID, out int autorId))  
                    {
                        var autor = context.Autors.FirstOrDefault(a => a.AutorId == autorId);  
                        return autor;
                    }
                    else
                    {
                        throw new ArgumentException("El ID proporcionado no es válido.");
                    }
                }
                catch (Exception ex)
                {
                 
                    throw new Exception("Error al buscar el autor con el ID proporcionado", ex);
                }
            }
        }

       

        public Autor Insertar(Autor nuevoAutor)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    context.Autors.Add(nuevoAutor);  
                    context.SaveChanges();  
                    return nuevoAutor;  
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error al insertar el nuevo autor", ex);
                }
            }
        }

       
        public void Actualizar(Autor autor)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var autorExistente = context.Autors.FirstOrDefault(a => a.AutorId == autor.AutorId);  
                    if (autorExistente != null)
                    {
                        autorExistente.Nombre = autor.Nombre;
                        autorExistente.Apellido = autor.Apellido;
                        autorExistente.Pais = autor.Pais;

                        context.SaveChanges();  
                    }
                    else
                    {
                        throw new Exception("El autor no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error al actualizar los datos del autor", ex);
                }
            }
        }

 
        public void Borrar(Autor autor)
        {
            using (var context = new ComicsContext())
            {
                try
                {
                    var autorExistente = context.Autors.FirstOrDefault(a => a.AutorId == autor.AutorId);  
                    if (autorExistente != null)
                    {
                        
                        context.Autors.Remove(autorExistente);

                        context.SaveChanges();  
                    }
                    else
                    {
                        throw new Exception("El autor no existe en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error al actualizar los datos del autor", ex);
                }
            }
        }

    

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


     
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                
            }

            disposed = true;
        }


    }
}
