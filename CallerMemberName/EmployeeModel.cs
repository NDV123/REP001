using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CallerMemberName
{
    public class EmployeeModel : ModelViewModelBase
    {
        public EmployeeModel()
        {

        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged();
            }
        }

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
                RaisePropertyChanged();
            }
        }
    }
}