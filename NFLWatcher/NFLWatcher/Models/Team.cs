using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Team {

        public Team(string Id, string Abbr, string City, string NickName, string FullName, string ImagePath ) {
            this.Id = Id;
            this.Abbr = Abbr;
            this.City = City;
            this.NickName = NickName;
            this.FullName = FullName;
            this.ImagePath = ImagePath;
        }
        public string Id { get; set; }
        public string Abbr { get; set; }
        public string City { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }
    }
}
