using cvManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using cvManager.Repositories;
using System.Net;

namespace cvManager.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        //Properties
        public string Username 
        { 
            get => _username;

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
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

            set
            { 
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            } 
        }


        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
       


        //Constructors
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("",""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length<3 || Password == null || Password.Length<3  )
                validData = false;
            else validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            //i was here 
            var isValidUser = userRepository.AuthenticationUser(new NetworkCredential(Username, Password));
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

    }
}
