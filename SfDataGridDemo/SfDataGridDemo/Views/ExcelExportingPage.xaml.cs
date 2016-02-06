using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Popups;
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
    public sealed partial class ExcelExportingPage : Page {
        public ExcelExportingPage() {
            this.InitializeComponent();
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e) {
            optionsStackPanel.Visibility = optionsStackPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private async void OnExportSelectedToExcel(object sender, RoutedEventArgs e) {
            ExcelEngine excelEngine = new ExcelEngine();
            var workBook = excelEngine.Excel.Workbooks.Create();
            workBook.Version = ExcelVersion.Excel2010;
            workBook.Worksheets.Create();

            if ((bool)this.customizeSelectedRow.IsChecked) {
                this.sfDataGrid.ExportToExcel(this.sfDataGrid.SelectedItems, new ExcelExportingOptions() {
                    CellsExportingEventHandler = CellExportingHandler,
                    ExportingEventHandler = CustomizedexportingHandler
                }, workBook.Worksheets[0]);
            }
            else {
                this.sfDataGrid.ExportToExcel(this.sfDataGrid.SelectedItems, new ExcelExportingOptions() {
                    CellsExportingEventHandler = CellExportingHandler,
                    ExportingEventHandler = exportingHandler
                }, workBook.Worksheets[0]);
            }

            workBook = excelEngine.Excel.Workbooks[0];
            var savePicker = new FileSavePicker {
                SuggestedStartLocation = PickerLocationId.Desktop,
                SuggestedFileName = "Sample"
            };

            if (workBook.Version == ExcelVersion.Excel97to2003) {
                savePicker.FileTypeChoices.Add("Excel File (.xls)", new List<string>() { ".xls" });
            }
            else {
                savePicker.FileTypeChoices.Add("Excel File (.xlsx)", new List<string>() { ".xlsx" });
            }

            var storageFile = await savePicker.PickSaveFileAsync();

            if (storageFile != null) {
                await workBook.SaveAsAsync(storageFile);

                var msgDialog = new MessageDialog("Do you want to view the Document?", "File has been created successfully.");

                var yesCmd = new UICommand("Yes");
                var noCmd = new UICommand("No");
                msgDialog.Commands.Add(yesCmd);
                msgDialog.Commands.Add(noCmd);
                var cmd = await msgDialog.ShowAsync();
                if (cmd == yesCmd) {
                    // Launch the saved file
                    bool success = await Windows.System.Launcher.LaunchFileAsync(storageFile);
                }
            }
            excelEngine.Dispose();
        }

        private async void OnExcelExportDataGrid(object sender, RoutedEventArgs e) {
            ExcelEngine excelEngine = null;
            ExcelExportingOptions options = new ExcelExportingOptions() {
                AllowOutlining = (bool)this.AllowOutlining.IsChecked,
                ExcelVersion = ExcelVersion.Excel2007,
                ExportingEventHandler = exportingHandler,
            };

            if ((bool)this.customizeColumns.IsChecked) {
                options.CellsExportingEventHandler = CustomizedCellExportingHandler;
                excelEngine = this.sfDataGrid.ExportToExcel(this.sfDataGrid.View, options);
            }
            else {
                options.CellsExportingEventHandler = CellExportingHandler;
                excelEngine = this.sfDataGrid.ExportToExcel(this.sfDataGrid.View, options);
            }

            var workBook = excelEngine.Excel.Workbooks[0];

            var savePicker = new FileSavePicker {
                SuggestedStartLocation = PickerLocationId.Desktop,
                SuggestedFileName = "Sample"
            };

            if (workBook.Version == ExcelVersion.Excel97to2003) {
                savePicker.FileTypeChoices.Add("Excel File (.xls)", new List<string>() { ".xls" });
            }
            else {
                savePicker.FileTypeChoices.Add("Excel File (.xlsx)", new List<string>() { ".xlsx" });
            }

            var storageFile = await savePicker.PickSaveFileAsync();

            if (storageFile != null) {
                await workBook.SaveAsAsync(storageFile);

                var msgDialog = new MessageDialog("Do you want to view the Document?", "File has been created successfully.");

                var yesCmd = new UICommand("Yes");
                var noCmd = new UICommand("No");
                msgDialog.Commands.Add(yesCmd);
                msgDialog.Commands.Add(noCmd);
                var cmd = await msgDialog.ShowAsync();
                if (cmd == yesCmd) {
                    // Launch the saved file
                    bool success = await Windows.System.Launcher.LaunchFileAsync(storageFile);
                }
            }
            excelEngine.Dispose();
        }


        public void CellExportingHandler(object sender, GridCellExcelExportingEventArgs args) {
            args.Range.CellStyle.Font.FontName = "Segoe UI";
        }

        public void CustomizedCellExportingHandler(object sender, GridCellExcelExportingEventArgs args) {
            if (args.ColumnName == "Designation") {
                args.Range.CellStyle.ColorIndex = ExcelKnownColors.Violet;
            }
        }

        public void exportingHandler(object sender, GridExcelExportingEventArgs e) {
            if (e.CellType == ExportCellType.HeaderCell) {
                e.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.LightSteelBlue);
                e.CellStyle.ForeGroundBrush = new SolidColorBrush(Colors.DarkRed);
                e.CellStyle.FontInfo.Bold = true;
            }
            else if (e.CellType == ExportCellType.GroupCaptionCell) {
                e.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.LightSlateGray);
                e.CellStyle.ForeGroundBrush = new SolidColorBrush(Colors.LightYellow);
            }
            else if (e.CellType == ExportCellType.GroupSummaryCell) {
                e.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.LightGray);
            }
            e.CellStyle.FontInfo.FontName = "Segoe UI";
        }

        public void CustomizedexportingHandler(object sender, GridExcelExportingEventArgs e) {
            if ((e.CellType == ExportCellType.RecordCell))
                e.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.Violet);
        }
    }
}
