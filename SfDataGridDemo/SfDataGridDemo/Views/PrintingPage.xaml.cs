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
    public sealed partial class PrintingPage : Page {
        public PrintingPage() {
            this.InitializeComponent();
        }

        private void OnPrintBtnClick(object sender, RoutedEventArgs e) {
            if (sfDataGrid != null)
                this.sfDataGrid.Print();
        }

        private void OnAllowFitColumnsChecked(object sender, RoutedEventArgs e) {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = true;
        }

        private void OnAllowFitColumnsUnChecked(object sender, RoutedEventArgs e) {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = false;
        }

        private void OnAllowRepeatHeaderChecked(object sender, RoutedEventArgs e) {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.AllowRepeatHeaders = true;
        }

        private void OnAllowRepeatHeaderUnChecked(object sender, RoutedEventArgs e) {
            if (sfDataGrid != null)
                this.sfDataGrid.PrintSettings.AllowRepeatHeaders = false;
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e) {
            optionsStackPanel.Visibility = optionsStackPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
