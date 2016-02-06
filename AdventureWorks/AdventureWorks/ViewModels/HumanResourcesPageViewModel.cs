using AdventureWorks.Repositories;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using System.Collections.ObjectModel;
using AdventureWorks.Models;

namespace AdventureWorks.ViewModels {
    public class HumanResourcesPageViewModel : ViewModelBase {
        private readonly IPersonRepository personRepository;

        #region Constructors

        public HumanResourcesPageViewModel(IPersonRepository personRepository) {
            this.personRepository = personRepository;
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            PersonVMs = new ObservableCollection<PersonVM>(await personRepository.GetPeopleAsync());
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private ObservableCollection<PersonVM> personVMs;
        public ObservableCollection<PersonVM> PersonVMs {
            get { return personVMs; }
            set {
                SetProperty<ObservableCollection<PersonVM>>(ref personVMs, value);
            }
        }


        #endregion
    }
}
