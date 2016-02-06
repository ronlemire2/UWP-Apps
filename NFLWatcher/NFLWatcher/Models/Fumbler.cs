using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Fumbler {
        public Fumbler(string Id, string Name, int Tot, int Rcv, int Trcv, int Yds, int Lost) {
            this.Id = Id;
            this.Name = Name;
            this.Tot = Tot;
            this.Rcv = Rcv;
            this.Trcv = Trcv;
            this.Lost = Lost;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Tot { get; set; }
        public int Rcv { get; set; }
        public int Trcv { get; set; }
        public int Yds { get; set; }
        public int Lost { get; set; }
    }
}
