using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using FeedReader.Models;
using Prism.Commands;

namespace FeedReader.ViewModels {
    public class WebPageViewModel : ViewModelBase {
        INavigationService navigationService;
        public DelegateCommand GoBackCommand { get; set; }

        #region Constructors

        public WebPageViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand, CanExecuteGoBackCommand);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            SelectedFeedItem = (FeedItem)e.Parameter;
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private FeedItem selectedFeedItem;
        public FeedItem SelectedFeedItem {
            get { return selectedFeedItem; }
            set {
                SetProperty<FeedItem>(ref selectedFeedItem, value);
            }
        }

        public void ExecuteGoBackCommand() {
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
        }
        public bool CanExecuteGoBackCommand() {
            return true;
        }

        #endregion
    }
}
