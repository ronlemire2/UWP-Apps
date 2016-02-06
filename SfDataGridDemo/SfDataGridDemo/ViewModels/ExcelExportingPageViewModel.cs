using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class ExcelExportingPageViewModel : ViewModelBase {
        private IEmployeeRepository employeeRepository;

        #region Constructors

        public ExcelExportingPageViewModel(IEmployeeRepository employeeRepository) {
            this.employeeRepository = employeeRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            EmployeeVMs = employeeRepository.GetEmployeesVMs(200).ToList();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private List<EmployeeViewModel> employeeVMs;
        public List<EmployeeViewModel> EmployeeVMs {
            get { return employeeVMs; }
            set { employeeVMs = value; }
        }

        #endregion
    }
}
