using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class ScoringSummary {
        public ScoringSummary() {

        }

        public List<ScoringDetails> ScoringDetailsList { get; set; }

        public void Initialize(JObject jGame, string gameId) {
            ScoringDetailsList = getScoringDetailsList(jGame, gameId);
        }

        private List<ScoringDetails> getScoringDetailsList(JObject jGame, string gameId) {
            List<ScoringDetails> scoringDetailsList = new List<ScoringDetails>();
            ScoringDetails scrSummary = null;
            int pos = 0;
            //List<Player> players = null;

            JObject scrSummaryJson = (JObject)jGame[gameId]["scrsummary"];
            dynamic jscrSummary = JsonConvert.DeserializeObject(scrSummaryJson.ToString());
            foreach (var jsummary in jscrSummary) {
                string jsummaryString = jsummary.ToString();
                pos = jsummaryString.IndexOf(":");
                string id = jsummaryString.Substring(0, pos);
                id = id.Replace("{\r\n", string.Empty);
                id = id.Replace("\"", string.Empty).Trim();
                id = id.Replace("}", string.Empty).Trim();

                foreach (var props in jsummary) {
                    scrSummary = new ScoringDetails(
                        id,
                        (string)props["type"],
                        (string)props["desc"],
                        (int)props["qtr"],
                        (string)props["team"],
                        BuildPlayersList(props["players"]));
                    scoringDetailsList.Add(scrSummary);
                }
                pos = pos + jsummaryString.Length;
            }
            return scoringDetailsList;
        }

        private List<Player> BuildPlayersList(JObject jplayers) {
            List<Player> playersList = new List<Player>();
            Player player = null;
            string playerName = string.Empty;
            string playerId = string.Empty;
            string[] playerSplit = null;

            dynamic dplayers = JsonConvert.DeserializeObject(jplayers.ToString());
            string dplayersString = ((JObject)dplayers).ToString(Formatting.None);
            string[] dplayersSplit = dplayersString.Split(',');
            foreach (var dplayer in dplayersSplit) {
                playerSplit = dplayer.Split(':');
                playerName = playerSplit[0];
                playerName = playerName.Replace("{\r\n", string.Empty);
                playerName = playerName.Replace("\"", string.Empty).Trim();
                playerName = playerName.Replace("}", string.Empty).Trim();
                playerId = playerSplit[1];
                playerId = playerId.Replace("\r\n", string.Empty);
                playerId = playerId.Replace("\"", string.Empty).Trim();
                playerId = playerId.Replace("}", string.Empty).Trim();
                player = new Player(playerName, playerId);
                playersList.Add(player);
            }
            return playersList;
        }
    }

}
