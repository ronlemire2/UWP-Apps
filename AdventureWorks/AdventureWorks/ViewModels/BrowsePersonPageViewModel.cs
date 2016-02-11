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
using AdventureWorks.Services;
using AdventureWorks.Repositories;
using Prism.Windows.Validation;
using Windows.UI.Popups;

namespace AdventureWorks.ViewModels {
    public class BrowsePersonPageViewModel : ViewModelBase {
        private readonly IPersonRepository personRepository;
        private readonly INavigationService navigationService;
        private bool isInEditMode;

        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand EditCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

        #region Constructors

        public BrowsePersonPageViewModel(IPersonRepository personRepository, INavigationService navigationService) {
            this.personRepository = personRepository;
            this.navigationService = navigationService;

            CancelCommand = new DelegateCommand(CancelPerson, CanCancelPerson);
            EditCommand = new DelegateCommand(EditPerson, CanEditPerson);
            DeleteCommand = new DelegateCommand(DeletePerson, CanDeletePerson);

            IsInEditMode = false;
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
            AllErrors = new ReadOnlyCollection<string>(SelectedPersonVM.GetAllErrors().Values.SelectMany(c => c).ToList());
        }

        #endregion

        #region Commands

        // Cancel AppBarButton
        private void CancelPerson() {
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
            AllErrors = BindableValidator.EmptyErrorsCollection;
        }
        private bool CanCancelPerson() {
            return true;
        }

        // Edit AppBarButton
        protected void EditPerson() {
            SelectedPersonVM.CrudState = Models.CrudState.Modified;
            navigationService.Navigate("EditPerson", SelectedPersonVM);
            RunAllCanExecuteChanged();
        }
        protected bool CanEditPerson() {
            return SelectedPersonVM != null && !this.IsInEditMode;
        }

        // Delete AppBarButton
        private async void DeletePerson() {
            var dialog = new MessageDialog(string.Format("Delete {0}?", SelectedPersonVM.BusinessEntityID));
            dialog.Title = "Are you sure?";
            dialog.Commands.Add(new UICommand { Label = "Delete", Id = 1 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 1) {
                SelectedPersonVM.CrudState = Models.CrudState.Deleted;
                await personRepository.DeletePersonAsync(SelectedPersonVM);
            }
            if (navigationService.CanGoBack()) {
                navigationService.GoBack();
            }
        }
        protected bool CanDeletePerson() {
            return SelectedPersonVM != null && !this.IsInEditMode;
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