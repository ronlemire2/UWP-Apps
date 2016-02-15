using Prism.Windows.Mvvm;
using ScreenshotViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using System.Collections.ObjectModel;
using ScreenshotViewer.Models;
using Prism.Commands;
using ScreenshotViewer.Views;

namespace ScreenshotViewer.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private readonly IScreenshotService screenshotService;

        #region Constructors

        public MainPageViewModel(IScreenshotService screenshotService) {
            AppName = "ScreenshotViewer";
            this.screenshotService = screenshotService;
        }

        public MainPageViewModel() {
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            RefreshScreenshots();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion

        #region Properties

        private string appName;
        public string AppName {
            get { return appName; }
            set {
                SetProperty<string>(ref appName, value);
            }
        }

        private ObservableCollection<ScreenshotViewModel> screenshotVMs;
        public ObservableCollection<ScreenshotViewModel> ScreenshotVMs {
            get { return screenshotVMs; }
            set { SetProperty<ObservableCollection<ScreenshotViewModel>>(ref screenshotVMs, value); }
        }

        private ScreenshotViewModel selectedScreenshotVM;
        public ScreenshotViewModel SelectedScreenshotVM {
            get { return selectedScreenshotVM; }
            set {
                SetProperty<ScreenshotViewModel>(ref selectedScreenshotVM, value);
            }
        }

        private IEnumerable<object> screenshotViewModelGroups;
        public IEnumerable<object> ScreenshotViewModelGroups {
            get { return screenshotViewModelGroups; }
            set {
                SetProperty<IEnumerable<object>>(ref screenshotViewModelGroups, value);
            }
        }

        public int ScreenshotVMCount {
            get { return ScreenshotVMs.Count - 1; }
        }

        private string results;
        public string Results {
            get { return results; }
            set {
                SetProperty<string>(ref results, value);
            }
        }

        #endregion

        #region Helpers

        private List<ScreenshotViewModel> MapScreenshotsToViewModels(List<Screenshot> screenshots) {
            List<ScreenshotViewModel> viewModels = new List<ScreenshotViewModel>();
            foreach (Screenshot s in screenshots) {
                viewModels.Add(new ScreenshotViewModel {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImagePath = s.ImagePath,
                    Repository = s.Repository,
                    App = s.App,
                    Notes = s.Notes
                });
            }
            return viewModels;
        }

        private List<Screenshot> MapViewModelsToScreenshots(List<ScreenshotViewModel> viewModels) {
            List<Screenshot> screenshots = new List<Screenshot>();
            foreach (ScreenshotViewModel vm in viewModels) {
                screenshots.Add(new Screenshot() {
                    Id = vm.Id,
                    Name = vm.Name,
                    Description = vm.Description,
                    ImagePath = vm.ImagePath,
                    Repository = vm.Repository,
                    App = vm.App,
                    Notes = vm.Notes
                });
            }
            return screenshots;
        }

        private async void RefreshScreenshots() {
            List<Screenshot> screenshots = await screenshotService.GetScreenshotsAsync();
            ScreenshotVMs = new ObservableCollection<ScreenshotViewModel>(MapScreenshotsToViewModels(screenshots));
            ScreenshotViewModelGroups = screenshotService.GetScreenshotViewModelGroups(ScreenshotVMs.ToList());
        }

        #endregion

    }
}
