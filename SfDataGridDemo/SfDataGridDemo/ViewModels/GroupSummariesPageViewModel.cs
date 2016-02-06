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
    public class GroupSummariesPageViewModel : ViewModelBase {
        private ISalesRepository salesRepository;

        #region Constructors

        public GroupSummariesPageViewModel(ISalesRepository salesRepository) {
            this.salesRepository = salesRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            YearlySales = salesRepository.GetSalesDetailsByYear(5);
            DailySales = salesRepository.GetSalesDetailsByDay(60);

            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        ObservableCollection<SalesByYearViewModel> yearlySales;
        public ObservableCollection<SalesByYearViewModel> YearlySales {
            get { return yearlySales; }
            set {
                SetProperty<ObservableCollection<SalesByYearViewModel>>(ref yearlySales, value);
            }
        }

        ObservableCollection<SalesByDateViewModel> dailySales;
        public ObservableCollection<SalesByDateViewModel> DailySales {
            get { return dailySales; }
            set {
                SetProperty<ObservableCollection<SalesByDateViewModel>>(ref dailySales, value);
            }
        }

        #endregion
    }
}
