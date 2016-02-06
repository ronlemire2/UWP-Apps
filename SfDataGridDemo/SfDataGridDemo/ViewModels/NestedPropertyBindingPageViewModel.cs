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
    public class NestedPropertyBindingPageViewModel : ViewModelBase {
        private ICustomerRepository customerRepository;

        #region Constructors

        public NestedPropertyBindingPageViewModel(ICustomerRepository customerRepository) {
            this.customerRepository = customerRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            CustomerVMs = customerRepository.GetCustomerDetails(50);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<CustomerViewModel> customerVMs;
        public ObservableCollection<CustomerViewModel> CustomerVMs {
            get { return customerVMs; }
            set {
                SetProperty<ObservableCollection<CustomerViewModel>>(ref customerVMs, value);
            }
        }

        #endregion

    }
}
