using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLWatcher.Models {
    public class Defender {
        public Defender(string Id, string Name, int Tkl, int Ast, int Sk, int Int, int Ffum) {
            this.Name = Name;
            this.Tkl = Tkl;
            this.Ast = Ast;
            this.Sk = Sk;
            this.Int = Int;
            this.Ffum = Ffum;
            this.Id = Id;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Tkl { get; set; }
        public int Ast { get; set; }
        public int Sk { get; set; }
        public int Int { get; set; }
        public int Ffum { get; set; }
    }
}
