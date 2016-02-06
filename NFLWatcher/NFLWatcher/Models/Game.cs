using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Game {
        const int gameIdLen = 10;

        public String GameId { get; set; }
        public Side Home { get; set; }
        public Side Away { get; set; }
        public ScoringSummary ScoringDetails { get; set; }
        public string Weather { get; set; }
        public string Media { get; set; }
        public string Yl { get; set; }
        public string Qtr { get; set; }
        public string Note { get; set; }
        public int Down { get; set; }
        public int Togo { get; set; }
        public string Redzone { get; set; }
        public string Clock { get; set; }
        public string Posteam { get; set; }
        public string Stadium { get; set; }
        public int NextUpdate { get; set; }

        public Game() {
        }

        public void Initialize(string jStats) {
            string gameId = jStats.Substring(2, gameIdLen);
            GameId = gameId;
            JObject jGame = JObject.Parse(jStats);

            Home = new Side();
            Home.Initialize(jGame, gameId, "home");

            Away = new Side();
            Away.Initialize(jGame, gameId, "away");

            ScoringDetails = new ScoringSummary();
            ScoringDetails.Initialize(jGame, gameId);

            Weather = (string)jGame[gameId]["weather"];
            Media = (string)jGame[gameId]["media"];
            Yl = (string)jGame[gameId]["yl"];
            Qtr = (string)jGame[gameId]["qtr"];
            Note = (string)jGame[gameId]["note"];
            Down = (int)jGame[gameId]["down"];
            Togo = (int)jGame[gameId]["togo"];
            Redzone = (string)jGame[gameId]["redzone"];
            Clock = (string)jGame[gameId]["clock"];
            Posteam = (string)jGame[gameId]["posteam"];
            Stadium = (string)jGame[gameId]["stadium"];
            NextUpdate = (int)jGame["nextupdate"];
        }
    }
}
