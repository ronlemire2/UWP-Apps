using Prism.Commands;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Prism.Windows.Validation;
using PrismBasicsDemo.Events;
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
    public class LifecyclePageViewModel : ViewModelBase {
        private readonly IPlanetRepository planetRepository;
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand AddCommand { get; private set; }

        #region Constructors

        public LifecyclePageViewModel(IPlanetRepository planetRepository, INavigationService navigationService, IEventAggregator eventAggregator) {
            this.planetRepository = planetRepository;
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            AddCommand = new DelegateCommand(AddPlanet, CanAddPlanet);
            AllErrors = BindableValidator.EmptyErrorsCollection;
        }

        private async void HandleTitleChangedEvent(string title) {
            MessageDialog dialog = new MessageDialog(title);
            await dialog.ShowAsync();
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
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

        // Add AppBarButton
        private void AddPlanet() {
            SelectedPlanetVM = new PlanetViewModel();
            navigationService.Navigate("LifecycleAdd", SelectedPlanetVM.Id);

            //navigationService.Navigate("LifecycleAdd", SelectedPlanetVM);
            // 1/8/2016 - Even though I have 'SessionStateService.RegisterKnownType(typeof(PlanetViewModel));'
            // in App.xaml.cs, when SelectedPlanetVM is passed in .Navigate I get this error:
            // Exception: "Session state service failed"
            // InnerExecption: "Unspecified error\r\n\r\nGetNavigationState doesn't support serialization of a parameter type
            //                  which was passed to Frame.Navigate."
            // 1/12/2016 - Here is a good discussion of the problem: // https://social.msdn.microsoft.com/Forums/en-US/ad753362-0d52-42b3-8917-b2897033ba49/getnavigationstate-doesnt-support-serialization-of-a-parameter-type-which-was-passed-to?forum=winappswithcsharp
            // Another: http://stackoverflow.com/questions/23896488/getnavigationstate-doesnt-support-serialization-of-a-parameter-type-which-was-p
            // Another: http://www.damirscorner.com/blog/posts/20120923-UsingSuspensionManagerForSavingApplicationState.html
            // Bottom Line: Pass the Id; if Id == 0, create a new PlanetViewModel; if Id != 0, GetPlanet(id) and map to PlanetViewModel.
        }
        private bool CanAddPlanet() {
            return true;
        }

        // Refresh Can delegates
        private void RunAllCanExecuteChanged() {
            AddCommand.RaiseCanExecuteChanged();
        }

        #endregion


        #region Utils

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e) {
            AllErrors = new ReadOnlyCollection<string>(SelectedPlanetVM.GetAllErrors().Values.SelectMany(c => c).ToList());
        }

        #endregion
    }
}
