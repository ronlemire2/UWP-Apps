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
    public class GroupingPageViewModel : ViewModelBase {
        private ISalesRepository salesRepository;

        #region Constructors

        public GroupingPageViewModel(ISalesRepository salesRepository) {
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

        private ObservableCollection<SalesByDateViewModel> dailySalesDetails = null;
        public ObservableCollection<SalesByDateViewModel> DailySalesDetails {
            get { return dailySalesDetails; }
            set {
                SetProperty<ObservableCollection<SalesByDateViewModel>>(ref dailySalesDetails, value);
            }
        }

        #endregion

    }
}
