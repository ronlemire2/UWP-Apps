using SfDataGridDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class BasicFilteringPage : Page {
        public BasicFilteringPage() {
            this.InitializeComponent();
            this.Loaded += BasicFilteringPage_Loaded;
        }

        private void BasicFilteringPage_Loaded(object sender, RoutedEventArgs e) {
            ((BasicFilteringPageViewModel)this.DataContext).filterChanged = OnFilterChanged;
        }

        private void OnFilterChanged() {
            var viewModel = this.DataContext as BasicFilteringPageViewModel;
            if (this.sfGrid.View != null) {
                this.sfGrid.View.Filter = viewModel.FilterRecords;
                this.sfGrid.View.RefreshFilter();
            }
        }
    }
}
