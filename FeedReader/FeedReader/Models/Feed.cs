using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedReader.Models {
    public class Feed : BindableBase {
        private string feedName;
        public string FeedName {
            get { return feedName; }
            set {
                SetProperty<string>(ref feedName, value);
            }
        }

        private string link;
        public string Link {
            get { return link; }
            set {
                SetProperty<string>(ref link, value);
            }
        }

        private string lastUpdated;
        public string LastUpdated {
            get { return lastUpdated; }
            set {
                SetProperty<string>(ref lastUpdated, value);
            }
        }
    }
}
