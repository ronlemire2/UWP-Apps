using Prism.Commands;
using Prism.Events;
using Prism.Windows.Mvvm;
using PrismBasicsDemo.Events;
using PrismBasicsDemo.Models;
using PrismBasicsDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBasicsDemo.ViewModels {
    public class EventAggregatorPageViewModel : ViewModelBase {
        private IPlanetRepository planetRepository;
        private IEventAggregator eventAggregator;
        public DelegateCommand PopulateListViewCommand { get; set; }
        public DelegateCommand PlanetsListViewSelectionChangedCommand { get; set; }
        public PlanetImageViewModel PlanetImageViewModel { get; set; }

        public EventAggregatorPageViewModel(IEventAggregator eventAggregator, IPlanetRepository planetRepository) {
            this.planetRepository = planetRepository;
            this.eventAggregator = eventAggregator;
            PlanetImageViewModel = new PlanetImageViewModel(eventAggregator);

            PopulateListViewCommand = new DelegateCommand(ExecutePopulateListViewCommand, CanExecutePopulateListViewCommand);
            PlanetsListViewSelectionChangedCommand = new DelegateCommand(ExecutePlanetsListViewSelectionChangedCommand,
                CanExecutePlanetsListViewSelectionChangedCommand);
        }

        private ObservableCollection<Planet> planets;
        public ObservableCollection<Planet> Planets {
            get { return planets; }
            set {
                SetProperty<ObservableCollection<Planet>>(ref planets, value);
            }
        }

        private Planet selectedPlanet;
        public Planet SelectedPlanet {
            get { return selectedPlanet; }
            set {
                SetProperty<Planet>(ref selectedPlanet, value);
            }
        }

        private void ExecutePopulateListViewCommand() {
            Planets = new ObservableCollection<Planet>(
                planetRepository.ReLoadPlanets().OrderBy(p => p.Name));
            eventAggregator.GetEvent<PlanetChangedEvent>().Publish(null);
        }
        private bool CanExecutePopulateListViewCommand() {
            return true;
        }

        private void ExecutePlanetsListViewSelectionChangedCommand() {
            // Fire PlanetChangedEvent on UI Thread
            eventAggregator.GetEvent<PlanetChangedEvent>().Publish(SelectedPlanet);
        }
        private bool CanExecutePlanetsListViewSelectionChangedCommand() {
            return true;
        }
    }
}
