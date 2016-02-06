using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class PuntReturner {
        public PuntReturner(string Id, string Name, int Ret, int Avg, int Tds, int Lng, int Lngtd) {
            this.Id = Id;
            this.Name = Name;
            this.Ret = Ret;
            this.Avg = Avg;
            this.Tds = Tds;
            this.Lng = Lng;
            this.Lngtd = Lngtd;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Ret { get; set; }
        public int Avg { get; set; }
        public int Tds { get; set; }
        public int Lng { get; set; }
        public int Lngtd { get; set; }

    }
}