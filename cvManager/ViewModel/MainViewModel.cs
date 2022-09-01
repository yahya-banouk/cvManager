using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using cvManager.Model;
using cvManager.Repositories;


namespace cvManager.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        //Fields
        private UserAccountModel _currentuserAccount;
        private IUserRepository userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get 
            { 
                return _currentuserAccount;
            }
            set 
            { 
                _currentuserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {

                CurrentUserAccount = new UserAccountModel()
                {
                    Username = user.Username,
                    DisplayName = $"BienVenue {user.Name} {user.LastName} ;)",
                    ProfilePicture = null
                };
                

                
            }
            else
            {
                MessageBox.Show("Utilisateur Invalide ,vous n'etes pas authentifier");
                Application.Current.Shutdown();

            }
        }
    }
}
