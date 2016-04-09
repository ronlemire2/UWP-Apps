using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotViewer.Models {
    public class Screenshot {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Repository { get; set; }
        public string App { get; set; }
        public string Notes { get; set; }

        public Screenshot() {

        }

        public Screenshot(int Id, string Name, string Description, string ImagePath, string Repository, string App, string Notes) {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.ImagePath = ImagePath;
            this.Repository = Repository;
            this.App = App;
            this.Notes = Notes;
        }
    }
}
