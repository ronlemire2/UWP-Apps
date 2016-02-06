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
    public sealed partial class UnboundRowPage : Page {
        // totalSales used to store sumamry of each column.
        Dictionary<string, decimal> totalSales;
        // totalSelectedSales used to store selected rows.
        Dictionary<string, decimal> totalSelectedSales;
        // percentSales used to store percentage of selected Rows summary.
        Dictionary<string, decimal> percentSales;

        public UnboundRowPage() {
            this.InitializeComponent();

            totalSales = new Dictionary<string, decimal>();
            totalSelectedSales = new Dictionary<string, decimal>();
            percentSales = new Dictionary<string, decimal>();

            this.SfDataGrid.Loaded += SfDataGrid_Loaded;
            this.SfDataGrid.Unloaded += SfGrid_Unloaded;
            this.SfDataGrid.QueryRowHeight += SfDataGrid_QueryRowHeight;
            this.SfDataGrid.QueryUnBoundRow += SfDataGrid_QueryUnBoundRow;
            this.SfDataGrid.SelectionChanged += SfDataGrid_SelectionChanged;
            this.SfDataGrid.CurrentCellEndEdit += SfDataGrid_CurrentCellEndEdit;
        }

        void SfDataGrid_Loaded(object sender, RoutedEventArgs e) {
            // populate the totalSales by summary value.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSales[column.MappingName] = Convert.ToDecimal(GetSummaryValue(column.MappingName));

            // populate the percentSales by default value fro QS1 column alone.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                percentSales[column.MappingName] = Convert.ToDecimal(column.MappingName.Equals("QS1") ? 2.25 : 0);

            // Refresh the UnboundRows.
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[0]);
            this.SfDataGrid.GetVisualContainer().InvalidateMeasureInfo();

            var collection = ((UnboundRowPageViewModel)this.DataContext).YearlySalesDetails;
            foreach (SalesByYearViewModel sales in collection.Skip(3).Take(3))
                this.SfDataGrid.SelectedItems.Add(sales);
        }

        private void SfGrid_Unloaded(object sender, RoutedEventArgs e) {
        }

        // Calculates summary value based on column names.
        double GetSummaryValue(string column, bool totalSummary = true) {
            double summary = 0.0;
            var view = this.SfDataGrid.View;
            if (this.SfDataGrid.SelectedItems.Count != 0 && !totalSummary) {
                foreach (var data in this.SfDataGrid.SelectedItems) {
                    if (column.Equals("QS1"))
                        summary += Convert.ToInt64((data as SalesByYearViewModel).QS1);
                    else if (column.Equals("QS2"))
                        summary += Convert.ToInt64((data as SalesByYearViewModel).QS2);
                    else if (column.Equals("QS3"))
                        summary += Convert.ToInt64((data as SalesByYearViewModel).QS3);
                    else if (column.Equals("QS4"))
                        summary += Convert.ToInt64((data as SalesByYearViewModel).QS4);
                    else if (column.Equals("Total"))
                        summary += Convert.ToInt64((data as SalesByYearViewModel).Total);
                }
            }
            else if (totalSummary) {
                foreach (var data in view.Records) {
                    if (column.Equals("QS1"))
                        summary += Convert.ToInt64(((data as RecordEntry).Data as SalesByYearViewModel).QS1);
                    else if (column.Equals("QS2"))
                        summary += Convert.ToInt64(((data as RecordEntry).Data as SalesByYearViewModel).QS2);
                    else if (column.Equals("QS3"))
                        summary += Convert.ToInt64(((data as RecordEntry).Data as SalesByYearViewModel).QS3);
                    else if (column.Equals("QS4"))
                        summary += Convert.ToInt64(((data as RecordEntry).Data as SalesByYearViewModel).QS4);
                    else if (column.Equals("Total"))
                        summary += Convert.ToInt64(((data as RecordEntry).Data as SalesByYearViewModel).Total);
                }
            }
            return summary;
        }

        // which customize the UnBoundRow values.
        void SfDataGrid_QueryUnBoundRow(object sender, GridUnBoundRowEventsArgs e) {
            if (!(totalSales.ContainsKey(e.Column.MappingName)))
                return;

            if (e.UnBoundAction == UnBoundActions.QueryData) {
                if (e.RowColumnIndex.RowIndex == 1) {
                    if (e.RowColumnIndex.ColumnIndex == 0) {
                        e.Value = "Total Sales By Month";
                        e.CellTemplate = Application.Current.Resources["UnBoundCellTemplate"] as DataTemplate;
                    }
                    else {
                        e.Value = totalSales[e.Column.MappingName];
                        e.CellTemplate = Application.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;
                    }
                }
                else if (e.GridUnboundRow.UnBoundRowIndex == 0 && e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true) {
                    if (e.RowColumnIndex.ColumnIndex == 0) {
                        e.Value = "Percent of Selected Rows";
                        e.CellTemplate = Application.Current.Resources["UnBoundCellTemplate"] as DataTemplate;
                    }
                    else {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return;

                        e.Value = totalSelectedSales[e.Column.MappingName] * (percentSales[e.Column.MappingName] / 100);
                        e.CellTemplate = Application.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;
                    }
                }
                else if (e.GridUnboundRow.UnBoundRowIndex == 1 && e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true) {
                    if (e.RowColumnIndex.ColumnIndex == 0) {
                        e.Value = "Summary of Selected Rows";
                        e.CellTemplate = Application.Current.Resources["UnBoundCellTemplate"] as DataTemplate;
                    }
                    else {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return;

                        e.Value = totalSelectedSales[e.Column.MappingName];
                        e.CellTemplate = Application.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;
                    }
                }

                else if (e.GridUnboundRow.UnBoundRowIndex == 2 && e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true) {
                    int count = this.SfDataGrid.SelectedItems.Count;
                    if (e.RowColumnIndex.ColumnIndex == 0) {
                        e.Value = "Average of Selected Rows";
                        e.CellTemplate = Application.Current.Resources["UnBoundCellTemplate"] as DataTemplate;
                    }
                    else {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return;

                        // rjl - just to get by divide by zero
                        count = count == 0 ? 1 : count;

                        e.Value = (totalSelectedSales[e.Column.MappingName] / count);
                        e.Value = double.IsNaN(Convert.ToDouble(e.Value)) ? 0.0 : e.Value;
                        e.CellTemplate = Application.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;

                        if (e.RowColumnIndex.ColumnIndex > 7)
                            e.CellTemplate = null;
                    }
                }
                else if (e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == false) {
                    if (e.RowColumnIndex.ColumnIndex == 0) {
                        e.Value = "Edit the Row to get the Percent of Selected Rows Summary";
                    }
                    else {
                        e.Value = percentSales[e.Column.MappingName];
                        e.EditTemplate = Application.Current.Resources["UnBoundRowEditTemplate"] as DataTemplate;
                        e.CellTemplate = Application.Current.Resources["UnBoundRowCellPercentTemplate"] as DataTemplate;
                    }
                }
                e.Handled = true;
            }
            else if (e.UnBoundAction == UnBoundActions.CommitData) {
                if (e.Value.ToString().Equals(string.Empty))
                    return;
                double data;
                foreach (char character in e.Value.ToString().ToCharArray())
                    if (char.IsLetter(character))
                        return;

                if (e.Value.ToString().Contains("$"))
                    data = Convert.ToDouble(e.Value.ToString().Substring(1, e.Value.ToString().Length - 1));
                else
                    data = Convert.ToDouble(e.Value);
                var value = Convert.ToDouble(data);
                percentSales[e.Column.MappingName] = Convert.ToDecimal(value);
                e.CellTemplate = Application.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;
            }
        }

        void SfDataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e) {
            if (e.RowIndex == 0) {
                e.Height = 40;
                e.Handled = true;
            }
            // Which customize the height of UnBoundRow.
            else if (this.SfDataGrid.IsUnBoundRow(e.RowIndex)) {
                e.Height = 50;
                e.Handled = true;
            }
            else {
                e.Height = this.SfDataGrid.RowHeight;
                e.Handled = true;
            }
        }

        void SfDataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e) {
            // Populate selected rows summary values.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSelectedSales[column.MappingName] = Convert.ToDecimal(GetSummaryValue(column.MappingName, false));

            // Refresh the UnBound rows.
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[1]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[2]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[3]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[4]);
            this.SfDataGrid.GetVisualContainer().InvalidateMeasureInfo();
        }

        void SfDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs args) {
            // Updates the totals with edited values.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSales[column.MappingName] = Convert.ToDecimal(GetSummaryValue(column.MappingName));

            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSelectedSales[column.MappingName] = Convert.ToDecimal(GetSummaryValue(column.MappingName, false));

            // Refresh unboundRow after complete editing.
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[0]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[1]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[2]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[3]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[4]);
            this.SfDataGrid.GetVisualContainer().InvalidateMeasureInfo();
        }

    }
}
