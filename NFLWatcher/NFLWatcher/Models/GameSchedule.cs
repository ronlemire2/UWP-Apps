using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class GameSchedule {
        public GameSchedule(string year, string seasonType, string week) {
            this.Year = year;
            this.SeasonType = seasonType;
            this.Week = week;
        }

        public string Year { get; set; }
        public string SeasonType { get; set; }
        public string  Week { get; set; }
        public string  GameId { get; set; }
        public string Gsis { get; set; }
        public string  Day { get; set; }
        public string Time { get; set; }
        public string AmPm { get; set; }
        public string  K { get; set; }
        public string Home { get; set; }
        public string HomeNickName { get; set; }
        public string Hs { get; set; }
        public string Visitor { get; set; }
        public string VisitorNickName { get; set; }
        public string Vs { get; set; }
        public string P { get; set; }
        public string Rz { get; set; }
        public string  Ga { get; set; }
        public string  GameType { get; set; }


    }
}
