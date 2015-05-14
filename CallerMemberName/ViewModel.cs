using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace CallerMemberName
{
    public class ViewModel : ModelViewModelBase
    {
        private RelayCommand _ButtonPressedCommand;

        DataAccessLevel DataAccessLevel = new DataAccessLevel();

        private ObservableCollection<EmployeeModel> _Employees;
        public ObservableCollection<EmployeeModel> Employees
        {
            get { return _Employees; }
            set
            {
                _Employees = value;
                RaisePropertyChanged();
            }
        }

        public ViewModel()
        {
            // subscribe to the event fired after the DataAccessLevel gets the data
            DataAccessLevel.TheDataChanged += DataAccessLevel_TheExternalDataChanged;
        }

        void DataAccessLevel_TheExternalDataChanged(object sender, EventArgs e)
        {
            this.Employees = ((CallerMemberName.EmployeeModelEventArgs)(e)).Data;
        }

        public ICommand ButtonPressedCommand
        {
            get
            {
                if (null == _ButtonPressedCommand)
                    _ButtonPressedCommand = new RelayCommand(Execute_ButtonPressedCommand);

                return _ButtonPressedCommand;
            }
        }

        private void Execute_ButtonPressedCommand()
        {
            DataAccessLevel.GetTheData();
        }
    }
}
