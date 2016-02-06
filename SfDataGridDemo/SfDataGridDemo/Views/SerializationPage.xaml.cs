using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class SerializationPage : Page {
        public SerializationPage() {
            this.InitializeComponent();
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e) {
            scrollViewer.Visibility = scrollViewer.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private async void OnSerializeDataGrid(object sender, RoutedEventArgs e) {
            var folder = ApplicationData.Current.LocalFolder;
            try {
                var storageFile = await folder.CreateFileAsync("SfDataGrid.xml", CreationCollisionOption.ReplaceExisting);
                var options = new SerializationOptions() {
                    SerializeColumns = (bool)this.SerializeColumns.IsChecked,
                    SerializeFiltering = (bool)this.SerializeFiltering.IsChecked,
                    SerializeGrouping = (bool)this.SerializeGrouping.IsChecked,
                    SerializeSorting = (bool)this.SerializeSorting.IsChecked,
                    SerializeGroupSummaries = (bool)this.SerializeGroupSummaries.IsChecked,
                    SerializeTableSummaries = (bool)this.SerializeTableSummaries.IsChecked,
                    SerializeStackedHeaders = (bool)this.SerializeStackedHeaders.IsChecked
                };
                this.sfDataGrid.Serialize(storageFile, options);
            }
            catch (Exception) {

            }
        }

        private async void OnDeserializeDataGrid(object sender, RoutedEventArgs e) {
            var folder = ApplicationData.Current.LocalFolder;
            try {
                var storageFile = await folder.GetFileAsync("DataGrid.xml");
                var options = new DeserializationOptions() {
                    DeserializeColumns = (bool)this.DeserializeColumns.IsChecked,
                    DeserializeFiltering = (bool)this.DeserializeFiltering.IsChecked,
                    DeserializeSorting = (bool)this.DeserializeSorting.IsChecked,
                    DeserializeGrouping = (bool)this.DeserializeGrouping.IsChecked,
                    DeserializeGroupSummaries = (bool)this.DeserializeGroupSummaries.IsChecked,
                    DeserializeTableSummaries = (bool)this.DeserializeTableSummaries.IsChecked,
                    DeserializeStackedHeaders = (bool)this.DeserializeStackedHeaders.IsChecked
                };
                this.sfDataGrid.Deserialize(storageFile, options);
            }
            catch (Exception) {

            }
        }
    }
}
