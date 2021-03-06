﻿using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Prism.Windows.Validation;
using AdventureWorks.Models;
using AdventureWorks.Services;
using AdventureWorks.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.ViewModels {
    public class PersonPageViewModel : ViewModelBase {
        private readonly IPersonRepository personRepository;
        private readonly INavigationService navigationService;
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand EditCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand ValidateCommand { get; private set; }
        public DelegateCommand PersonsListViewSelectionChangedCommand { get; set; }

        #region Constructors

        public PersonPageViewModel(IPersonRepository personRepository, INavigationService navigationService) {
            this.personRepository = personRepository;
            this.navigationService = navigationService;

            AddCommand = new DelegateCommand(AddPerson, CanAddPerson);
            PersonsListViewSelectionChangedCommand = new DelegateCommand(ExecutePersonsListViewSelectionChangedCommand,
    CanExecutePersonsListViewSelectionChangedCommand);

            AllErrors = BindableValidator.EmptyErrorsCollection;
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            if (e.NavigationMode != Windows.UI.Xaml.Navigation.NavigationMode.Back) {
                Loading = true;
                List<PersonVM> personVMs = await personRepository.GetPersonsAsync();
                PersonVMs = new ObservableCollection<PersonVM>(personVMs.OrderBy(p => p.LastName));
                SelectedPersonVM = null;
                Loading = false;
            }
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<PersonVM> personVMs;
        public ObservableCollection<PersonVM> PersonVMs {
            get { return personVMs; }
            set { SetProperty<ObservableCollection<PersonVM>>(ref personVMs, value); }
        }

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

        private bool loading;
        public bool Loading {
            get { return loading; }
            set {
                SetProperty<bool>(ref loading, value);
            }
        }

        #endregion

        #region Commands

        private async void GetPersonVMs() {
            List<PersonVM> personVMs = await personRepository.GetPersonsAsync();
        }

        // Add AppBarButton
        private void AddPerson() {
            SelectedPersonVM = new PersonVM();
            navigationService.Navigate("AddPerson", SelectedPersonVM);
        }
        private bool CanAddPerson() {
            return true;
        }

        // ListView SelectionChanged
        private void ExecutePersonsListViewSelectionChangedCommand() {
            navigationService.Navigate("BrowsePerson", SelectedPersonVM);
        }
        private bool CanExecutePersonsListViewSelectionChangedCommand() {
            return true;
        }

        // Refresh Can delegates
        private void RunAllCanExecuteChanged() {
            AddCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Utils

        // TODO: Simulate Server Validation errors 
        private void DisplayServerErrorMessages(ModelValidationResult validationResult) {
            var serverErrors = new Dictionary<string, ReadOnlyCollection<string>>();

            // Property keys of the form. Format: person.{Property}
            foreach (var propkey in validationResult.ModelState.Keys) {
                //string personPropAndEntityProp = propkey.Substring(propkey.IndexOf('.') + 1); // strip off person. prefix
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
