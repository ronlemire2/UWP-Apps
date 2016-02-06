using SfDataGridDemo.ViewModels;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
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
    public sealed partial class CellMergePage : Page {
        IPropertyAccessProvider reflector = null;

        public CellMergePage() {
            this.InitializeComponent();
            this.sfDataGrid.QueryCoveredRange += SfDataGrid_QueryCoveredRange;
            this.sfDataGrid.ItemsSourceChanged += SfDataGrid_ItemsSourceChanged;
            PrepareCoveredData();
        }

        private void SfDataGrid_ItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e) {
            if (sfDataGrid.View != null)
                reflector = sfDataGrid.View.GetPropertyAccessProvider();
            else
                reflector = null;
        }

        private void SfDataGrid_QueryCoveredRange(object sender, Syncfusion.UI.Xaml.Grid.GridQueryCoveredRangeEventArgs e) {
            if (!e.GridColumn.MappingName.Equals("CustomerID"))
                return;

            // Merging cells for flat grid
            var range = GetRange(e.GridColumn, e.RowColumnIndex.RowIndex, e.RowColumnIndex.ColumnIndex, e.Record);
            if (range == null)
                return;

            e.Range = range;
            e.Handled = true;
        }

        CoveredCellInfo GetRange(GridColumn column, int rowIndex, int columnIndex, object rowData) {
            var range = new CoveredCellInfo(columnIndex, columnIndex, rowIndex, rowIndex);
            object data = reflector.GetFormattedValue(rowData, column.MappingName);

            GridColumn leftColumn = null;
            GridColumn rightColumn = null;


            // total rows count.
            int recordsCount = this.sfDataGrid.GroupColumnDescriptions.Count != 0 ? this.sfDataGrid.View.TopLevelGroup.DisplayElements.Count : this.sfDataGrid.View.Records.Count;

            // Merge Horizontally
            // compare right column               
            for (int i = sfDataGrid.Columns.IndexOf(column); i < this.sfDataGrid.Columns.Count - 1; i++) {
                var compareData = reflector.GetFormattedValue(rowData, sfDataGrid.Columns[i + 1].MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                rightColumn = sfDataGrid.Columns[i + 1];
            }

            // compare left column.
            for (int i = sfDataGrid.Columns.IndexOf(column); i > 0; i--) {
                var compareData = reflector.GetFormattedValue(rowData, sfDataGrid.Columns[i - 1].MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                leftColumn = sfDataGrid.Columns[i - 1];
            }

            if (leftColumn != null || rightColumn != null) {
                // set left index
                if (leftColumn != null) {
                    var leftColumnIndex = this.sfDataGrid.ResolveToScrollColumnIndex(this.sfDataGrid.Columns.IndexOf(leftColumn));
                    range = new CoveredCellInfo(leftColumnIndex, range.Right, range.Top, range.Bottom);
                }

                // set right index
                if (rightColumn != null) {
                    var rightColumIndex = this.sfDataGrid.ResolveToScrollColumnIndex(this.sfDataGrid.Columns.IndexOf(rightColumn));
                    range = new CoveredCellInfo(range.Left, rightColumIndex, range.Top, range.Bottom);
                }
                return range;
            }

            // Merge Vertically from the row index.

            int previousRowIndex = -1;
            int nextRowIndex = -1;

            // Get previous row data.                
            var startIndex = sfDataGrid.ResolveStartIndexBasedOnPosition();
            for (int i = rowIndex - 1; i > startIndex; i--) {
                var previousData = this.sfDataGrid.GetRecordEntryAtRowIndex(i);
                if (previousData == null || !previousData.IsRecords)
                    break;

                var compareData = reflector.GetFormattedValue((previousData as RecordEntry).Data, column.MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                previousRowIndex = i;
            }

            // get next row data.
            for (int i = rowIndex + 1; i < recordsCount + 1; i++) {
                var nextData = this.sfDataGrid.GetRecordEntryAtRowIndex(i);
                if (nextData == null || !nextData.IsRecords)
                    break;

                var compareData = reflector.GetFormattedValue((nextData as RecordEntry).Data, column.MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                nextRowIndex = i;
            }

            if (previousRowIndex != -1 || nextRowIndex != -1) {
                if (previousRowIndex != -1)
                    range = new CoveredCellInfo(range.Left, range.Right, previousRowIndex, range.Bottom);

                if (nextRowIndex != -1)
                    range = new CoveredCellInfo(range.Left, range.Right, range.Top, nextRowIndex);
                return range;
            }
            return null;
        }

        private void PrepareCoveredData() {
            int range = 0;
            if (((CellMergePageViewModel)this.DataContext).OrderVMs != null) {
                for (int i = 0; i < ((CellMergePageViewModel)this.DataContext).OrderVMs.Count; i++) {
                    var orderInfo = ((CellMergePageViewModel)this.DataContext).OrderVMs[range];
                    if (i == 0 || i % 4 != 0) {
                        var modifyOrderinfo = ((CellMergePageViewModel)this.DataContext).OrderVMs[i];
                        modifyOrderinfo.CustomerId = orderInfo.CustomerId;
                    }
                    else {
                        if (range % 4 == 0)
                            range = i;
                    }
                }
            }
        }
    }
}
