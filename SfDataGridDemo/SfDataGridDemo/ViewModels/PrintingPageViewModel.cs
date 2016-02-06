using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class PrintingPageViewModel : ViewModelBase {
        private ICountryRepository countryRepository;

        #region Constructors

        public PrintingPageViewModel(ICountryRepository countryRepository) {
            this.countryRepository = countryRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            CountryVMs = countryRepository.GetCountryVMs();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private List<CountryViewModel> countryVMs;
        public List<CountryViewModel> CountryVMs {
            get { return countryVMs; }
            set {
                SetProperty<List<CountryViewModel>>(ref countryVMs, value);
            }
        }


        #endregion
    }
}
