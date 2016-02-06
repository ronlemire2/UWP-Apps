using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class AdvancedFilteringPageViewModel : ViewModelBase {
        private IEmployeeRepository employeeRepository;

        #region Constructors

        public AdvancedFilteringPageViewModel(IEmployeeRepository employeeRepository) {
            this.employeeRepository = employeeRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            EmployeeVMs = employeeRepository.GetEmployeesVMs(200);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion


        #region Properties

        private ObservableCollection<EmployeeViewModel> employeeVMs;
        public ObservableCollection<EmployeeViewModel> EmployeeVMs {
            get { return employeeVMs; }
            set { employeeVMs = value; }
        }

        #endregion
    }
}
