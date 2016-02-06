using Prism.Windows.Mvvm;
using PrismBasicsDemo.Models;
using PrismBasicsDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBasicsDemo.ViewModels {
    public class MvvmPageViewModel : ViewModelBase {
        private readonly IPlanetRepository planetRepository;
        private ObservableCollection<PlanetViewModel> planetVMs;
        private PlanetViewModel selectedPlanetVM;

        public MvvmPageViewModel(IPlanetRepository planetRepository) {
            this.planetRepository = planetRepository;
            List<Planet> planets = planetRepository.ReLoadPlanets();

            PlanetVMs = new ObservableCollection<PlanetViewModel>();
            foreach (Planet p in planets) {
                PlanetVMs.Add(new PlanetViewModel {
                    Id = p.Id,
                    Name = p.Name,
                    ImagePath = p.ImagePath,
                    Mass = p.Mass,
                    Diameter = p.Diameter,
                    Gravity = p.Gravity,
                    LengthOfDay = p.LengthOfDay,
                    DistanceFromSun = p.DistanceFromSun,
                    OrbitalPeriod = p.OrbitalPeriod,
                    MeanTemperature = p.MeanTemperature,
                    NumberOfMoons = p.NumberOfMoons
                });
            }

            SelectedPlanetVM = PlanetVMs[2];
        }


        public ObservableCollection<PlanetViewModel> PlanetVMs {
            get { return planetVMs; }
            set { SetProperty<ObservableCollection<PlanetViewModel>>(ref planetVMs, value); }
        }

        public PlanetViewModel SelectedPlanetVM {
            get { return selectedPlanetVM; }
            set { SetProperty<PlanetViewModel>(ref selectedPlanetVM, value); }
        }

        public int PlanetCount {
            get { return PlanetVMs.Count - 1; }
        }
    }
}
