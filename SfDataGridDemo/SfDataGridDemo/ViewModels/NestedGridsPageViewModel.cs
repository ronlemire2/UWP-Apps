using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class NestedGridsPageViewModel : ViewModelBase {
        private IOrder2Repository order2Repository;

        #region Constructors

        public NestedGridsPageViewModel(IOrder2Repository order2Repository) {
            this.order2Repository = order2Repository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            ComboBoxItemsSource = order2Repository.GetCustomerCities();
            Order2VMs = order2Repository.GetOrder2VMs(100);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private List<Order2ViewModel> order2VMs;
        public List<Order2ViewModel> Order2VMs {
            get { return order2VMs; }
            set { order2VMs = value; }
        }

        private List<string> comboxItemsSource;
        public List<string> ComboBoxItemsSource {
            get { return comboxItemsSource; }
            set {
                SetProperty<List<string>>(ref comboxItemsSource, value);
            }
        }

        #endregion
    }
}
