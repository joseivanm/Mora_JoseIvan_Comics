using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComicWPF.Models;
using Entidades;
using Ventas;


namespace ComicWPF.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    List<Empleado> empleados = ventasADO.ListarEmpleados();
                    string hashedPassword = GetMd5Hash(credential.Password);

                    foreach (Empleado empleado in empleados)
                    {
                        if (empleado.Nif == credential.UserName && empleado.Password == hashedPassword)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                  
                    throw new Exception($"Error during authentication: {ex.Message}");
                }
            }
            return false; 
        }


        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    List<Empleado> empleados = ventasADO.ListarEmpleados();

                    Empleado empleado = empleados.FirstOrDefault(e => e.Nif == username);

                    if (empleado != null)
                    {
                        return new UserModel
                        {
                            Username = empleado.Nif,
                            Id = empleado.EmpleadoId.ToString(),
                            Password = empleado.Password,
                            Name = empleado.Nombre,
                            LastName = empleado.Apellido 
                        };
                    }
                    return null; 
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener el usuario: {ex.Message}");
                }
            }
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        private string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }


}
