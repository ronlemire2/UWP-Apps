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
    public class MainPageViewModel : ViewModelBase {
        private INavigationService navigationService;
        public DelegateCommand GridViewSelectionChangedCommand { get; set; }
        public DelegateCommand ListViewSelectionChangedCommand { get; set; }

        #region Constructor

        public MainPageViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
            GridViewSelectionChangedCommand = new DelegateCommand(ExecuteGridViewSelectionChangedCommand, CanExecuteGridViewSelectionChangedCommand);
            ListViewSelectionChangedCommand = new DelegateCommand(ExecuteListViewSelectionChangedCommand, CanExecuteListViewSelectionChangedCommand);
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            // Get all 300 (approx) Comic Feeds
            List<Feed> feeds = await feedService.GetFeedsAsync("http://www.comicsyndicate.org/");
            Feeds = new ObservableCollection<Feed>(feeds);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private IFeedService feedService;
        public IFeedService FeedService {
            get { return feedService; }
            set { feedService = value; }
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
            }
        }

        #endregion

        #region Commands

        private void ExecuteGridViewSelectionChangedCommand() {
            if (SelectedFeed != null) {
                navigationService.Navigate("ComicsFeed", SelectedFeed);
            }
        }
        private bool CanExecuteGridViewSelectionChangedCommand() {
            return true;
        }

        private void ExecuteListViewSelectionChangedCommand() {
            if (SelectedFeed != null) {
                // Display the Selected Feed
                navigationService.Navigate("ComicsFeed", SelectedFeed);
            }
        }
        private bool CanExecuteListViewSelectionChangedCommand() {
            return true;
        }

        #endregion
    }
}
