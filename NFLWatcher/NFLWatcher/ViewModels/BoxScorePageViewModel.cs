using NFLWatcher.Models;
using NFLWatcher.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NFLWatcher.ViewModels {
    public class BoxScorePageViewModel : ViewModelBase {
        private readonly INavigationService navigationService;
        public DelegateCommand HighlightsCommand { get; set; }
        public DelegateCommand StatsCommand { get; set; }
        public DelegateCommand PlayByPlayCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        #region Constructors

        public BoxScorePageViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
            PageTitle = "Box Score";

            HighlightsCommand = new DelegateCommand(ExecuteHighlightsCommand, CanExecuteHighlightsCommand);
            StatsCommand = new DelegateCommand(ExecuteStatsCommand, CanExecuteStatsCommand);
            PlayByPlayCommand = new DelegateCommand(ExecutePlayByPlayCommand, CanExecutePlayByPlayCommand);
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand, CanExecuteGoBackCommand);
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            FileService fileService = new FileService();
            ObservableCollection<Team> teams = await fileService.GetTeamsAsync();

            BoxScoreParameters parms = (BoxScoreParameters)e.Parameter;
            CurrentSeason = parms.SelectedSeason;
            CurrentWeek = parms.SelectedWeek;
            string gameId = parms.GamePageVM.GameId;
            Game game = await NFLService.GetGameFromUrlAsync(string.Format("http://www.nfl.com/liveupdate/game-center/{0}/{0}_gtd.json", gameId));

            string imagePath = string.Empty;
            string nickName = string.Empty;

            if (game == null || game.Away == null || game.Home == null) {
                var messageDialog = new MessageDialog("Please try again later.", "Sorry, stats not available yet.");
                await messageDialog.ShowAsync();
            }
            else {
                FindTeamValues(game.Away.Abbr, teams, ref imagePath, ref nickName);
                AwayImagePath = imagePath; // needed because Image not deep binding to AwayImagePath
                AwayNickName = nickName;
                AwayQ1 = game.Away.Score.Q1.ToString();
                AwayQ2 = game.Away.Score.Q2.ToString();
                AwayQ3 = game.Away.Score.Q3.ToString();
                AwayQ4 = game.Away.Score.Q4.ToString();
                AwayQ5 = game.Away.Score.Q5 == 0 ? string.Empty : game.Away.Score.Q5.ToString();
                AwayTotal = game.Away.Score.Total.ToString();

                FindTeamValues(game.Home.Abbr, teams, ref imagePath, ref nickName);
                HomeImagePath = imagePath; // needed because Image not deep binding to BoxScoreVM.HomeImagePath
                HomeNickName = nickName;
                HomeQ1 = game.Home.Score.Q1.ToString();
                HomeQ2 = game.Home.Score.Q2.ToString();
                HomeQ3 = game.Home.Score.Q3.ToString();
                HomeQ4 = game.Home.Score.Q4.ToString();
                HomeQ5 = game.Home.Score.Q5 == 0 ? string.Empty : game.Home.Score.Q5.ToString();
                HomeTotal = game.Home.Score.Total.ToString();

                if (game.Qtr == null) {
                    Qtr = "Qtr N/A";
                }
                else {
                    Qtr = game.Qtr.ToLower() != "final" ?
                        string.Format("Q{0}  {1}", game.Qtr, game.Clock) : game.Qtr;
                }
            }

            base.OnNavigatedTo(e, viewModelState);
        }

        private void FindTeamValues(string abbr, ObservableCollection<Team> teams, ref string imagePath, ref string nickName) {
            foreach (Team team in teams) {
                if (team.Abbr == abbr) {
                    imagePath = team.ImagePath;
                    nickName = team.NickName;
                    break;
                }
            }
            return;
        }

        #endregion

        #region Properties

        public string GameId { get; set; }
        public string CurrentWeek { get; set; }
        public string CurrentSeason { get; set; }
        public string PageTitle { get; set; }
        private string awayImagePath;
        public string AwayImagePath {
            get {
                return awayImagePath;
            }
            set {
                SetProperty<string>(ref awayImagePath, value);
            }
        }
        private string homeImagePath;
        public string HomeImagePath {
            get {
                return homeImagePath;
            }
            set {
                SetProperty<string>(ref homeImagePath, value);
            }
        }

        private string awayNickName;
        private string awayQ1;
        private string awayQ2;
        private string awayQ3;
        private string awayQ4;
        private string awayQ5;
        private string awayTotal;
        public string AwayNickName {
            get {
                return awayNickName;
            }
            set {
                SetProperty<string>(ref awayNickName, value);
            }
        }
        public string AwayQ1 {
            get {
                return awayQ1;
            }
            set {
                SetProperty<string>(ref awayQ1, value);
            }
        }
        public string AwayQ2 {
            get {
                return awayQ2;
            }
            set {
                SetProperty<string>(ref awayQ2, value);
            }
        }
        public string AwayQ3 {
            get {
                return awayQ3;
            }
            set {
                SetProperty<string>(ref awayQ3, value);
            }
        }
        public string AwayQ4 {
            get {
                return awayQ4;
            }
            set {
                SetProperty<string>(ref awayQ4, value);
            }
        }
        public string AwayQ5 {
            get {
                return awayQ5;
            }
            set {
                SetProperty<string>(ref awayQ5, value);
            }
        }
        public string AwayTotal {
            get {
                return awayTotal;
            }
            set {
                SetProperty<string>(ref awayTotal, value);
            }
        }

        private string homeNickName;
        private string homeQ1;
        private string homeQ2;
        private string homeQ3;
        private string homeQ4;
        private string homeQ5;
        private string homeTotal;
        public string HomeNickName {
            get {
                return homeNickName;
            }
            set {
                SetProperty<string>(ref homeNickName, value);
            }
        }
        public string HomeQ1 {
            get {
                return homeQ1;
            }
            set {
                SetProperty<string>(ref homeQ1, value);
            }
        }
        public string HomeQ2 {
            get {
                return homeQ2;
            }
            set {
                SetProperty<string>(ref homeQ2, value);
            }
        }
        public string HomeQ3 {
            get {
                return homeQ3;
            }
            set {
                SetProperty<string>(ref homeQ3, value);
            }
        }
        public string HomeQ4 {
            get {
                return homeQ4;
            }
            set {
                SetProperty<string>(ref homeQ4, value);
            }
        }
        public string HomeQ5 {
            get {
                return homeQ5;
            }
            set {
                SetProperty<string>(ref homeQ5, value);
            }
        }
        public string HomeTotal {
            get {
                return homeTotal;
            }
            set {
                SetProperty<string>(ref homeTotal, value);
            }
        }
        private string qtr;
        public string Qtr {
            get {
                return qtr;
            }
            set {
                SetProperty<string>(ref qtr, value);
            }
        }
        #endregion

        #region Commands 

        public void ExecuteHighlightsCommand() {
            navigationService.Navigate("Highlights", new HighlightsParameters {
                CurrentWeek = this.CurrentWeek,
                CurrentSeason = this.CurrentSeason,
                AwayNickName = this.AwayNickName,
                HomeNickName = this.HomeNickName
            });
        }
        public bool CanExecuteHighlightsCommand() {
            return true;
        }

        public async void ExecuteStatsCommand() {
            var messageDialog = new MessageDialog("Stats feature not implemented yet.", "Stats coming soon.");
            await messageDialog.ShowAsync();
        }
        public bool CanExecuteStatsCommand() {
            return true;
        }

        public async void ExecutePlayByPlayCommand() {
            var messageDialog = new MessageDialog("Play by Play feature not implemented yet.", "Play by Play coming soon.");
            await messageDialog.ShowAsync();
        }
        public bool CanExecutePlayByPlayCommand() {
            return true;
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
