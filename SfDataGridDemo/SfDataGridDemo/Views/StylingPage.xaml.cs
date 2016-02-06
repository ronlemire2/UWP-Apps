using SfDataGridDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SfDataGridDemo.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StylingPage : Page {
        public StylingPage() {
            this.InitializeComponent();
            this.sfDataGrid.Loaded += SfDataGrid_Loaded;
        }

        private async void SfDataGrid_Loaded(object sender, RoutedEventArgs e) {
            await Task.Delay(100);

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                if (this.DataContext != null) {
                    this.sfDataGrid.ItemsSource = (this.DataContext as StylingPageViewModel).CountryVMs;
                }
            });

            var stylingPageViewModel = (this.DataContext as StylingPageViewModel);
            var r = new Random();
            for (int i = 0; i < stylingPageViewModel.CountryVMs.Count; i++) {
                var item = stylingPageViewModel.CountryVMs[i];
                var economy = new ObservableCollection<EconomicGrowthViewModel>();
                for (int j = 0; j < 5; j++) {
                    economy.Add(new EconomicGrowthViewModel() { Year = DateTime.Now.Year - j, GrowthPercentage = r.Next(99) });
                }

                //await Task.Delay(100);
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                    item.EconomyRate = economy;
                });

            }
        }

    }
}
