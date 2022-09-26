using CrystalDecisions.Web;
using cvManager.Model;
using cvManager.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace cvManager.ViewModel
{
    public class CondidateViewModel: ViewModelBase
    {

        private int _id;
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
        private bool _am_Checked;
        private bool _a1_Checked;
        private bool _a_Checked;
        private bool _b_Checked;
        private bool _eb_Checked;
        private bool _c_Checked;
        private bool _ec_Checked;
        private bool _d_Checked;
        private bool _ed_Checked;

        private string _driverGeneratedString = "";


        private ObservableCollection<CondidatModel> _CondidateRecords;
        private ICondidatRepository _CondidatRepository;
        private CondidatModel _condidatModel=null;

        private ObservableCollection<string> _levels;
        private ObservableCollection<string> _sexes;
        //private ObservableCollection<string> _drivers;
        public ObservableCollection<string> Sexes { get => _sexes; set => _sexes = value; }
        //public ObservableCollection<string> Drivers { get => _drivers; set => _drivers = value; }
        public ObservableCollection<string> Levels { get => _levels; set => _levels = value; }

        private string _searchString;

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
        public int Id
        {
            get
            {
                return _id;
            }

            set

            {
                _id = value;
                OnPropertyChanged(nameof(Id));
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
        public ObservableCollection<CondidatModel> CondidateRecords 
        { 
            get
            {
                return  _CondidateRecords;
            }
            set
            {
                _CondidateRecords = value;
                OnPropertyChanged(nameof(CondidateRecords));
            }
        }

        public string SearchString 
        {
            get
            {
                return _searchString;
            }
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }







        private ICommand _updateCommand;
        private ICommand _resetCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ICommand _searchCommand;
        



        

        

        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new ViewModelCommand(param => ResetData(), null);

                return _resetCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                    _updateCommand = new ViewModelCommand(param => UpdateData(), null);

                return _updateCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new ViewModelCommand(param => EditData((int)System.Convert.ToInt32(param)), null);

                return _editCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new ViewModelCommand(param => DeleteCondidate((int)System.Convert.ToInt32(param)), null);

                return _deleteCommand;
            }
        }


        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new ViewModelCommand(param => SearchCondidate(), null);

                return _searchCommand;
            }
        }

        private void SearchCondidate()
        {
            CondidateRecords = new ObservableCollection<CondidatModel>();
            _CondidatRepository.GetByWhatever(SearchString).ForEach(data => CondidateRecords.Add(new CondidatModel()
            {
                Id = data.Id,
                Name = data.Name,
                LastName = data.LastName,
                Age = Convert.ToInt32(data.Age),
                Email = data.Email,
                Level = data.Level,
                Experience = data.Experience,
                Profession = data.Profession,
                Sexe = data.Sexe,
                City = data.City,

                Driver = data.Driver

            })) ;
            if (CondidateRecords.Count == 0)
            {
                
                GetAll();
            }
        }

        public CondidateViewModel()
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
            /*Drivers = new ObservableCollection<string>()
            {
                "","AM","A1","A","B","EB","C", "EC" ,"D" ,"ED"
            };*/
            _condidatModel = new CondidatModel();
            _CondidatRepository = new CondidateRepository();
            GetAll();
        }

        public void ResetData()
        {
            

            Name = string.Empty;
            LastName = string.Empty;
            Age = 0;
            Email= string.Empty;
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

        public void DeleteCondidate(int id)
        {
            if (MessageBox.Show("Confirm delete of this record?", "Condidate", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    _CondidatRepository.Remove(id);
                    MessageBox.Show("Record successfully deleted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while deleting. " + ex.InnerException);
                }
                finally
                {
                    GetAll();
                }
            }
        }
        public void ReadDrivers(string driver)
        {
            char[] c = new char[driver.Length];
            using(StringReader sr = new StringReader(driver) )
            { 
                if(driver.Length > 0)
                {
                    sr.Read(c, 0, driver.Length - 1);
                    for (int i = 0; i < driver.Length; i++)
                    {

                        Console.WriteLine(c[i]);
                        //if (c[i].Equals(" "))
                          //  continue;
                        AM_Checked = (c[i].Equals("A") && c[i + 1].Equals("M")) ? true : false;
                        A1_Checked = (c[i].Equals("A") && c[i + 1].Equals("1")) ? true : false;
                        A_Checked = (c[i].Equals("A") && c[i + 1].Equals(" ")) ? true : false;
                        B_Checked = (c[i].Equals("B") && c[i + 1].Equals(" ") && c[i - 1].Equals(" ")) ? true : false;
                        EB_Checked = (c[i].Equals("E") && c[i + 1].Equals("B")) ? true : false;
                        C_Checked = (c[i].Equals("C") && c[i + 1].Equals(" ") && c[i - 1].Equals(" ")) ? true : false;
                        EC_Checked = (c[i].Equals("E") && c[i + 1].Equals("C")) ? true : false;
                        D_Checked = (c[i].Equals("D") && c[i + 1].Equals(" ") && c[i - 1].Equals("")) ? true : false;



                    }
                }

            }
        }
        public void UpdateData()
        {
            DriverGeneratedString = "";
            DriverGeneratedString += (AM_Checked == true) ? "AM" : "";
            DriverGeneratedString += (A1_Checked == true) ? " A1" : "";
            DriverGeneratedString += (A_Checked == true) ? " A" : "";
            DriverGeneratedString += (B_Checked == true) ? " B" : "";
            DriverGeneratedString += (EB_Checked == true) ? " EB" : "";
            DriverGeneratedString += (C_Checked == true) ? " C" : "";
            DriverGeneratedString += (EC_Checked == true) ? " EC" : "";
            DriverGeneratedString += (D_Checked == true) ? " D" : "";
            DriverGeneratedString += (ED_Checked == true) ? " ED" : "";
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(LastName)   && !String.IsNullOrEmpty(Level) && !String.IsNullOrEmpty(Profession))
            {
                _condidatModel.Id = Id;
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
                    _CondidatRepository.Edit(_condidatModel);
                    MessageBox.Show("la mise à jour est effectuer avec succée ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    GetAll();
                    Id = 0;
                    ResetData();
                }
            }
        }

        public void EditData(int id)
        {
            
            var model = _CondidatRepository.GetById(id);
            Id = (int)Convert.ToInt32(model[0].Id);
            Name = model[0].Name;
            LastName = model[0].LastName;
            Age = (int)Convert.ToInt32(model[0].Age);
            Email = model[0].Email;
            Level = model[0].Level;
            Experience = model[0].Experience;
            Profession = model[0].Profession;
            Sexe = model[0].Sexe;
            City = model[0].City;
            //DriverGeneratedString = model[0].Driver;
            ReadDrivers(model[0].Driver);
        }

        public void GetAll()
        {
           CondidateRecords = new ObservableCollection<CondidatModel>();
            _CondidatRepository.GetAll().ForEach(data => CondidateRecords.Add(new CondidatModel()
            {
                Id = data.Id,
                Name = data.Name,
                LastName = data.LastName,
                Age = Convert.ToInt32(data.Age),
                Email = data.Email,
                Level = data.Level,
                Experience = data.Experience,
                Profession = data.Profession,
                Sexe = data.Sexe,
                City = data.City,
                Driver = data.Driver

                
                 
            }));
        }





    }
}
