using Prism.Windows.Validation;
using PrismBasicsDemo.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PrismBasicsDemo.ViewModels {
    public class PlanetViewModel : ValidatableBindableBase {
        private int id;
        public int Id {
            get { return id; }
            set { SetProperty<int>(ref id, value); }
        }

        private string name;
        [Required(ErrorMessageResourceType = typeof(ErrorMessageHelper), ErrorMessageResourceName = "NameRequired")]
        [RegularExpression(Constants.NAME_REGEX_PATTERN, ErrorMessageResourceType = typeof(ErrorMessageHelper), ErrorMessageResourceName = "NameRegex")]
        public string Name {
            get { return name; }
            set { SetProperty<string>(ref name, value); }
        }

        private string imagePath;
        public string ImagePath {
            get { return imagePath; }
            set { SetProperty<string>(ref imagePath, value); }
        }

        private string mass;
        public string Mass {
            get { return mass; }
            set { SetProperty<string>(ref mass, value); }
        }

        private string diameter;
        public string Diameter {
            get { return diameter; }
            set { SetProperty<string>(ref diameter, value); }
        }

        private string gravity;
        public string Gravity {
            get { return gravity; }
            set { SetProperty<string>(ref gravity, value); }
        }

        private string lengthOfDay;
        public string LengthOfDay {
            get { return lengthOfDay; }
            set { SetProperty<string>(ref lengthOfDay, value); }
        }

        private string distanceFromSun;
        [Required(ErrorMessageResourceType = typeof(ErrorMessageHelper), ErrorMessageResourceName = "DistanceFromTheSunRequired")]
        [RegularExpression(Constants.DECIMAL_REGEX_PATTERN, ErrorMessageResourceType = typeof(ErrorMessageHelper), ErrorMessageResourceName = "DistanceFromTheSunRegex")]
        public string DistanceFromSun {
            get { return distanceFromSun; }
            set { SetProperty<string>(ref distanceFromSun, value); }
        }

        private string orbitalPeriod;
        public string OrbitalPeriod {
            get { return orbitalPeriod; }
            set { SetProperty<string>(ref orbitalPeriod, value); }
        }

        private string meanTemperature;
        public string MeanTemperature {
            get { return meanTemperature; }
            set { SetProperty<string>(ref meanTemperature, value); }
        }

        private string numberOfMoons;
        [Required(ErrorMessageResourceType = typeof(ErrorMessageHelper), ErrorMessageResourceName = "NumberOfMoonsRequired")]
        [RegularExpression(Constants.POSITIVE_INTEGER_REGEX_PATTERN, ErrorMessageResourceType = typeof(ErrorMessageHelper), ErrorMessageResourceName = "NumberOfMoonsRegex")]
        public string NumberOfMoons {
            get { return numberOfMoons; }
            set { SetProperty<string>(ref numberOfMoons, value); }
        }

        public ImageSource PlanetImage {
            get {
                // ImagePath contains a path of the form "/Assets/Planets/Earth.png".
                return new BitmapImage(new Uri(new Uri("ms-appx://"), this.ImagePath));
            }
        }
    }
}
