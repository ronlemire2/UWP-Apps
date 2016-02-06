using Prism.Windows.Mvvm;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;

namespace SfDataGridDemo.ViewModels {
    public class SortBySummaryPageViewModel : ViewModelBase {
        private IOrderRepository orderRepository;
        private OrderInfoViewModel orderInfoViewModel;

        #region Constructors

        public SortBySummaryPageViewModel(IOrderRepository orderRepository) {
            this.orderRepository = orderRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            orderInfoViewModel = new OrderInfoViewModel();
            this.OrderVMs = orderRepository.GetOrderVMs(2000);
            this.OrderDetailVMs = this.OrderVMs.Take(100).ToList<OrderViewModel>();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private List<OrderViewModel> orderVMs;
        public List<OrderViewModel> OrderVMs {
            get { return orderVMs; }
            set {
                SetProperty<List<OrderViewModel>>(ref orderVMs, value);
            }
        }

        private List<OrderViewModel> orderDetailVMs;
        public List<OrderViewModel> OrderDetailVMs {
            get { return orderDetailVMs; }
            set {
                SetProperty<List<OrderViewModel>>(ref orderDetailVMs, value);
            }
        }

        #endregion
    }
}
