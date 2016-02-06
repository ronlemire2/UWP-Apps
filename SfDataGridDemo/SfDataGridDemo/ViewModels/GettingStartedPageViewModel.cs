using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class GettingStartedPageViewModel : ViewModelBase {
        private IOrderRepository orderRepository;
        public DelegateCommand SfDataGridLoadedCommand { get; set; }

        #region Constructors

        public GettingStartedPageViewModel(IOrderRepository orderRepository) {
            this.orderRepository = orderRepository;
            SfDataGridLoadedCommand = new DelegateCommand(ExecuteSfDataGridLoadedCommand, CanExecuteSfDataGridLoadedCommand);
            BusyText = "Getting Data. Please wait...";
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            IsBusy = true;
            OrderVMs = orderRepository.GetOrderVMs(200);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private List<OrderViewModel> orderVMs;
        public List<OrderViewModel> OrderVMs {
            get { return orderVMs; }
            set { orderVMs = value; }
        }

        private bool isBusy;
        public bool IsBusy {
            get { return isBusy; }
            set {
                SetProperty<bool>(ref isBusy, value);
            }
        }

        private string busyText;
        public string BusyText {
            get { return busyText; }
            set {
                SetProperty<string>(ref busyText, value);
            }
        }

        #endregion

        #region Commands

        private void ExecuteSfDataGridLoadedCommand() {
            IsBusy = false;
        }
        private bool CanExecuteSfDataGridLoadedCommand() {
            return true;
        }
        #endregion
    }
}
