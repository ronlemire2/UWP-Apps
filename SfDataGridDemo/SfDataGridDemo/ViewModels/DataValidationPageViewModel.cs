using Prism.Windows.Mvvm;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;

namespace SfDataGridDemo.ViewModels {
    public class DataValidationPageViewModel : ViewModelBase {
        private IUserRepository userRepository;

        #region Constructor

        public DataValidationPageViewModel(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            UserVMs = userRepository.GetUserVMs(100);
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion



        #region Properties

        private ObservableCollection<UserViewModel> userVMs;
        public ObservableCollection<UserViewModel> UserVMs {
            get { return userVMs; }
            set {
                SetProperty<ObservableCollection<UserViewModel>>(ref userVMs, value);
            }
        }

        #endregion

    }
}
