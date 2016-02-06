using FeedReader.Models;
using FeedReader.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.ViewModels {
    public class BasePageViewModel : ViewModelBase {
        protected INavigationService navigationService;
        protected string link;

        #region Constructors

        public BasePageViewModel(string link) {
            this.link = link;
            IsBusy = false;
        }

        #endregion

        #region Properties

        private string feedType;
        public string FeedType {
            get { return feedType; }
            set { SetProperty<string>(ref feedType, value); }
        }

        private IEnumerable<object> feedGroups;
        public IEnumerable<object> FeedGroups {
            get { return feedGroups; }
            set {
                SetProperty<IEnumerable<object>>(ref feedGroups, value);
            }
        }

        private ObservableCollection<Feed> feeds;
        public ObservableCollection<Feed> Feeds {
            get { return feeds; }
            set {
                SetProperty<ObservableCollection<Feed>>(ref feeds, value);
            }
        }

        private Feed selectedFeed;
        public Feed SelectedFeed {
            get { return selectedFeed; }
            set {
                SetProperty<Feed>(ref selectedFeed, value);
                navigationService.Navigate("Feed", SelectedFeed);
            }
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
    }
}
