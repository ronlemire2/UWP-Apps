using Prism.Commands;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Prism.Windows.Validation;
using PrismBasicsDemo.Events;
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
    public class PlanetAddPageViewModel : ViewModelBase {
        private readonly IPlanetRepository planetRepository;
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand ValidateCommand { get; private set; }

        #region Constructors

        public PlanetAddPageViewModel(IPlanetRepository planetRepository, INavigationService navigationService, IEventAggregator eventAggregator) {
            this.planetRepository = planetRepository;
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;

            SaveCommand = new DelegateCommand(SavePlanet, CanSavePlanet);
            CancelCommand = new DelegateCommand(CancelPlanet, CanCancelPlanet);
            ValidateCommand = new DelegateCommand(ValidatePlanet);

            AllErrors = BindableValidator.EmptyErrorsCollection;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            SelectedPlanetVM = e.Parameter as PlanetViewModel;
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Add Planet");
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

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

        // Save AppBarButton
        private void SavePlanet() {
            ValidatePlanet();
            if (SelectedPlanetVM.Errors.Errors.Count > 0) {
                return;
            }

            try {
                // Create Planet
                int newId = planetRepository.CreatePlanet(MapPlanetVMToPlanet(SelectedPlanetVM));
            }
            // Catch Server-Side Errors
            catch (ModelValidationException mvex) {
                DisplayServerErrorMessages(mvex.ValidationResult);
            }

            if (SelectedPlanetVM.Errors.Errors.Count == 0) {
                AllErrors = BindableValidator.EmptyErrorsCollection;
                if (navigationService.CanGoBack()) {
                    navigationService.GoBack();
                }
                RunAllCanExecuteChanged();
            }
        }
        private bool CanSavePlanet() {
            return AllErrors.Count == 0;
        }

        // Cancel AppBarButton
        private void CancelPlanet() {
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
            AllErrors = BindableValidator.EmptyErrorsCollection;
            RunAllCanExecuteChanged();
        }
        private bool CanCancelPlanet() {
            return true;
        }

        // Refresh Can delegates
        private void RunAllCanExecuteChanged() {
            SaveCommand.RaiseCanExecuteChanged();
            CancelCommand.RaiseCanExecuteChanged();
        }

        // Validate
        private void ValidatePlanet() {
            SelectedPlanetVM.ValidateProperties();
        }

        #endregion

        #region Utils

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
