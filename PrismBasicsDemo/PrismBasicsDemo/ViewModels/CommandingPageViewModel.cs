using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismBasicsDemo.Models;
using PrismBasicsDemo.Services;
using PrismBasicsDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBasicsDemo.ViewModels {
    public class CommandingPageViewModel : ViewModelBase {
        private IPlanetRepository planetRepository;
        public DelegateCommand PopulateListViewCommand { get; set; }
        public DelegateCommand PlanetsListViewSelectionChangedCommand { get; set; }

        public CommandingPageViewModel(IPlanetRepository planetRepository) {
            this.planetRepository = planetRepository;

            PopulateListViewCommand = new DelegateCommand(ExecutePopulateListViewCommand, CanExecutePopulateListViewCommand);
            PlanetsListViewSelectionChangedCommand = new DelegateCommand(ExecutePlanetsListViewSelectionChangedCommand,
                CanExecutePlanetsListViewSelectionChangedCommand);
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {

            base.OnNavigatedTo(e, viewModelState);
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
        }
        private bool CanExecutePopulateListViewCommand() {
            return true;
        }

        private async void ExecutePlanetsListViewSelectionChangedCommand() {
            if (SelectedPlanet != null) {
                PlanetDialog dialog = new PlanetDialog();
                dialog.Title = SelectedPlanet.Name;
                dialog.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                ((PlanetViewModel)dialog.DataContext).ImagePath = SelectedPlanet.ImagePath;
                await dialog.ShowAsync();
            }
        }
        private bool CanExecutePlanetsListViewSelectionChangedCommand() {
            return true;
        }
    }
}
