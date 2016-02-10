using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Prism.Windows.Validation;
using AdventureWorks.Models;
using AdventureWorks.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Repositories;

namespace AdventureWorks.ViewModels {
    public class EditPersonPageViewModel : ViewModelBase {
        private readonly IPersonRepository personRepository;
        private readonly INavigationService navigationService;
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand ValidateCommand { get; private set; }

        #region Constructors

        public EditPersonPageViewModel(IPersonRepository personRepository, INavigationService navigationService) {
            this.personRepository = personRepository;
            this.navigationService = navigationService;

            SaveCommand = new DelegateCommand(SavePerson, CanSavePerson);
            CancelCommand = new DelegateCommand(CancelPerson, CanCancelPerson);
            ValidateCommand = new DelegateCommand(ValidatePerson);

            AllErrors = BindableValidator.EmptyErrorsCollection;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            SelectedPersonVM = e.Parameter as PersonVM;
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private PersonVM selectedPersonVM;
        public PersonVM SelectedPersonVM {
            get { return selectedPersonVM; }
            set {
                SetProperty<PersonVM>(ref selectedPersonVM, value);
                if (SelectedPersonVM != null) {
                    SelectedPersonVM.ErrorsChanged += OnErrorsChanged;
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
        private async void SavePerson() {
            ValidatePerson();
            if (SelectedPersonVM.Errors.Errors.Count > 0) {
                return;
            }

            try {
                // Update Person
                int numberOfRowsAffected = await personRepository.EditPersonAsync(SelectedPersonVM);
            }
            // Catch Server-Side Errors
            catch (ModelValidationException mvex) {
                DisplayServerErrorMessages(mvex.ValidationResult);
            }

            if (SelectedPersonVM.Errors.Errors.Count == 0) {
                AllErrors = BindableValidator.EmptyErrorsCollection;
                if (navigationService.CanGoBack()) {
                    navigationService.GoBack();
                }
                RunAllCanExecuteChanged();
            }
        }
        private bool CanSavePerson() {
            return AllErrors.Count == 0;
        }

        // Cancel AppBarButton
        private void CancelPerson() {
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
            AllErrors = BindableValidator.EmptyErrorsCollection;
            RunAllCanExecuteChanged();
        }
        private bool CanCancelPerson() {
            return true;
        }

        // Refresh Can delegates
        private void RunAllCanExecuteChanged() {
            SaveCommand.RaiseCanExecuteChanged();
            CancelCommand.RaiseCanExecuteChanged();
        }

        // Validate
        private void ValidatePerson() {
            SelectedPersonVM.ValidateProperties();
        }

        #endregion

        #region Utils

        // TODO: Simulate Server Validation errors 
        private void DisplayServerErrorMessages(ModelValidationResult validationResult) {
            var serverErrors = new Dictionary<string, ReadOnlyCollection<string>>();

            // Property keys of the form. Format: person.{Property}
            foreach (var propkey in validationResult.ModelState.Keys) {
                //string orderPropAndEntityProp = propkey.Substring(propkey.IndexOf('.') + 1); // strip off order. prefix
                string personProperty = propkey.Substring(0, propkey.IndexOf('.') + 1);
                string entityProperty = propkey.Substring(personProperty.IndexOf('.') + 1);

                if (personProperty.ToLower().Contains("person")) {
                    serverErrors.Add(entityProperty, new ReadOnlyCollection<string>(validationResult.ModelState[propkey]));
                }
            }

            if (serverErrors.Count > 0) {
                SelectedPersonVM.Errors.SetAllErrors(serverErrors);
            }
        }

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e) {
            AllErrors = new ReadOnlyCollection<string>(SelectedPersonVM.GetAllErrors().Values.SelectMany(c => c).ToList());
        }

        #endregion

    }
}
