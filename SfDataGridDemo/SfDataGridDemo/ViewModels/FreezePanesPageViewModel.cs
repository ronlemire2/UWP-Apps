using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class FreezePanesPageViewModel : ViewModelBase {
        private ISalesRepository salesRepository;


        #region Constructors

        public FreezePanesPageViewModel(ISalesRepository salesRepository) {
            this.salesRepository = salesRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            this.SalesByYearVMs = salesRepository.GetSalesDetailsByYear(2015).ToList();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion


        #region Properties

        private List<SalesByYearViewModel> salesByYearVMs;
        public List<SalesByYearViewModel> SalesByYearVMs {
            get { return salesByYearVMs; }
            set {
                SetProperty<List<SalesByYearViewModel>>(ref salesByYearVMs, value);
            }
        }

        #endregion
    }
}
