using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Prism.Windows.Validation;
using PrismBasicsDemo.Models;
using PrismBasicsDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBasicsDemo.ViewModels {
    public class NavigationPageViewModel : ViewModelBase {
        private readonly IPlanetRepository planetRepository;
        private readonly INavigationService navigationService;
        private bool hasSelection = false;
        private bool isInEditMode;
        int saveSelectedPlanetId;
        public DelegateCommand ReLoadCommand { get; private set; }
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand EditCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand ValidateCommand { get; private set; }
        public DelegateCommand PlanetsListViewSelectionChangedCommand { get; set; }

        #region Constructors

        public NavigationPageViewModel(IPlanetRepository planetRepository, INavigationService navigationService) {
            this.planetRepository = planetRepository;
            this.navigationService = navigationService;

            ReLoadCommand = new DelegateCommand(ReLoadPlanetVMs);
            AddCommand = new DelegateCommand(AddPlanet, CanAddPlanet);
            PlanetsListViewSelectionChangedCommand = new DelegateCommand(ExecutePlanetsListViewSelectionChangedCommand,
    CanExecutePlanetsListViewSelectionChangedCommand);

            AllErrors = BindableValidator.EmptyErrorsCollection;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            ReLoadPlanetVMs();
            if ((PlanetViewModel)e.Parameter != null) {
                SelectedPlanetVM = e.Parameter as PlanetViewModel;
            }
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<PlanetViewModel> planetVMs;
        public ObservableCollection<PlanetViewModel> PlanetVMs {
            get { return planetVMs; }
            set { SetProperty<ObservableCollection<PlanetViewModel>>(ref planetVMs, value); }
        }

        private PlanetViewModel selectedPlanetVM;
        public PlanetViewModel SelectedPlanetVM {
            get { return selectedPlanetVM; }
            set {
                SetProperty<PlanetViewModel>(ref selectedPlanetVM, value);
                if (SelectedPlanetVM != null) {
                    SelectedPlanetVM.ErrorsChanged += OnErrorsChanged;
                }
                RunAllCanExecuteChanged();
            }
        }

        private ReadOnlyCollection<string> _allErrors;
        public ReadOnlyCollection<string> AllErrors {
            get { return _allErrors; }
            set { SetProperty(ref _allErrors, value); }
        }

        #endregion

        #region Commands

        // ReLoad AppBarButton
        private void ReLoadPlanetVMs() {
            List<Planet> planets = planetRepository.ReLoadPlanets();
            PlanetVMs = new ObservableCollection<PlanetViewModel>();
            foreach (Planet planet in planets) {
                PlanetVMs.Add(MapPlanetToPlanetVM(planet));
            }
        }

        private void GetPlanetVMs() {
            List<Planet> planets = planetRepository.GetPlanets();
            if (planets == null) {
                planets = planetRepository.ReLoadPlanets();
            }
            PlanetVMs = new ObservableCollection<PlanetViewModel>();
            foreach (Planet planet in planets) {
                PlanetVMs.Add(MapPlanetToPlanetVM(planet));
            }
        }

        // Add AppBarButton
        private void AddPlanet() {
            SelectedPlanetVM = new PlanetViewModel();
            navigationService.Navigate("PlanetAdd", SelectedPlanetVM);
        }
        private bool CanAddPlanet() {
            return true;
        }

        // ListView SelectionChanged
        private void ExecutePlanetsListViewSelectionChangedCommand() {
            navigationService.Navigate("PlanetBrowse", SelectedPlanetVM);
        }
        private bool CanExecutePlanetsListViewSelectionChangedCommand() {
            return true;
        }

        // Refresh Can delegates
        private void RunAllCanExecuteChanged() {
            ReLoadCommand.RaiseCanExecuteChanged();
            AddCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Utils

        // Planet -> PlanetVM  Mapper
        // TODO: use AutoMapper instead https://github.com/AutoMapper/AutoMapper/wiki
        private PlanetViewModel MapPlanetToPlanetVM(Planet planet) {
            return new PlanetViewModel {
                Id = planet.Id,
                Name = planet.Name,
                ImagePath = planet.ImagePath,
                Mass = planet.Mass,
                Diameter = planet.Diameter,
                Gravity = planet.Gravity,
                LengthOfDay = planet.LengthOfDay,
                DistanceFromSun = planet.DistanceFromSun,
                OrbitalPeriod = planet.OrbitalPeriod,
                MeanTemperature = planet.MeanTemperature,
                NumberOfMoons = planet.NumberOfMoons
            };
        }

        // PlanetVM -> Planet Mapper
        // TODO: use AutoMapper instead https://github.com/AutoMapper/AutoMapper/wiki
        private Planet MapPlanetVMToPlanet(PlanetViewModel planetVM) {
            return new Planet {
                Id = planetVM.Id,
                Name = planetVM.Name,
                ImagePath = planetVM.ImagePath,
                Mass = planetVM.Mass,
                Diameter = planetVM.Diameter,
                Gravity = planetVM.Gravity,
                LengthOfDay = planetVM.LengthOfDay,
                DistanceFromSun = planetVM.DistanceFromSun,
                OrbitalPeriod = planetVM.OrbitalPeriod,
                MeanTemperature = planetVM.MeanTemperature,
                NumberOfMoons = planetVM.NumberOfMoons
            };
        }

        // TODO: Simulate Server Validation errors 
        private void DisplayServerErrorMessages(ModelValidationResult validationResult) {
            var serverErrors = new Dictionary<string, ReadOnlyCollection<string>>();

            // Property keys of the form. Format: product.{Property}
            foreach (var propkey in validationResult.ModelState.Keys) {
                //string orderPropAndEntityProp = propkey.Substring(propkey.IndexOf('.') + 1); // strip off order. prefix
                string orderProperty = propkey.Substring(0, propkey.IndexOf('.') + 1);
                string entityProperty = propkey.Substring(orderProperty.IndexOf('.') + 1);

                if (orderProperty.ToLower().Contains("product")) {
                    serverErrors.Add(entityProperty, new ReadOnlyCollection<string>(validationResult.ModelState[propkey]));
                }
            }

            if (serverErrors.Count > 0) {
                SelectedPlanetVM.Errors.SetAllErrors(serverErrors);
            }
        }

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e) {
            AllErrors = new ReadOnlyCollection<string>(SelectedPlanetVM.GetAllErrors().Values.SelectMany(c => c).ToList());
        }


        #endregion
    }
}
