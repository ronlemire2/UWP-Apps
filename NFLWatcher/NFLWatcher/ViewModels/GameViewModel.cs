using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.ViewModels {
    public class GameViewModel : ViewModelBase {
        private string gameId;
        private string gameDate;
        private string day;
        private string time;
        private string homeAbbr;
        private string homeNickName;
        private string homeImagePath;
        private string visitorAbbr;
        private string visitorNickName;
        private string visitorImagePath;

        public string GameId {
            get {
                return gameId;
            }
            set {
                SetProperty<string>(ref gameId, value);
            }
        }
        public string GameDate {
            get {
                return gameDate;
            }
            set {
                SetProperty<string>(ref gameDate, value);
            }
        }
        public string Day {
            get {
                return day;
            }
            set {
                SetProperty<string>(ref day, value);
            }
        }
        public string Time {
            get {
                return time;
            }
            set {
                SetProperty<string>(ref time, value);
            }
        }
        public string HomeAbbr {
            get {
                return homeAbbr;
            }
            set {
                SetProperty<string>(ref homeAbbr, value);
            }
        }
        public string HomeNickName {
            get {
                return homeNickName;
            }
            set {
                SetProperty<string>(ref homeNickName, value);
            }
        }
        public string HomeImagePath {
            get {
                return homeImagePath;
            }
            set {
                SetProperty<string>(ref homeImagePath, value);
            }
        }
        public string VisitorAbbr {
            get {
                return visitorAbbr;
            }
            set {
                SetProperty<string>(ref visitorAbbr, value);
            }
        }
        public string VisitorNickName {
            get {
                return visitorNickName;
            }
            set {
                SetProperty<string>(ref visitorNickName, value);
            }
        }
        public string VisitorImagePath {
            get {
                return visitorImagePath;
            }
            set {
                SetProperty<string>(ref visitorImagePath, value);
            }
        }
        private string awayCurrentScore;
        public string AwayCurrentScore {
            get {
                return awayCurrentScore;
            }
            set {
                SetProperty<string>(ref awayCurrentScore, value);
            }
        }
        private string homeCurrentScore;
        public string HomeCurrentScore {
            get {
                return homeCurrentScore;
            }
            set {
                SetProperty<string>(ref homeCurrentScore, value);
            }
        }
        private string qtr;
        public string Qtr {
            get {
                if (!String.IsNullOrEmpty(qtr)) {
                    return qtr.Replace("Qfinal overtime", "OT ");
                }
                else {
                    return string.Empty;
                }
            }
            set {
                SetProperty<string>(ref qtr, value);
            }
        }
        private string clock;
        public string Clock {
            get {
                return clock;
            }
            set {
                SetProperty<string>(ref clock, value);
            }
        }
    }
}
