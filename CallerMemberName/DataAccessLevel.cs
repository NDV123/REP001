using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CallerMemberName
{
    public class DataAccessLevel
    {

        public event EventHandler TheDataChanged;

        private readonly BackgroundWorker worker = new BackgroundWorker();

        public DataAccessLevel()
        {
            // Create the Background Worker and subscribe to events
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TheDataChanged(this, new EmployeeModelEventArgs((ObservableCollection<EmployeeModel>)e.UserState));
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker.ReportProgress(0, PseudoServiceFunctionResonse());  
        }

        public void GetTheData()
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync();
        }

        /// <summary>
        /// Simulate getting some data from Database
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<EmployeeModel> PseudoServiceFunctionResonse()
        {
            Thread.Sleep(0);
            ObservableCollection<EmployeeModel> EmployeeModels = new ObservableCollection<EmployeeModel>(); 
            EmployeeModel EmployeeModel = new EmployeeModel();
            EmployeeModel.Name = "Jane Doe";
            EmployeeModel.Gender = "Female";

            EmployeeModels.Add(EmployeeModel);

            EmployeeModel = new EmployeeModel();
            EmployeeModel.Name = "John Doe";
            EmployeeModel.Gender = "Male";

            EmployeeModels.Add(EmployeeModel);

            return EmployeeModels;
        }
            
    }
}
