using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Passer {
        public Passer(string Id, string Name, int Att, int Cmp, int Yds, int Tds, int Ints, int Twopta, int Twoptm) {
            this.Id = Id;
            this.Name = Name;
            this.Att = Att;
            this.Cmp = Cmp;
            this.Yds = Yds;
            this.Tds = Tds;
            this.Ints = Ints;
            this.Twopta = Twopta;
            this.Twoptm = Twoptm;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Att { get; set; }
        public int Cmp { get; set; }
        public int Yds { get; set; }
        public int Tds { get; set; }
        public int Ints { get; set; }
        public int Twopta { get; set; }
        public int Twoptm { get; set; }
    }
}
