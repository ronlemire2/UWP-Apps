using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class AutoCellMergePageViewModel : ViewModelBase {
        private IOrderRepository orderRepository;

        #region Constructors

        public AutoCellMergePageViewModel(IOrderRepository orderRepository) {
            this.orderRepository = orderRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            this.OrderVMs = orderRepository.GetOrderVMs(200);
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

        #endregion
    }
}
