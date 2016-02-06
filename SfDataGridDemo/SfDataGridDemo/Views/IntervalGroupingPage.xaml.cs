using SfDataGridDemo.Converters;
using SfDataGridDemo.Helpers;
using Syncfusion.UI.Xaml.Grid;
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
    public sealed partial class IntervalGroupingPage : Page {
        public IntervalGroupingPage() {
            this.InitializeComponent();
            this.sfGrid.GroupColumnDescriptions.CollectionChanged += GroupColumnDescriptions_CollectionChanged;
        }

        private void GroupColumnDescriptions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            if (e.NewItems != null) {
                var groupDesc = e.NewItems[0] as GroupColumnDescription;
                if (groupDesc.ColumnName == "OrderDate") {
                    groupDesc.Converter = new GridDateTimeRangeConverter() { GroupMode = DateGroupingMode.Range };
                    groupDesc.Comparer = new CustomGroupDateTimeComparer() { GroupMode = DateGroupingMode.Range };
                }
                if (groupDesc.ColumnName == "OrderId") {
                    groupDesc.Converter = new GridNumericRangeConverter() { GroupInterval = 10 };
                    groupDesc.Comparer = new CustomGroupNumericComparer();
                }
                if (groupDesc.ColumnName == "CustomerId") {
                    groupDesc.Converter = new GridTextRangeConverter();
                    groupDesc.Comparer = new CustomGroupTextComparer();
                }
                if (groupDesc.ColumnName == "ShipDate") {
                    groupDesc.Converter = new GridDateTimeRangeConverter() { GroupMode = DateGroupingMode.Month };
                    groupDesc.Comparer = new CustomGroupDateTimeComparer() { GroupMode = DateGroupingMode.Month };
                }
                if (groupDesc.ColumnName == "Freight") {
                    groupDesc.Converter = new GridNumericRangeConverter() { GroupInterval = 10 };
                    groupDesc.Comparer = new CustomGroupNumericComparer();
                }
                if (groupDesc.ColumnName == "ShipCountry") {
                    groupDesc.Converter = new GridTextRangeConverter();
                    groupDesc.Comparer = new CustomGroupTextComparer();
                }
            }
        }
    }
}
