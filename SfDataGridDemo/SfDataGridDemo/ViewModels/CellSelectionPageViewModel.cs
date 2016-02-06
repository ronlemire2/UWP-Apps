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
    public class CellSelectionPageViewModel : ViewModelBase {
        private IProductRepository productRepository;

        #region Constructors

        public CellSelectionPageViewModel(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            ProductVMs = new ObservableCollection<ProductViewModel>(productRepository.GetProductVMs(1000));
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
