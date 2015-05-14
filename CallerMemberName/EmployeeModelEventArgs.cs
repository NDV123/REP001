using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallerMemberName
{
    class EmployeeModelEventArgs : EventArgs
    {
        private ObservableCollection<EmployeeModel> m_Data;
        public ObservableCollection<EmployeeModel> Data { get { return m_Data; } }

        public EmployeeModelEventArgs() { }

        public EmployeeModelEventArgs(ObservableCollection<EmployeeModel> _myData)
        {
            m_Data = _myData;
        }
    }
}
