using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace PrismBasicsDemo.Attributes {
    public static class ErrorMessageHelper {
        private static readonly ResourceLoader _resourceLoader = new ResourceLoader();

        public static string NameRequired {
            get { return _resourceLoader.GetString("ErrorNameRequired"); }
        }
        public static string NameRegex {
            get { return _resourceLoader.GetString("ErrorNameRegex"); }
        }

        public static string NumberOfMoonsRequired {
            get { return _resourceLoader.GetString("ErrorNumberOfMoonsRequired"); }
        }
        public static string NumberOfMoonsRegex {
            get { return _resourceLoader.GetString("ErrorNumberOfMoonsRegex"); }
        }

        public static string DistanceFromTheSunRequired {
            get { return _resourceLoader.GetString("ErrorDistanceFromTheSunRequired"); }
        }
        public static string DistanceFromTheSunRegex {
            get { return _resourceLoader.GetString("ErrorDistanceFromTheSunRegex"); }
        }
    }
}
