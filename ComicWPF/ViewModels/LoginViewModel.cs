using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ComicWPF.Repositories;
using Ventas;
using ComicADO;
using Entidades;
using ComicWPF.ViewModels;
using System.Windows;

namespace ComicWPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        // Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // Properties
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public SecureString Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }

        // Constructor
        public LoginViewModel()
        {
            // Initialize the commands
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = !string.IsNullOrWhiteSpace(Username) && Username.Length >= 3 &&
                             Password != null && Password.Length >= 3;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            string passwordIngresada = ConvertSecureStringToString(Password);
            string hashedPassword = GetMd5Hash(passwordIngresada); 

            using (VentasADO ventasADO = new VentasADO())
            {
                try
                {
                    List<Empleado> empleados = ventasADO.ListarEmpleados();

                    if (empleados == null || empleados.Count == 0)
                    {
                        ErrorMessage = "No empleados disponibles";
                        return;
                    }


                    bool loginExitoso = false;

                    foreach (Empleado empleado in empleados)
                    {
    
                        if (empleado.Nif == Username && empleado.Password == hashedPassword)
                        {
                            loginExitoso = true;
                            break;
                        }
                    }


                    if (loginExitoso)
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                        IsViewVisible = false; 
                    }
                    else
                    {
                        ErrorMessage = "* Invalid username or password";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Error during login: {ex.Message}";
                }
            }
        }
    
        

        // Convert SecureString to string
        private string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeBSTR(ptr);
                }
            }
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

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            // Implement password recovery logic here
            throw new NotImplementedException();
        }
    }
}
