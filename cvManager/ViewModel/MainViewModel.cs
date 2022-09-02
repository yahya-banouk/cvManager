using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using cvManager.Model;
using cvManager.Repositories;
using FontAwesome.Sharp;

namespace cvManager.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        //Fields
        private UserAccountModel _currentuserAccount;

        //this is for childs views 
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        //

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

        //this is for childs views
        public ViewModelBase CurrentChildView 
        { 
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));    
            }


        }




        public string Caption 
        { 
            get
            {
                return _caption;
            }
             
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
             
        
        
        }
        public IconChar Icon 
        { 
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }  
        }


        //////////
        /// <summary>
        /// 
        /// 
        /// 
        /// </summary>
        /// 
        // here will define the commands  for user interaction 
        // a command to show the HomeView a command to show the CondidateView

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCondidateViewCommand { get; }
        //now it's time to initialize these commands in the constructor using the ViewModelCommand class 



        public MainViewModel()
        {
            userRepository = new UserRepository();
            //here it comes 
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCondidateViewCommand = new ViewModelCommand(ExecuteShowCondidateViewCommand);


            //Default View
            ExecuteShowHomeViewCommand(null);
            //
            LoadCurrentUserData();
        }

        private void ExecuteShowCondidateViewCommand(object obj)
        {
            CurrentChildView = new CondidateViewModel();
            Caption = "Condidat";
            Icon = IconChar.UserGroup;

        }

        // we do the same for the HomeView and any other child views i have
        // 
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Accueil";
            Icon = IconChar.Home;
            //this is the home view child that should be desplayed by default 
            // so muste make it by initialize the CurrentChildView in the constructor
            // by HomeView after that web bind this properties
            // to the maind view properties
            // also bind the commands to the
            // navigation menu button commands 
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {

                CurrentUserAccount = new UserAccountModel()
                {
                    Username = user.Username,
                    DisplayName = $"{user.Name} {user.LastName}",
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
