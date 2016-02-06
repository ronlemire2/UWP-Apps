using Prism.Windows.Mvvm;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;

namespace SfDataGridDemo.ViewModels {
    public class SortingPageViewModel : ViewModelBase {
        private IEmployeeRepository employeeRepository;

        #region Constructors

        public SortingPageViewModel(IEmployeeRepository employeeRepository) {
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
