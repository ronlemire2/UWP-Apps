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
    public class FeedPageViewModel : ViewModelBase {
        protected INavigationService navigationService;
        protected FeedService feedService;
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoToWebPageCommand { get; set; }

        #region Constructors

        public FeedPageViewModel(FeedService feedService, INavigationService navigationService) {
            this.navigationService = navigationService;
            this.feedService = feedService;
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand, CanExecuteGoBackCommand);
            GoToWebPageCommand = new DelegateCommand(ExecuteGoToWebPageCommandCommand, CanExecuteGoToWebPageCommandCommand);
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            SelectedFeed = (Feed)e.Parameter;
            IsBusy = true;
            await Task.Delay(1);
            FeedData feedData = await feedService.GetFeedAsync(SelectedFeed.Link);
            Title = feedData.Title;
            Description = feedData.Description;
            PubDate = feedData.PubDate;
            FeedItems = new ObservableCollection<FeedItem>(feedData.Items);
            IsBusy = false;
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private Feed selectedFeed;
        public Feed SelectedFeed {
            get { return selectedFeed; }
            set {
                SetProperty<Feed>(ref selectedFeed, value);
                busyText = string.Format("Getting the {0} Feed.Please wait...", SelectedFeed.FeedName);
            }
        }

        private string title;
        public string Title {
            get { return title; }
            set {
                SetProperty<string>(ref title, value);
            }
        }

        private string description;
        public string Description {
            get { return description; }
            set {
                SetProperty<string>(ref description, value);
            }
        }

        private DateTime pubDate;
        public DateTime PubDate {
            get { return pubDate; }
            set {
                SetProperty<DateTime>(ref pubDate, value);
            }
        }

        private ObservableCollection<FeedItem> feedItems;
        public ObservableCollection<FeedItem> FeedItems {
            get { return feedItems; }
            set {
                SetProperty<ObservableCollection<FeedItem>>(ref feedItems, value);
            }
        }

        private FeedItem selectedFeedItem;
        public FeedItem SelectedFeedItem {
            get { return selectedFeedItem; }
            set {
                SetProperty<FeedItem>(ref selectedFeedItem, value);
                navigationService.Navigate("Web", selectedFeedItem);
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

        #region Commands

        public void ExecuteGoBackCommand() {
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
        }
        public bool CanExecuteGoBackCommand() {
            return true;
        }

        private void ExecuteGoToWebPageCommandCommand() {
            if (SelectedFeedItem != null) {
                navigationService.Navigate("Web", SelectedFeedItem);
            }
        }
        private bool CanExecuteGoToWebPageCommandCommand() {
            return true;
        }

        #endregion
    }
}
