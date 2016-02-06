using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Stats {
        const string gameIdStart = "00-";
        const int gameIdLen = 10;
        public List<Passer> Passers { get; set; }
        public List<Rusher> Rushers { get; set; }
        public List<Receiver> Receivers { get; set; }
        public List<Fumbler> Fumblers { get; set; }
        public List<Defender> Defenders { get; set; }
        public List<Kicker> Kickers { get; set; }
        public List<Punter> Punters { get; set; }
        public List<KickReturner> KickReturners { get; set; }
        public List<PuntReturner> PuntReturners { get; set; }
        public TeamStats TeamStats { get; set; }

        public Stats() {
        }

        public void Initialize(JObject jGame, string gameId, string home_away) {
            Passers = getPassing(jGame, gameId, home_away);
            Rushers = getRushing(jGame, gameId, home_away);
            Receivers = getReceiving(jGame, gameId, home_away);
            Fumblers = getFumbling(jGame, gameId, home_away);
            Defenders = getDefending(jGame, gameId, home_away);
            Kickers = getKicking(jGame, gameId, home_away);
            Punters = getPunting(jGame, gameId, home_away);
            KickReturners = getKickret(jGame, gameId, home_away);
            PuntReturners = getPuntret(jGame, gameId, home_away);
            TeamStats = getTeamStats(jGame, gameId, home_away);
        }

        private List<Passer> getPassing(JObject jGame, string gameId, string home_away) {
            Passer passer = null;
            List<Passer> passers = new List<Passer>();

            JObject passingJson = (JObject)jGame[gameId][home_away]["stats"]["passing"];
            dynamic jpassing = JsonConvert.DeserializeObject(passingJson.ToString());
            foreach (var jpasser in jpassing) {
                string jpassingString = ((JObject)jpassing).ToString(Formatting.None);
                string id = jpassingString.Substring(jpassingString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty);
                foreach (var props in jpasser) {
                    passer = new Passer(
                        id,
                        (string)props["name"],
                        (int)props["att"],
                        (int)props["cmp"],
                        (int)props["yds"],
                        (int)props["tds"],
                        (int)props["ints"],
                        (int)props["twopta"],
                        (int)props["twoptm"]);
                    passers.Add(passer);
                }
            }
            return passers;
        }
        private List<Rusher> getRushing(JObject jGame, string gameId, string home_away) {
            Rusher rusher = null;
            List<Rusher> rushers = new List<Rusher>();

            JObject rushingJson = (JObject)jGame[gameId][home_away]["stats"]["rushing"];
            dynamic jrushing = JsonConvert.DeserializeObject(rushingJson.ToString());
            foreach (var jrusher in jrushing) {
                string jrushingString = ((JObject)jrushing).ToString(Formatting.None);
                string id = jrushingString.Substring(jrushingString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty); ;
                foreach (var props in jrusher) {
                    rusher = new Rusher(
                        id,
                        (string)props["name"],
                        (int)props["att"],
                        (int)props["yds"],
                        (int)props["tds"],
                        (int)props["lng"],
                        (int)props["lngtd"],
                        (int)props["twopta"],
                        (int)props["twoptm"]);
                    rushers.Add(rusher);
                }
            }
            return rushers;
        }
        private List<Receiver> getReceiving(JObject jGame, string gameId, string home_away) {
            Receiver receiver = null;
            List<Receiver> receivers = new List<Receiver>();

            JObject receivingJson = (JObject)jGame[gameId][home_away]["stats"]["receiving"];
            dynamic jreceiving = JsonConvert.DeserializeObject(receivingJson.ToString());
            foreach (var jreceiver in jreceiving) {
                string jreceivingString = ((JObject)jreceiving).ToString(Formatting.None);
                string id = jreceivingString.Substring(jreceivingString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty); ;
                foreach (var props in jreceiver) {
                    receiver = new Receiver(
                        id,
                        (string)props["name"],
                        (int)props["rec"],
                        (int)props["yds"],
                        (int)props["tds"],
                        (int)props["lng"],
                        (int)props["lngtd"],
                        (int)props["twopta"],
                        (int)props["twoptm"]);
                    receivers.Add(receiver);
                }
            }
            return receivers;
        }
        private List<Fumbler> getFumbling(JObject jGame, string gameId, string home_away) {
            Fumbler fumbler = null;
            List<Fumbler> fumblers = new List<Fumbler>();

            JObject fumblingJson = (JObject)jGame[gameId][home_away]["stats"]["fumbles"];
            if (fumblingJson != null) {
                dynamic jfumbling = JsonConvert.DeserializeObject(fumblingJson.ToString());
                foreach (var jfumbler in jfumbling) {
                    string jfumblingString = ((JObject)jfumbling).ToString(Formatting.None);
                    string id = jfumblingString.Substring(jfumblingString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty); ;
                    foreach (var props in jfumbler) {
                        fumbler = new Fumbler(
                            id,
                            (string)props["name"],
                            (int)props["tot"],
                            (int)props["rcv"],
                            (int)props["trcv"],
                            (int)props["yds"],
                            (int)props["lost"]
                            );
                        fumblers.Add(fumbler);
                    }
                }
            }
            return fumblers;
        }
        private List<Kicker> getKicking(JObject jGame, string gameId, string home_away) {
            Kicker kicker = null;
            List<Kicker> kickers = new List<Kicker>();

            JObject kickingJson = (JObject)jGame[gameId][home_away]["stats"]["kicking"];
            dynamic jkicking = JsonConvert.DeserializeObject(kickingJson.ToString());
            foreach (var jkicker in jkicking) {
                string jkickingString = ((JObject)jkicking).ToString(Formatting.None);
                string id = jkickingString.Substring(jkickingString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty); ;
                foreach (var props in jkicker) {
                    kicker = new Kicker(
                        id,
                        (string)props["name"],
                        (int)props["fgm"],
                        (int)props["fga"],
                        (int)props["fgyds"],
                        (int)props["totpfg"],
                        (int)props["xpmade"],
                        (int)props["xpmissed"],
                        (int)props["xpa"],
                        (int)props["xpb"],
                        (int)props["xptot"]);
                    kickers.Add(kicker);
                }
            }
            return kickers;
        }
        private List<Punter> getPunting(JObject jGame, string gameId, string home_away) {
            Punter punter = null;
            List<Punter> punters = new List<Punter>();

            JObject puntingJson = (JObject)jGame[gameId][home_away]["stats"]["punting"];
            dynamic jpunting = JsonConvert.DeserializeObject(puntingJson.ToString());
            foreach (var jpunter in jpunting) {
                string jpuntingString = ((JObject)jpunting).ToString(Formatting.None);
                string id = jpuntingString.Substring(jpuntingString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty);
                foreach (var props in jpunter) {
                    punter = new Punter(
                        id,
                        (string)props["name"],
                        (int)props["pts"],
                        (int)props["yds"],
                        (int)props["avg"],
                        (int)props["i20"],
                        (int)props["lng"]);

                    punters.Add(punter);
                }
            }
            return punters;
        }
        private List<KickReturner> getKickret(JObject jGame, string gameId, string home_away) {
            KickReturner kickReturner = null;
            List<KickReturner> kickReturners = new List<KickReturner>();

            JObject kickretJson = (JObject)jGame[gameId][home_away]["stats"]["kickret"];
            dynamic jkickret = JsonConvert.DeserializeObject(kickretJson.ToString());
            foreach (var jkickReturner in jkickret) {
                string jkickretString = ((JObject)jkickret).ToString(Formatting.None);
                string id = jkickretString.Substring(jkickretString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty); ;
                foreach (var props in jkickReturner) {
                    kickReturner = new KickReturner(
                        id,
                        (string)props["name"],
                        (int)props["ret"],
                        (int)props["avg"],
                        (int)props["tds"],
                        (int)props["lng"],
                        (int)props["lngtd"]);
                    kickReturners.Add(kickReturner);
                }
            }
            return kickReturners;
        }
        private List<PuntReturner> getPuntret(JObject jGame, string gameId, string home_away) {
            PuntReturner puntReturner = null;
            List<PuntReturner> puntReturners = new List<PuntReturner>();

            JObject puntretJson = (JObject)jGame[gameId][home_away]["stats"]["puntret"];
            dynamic jpuntret = JsonConvert.DeserializeObject(puntretJson.ToString());
            foreach (var jpuntReturner in jpuntret) {
                string jpuntretString = ((JObject)jpuntret).ToString(Formatting.None);
                string id = jpuntretString.Substring(jpuntretString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty); ;
                foreach (var props in jpuntReturner) {
                    puntReturner = new PuntReturner(
                        id,
                        (string)props["name"],
                        (int)props["ret"],
                        (int)props["avg"],
                        (int)props["tds"],
                        (int)props["lng"],
                        (int)props["lngtd"]
                        );
                    puntReturners.Add(puntReturner);
                }
            }
            return puntReturners;
        }
        private List<Defender> getDefending(JObject jGame, string gameId, string home_away) {
            Defender defender = null;
            List<Defender> defenders = new List<Defender>();

            JObject defendingJson = (JObject)jGame[gameId][home_away]["stats"]["defense"];
            dynamic jdefending = JsonConvert.DeserializeObject(defendingJson.ToString());
            foreach (var jdefender in jdefending) {
                string jdefendingString = ((JObject)jdefending).ToString(Formatting.None);
                string id = jdefendingString.Substring(jdefendingString.IndexOf(gameIdStart), gameIdLen).Replace(" ", string.Empty); ;
                foreach (var props in jdefender) {
                    defender = new Defender(
                        id,
                        (string)props["name"],
                        (int)props["tkl"],
                        (int)props["ast"],
                        (int)props["sk"],
                        (int)props["int"],
                        (int)props["ffum"]);
                    defenders.Add(defender);
                }
            }
            return defenders;
        }
        private TeamStats getTeamStats(JObject jGame, string gameId, string home_away) {
            TeamStats teamStats = null;

            JObject teamStatsJson = (JObject)jGame[gameId][home_away]["stats"]["team"];
            teamStats = new TeamStats(
                (int)teamStatsJson["totfd"],
                (int)teamStatsJson["totyds"],
                (int)teamStatsJson["pyds"],
                (int)teamStatsJson["ryds"],
                (int)teamStatsJson["pen"],
                (int)teamStatsJson["penyds"],
                (int)teamStatsJson["trnovr"],
                (int)teamStatsJson["pt"],
                (int)teamStatsJson["ptyds"],
                (int)teamStatsJson["ptavg"],
                (string)teamStatsJson["top"]);

            return teamStats;
        }
    }
}
