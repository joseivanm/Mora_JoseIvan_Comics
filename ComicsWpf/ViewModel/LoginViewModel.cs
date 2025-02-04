using LoginComicsWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginComicsWpf.Repositories;
using System.Security.Principal;

namespace LoginComicsWpf.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private string _userName;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;
        public string UserName {
            get => _userName;
            set {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public SecureString Password {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage 
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible 
        { 
            get => _isViewVisible;
            set {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommand { get;}
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("",""));
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else validData = true;
            return validData;
        }
        
        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(UserName, Password));
            if(isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(UserName), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalidad username or password";
            }
        }
    }
}
