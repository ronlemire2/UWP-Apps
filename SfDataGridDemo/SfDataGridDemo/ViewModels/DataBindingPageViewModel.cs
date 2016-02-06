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
    public class DataBindingPageViewModel : ViewModelBase {
        private IOrderRepository orderRepository;
        private IEmployeeRepository employeeRepository;

        #region Constructors

        public DataBindingPageViewModel(IOrderRepository orderRepository, IEmployeeRepository employeeRepository) {
            this.orderRepository = orderRepository;
            this.employeeRepository = employeeRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            OrderVMs = orderRepository.GetOrderVMs(200);
            EmployeeVMs = employeeRepository.GetEmployeesVMs(200);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        private List<OrderViewModel> orderVMs = null;
        public List<OrderViewModel> OrderVMs {
            get { return orderVMs; }
            set {
                SetProperty<List<OrderViewModel>>(ref orderVMs, value);
            }
        }

        private ObservableCollection<EmployeeViewModel> employeeVMs = null;
        public ObservableCollection<EmployeeViewModel> EmployeeVMs {
            get { return employeeVMs; }
            set {
                SetProperty<ObservableCollection<EmployeeViewModel>>(ref employeeVMs, value);
            }
        }
    }
}
