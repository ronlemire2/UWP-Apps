using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Rusher {
        public Rusher(string Id, string Name, int Att, int Yds, int Tds, int Lng, int Lngtd, int Twopta, int Twoptm) {
            this.Id = Id;
            this.Name = Name;
            this.Att = Att;
            this.Yds = Yds;
            this.Tds = Tds;
            this.Lng = Lng;
            this.Lngtd = Lngtd;
            this.Twopta = Twopta;
            this.Twoptm = Twoptm;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Att { get; set; }
        public int Yds { get; set; }
        public int Tds { get; set; }
        public int Lng { get; set; }
        public int Lngtd { get; set; }
        public int Twopta { get; set; }
        public int Twoptm { get; set; }
    }
}