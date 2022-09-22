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
        //private string _driver;

        //fields tha that handls multiDriver licences  "AM","A1","A","B","EB","C", "EC" ,"D" ,"ED"
        private bool _am_Checked ;
        private bool _a1_Checked ;
        private bool _a_Checked ;
        private bool _b_Checked ;
        private bool _eb_Checked ;
        private bool _c_Checked;
        private bool _ec_Checked ;
        private bool _d_Checked ;
        private bool _ed_Checked;

        private string _driverGeneratedString = "";


        private ICondidatRepository _CondidatRepository;
        private CondidatModel _condidatModel = null;
        
        
        private ObservableCollection<string> _levels;
        private ObservableCollection<string> _sexes;
        //private ObservableCollection<string> _drivers;


        public ObservableCollection<string> Sexes { get => _sexes; set => _sexes = value; }
        //public ObservableCollection<string> Drivers { get => _drivers; set => _drivers = value; }
        public ObservableCollection<string> Levels { get => _levels; set => _levels = value; }


        public bool AM_Checked
        {
            get
            {
                return _am_Checked;
            }
            set
            {
                _am_Checked = value;
                OnPropertyChanged(nameof(AM_Checked));
                
            }
        }
        public bool A1_Checked
        {
            get
            {
                return _a1_Checked;
            }
            set
            {
                _a1_Checked = value;
                OnPropertyChanged(nameof(A1_Checked));
            }
        }
        public bool A_Checked
        {
            get
            {
                return _a_Checked;
            }
            set
            {
                _a_Checked = value;
                OnPropertyChanged(nameof(A_Checked));
            }
        }
        public bool B_Checked
        {
            get
            {
                return _b_Checked;
            }
            set
            {
                _b_Checked = value;
                OnPropertyChanged(nameof(B_Checked));
            }
        }
        public bool EB_Checked
        {
            get
            {
                return _eb_Checked;
            }
            set
            {
                _eb_Checked = value;
                OnPropertyChanged(nameof(EB_Checked));
            }
        }
        public bool C_Checked
        {
            get
            {
                return _c_Checked;
            }
            set
            {
                _c_Checked = value;
                OnPropertyChanged(nameof(C_Checked));
            }
        }
        public bool EC_Checked
        {
            get
            {
                return _ec_Checked;
            }
            set
            {
                _ec_Checked = value;
                OnPropertyChanged(nameof(EC_Checked));
            }
        }
        public bool D_Checked
        {
            get
            {
                return _d_Checked;
            }
            set
            {
                _d_Checked = value;
                OnPropertyChanged(nameof(D_Checked));
            }
        }
        public bool ED_Checked
        {
            get
            {
                return _ed_Checked;
            }
            set
            {
                _ed_Checked = value;
                OnPropertyChanged(nameof(ED_Checked));
            }
        }


        public string DriverGeneratedString
        {
            get
            {
                return _driverGeneratedString;
            }

            set

            {
                _driverGeneratedString = value;
                OnPropertyChanged(nameof(DriverGeneratedString));
            }
        }
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
        /*public string Driver
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

        }*/
        

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
            //Drivers = new ObservableCollection<string>()
            //{
            //  "","AM","A1","A","B","EB","C", "EC" ,"D" ,"ED"
           //};
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
            //Driver = string.Empty;
            AM_Checked = false;
            A1_Checked = false;
            A_Checked = false;
            B_Checked = false;
            EB_Checked = false;
            C_Checked = false;
            EC_Checked = false;
            D_Checked = false;
            ED_Checked = false; 


        }

        

        public void SaveData()
        {
            DriverGeneratedString += (AM_Checked == true) ? "AM" : "" ;
            DriverGeneratedString += (A1_Checked == true) ? " A1" : "" ;
            DriverGeneratedString += (A_Checked == true) ? " A" : "" ;
            DriverGeneratedString += (B_Checked == true) ? " B" : "" ;
            DriverGeneratedString += (EB_Checked == true) ? " EB" : "" ;
            DriverGeneratedString += (C_Checked == true) ? " C" : "" ;
            DriverGeneratedString += (EC_Checked == true) ? " EC" : "" ;
            DriverGeneratedString += (D_Checked == true) ? " D" : "" ;
            DriverGeneratedString += (ED_Checked == true) ? " ED" : "" ;

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
                _condidatModel.Driver = DriverGeneratedString;




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
