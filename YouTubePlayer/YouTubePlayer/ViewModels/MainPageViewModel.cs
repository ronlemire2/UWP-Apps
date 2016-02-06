using MyToolkit.Multimedia;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubePlayer.Models;
using YouTubePlayer.Services;

namespace YouTubePlayer.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private string appName;
        private readonly INavigationService navigationService;
        private bool isLoading;
        public DelegateCommand SearchYouTubeCommand { get; set; }
        public DelegateCommand GotFocusCommand { get; set; }
        public DelegateCommand KeyDownCommand { get; set; }

        #region Constructors

        public MainPageViewModel(INavigationService navigationService) {
            AppName = "YouTubePlayer";
            this.navigationService = navigationService;
            isLoading = false;
            SearchItem = "Enter search here";

            SearchYouTubeCommand = new DelegateCommand(ExecuteSearchYouTubeCommand, CanExecuteSearchYouTubeCommand);
            GotFocusCommand = new DelegateCommand(ExecuteGotFocusCommand, CanExecuteGotFocusCommand);
            KeyDownCommand = new DelegateCommand(ExecuteKeyDownCommand, CanExecuteKeyDownCommand);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            base.OnNavigatedTo(e, viewModelState);
        }


        private async Task LoadSearchItems(string searchItem) {
            try {
                List<YouTubeDTO> DTOs = await MyYouTubeService.SearchYouTube(searchItem);
                YouTubeUrl = DTOs[0].Id;
                isLoading = true;
                SearchItems = new ObservableCollection<string>();
                bool includeItem = true;
                foreach (YouTubeDTO dto in DTOs) {
                    // TODO: add logic for PRE and POST
                    switch (CurrentSeason) {
                        case "PRE":
                            break;
                        case "REG":
                            if (dto.Title.ToLower().IndexOf("preseason") >= 0) {
                                includeItem = false;
                            }
                            break;
                        case "POST":
                            break;
                    }
                    if (includeItem) {
                        SearchItems.Add(string.Format("{0}?Id={1}", dto.Title, dto.Id));
                    }
                }
                isLoading = false;
                SelectedSearchItem = SearchItems[0];
            }
            catch (Exception x) {
                string msg = x.Message;
            }
        }

        #endregion

        #region Properties

        public string PageTitle { get; set; }
        public string CurrentWeek { get; set; }
        public string CurrentSeason { get; set; }
        public string AwayNickName { get; set; }
        public string HomeNickName { get; set; }

        private string youTubeUrl;
        public string YouTubeUrl {
            get {
                return youTubeUrl;
            }
            set {
                SetProperty<string>(ref youTubeUrl, value);
            }
        }

        private ObservableCollection<string> searchItems;
        public ObservableCollection<string> SearchItems {
            get {
                return searchItems;
            }
            set {
                SetProperty<ObservableCollection<string>>(ref searchItems, value);
            }
        }

        private string  selectedSearchItem;
        public string  SelectedSearchItem {
            get { return selectedSearchItem; }
            set {
                SetProperty<string>(ref selectedSearchItem, value);
                if (isLoading == false) {
                    int pos = value.IndexOf("?Id=");
                    YouTubeUrl = value.Substring(pos + 4);
                }
            }
        }

        private string searchItem;
        public string SearchItem {
            get {
                return searchItem;
            }
            set {
                SetProperty<string>(ref searchItem, value);
            }
        }

        public string AppName {
            get { return appName; }
            set {
                SetProperty<string>(ref appName, value);
            }
        }

        #endregion

        #region Commands

        private async void ExecuteSearchYouTubeCommand() {
            await LoadSearchItems(SearchItem);
        }
        private bool CanExecuteSearchYouTubeCommand() {
            return true;
        }

        private void ExecuteGotFocusCommand() {
            SearchItem = string.Empty;
        }
        private bool CanExecuteGotFocusCommand() {
            return true;
        }

        private void ExecuteKeyDownCommand() {

        }
        private bool CanExecuteKeyDownCommand() {
            return true;
        }

        #endregion

    }
}


//public DelegateCommand SearchItemsSelectionChangedCommand { get; set; }
//SearchItemsSelectionChangedCommand = new DelegateCommand(ExecuteSearchItemsSelectionChangedCommand, CanExecuteSearchItemsSelectionChangedCommand);
//private void ExecuteSearchItemsSelectionChangedCommand() {
//    //if (((KeyRoutedEventArgs)context.EventArgs).Key == Windows.System.VirtualKey.Enter) {
//    //    await LoadYouTubeSearchItems(((HighlightsViewModel)context.Target).SearchItem);
//    //}
//}
//private bool CanExecuteSearchItemsSelectionChangedCommand() {
//    return true;
//}
