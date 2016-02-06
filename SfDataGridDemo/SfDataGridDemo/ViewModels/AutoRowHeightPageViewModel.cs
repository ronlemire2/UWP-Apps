using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class AutoRowHeightPageViewModel : ViewModelBase {
        private ICustomerRepository customerRepository;


        #region Constructors

        public AutoRowHeightPageViewModel(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            this.CustomerDetailVMs = customerRepository.GetCustomerDetails(50).ToList();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion


        #region Properties

        private List<CustomerViewModel> customerDetailVMs;
        public List<CustomerViewModel> CustomerDetailVMs {
            get { return customerDetailVMs; }
            set {
                SetProperty<List<CustomerViewModel>>(ref customerDetailVMs, value);
            }
        }

        #endregion
    }
}
