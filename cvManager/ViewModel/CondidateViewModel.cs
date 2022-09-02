using cvManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cvManager.ViewModel
{
    public class CondidateViewModel: ViewModelBase
    {

        private string _name;
        private string _lastName;
        private string _age;
        private string _email;
        private string _level;
        private string _experience;
        private string _profession;
        private ObservableCollection<CondidatModel> _CondidateRecords;

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


        public string Age 
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
        public string Experience
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


    }
}
