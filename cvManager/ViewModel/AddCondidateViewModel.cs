using cvManager.Model;
using cvManager.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace cvManager.ViewModel
{
    public class AddCondidateViewModel:ViewModelBase
    {
        private string _name;
        private string _lastName;
        private int _age;
        private string _email;
        private string _level;
        private int _experience;
        private string _profession;
        private string _sexe;
        private string _city;
        private string _driver;


        private ICondidatRepository _CondidatRepository;
        private CondidatModel _condidatModel = null;
        
        
        private ObservableCollection<string> _levels;
        private ObservableCollection<string> _sexes;
        private ObservableCollection<string> _drivers;


        public ObservableCollection<string> Sexes { get => _sexes; set => _sexes = value; }
        public ObservableCollection<string> Drivers { get => _drivers; set => _drivers = value; }
        public ObservableCollection<string> Levels { get => _levels; set => _levels = value; }

        public string Name
        {
            get
            {
                return _name;
            }

            set

            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set

            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public int Age
        {
            get
            {
                return _age;

            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Level
        {
            get
            {
                return _level;

            }

            set

            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;
                OnPropertyChanged(nameof(Experience));

            }
        }
        public string Profession
        {
            get
            {
                return _profession;
            }
            set
            {
                _profession = value;
                OnPropertyChanged(nameof(Profession));
            }
        }


        private ICommand _saveCommand;
        private ICommand _resetCommand;

        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new ViewModelCommand(param => ResetData(), null);

                return _resetCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new ViewModelCommand(param => SaveData(), null);

                return _saveCommand;
            }
        }


        public string Sexe
        {
            get
            {
                return _sexe;
            }


            set
            {
                _sexe = value;
                OnPropertyChanged(nameof(Sexe));

            }

        }
        public string City
        {
            get
            {
                return _city;
            }


            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));

            }

        }
        public string Driver
        {
            get
            {
                return _driver;
            }


            set
            {
                _driver = value;
                OnPropertyChanged(nameof(Driver));

            }

        }
        

        public AddCondidateViewModel()
        {
            //_studentEntity = new Student();
            //_repository = new StudentRepository();
            //StudentRecord = new StudentRecord();
            Levels = new ObservableCollection<string>()
            {
                "","3eme College","1er Lycée","1er Bac" , "2eme bac", "bac+1", "bac+2", "bac+3", "bac+4" ,  "bac+5",  "bac+6",  "bac+7",  "bac+8",  "bac+9"
            };
            Sexes = new ObservableCollection<string>()
            {
                "Homme","Femme"
            };
            Drivers = new ObservableCollection<string>()
            {
                "","AM","A1","A","B","EB","C", "EC" ,"D" ,"ED"
            };
            _condidatModel = new CondidatModel();
            _CondidatRepository = new CondidateRepository();
            
        }
        public void ResetData()
        {


            Name = string.Empty;
            LastName = string.Empty;
            Age = 0;
            Email = string.Empty;
            Level = string.Empty;
            Experience = 0;
            Profession = string.Empty;
            Sexe = string.Empty;    
            City = string.Empty;
            Driver = string.Empty;

        }

        

        public void SaveData()
        {
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(LastName) && !String.IsNullOrEmpty(Level) && !String.IsNullOrEmpty(Profession))
            {
                _condidatModel.Name = Name;
                _condidatModel.LastName = LastName;
                _condidatModel.Level = Level;
                _condidatModel.Profession = Profession;
                _condidatModel.Experience = Experience;
                _condidatModel.Age = Age;
                _condidatModel.Email = Email;
                _condidatModel.Sexe = Sexe;
                _condidatModel.City = City;
                _condidatModel.Driver = Driver;




                try
                {
                    _CondidatRepository.Add(_condidatModel);
                    MessageBox.Show("la conservation est effectuer avec succée ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    
                    ResetData();
                }
            }
        }
    }
}
