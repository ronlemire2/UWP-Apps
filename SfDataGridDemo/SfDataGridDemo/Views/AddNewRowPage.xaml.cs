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
    public sealed partial class AddNewRowPage : Page {
        public AddNewRowPage() {
            this.InitializeComponent();
            sfDataGrid.RowValidating += SfDataGrid_RowValidating;

            //https://www.syncfusion.com/kb/2501/how-to-set-default-values-for-columns-in-addnewrow
            sfDataGrid.AddNewRowInitiating += SfDataGrid_AddNewRowInitiating;
        }

        private void SfDataGrid_AddNewRowInitiating(object sender, Syncfusion.UI.Xaml.Grid.AddNewRowInitiatingEventArgs args) {
            var data = args.NewObject as OrderViewModel;
            data.OrderDate = DateTime.Now;
        }

        private void SfDataGrid_RowValidating(object sender, Syncfusion.UI.Xaml.Grid.RowValidatingEventArgs args) {
            if (args.RowData != null && (args.RowData as OrderViewModel).OrderId <= 0) {
                args.ErrorMessages.Add("OrderID", "Order Id field should not contain null or minimum value.");
                args.IsValid = false;
            }
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e) {
            optionsStackPanel.Visibility = optionsStackPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
