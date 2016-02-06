using Prism.Windows.Mvvm;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using System.Collections.ObjectModel;

namespace SfDataGridDemo.ViewModels {
    public class EditingPageViewModel : ViewModelBase {
        private IOrderRepository orderRepository;

        #region Constructors

        public EditingPageViewModel(IOrderRepository orderRepository) {
            this.orderRepository = orderRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            OrderVMs = new ObservableCollection<OrderViewModel>(orderRepository.GetOrderVMs(100));
            ShipCountries = orderRepository.GetShipCountries();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<OrderViewModel> orderVMs;
        public ObservableCollection<OrderViewModel> OrderVMs {
            get { return orderVMs; }
            set { orderVMs = value; }
        }

        private List<string> shipCountries;
        public List<string> ShipCountries {
            get { return shipCountries; }
            set { shipCountries = value; }
        }


        #endregion
    }
}
