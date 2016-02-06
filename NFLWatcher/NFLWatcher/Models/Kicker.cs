using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Kicker {
        public Kicker(string Id, string Name, int Fgm, int Fga, int Totpf, 
                        int Totpfg, int Xpmade, int Xpmissed, int Xpa, int Xpb, int Xptot) {
            this.Id = Id;
            this.Name = Name;
            this.Fgm = Fgm;
            this.Fga = Fga;
            this.Totpf = Totpf;
            this.Totpfg = Totpfg;
            this.Xpmade = Xpmade;
            this.Xpmissed = Xpmissed;
            this.Xpa = Xpa;
            this.Xpb = Xpb;
            this.Xptot = Xptot;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Fgm { get; set; }
        public int Fga { get; set; }
        public int Totpf { get; set; }
        public int Totpfg { get; set; }
        public int Xpmade { get; set; }
        public int Xpmissed { get; set; }
        public int Xpa { get; set; }
        public int Xpb { get; set; }
        public int Xptot { get; set; }
    }
}
