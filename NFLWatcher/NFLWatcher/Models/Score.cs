using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Score {
        public Score() {
        }

        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Q5 { get; set; }
        public int Total { get; set; }

        public void Initialize(JObject jGame, string gameId, string home_away) {
            Q1 = (int)jGame[gameId][home_away]["score"]["1"];
            Q2 = (int)jGame[gameId][home_away]["score"]["2"];
            Q3 = (int)jGame[gameId][home_away]["score"]["3"];
            Q4 = (int)jGame[gameId][home_away]["score"]["4"];
            Q5 = (int)jGame[gameId][home_away]["score"]["5"];
            Total = (int)jGame[gameId][home_away]["score"]["T"];
        }
    }
}
