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
    public class ComicsPageViewModel : BasePageViewModel {
        private IComicsService comicsService;

        public ComicsPageViewModel(INavigationService navigationService, IComicsService comicsService) : base("http://www.comicsyndicate.org/") {
            this.comicsService = comicsService;
            this.navigationService = navigationService;
            IsBusy = false;
            BusyText = "Getting Comics Feeds. Please wait...";
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            FeedType = "Comic";
            List<Feed> feeds = null;
            Task.Run(async () => {
                feeds = await comicsService.GetFeedsAsync(link);
            }).Wait();
            feeds.Add(new Feed { FeedName = "0 Political Cartoons", Link = "http://editorialcartoonists.com/rss/daily.xml", LastUpdated = "" });
            Feeds = new ObservableCollection<Feed>(feeds);
            FeedGroups = ((ComicsService)comicsService).GetFeedGroups(Feeds.ToList());
            base.OnNavigatedTo(e, viewModelState);
        }
    }
}


    //{
    //  "Id": "10",
    //  "Name": "Cartoons",
    //  "Link": "http://editorialcartoonists.com/rss/daily.xml",
    //  "LastUpdated": " "
    //}