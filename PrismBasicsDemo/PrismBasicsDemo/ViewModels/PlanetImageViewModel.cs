using Prism.Events;
using Prism.Windows.Mvvm;
using PrismBasicsDemo.Events;
using PrismBasicsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PrismBasicsDemo.ViewModels {
    public class PlanetImageViewModel : ViewModelBase {
        private IEventAggregator eventAggregator;

        public PlanetImageViewModel(IEventAggregator eventAggregator) {
            this.eventAggregator = eventAggregator;

            // Subscribe to PlanetChangedEvent always on UI Thread
            this.eventAggregator.GetEvent<PlanetChangedEvent>().Subscribe(HandlePlanetChangedEvent, ThreadOption.UIThread);
        }

        private void HandlePlanetChangedEvent(Planet planet) {
            if (planet != null) {
                ImagePath = planet.ImagePath;
            }
            else {
                ImagePath = string.Empty;
            }
        }

        private string imagePath;
        public string ImagePath {
            get { return imagePath; }
            set { SetProperty<string>(ref imagePath, value); }
        }

        public ImageSource PlanetImage {
            get {
                // ImagePath contains a path of the form "/Assets/Planets/Earth.png".
                return new BitmapImage(new Uri(new Uri("ms-appx://"), this.ImagePath));
            }
        }
    }
}
