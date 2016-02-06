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
    public class PoliticsPageViewModel : BasePageViewModel {
        private IFeedService feedService;

        public PoliticsPageViewModel(INavigationService navigationService, IFeedService feedService) : base("ms-appx:///Assets/Data/Politics.json") {
            this.feedService = feedService;
            this.navigationService = navigationService;
            IsBusy = false;
            BusyText = "Getting Politics Feeds. Please wait...";        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            if (e.SourcePageType != null) {
                string sourcePageType = e.SourcePageType.Name;
                int len = sourcePageType.Length;
                FeedType = sourcePageType.Substring(0, len - 4);
            }

            IsBusy = true;
            await Task.Delay(1);
            List<Feed> feeds = null;
            feeds = await feedService.GetFeedsAsync(link);
            Feeds = new ObservableCollection<Feed>(feeds);
            IsBusy = false;
            base.OnNavigatedTo(e, viewModelState);
        }
    }
}
