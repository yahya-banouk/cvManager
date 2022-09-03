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

        private string _name;
        private string _lastName;
        private int _age;
        private string _email;
        private string _level;
        private int _experience;
        private string _profession;
        private ObservableCollection<CondidatModel> _CondidateRecords;
        private ICondidatRepository _CondidatRepository;

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






        private ICommand _saveCommand;
        private ICommand _resetCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        




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

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new ViewModelCommand(param => EditData((int)param), null);

                return _editCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new ViewModelCommand(param => DeleteStudent((int)param), null);

                return _deleteCommand;
            }
        }

        public CondidateViewModel()
        {
            //_studentEntity = new Student();
            //_repository = new StudentRepository();
            //StudentRecord = new StudentRecord();
            _CondidatRepository = new CondidateRepository();
            GetAll();
        }

        public void ResetData()
        {
            

            _name = string.Empty;
            _lastName = string.Empty;
            _age = 0;
            _email= string.Empty;
            _level = string.Empty;
            _experience = 0;
            _profession = string.Empty;
        }

        public void DeleteStudent(int id)
        {
            if (MessageBox.Show("Confirm delete of this record?", "Student", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    _CondidatRepository.Remove(id);
                    MessageBox.Show("Record successfully deleted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    GetAll();
                }
            }
        }

        public void SaveData()
        {
            /*if (StudentRecord != null)
            {
                _studentEntity.Name = StudentRecord.Name;
                _studentEntity.Age = StudentRecord.Age;
                _studentEntity.Address = StudentRecord.Address;
                _studentEntity.Contact = StudentRecord.Contact;

                try
                {
                    if (StudentRecord.Id <= 0)
                    {
                        _repository.AddStudent(_studentEntity);
                        MessageBox.Show("New record successfully saved.");
                    }
                    else
                    {
                        _studentEntity.ID = StudentRecord.Id;
                        _repository.UpdateStudent(_studentEntity);
                        MessageBox.Show("Record successfully updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while saving. " + ex.InnerException);
                }
                finally
                {
                    GetAll();
                    ResetData();
                }
            }*/
        }

        public void EditData(int id)
        {
            /*var model = _repository.Get(id);
            StudentRecord.Id = model.ID;
            StudentRecord.Name = model.Name;
            StudentRecord.Age = (int)model.Age;
            StudentRecord.Address = model.Address;
            StudentRecord.Contact = model.Contact;*/
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
                Profession = data.Profession
                 
            }));
        }





    }
}
