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
    public class UnboundRowPageViewModel : ViewModelBase {
        private ISalesRepository salesRepository;

        #region Constructors

        public UnboundRowPageViewModel(ISalesRepository salesRepository) {
            this.salesRepository = salesRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            YearlySalesDetails = salesRepository.GetSalesDetailsByYear(5);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<SalesByYearViewModel> yearlySalesDetails = null;
        public ObservableCollection<SalesByYearViewModel> YearlySalesDetails {
            get { return yearlySalesDetails; }
            set {
                SetProperty<ObservableCollection<SalesByYearViewModel>>(ref yearlySalesDetails, value);
            }
        }

        #endregion

    }
}
