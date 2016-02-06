using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class TeamStats {
        public TeamStats(int Totfd, int Totyds, int Pyds, int Ryds, int Pen, int Penyds, int Trnovr, int Pt, int Ptyds, int Ptavg, string Top) {
            this.Totfd = Totfd;
            this.Totyds = Totyds;
            this.Pyds = Pyds;
            this.Ryds = Ryds;
            this.Pen = Pen;
            this.Penyds = Penyds;
            this.Trnovr = Trnovr;
            this.Pt = Pt;
            this.Ptyds = Ptyds;
            this.Ptavg = Ptavg;
            this.Top = Top;
        }

        public int Totfd { get; set; }
        public int Totyds { get; set; }
        public int Pyds { get; set; }
        public int Ryds { get; set; }
        public int Pen { get; set; }
        public int Penyds { get; set; }
        public int Trnovr { get; set; }
        public int Pt { get; set; }
        public int Ptyds { get; set; }
        public int Ptavg { get; set; }
        public string Top { get; set; }
    }
}
