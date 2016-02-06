using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Side {
        public Side() {
        }

        public Score Score { get; set; }
        public string Abbr { get; set; }
        public int To { get; set; }
        public Stats Stats { get; set; }

        public void Initialize(JObject jGame, string gameId, string home_away) {
            Score = new Score();
            Score.Initialize(jGame, gameId, home_away);

            Abbr = (string)jGame[gameId][home_away]["abbr"];
            To = (int)jGame[gameId][home_away]["to"];

            Stats = new Stats();
            Stats.Initialize(jGame, gameId, home_away);
        }
    }
}
