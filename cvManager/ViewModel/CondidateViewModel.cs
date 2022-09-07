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
        private string _driver;
        private ObservableCollection<CondidatModel> _CondidateRecords;
        private ICondidatRepository _CondidatRepository;
        private CondidatModel _condidatModel=null;

        private ObservableCollection<string> _levels;
        private ObservableCollection<string> _sexes;
        private ObservableCollection<string> _drivers;
        public ObservableCollection<string> Sexes { get => _sexes; set => _sexes = value; }
        public ObservableCollection<string> Drivers { get => _drivers; set => _drivers = value; }
        public ObservableCollection<string> Levels { get => _levels; set => _levels = value; }

        private string _searchString;



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
                Profession = data.Profession

            }));
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
                "3eme College","1er Lycée","1er Bac" , "2eme bac", "bac+1", "bac+2", "bac+3", "bac+4" ,  "bac+5",  "bac+6",  "bac+7",  "bac+8",  "bac+9"
            };
            Sexes = new ObservableCollection<string>()
            {
                "Homme","Femme"
            };
            Drivers = new ObservableCollection<string>()
            {
                "AM","A1","A","B","EB","C", "EC" ,"D" ,"ED"
            };
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
            Driver = string.Empty;
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

        public void UpdateData()
        {
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
                _condidatModel.Driver = Driver;




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
            Driver = model[0].Driver;
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
