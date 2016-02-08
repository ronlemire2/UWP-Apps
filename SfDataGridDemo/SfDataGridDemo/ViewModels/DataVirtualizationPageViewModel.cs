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
    public class DataVirtualizationPageViewModel : ViewModelBase {
        private IEmployeeRepository employeeRepository; 
        
        #region Constructors

        public DataVirtualizationPageViewModel(IOrderRepository orderRepository, IEmployeeRepository employeeRepository) {
            this.employeeRepository = employeeRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<EmployeeViewModel> employeeVMs = null;
        public ObservableCollection<EmployeeViewModel> EmployeeVMs {
            get { return employeeVMs; }
            set {
                SetProperty<ObservableCollection<EmployeeViewModel>>(ref employeeVMs, value);
            }
        }

        #endregion
    }
}
