using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {

    public class ScoringDetails {
        public ScoringDetails(string Id, string ScoreType, string Desc, int Qtr, string Team, List<Player> Players) {
            this.Id = Id;
            this.ScoreType = ScoreType;
            this.Desc = Desc;
            this.Qtr = Qtr;
            this.Team = Team;
            this.Players = Players;
        }

        public string Id { get; set; }
        public string ScoreType { get; set; }
        public string Desc { get; set; }
        public int Qtr { get; set; }
        public string Team { get; set; }
        public List<Player> Players { get; set; }
    }
 }
