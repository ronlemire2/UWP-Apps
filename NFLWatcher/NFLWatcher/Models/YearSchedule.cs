using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class YearSchedule {
        public YearSchedule(string year, string seasonType, List<WeekSchedule> weeks) {
            this.Year = year;
            this.SeasonType = seasonType;
            this.Weeks = weeks;
        }

        public string Year { get; set; }
        public string SeasonType { get; set; }
        public List<WeekSchedule> Weeks { get; set; }
    }
   
}
