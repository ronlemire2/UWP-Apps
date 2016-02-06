using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NFLWatcher.Models {
    public class WeekSchedule {
        public WeekSchedule(string year, string seasonType, string week) {
            this.Year = year;
            this.SeasonType = seasonType;
            this.Week = week;
        }

        public string Year { get; set; }
        public string SeasonType { get; set; }
        public string Week { get; set; }

        public List<GameSchedule> GameSchedules { get; set; }

        public void Initialize(string xSchedule) {
            XDocument doc = XDocument.Parse(xSchedule);
            var jScheduleSerialized = JsonConvert.SerializeXNode(doc);
            JObject jGame = JObject.Parse(jScheduleSerialized);
            JArray jGames = (JArray)jGame["ss"]["gms"]["g"];

            List<GameSchedule> gameSchedules = new List<GameSchedule>();
            GameSchedule gs;
            for (int i = 0; i < jGames.Count; i++) {
                gs = new GameSchedule(Year, SeasonType, Week);
                gs.GameId = (string)jGame["ss"]["gms"]["g"][i]["@eid"];
                gs.Gsis = (string)jGame["ss"]["gms"]["g"][i]["@gsis"];
                gs.Day = (string)jGame["ss"]["gms"]["g"][i]["@d"];
                gs.Time = (string)jGame["ss"]["gms"]["g"][i]["@t"];
                gs.AmPm = (string)jGame["ss"]["gms"]["g"][i]["@q"];
                gs.K = (string)jGame["ss"]["gms"]["g"][i]["@k"];
                gs.Home = (string)jGame["ss"]["gms"]["g"][i]["@h"];
                gs.HomeNickName = (string)jGame["ss"]["gms"]["g"][i]["@hnn"];
                gs.Hs = (string)jGame["ss"]["gms"]["g"][i]["@hs"];
                gs.Visitor = (string)jGame["ss"]["gms"]["g"][i]["@v"];
                gs.VisitorNickName = (string)jGame["ss"]["gms"]["g"][i]["@vnn"];
                gs.Vs = (string)jGame["ss"]["gms"]["g"][i]["@vs"];
                gs.P = (string)jGame["ss"]["gms"]["g"][i]["@p"];
                gs.Rz = (string)jGame["ss"]["gms"]["g"][i]["@rz"];
                gs.Ga = (string)jGame["ss"]["gms"]["g"][i]["@ga"];
                gs.GameType = (string)jGame["ss"]["gms"]["g"][i]["@gt"];
                gameSchedules.Add(gs);
            }
            GameSchedules = gameSchedules;
        }
    }
}
