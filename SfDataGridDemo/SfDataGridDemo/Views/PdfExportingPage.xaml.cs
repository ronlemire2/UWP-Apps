using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class PdfExportingPage : Page {
        PdfGridCellStyle cellstyle;

        public PdfExportingPage() {
            this.InitializeComponent();
       }

        private void optionsButton_Click(object sender, RoutedEventArgs e) {
            optionsStackPanel.Visibility = optionsStackPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private async void OnPdfExportDataGrid(object sender, RoutedEventArgs e) {
            cellstyle = new PdfGridCellStyle();
            cellstyle.StringFormat = new PdfStringFormat() { Alignment = PdfTextAlignment.Right };
            cellstyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 9f, PdfFontStyle.Regular);
            cellstyle.Borders.All = new PdfPen(PdfBrushes.DarkGray, 0.2f);
            var options = new PdfExportingOptions() {
                AutoColumnWidth = (bool)this.ColumnWidth.IsChecked,
                AutoRowHeight = (bool)this.RowHeight.IsChecked,
                ExportGroups = (bool)this.ExportGroup.IsChecked,
                ExportGroupSummary = (bool)this.ExportGroupSummary.IsChecked,
                ExportTableSummary = (bool)this.ExportTableSummary.IsChecked,
                RepeatHeaders = (bool)this.RepeatHeader.IsChecked,
                FitAllColumnsInOnePage = (bool)this.FitAllColumns.IsChecked,
                ExportingEventHandler = GridPdfExportingEventhandler,
                CellsExportingEventHandler = GridCellPdfExportingEventhandler,
                PageHeaderFooterEventHandler = PdfHeaderFooterEventHandler
            };

            var pdfDocument = this.sfDataGrid.ExportToPdf(this.sfDataGrid.SelectedItems, options);
            pdfDocument.PageSettings.Margins.Top = -34f;
            pdfDocument.PageSettings.Margins.Bottom = -30f;
            var savePicker = new FileSavePicker {
                SuggestedStartLocation = PickerLocationId.Desktop,
                SuggestedFileName = "Sample"
            };


            savePicker.FileTypeChoices.Add("Pdf Files(.pdf)", new List<string>() { ".pdf" });

            var storageFile = await savePicker.PickSaveFileAsync();

            if (storageFile != null) {
                await pdfDocument.SaveAsync(storageFile);

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
        }

        #region ExportToPdf Event Handlers

        void GridPdfExportingEventhandler(object sender, GridPdfExportingEventArgs e) {
            if (e.CellType == ExportCellType.HeaderCell) {
                e.CellStyle.BackgroundBrush = PdfBrushes.LightSteelBlue;
            }
            else if (e.CellType == ExportCellType.GroupCaptionCell) {
                e.CellStyle.BackgroundBrush = PdfBrushes.LightGray;
            }
            else if (e.CellType == ExportCellType.GroupSummaryCell) {
                e.CellStyle.BackgroundBrush = PdfBrushes.Azure;
            }
            else if (e.CellType == ExportCellType.TableSummaryCell) {
                e.CellStyle.BackgroundBrush = PdfBrushes.LightSlateGray;
                e.CellStyle.TextBrush = PdfBrushes.White;
            }
        }

        void GridCellPdfExportingEventhandler(object sender, GridCellPdfExportingEventArgs e) {
            if ((e.ColumnName == "EmployeeID" || e.ColumnName == "HireDate" || e.ColumnName == "BirthDate"
                || e.ColumnName == "Salary" || e.ColumnName == "SickLeaveHours")
                && e.CellType == ExportCellType.RecordCell) {
                e.PdfGridCell.Style = cellstyle;
            }
        }

        async void PdfHeaderFooterEventHandler(object sender, PdfHeaderFooterEventArgs e) {
            var width = e.PdfPage.GetClientSize().Width;

            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 38);
            e.PdfDocumentTemplate.Top = header;

            PdfPageTemplateElement footer = new PdfPageTemplateElement(width, 30);
            e.PdfDocumentTemplate.Bottom = footer;

            var uri = new Uri("ms-appx:///Assets/Header.jpg", UriKind.RelativeOrAbsolute);
            var srcfile = await StorageFile.GetFileFromApplicationUriAsync(uri);
            var stream = await srcfile.OpenStreamForReadAsync();
            header.Graphics.DrawImage(PdfImage.FromStream(stream), 0, 0, width / 3f, 34);

            uri = new Uri("ms-appx:///Assets/Footer.jpg", UriKind.RelativeOrAbsolute);
            srcfile = await StorageFile.GetFileFromApplicationUriAsync(uri);
            stream = await srcfile.OpenStreamForReadAsync();
            footer.Graphics.DrawImage(PdfImage.FromStream(stream), 0, 0, width, 25);
            stream.Dispose();
        }

        #endregion

        private void OnPdfExportSelectedItems(object sender, RoutedEventArgs e) {

        }
    }
}
