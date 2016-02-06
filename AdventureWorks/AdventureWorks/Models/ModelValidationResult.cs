using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Models {
    public class ModelValidationResult {
        public ModelValidationResult() {
            ModelState = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> ModelState { get; private set; }
    }
}
