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

namespace NFLWatcher.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private readonly INavigationService navigationService;
        private bool IsLoading = false;
        public DelegateCommand YearItemsSelectionChangedCommand { get; set; }
        public DelegateCommand SeasonItemsSelectionChangedCommand { get; set; }
        public DelegateCommand WeekItemsSelectionChangedCommand { get; set; }
        public DelegateCommand GameViewModelsSelectionChangedCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }

        #region Constructors

        public MainPageViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            Title = "NFL Schedule";
            YearItemsSelectionChangedCommand = new DelegateCommand(ExecuteYearItemsSelectionChangedCommand, CanExecuteYearItemsSelectionChangedCommand);
            SeasonItemsSelectionChangedCommand = new DelegateCommand(ExecuteSeasonItemsSelectionChangedCommand,
                CanExecuteSeasonItemsSelectionChangedCommand);
            WeekItemsSelectionChangedCommand = new DelegateCommand(ExecuteWeekItemsSelectionChangedCommand,
                CanExecuteWeekItemsSelectionChangedCommand);
            GameViewModelsSelectionChangedCommand = new DelegateCommand(ExecuteGameViewModelsSelectionChangedCommand,
                CanExecuteGameViewModelsSelectionChangedCommand);
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand,
                CanExecuteRefreshCommand);
            if (e.NavigationMode != Windows.UI.Xaml.Navigation.NavigationMode.Back) {
                InitializeWeekScheduleComboBoxes();
            }

            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region SelectionChanged EventHandlers

        public void ExecuteGameViewModelsSelectionChangedCommand() {
            if (SelectedGamePageVM != null) {
                // Navigate BoxScorePage passing GameId, SelectedSeasonItem, SelectedWeekItem
                navigationService.Navigate("BoxScore", new BoxScoreParameters {
                    GamePageVM = SelectedGamePageVM,
                    SelectedYear = SelectedYearItem,
                    SelectedSeason = SelectedSeasonItem,
                    SelectedWeek = SelectedWeekItem
                });
            }
        }

        public bool CanExecuteGameViewModelsSelectionChangedCommand() {
            return true;
        }

        public  void ExecuteYearItemsSelectionChangedCommand() {
            GamePageVMs = null;
        }
        public bool CanExecuteYearItemsSelectionChangedCommand() {
            return true;
        }

        public void ExecuteSeasonItemsSelectionChangedCommand() {
            // Get new WeekSchedule when Season has changed
            // What Season has been selected?
            string selectedSeason = SelectedSeasonItem;

            // Fill WeekComboBox based on Season
            // REG 1-17, PRE 1-4, POST 18-20
            SetWeekComboBox(selectedSeason);

            // Select 1st Item in WeekComboBox based on Season
            // REG 1, PRE 1, POST 18
            switch (selectedSeason) {
                case "REG":
                case "PRE":
                    SelectedWeekItem = "01";
                    break;
                case "POST":
                    SelectedWeekItem = "18";
                    break;
                default:
                    break;
            }

            GamePageVMs = null;
        }
        public bool CanExecuteSeasonItemsSelectionChangedCommand() {
            return true;
        }

        public void ExecuteWeekItemsSelectionChangedCommand() {
            GamePageVMs = null;
        }
        public bool CanExecuteWeekItemsSelectionChangedCommand() {
            return true;
        }

        public async void ExecuteRefreshCommand() {
            if (IsLoading == false) {
                await GetWeekSchedule(SelectedYearItem, SelectedSeasonItem, SelectedWeekItem);
            }
        }
        public bool CanExecuteRefreshCommand() {
            return true;
        }

        #endregion

        #region Properties

        private ObservableCollection<GameViewModel> gamePageVMs;
        private GameViewModel selectedGamePageVM;
        private ObservableCollection<string> yearItems;
        private string selectedYearItem;
        private ObservableCollection<string> seasonItems;
        private string selectedSeasonItem;
        private ObservableCollection<string> weekItems;
        private string selectedWeekItem;

        public string Year { get; set; }
        public string SeasonType { get; set; }
        public string Week { get; set; }
        public string Title { get; set; }

        public ObservableCollection<GameViewModel> GamePageVMs {
            get {
                return gamePageVMs;
            }
            set {
                SetProperty< ObservableCollection<GameViewModel>>(ref gamePageVMs, value);
            }
        }

        public GameViewModel SelectedGamePageVM {
            get {
                return selectedGamePageVM;
            }
            set {
                SetProperty<GameViewModel>(ref selectedGamePageVM, value);
            }
        }

        public ObservableCollection<string> YearItems {
            get {
                return yearItems;
            }
            set {
                SetProperty<ObservableCollection<string>>(ref yearItems, value);
            }
        }

        public string SelectedYearItem {
            get {
                return selectedYearItem;
            }
            set {
                SetProperty<string>(ref selectedYearItem, value);
            }
        }

        public ObservableCollection<string> SeasonItems {
            get {
                return seasonItems;
            }
            set {
                SetProperty< ObservableCollection<string>>(ref seasonItems, value);
            }
        }
        public string SelectedSeasonItem {
            get {
                return selectedSeasonItem;
            }
            set {
                SetProperty<string>(ref selectedSeasonItem, value);
            }
        }
        public ObservableCollection<string> WeekItems {
            get {
                return weekItems;
            }
            set {
                SetProperty< ObservableCollection<string>>(ref weekItems, value);
            }
        }
        public string SelectedWeekItem {
            get {
                return selectedWeekItem;
            }
            set {
                SetProperty<string>(ref selectedWeekItem, value);
            }
        }

        #endregion

        private async void InitializeWeekScheduleComboBoxes() {
            IsLoading = true;
            YearItems = new ObservableCollection<string>();
            YearItems.Add("2015");
            YearItems.Add("2014");
            YearItems.Add("2013");
            SeasonItems = new ObservableCollection<string>();
            SeasonItems.Add("REG");
            SeasonItems.Add("PRE");
            SeasonItems.Add("POST");

            WeekDateSpan currentWeek = await NFLService.GetCurrentWeekAsync(DateTime.Now, "YearCalendar.json");
            // Fill WeekComboBox based on Season
            // REG 1-17, PRE 1-4, POST 18-20
            SetWeekComboBox(currentWeek.Season);

            SelectedYearItem = currentWeek.Year;
            SelectedSeasonItem = currentWeek.Season;
            SelectedWeekItem = currentWeek.Week;

            await GetWeekSchedule(currentWeek.Year, currentWeek.Season, currentWeek.Week);
            IsLoading = false;
        }

        private void SetWeekComboBox(string season) {
            WeekItems = new ObservableCollection<string>();
            switch (season) {
                case "PRE":
                    for (int i = 1; i <= 4; i++) {
                        WeekItems.Add(i.ToString().Length == 1 ? "0" + i.ToString() : i.ToString());
                    }
                    break;
                case "REG":
                    for (int i = 1; i <= 17; i++) {
                        WeekItems.Add(i.ToString().Length == 1 ? "0" + i.ToString() : i.ToString());
                    }
                    break;
                case "POST":
                    for (int i = 18; i <= 20; i++) {
                        WeekItems.Add(i.ToString().Length == 1 ? "0" + i.ToString() : i.ToString());
                    }
                    break;
                default:
                    break;
            }
        }


        private async Task GetWeekSchedule(string year, string season, string week) {
            string url = NFLService.BuildWeekScheduleUrl(year, season, week);
            WeekSchedule weekSchedule = await NFLService.GetWeekScheduleFromUrlAsync(url);
            Game game = null;
            GameViewModel vm;

            try {
                GamePageVMs = new ObservableCollection<GameViewModel>();
                foreach (GameSchedule gs in weekSchedule.GameSchedules) {
                    vm = new GameViewModel();
                    vm.GameId = gs.GameId;
                    vm.GameDate = string.Format("{0}/{1}/{2}",
                        gs.GameId.Substring(4, 2),
                        gs.GameId.Substring(6, 2),
                        gs.GameId.Substring(0, 4));
                    vm.Day = gs.Day;
                    vm.Time = gs.Time;
                    vm.HomeAbbr = gs.Home;
                    vm.HomeNickName = ToTitleCase(gs.HomeNickName);
                    vm.HomeImagePath = string.Format("/Assets/Logos/{0}.png", gs.Home.ToLower());
                    vm.VisitorAbbr = gs.Visitor;
                    vm.VisitorNickName = ToTitleCase(gs.VisitorNickName);
                    vm.VisitorImagePath = string.Format("/Assets/Logos/{0}.png", gs.Visitor.ToLower());

                    game = await NFLService.GetGameFromUrlAsync(string.Format("http://www.nfl.com/liveupdate/game-center/{0}/{0}_gtd.json", gs.GameId));

                    if (game == null || game.Away == null || game.Home == null) {
                        vm.AwayCurrentScore = "0";
                        vm.HomeCurrentScore = "0";
                        vm.Qtr = "Qtr N/A";
                    }
                    else {
                        vm.AwayCurrentScore = game.Away.Score.Total.ToString();
                        vm.HomeCurrentScore = game.Home.Score.Total.ToString();
                        if (game.Qtr == null) {
                            vm.Qtr = "Qtr N/A";
                        }
                        else {
                            vm.Qtr = game.Qtr.ToLower() != "final" ?
                                string.Format("Q{0} {1}", game.Qtr, game.Clock) : game.Qtr;
                        }
                    }

                    GamePageVMs.Add(vm);
                }
            }
            catch (Exception x) {
                string msg = x.Message;
            }
        }

        private string ToTitleCase(string word) {
            return string.Format("{0}{1}", word.Substring(0, 1).ToUpper(), word.Substring(1));
        }
    }
}
