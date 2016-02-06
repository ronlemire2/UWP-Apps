using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Prism.Commands;
using PrismBasicsDemo.Services;
using Prism.Windows.Validation;
using Windows.UI.Popups;

namespace PrismBasicsDemo.ViewModels {
    public class PlanetBrowsePageViewModel :ViewModelBase {
        private readonly IPlanetRepository planetRepository;
        private readonly INavigationService navigationService;
        private bool isInEditMode;
        int saveSelectedPlanetId;

        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand EditCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

        #region Constructors

        public PlanetBrowsePageViewModel(IPlanetRepository planetRepository, INavigationService navigationService) {
            this.planetRepository = planetRepository;
            this.navigationService = navigationService;

            CancelCommand = new DelegateCommand(CancelPlanet, CanCancelPlanet);
            EditCommand = new DelegateCommand(EditPlanet, CanEditPlanet);
            DeleteCommand = new DelegateCommand(DeletePlanet, CanDeletePlanet);

            IsInEditMode = false;
            AllErrors = BindableValidator.EmptyErrorsCollection;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            SelectedPlanetVM = e.Parameter as PlanetViewModel;
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

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e) {
            AllErrors = new ReadOnlyCollection<string>(SelectedPlanetVM.GetAllErrors().Values.SelectMany(c => c).ToList());
        }

        #endregion

        #region Commands

        // Cancel AppBarButton
        private void CancelPlanet() {
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
            AllErrors = BindableValidator.EmptyErrorsCollection;
        }
        private bool CanCancelPlanet() {
            return true;
        }

        // Edit AppBarButton
        protected void EditPlanet() {
            navigationService.Navigate("PlanetEdit", SelectedPlanetVM);
            RunAllCanExecuteChanged();
        }
        protected bool CanEditPlanet() {
            return SelectedPlanetVM != null && !this.IsInEditMode;
        }

        // Delete AppBarButton
        private async void DeletePlanet() {
            var dialog = new MessageDialog(string.Format("Delete {0}?", SelectedPlanetVM.Name));
            dialog.Title = "Are you sure?";
            dialog.Commands.Add(new UICommand { Label = "Delete", Id = 1 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 1) {
                planetRepository.DeletePlanet(SelectedPlanetVM.Id);
            }
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
        }
        protected bool CanDeletePlanet() {
            return SelectedPlanetVM != null && !this.IsInEditMode;
        }

        // Refresh Can delegates
        private void RunAllCanExecuteChanged() {
            CancelCommand.RaiseCanExecuteChanged();
            EditCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
        }

        #endregion


    }
}
