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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SfDataGridDemo.Views {
    public sealed partial class ObservableCollectionBindingUC : UserControl {
        public ObservableCollectionBindingUC() {
            this.InitializeComponent();
            this.syncgrid.Loaded += Syncgrid_Loaded;
            this.syncgrid.Unloaded += Syncgrid_Unloaded;
        }

        private void Syncgrid_Loaded(object sender, RoutedEventArgs e) {
            this.syncgrid.ItemsSource = (this.DataContext as DataBindingPageViewModel).EmployeeVMs;
        }

        private void Syncgrid_Unloaded(object sender, RoutedEventArgs e) {
            this.syncgrid.ItemsSource = null;
        }

        public void Dispose() {
            this.syncgrid.Loaded -= Syncgrid_Loaded;
            this.syncgrid.Unloaded -= Syncgrid_Unloaded;
            this.syncgrid.ItemsSource = null;
            this.syncgrid.Dispose();
            (this.DataContext as IDisposable).Dispose();
            this.DataContext = null;
        }
    }
}
