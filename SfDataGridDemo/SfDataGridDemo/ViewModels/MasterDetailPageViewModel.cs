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
    public class MasterDetailPageViewModel : ViewModelBase {
        private IProductRepository productRepository;

        #region Constructors

        public MasterDetailPageViewModel(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            ProductVMs = new ObservableCollection<ProductViewModel>(productRepository.GetProductVMs(100));
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<ProductViewModel> productVMs;
        public ObservableCollection<ProductViewModel> ProductVMs {
            get { return productVMs; }
            set { productVMs = value; }
        }

        #endregion
    }
}
