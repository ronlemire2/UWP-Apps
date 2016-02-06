using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.ViewModels {
    public class BoxScoreParameters {
        public GameViewModel GamePageVM { get; set; }
        public string SelectedYear { get; set; }
        public string SelectedSeason { get; set; }
        public string SelectedWeek { get; set; }
    }
}
