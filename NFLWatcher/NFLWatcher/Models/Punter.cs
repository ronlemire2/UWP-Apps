using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Punter {
        public Punter(string Id, string Name, int Pts, int Yds, int Avg, int i20, int Lng) {
            this.Id = Id;
            this.Name = Name;
            this.Pts = Pts;
            this.Yds = Yds;
            this.Avg = Avg;
            this.i20 = i20;
            this.Lng = Lng;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Pts { get; set; }
        public int Yds { get; set; }
        public int Avg { get; set; }
        public int i20 { get; set; }
        public int Lng { get; set; }
    }
}
