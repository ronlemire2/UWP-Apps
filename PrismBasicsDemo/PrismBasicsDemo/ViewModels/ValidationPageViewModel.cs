using Prism.Commands;
using Prism.Windows.AppModel;
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
using Windows.UI.Popups;

namespace PrismBasicsDemo.ViewModels {
    public class ValidationPageViewModel : ViewModelBase {
        private readonly IPlanetRepository planetRepository;
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

        #region Constructors

        public ValidationPageViewModel(IPlanetRepository planetRepository) {
            this.planetRepository = planetRepository;

            ReLoadCommand = new DelegateCommand(ReLoadPlanetVMs);
            AddCommand = new DelegateCommand(AddPlanet, CanAddPlanet);
            EditCommand = new DelegateCommand(EditPlanet, CanEditPlanet);
            SaveCommand = new DelegateCommand(SavePlanet, CanSavePlanet);
            CancelCommand = new DelegateCommand(CancelPlanet, CanCancelPlanet);
            DeleteCommand = new DelegateCommand(DeletePlanet, CanDeletePlanet);
            ValidateCommand = new DelegateCommand(ValidatePlanet);

            IsInEditMode = false;
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
        [RestorableState]
        public PlanetViewModel SelectedPlanetVM {
            get { return selectedPlanetVM; }
            set {
                SetProperty<PlanetViewModel>(ref selectedPlanetVM, value);
                if (SelectedPlanetVM != null) {
                    SelectedPlanetVM.ErrorsChanged += OnErrorsChanged;
                }
                HasSelection = selectedPlanetVM != null;
                RunAllCanExecuteChanged();
            }
        }

        private ReadOnlyCollection<string> _allErrors;
        public ReadOnlyCollection<string> AllErrors {
            get { return _allErrors; }
            set { SetProperty(ref _allErrors, value); }
        }

        public bool HasSelection {
            get { return this.hasSelection; }
            private set { this.SetProperty(ref this.hasSelection, value); }
        }

        public bool IsInEditMode {
            get {
                return isInEditMode;
            }

            set {
                SetProperty(ref isInEditMode, value);
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsInDesignMode {
            get { return Windows.ApplicationModel.DesignMode.DesignModeEnabled; }
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
            PlanetVMs = new ObservableCollection<PlanetViewModel>();
            foreach (Planet planet in planets) {
                PlanetVMs.Add(MapPlanetToPlanetVM(planet));
            }
        }

        // Add AppBarButton
        private void AddPlanet() {
            if (SelectedPlanetVM != null) {
                saveSelectedPlanetId = SelectedPlanetVM.Id;
            }
            SelectedPlanetVM = new PlanetViewModel();
            IsInEditMode = true;
            RunAllCanExecuteChanged();
        }
        private bool CanAddPlanet() {
            return !IsInEditMode;
        }

        // Edit AppBarButton
        protected void EditPlanet() {
            saveSelectedPlanetId = SelectedPlanetVM.Id;
            IsInEditMode = true;
            RunAllCanExecuteChanged();
        }
        protected bool CanEditPlanet() {
            return SelectedPlanetVM != null && !this.IsInEditMode;
        }

        // Save AppBarButton
        private void SavePlanet() {
            ValidatePlanet();
            if (SelectedPlanetVM.Errors.Errors.Count > 0) {
                return;
            }

            try {
                // Create Planet
                if (SelectedPlanetVM.Id == 0) {
                    int newId = planetRepository.CreatePlanet(MapPlanetVMToPlanet(SelectedPlanetVM));
                }
                // Update Planet
                else {
                    int numberOfRowsAffected = planetRepository.UpdatePlanet(MapPlanetVMToPlanet(SelectedPlanetVM));
                }
            }
            // Catch Server-Side Errors
            catch (ModelValidationException mvex) {
                DisplayServerErrorMessages(mvex.ValidationResult);
            }

            if (SelectedPlanetVM.Errors.Errors.Count == 0) {
                if (saveSelectedPlanetId != 0) {
                    GetPlanetVMs();
                    SelectedPlanetVM = PlanetVMs.Where(p => p.Id == saveSelectedPlanetId).FirstOrDefault();
                }
                else {
                    ReLoadPlanetVMs();
                }
                IsInEditMode = false;
                AllErrors = BindableValidator.EmptyErrorsCollection;
                RunAllCanExecuteChanged();
            }
        }
        private bool CanSavePlanet() {
            return this.IsInEditMode && AllErrors.Count == 0;
        }

        // Delete AppBarButton
        // TODO: Confirm delete dialog
        private async void DeletePlanet() {
            var dialog = new MessageDialog(string.Format("Delete {0}?", SelectedPlanetVM.Name));
            dialog.Title = "Are you sure?";
            dialog.Commands.Add(new UICommand { Label = "Delete", Id = 1 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 0 });
            var res = await dialog.ShowAsync();
            if ((int)res.Id == 1) {
                planetRepository.DeletePlanet(SelectedPlanetVM.Id);
            }

            GetPlanetVMs();
            IsInEditMode = false;
            RunAllCanExecuteChanged();
        }
        protected bool CanDeletePlanet() {
            return SelectedPlanetVM != null && !this.IsInEditMode;
        }

        // Cancel AppBarButton
        private void CancelPlanet() {
            IsInEditMode = false;
            if (saveSelectedPlanetId != 0) {
                SelectedPlanetVM = MapPlanetToPlanetVM(planetRepository.GetPlanet(saveSelectedPlanetId));
            }
            else {
                ReLoadPlanetVMs();
            }
            AllErrors = BindableValidator.EmptyErrorsCollection;
            RunAllCanExecuteChanged();
        }
        private bool CanCancelPlanet() {
            return this.IsInEditMode;
        }

        // Validate Button
        private void ValidatePlanet() {
            SelectedPlanetVM.ValidateProperties();
        }

        // Refresh Can delegates
        private void RunAllCanExecuteChanged() {
            ReLoadCommand.RaiseCanExecuteChanged();
            EditCommand.RaiseCanExecuteChanged();
            AddCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
            SaveCommand.RaiseCanExecuteChanged();
            CancelCommand.RaiseCanExecuteChanged();
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
                Id =planetVM.Id,
                Name =planetVM.Name,
                ImagePath =planetVM.ImagePath,
                Mass =planetVM.Mass,
                Diameter =planetVM.Diameter,
                Gravity =planetVM.Gravity,
                LengthOfDay =planetVM.LengthOfDay,
                DistanceFromSun =planetVM.DistanceFromSun,
                OrbitalPeriod =planetVM.OrbitalPeriod,
                MeanTemperature =planetVM.MeanTemperature,
                NumberOfMoons =planetVM.NumberOfMoons
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
