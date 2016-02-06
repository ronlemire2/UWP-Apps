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
    public sealed partial class AutoRowHeightPage : Page {
        GridRowSizingOptions gridRowResizingOptions = new GridRowSizingOptions();
        List<string> excludeColumns = new List<string>();
        double autoHeight = double.NaN;

        public AutoRowHeightPage() {
            this.InitializeComponent();
            this.sfDataGrid.ItemsSourceChanged += sfDataGrid_ItemsSourceChanged;
            this.sfDataGrid.QueryRowHeight += sfDataGrid_QueryRowHeight;
        }

        void sfDataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e) {
            if (this.sfDataGrid.IsTableSummaryIndex(e.RowIndex)) {
                e.Height = 40;
                e.Handled = true;
            }
            else if (this.sfDataGrid.GridColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowResizingOptions, out autoHeight)) {
                if (Height > this.sfDataGrid.RowHeight) {
                    e.Height = autoHeight;
                    e.Handled = true;
                }
            }
        }

        void sfDataGrid_ItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e) {
            foreach (var column in this.sfDataGrid.Columns)
                if (!column.MappingName.Equals("Address") && !column.MappingName.Equals("CompanyName"))
                    excludeColumns.Add(column.MappingName);

            gridRowResizingOptions.ExcludeColumns = excludeColumns;
        }
    }
}
