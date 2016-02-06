using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SfChartDemo.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PieChartsPage : Page {
        PieChartViewModel viewModel;

        public PieChartsPage() {
            viewModel = new PieChartViewModel();
            this.InitializeComponent();
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
                this.Accumulation_charts.Series[0].ItemsSource = viewModel.Expenditure;
        }

        private void OnChartTypeSelectionChanged1(object sender, SelectionChangedEventArgs e) {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == 0 && viewModel != null) {
                if (Accumulation_charts != null) {
                    Accumulation_charts.Header = "Agriculture Expenses Comparison";
                    PieSeries series1 = new PieSeries();
                    DataTemplate template1 = MainGrid.Resources["labelTemplate"] as DataTemplate;
                    ChartAdornmentInfo adornmentInfo1 = new ChartAdornmentInfo();
                    adornmentInfo1.ShowLabel = true;
                    ChartLegend1.Visibility = Visibility.Visible;
                    series1.XBindingPath = "Expense";
                    series1.YBindingPath = "Amount";
                    series1.ItemsSource = viewModel.Expenditure;
                    series1.ConnectorType = ConnectorMode.Bezier;
                    series1.PieCoefficient = 0.7;
                    series1.EnableSmartLabels = true;
                    series1.LabelPosition = CircularSeriesLabelPosition.OutsideExtended;
                    adornmentInfo1.LabelTemplate = template1;
                    adornmentInfo1.AdornmentsPosition = AdornmentsPosition.Bottom;
                    adornmentInfo1.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                    adornmentInfo1.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
                    adornmentInfo1.ShowConnectorLine = true;
                    adornmentInfo1.ConnectorHeight = 80;
                    adornmentInfo1.ShowLabel = true;
                    adornmentInfo1.UseSeriesPalette = true;
                    adornmentInfo1.SegmentLabelContent = LabelContent.LabelContentPath;
                    series1.AdornmentsInfo = adornmentInfo1;
                    Accumulation_charts.Series.Clear();
                    Accumulation_charts.Series.Add(series1);
                }
            }

            if (comboBox.SelectedIndex == 2 && viewModel != null) {
                Accumulation_charts.Header = "Top car company's turnover";
                DoughnutSeries series1 = new DoughnutSeries();
                DataTemplate template1 = MainGrid.Resources["labeltemplate"] as DataTemplate;
                ChartAdornmentInfo adornmentInfo1 = new ChartAdornmentInfo();
                adornmentInfo1.ShowLabel = true;
                ChartLegend1.Visibility = Visibility.Visible;
                series1.XBindingPath = "CompanyName";
                series1.YBindingPath = "CompanyTurnover";
                series1.ItemsSource = viewModel.CompanyDetails;
                adornmentInfo1.LabelTemplate = template1;
                series1.AdornmentsInfo = adornmentInfo1;
                Accumulation_charts.Series.Clear();
                Accumulation_charts.Series.Add(series1);
            }

            if (comboBox.SelectedIndex == 4 && viewModel != null) {
                Accumulation_charts.Header = "Top car company's turnover";
                Accumulation_charts.Margin = new Thickness(20, 20, 20, 20);
                PyramidSeries series1 = new PyramidSeries();
                series1.Margin = new Thickness(20, 0, 20, 20);
                DataTemplate template1 = MainGrid.Resources["labelTemplate"] as DataTemplate;
                ChartAdornmentInfo adornmentInfo1 = new ChartAdornmentInfo();
                adornmentInfo1.ShowLabel = true;
                ChartLegend1.Visibility = Visibility.Collapsed;
                series1.XBindingPath = "CompanyName";
                series1.YBindingPath = "CompanyTurnover";
                series1.ItemsSource = viewModel.CompanyDetails;
                adornmentInfo1.LabelTemplate = template1;
                series1.AdornmentsInfo = adornmentInfo1;
                Accumulation_charts.Series.Clear();
                Accumulation_charts.Series.Add(series1);
            }

            if (comboBox.SelectedIndex == 5 && viewModel != null) {
                Accumulation_charts.Header = "Top car company's turnover";
                Accumulation_charts.Margin = new Thickness(20, 20, 20, 20);
                FunnelSeries series1 = new FunnelSeries();
                series1.Margin = new Thickness(20, 0, 20, 20);
                DataTemplate template1 = MainGrid.Resources["labelTemplate"] as DataTemplate;
                ChartAdornmentInfo adornmentInfo1 = new ChartAdornmentInfo();
                adornmentInfo1.ShowLabel = true;
                ChartLegend1.Visibility = Visibility.Collapsed;
                series1.XBindingPath = "CompanyName";
                series1.YBindingPath = "CompanyTurnover";
                series1.ItemsSource = viewModel.CompanyDetails;
                adornmentInfo1.LabelTemplate = template1;
                series1.AdornmentsInfo = adornmentInfo1;
                Accumulation_charts.Series.Clear();
                Accumulation_charts.Series.Add(series1);
            }
            if (comboBox.SelectedIndex == 1 && viewModel != null) {
                Accumulation_charts.Header = "Application Performance Metrics";
                ChartLegend1.Visibility = Visibility.Collapsed;
                PieSeries series1 = new PieSeries();
                series1.Margin = new Thickness(0, 25, 0, 0);
                ChartAdornmentInfo adornmentInfo1 = new ChartAdornmentInfo();
                adornmentInfo1.ShowLabel = true;
                adornmentInfo1.ShowConnectorLine = true;
                adornmentInfo1.UseSeriesPalette = true;
                adornmentInfo1.ConnectorHeight = 37;
                adornmentInfo1.SegmentLabelContent = LabelContent.Percentage;
                adornmentInfo1.SegmentLabelFormat = "##.#";
                series1.XBindingPath = "Utilization";
                series1.YBindingPath = "ResponseTime";
                series1.StartAngle = 180;
                series1.EndAngle = 360;
                series1.ConnectorType = ConnectorMode.Bezier;
                series1.EnableSmartLabels = true;
                series1.LabelPosition = CircularSeriesLabelPosition.Outside;
                series1.ItemsSource = viewModel.Metric;
                series1.AdornmentsInfo = adornmentInfo1;
                Accumulation_charts.Series.Clear();
                Accumulation_charts.Series.Add(series1);
            }

            if (comboBox.SelectedIndex == 3 && viewModel != null) {
                Accumulation_charts.Header = "Application Performance Metrics";
                ChartLegend1.Visibility = Visibility.Collapsed;
                DoughnutSeries series1 = new DoughnutSeries();
                series1.Margin = new Thickness(0, 25, 0, 0);
                ChartAdornmentInfo adornmentInfo1 = new ChartAdornmentInfo();
                adornmentInfo1.ShowLabel = true;
                adornmentInfo1.ShowConnectorLine = true;
                adornmentInfo1.UseSeriesPalette = true;
                adornmentInfo1.ConnectorHeight = 37;
                adornmentInfo1.SegmentLabelContent = LabelContent.Percentage;
                adornmentInfo1.SegmentLabelFormat = "##.#";
                series1.XBindingPath = "Utilization";
                series1.YBindingPath = "ResponseTime";
                series1.StartAngle = 180;
                series1.EndAngle = 360;
                series1.ConnectorType = ConnectorMode.Bezier;
                series1.EnableSmartLabels = true;
                series1.LabelPosition = CircularSeriesLabelPosition.Outside;
                series1.ItemsSource = viewModel.Metric;
                series1.AdornmentsInfo = adornmentInfo1;
                Accumulation_charts.Series.Clear();
                Accumulation_charts.Series.Add(series1);
            }


        }

        public void Dispose() {
            if (this.Accumulation_charts != null) {
                foreach (var series in this.Accumulation_charts.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.DataContext is PieChartViewModel)
                (this.DataContext as PieChartViewModel).Dispose();
        }
    }

    public class CompanyExpense {
        public string Expense {
            get;
            set;
        }
        public double Amount {
            get;
            set;
        }
    }

    public class CompanyDetail {
        public string CompanyName {
            get;
            set;
        }
        public double CompanyTurnover {
            get;
            set;
        }
    }

    public class Metrics {
        public double Utilization {
            get;
            set;
        }
        public double ResponseTime {
            get;
            set;
        }
    }

    public class PieChartViewModel : IDisposable {
        public PieChartViewModel() {
            this.Expenditure = new List<CompanyExpense>();
            Expenditure.Add(new CompanyExpense() { Expense = "Seeds", Amount = 7658d });
            Expenditure.Add(new CompanyExpense() { Expense = "Fertilizers", Amount = 7090d });
            Expenditure.Add(new CompanyExpense() { Expense = "Insurance", Amount = 3577d });
            Expenditure.Add(new CompanyExpense() { Expense = "Labor", Amount = 1473d });
            Expenditure.Add(new CompanyExpense() { Expense = "Warehousing", Amount = 820d });
            Expenditure.Add(new CompanyExpense() { Expense = "Taxes", Amount = 571d });
            Expenditure.Add(new CompanyExpense() { Expense = "Truck", Amount = 462d });

            CompanyDetails = new List<CompanyDetail>();
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Rolls Royce", CompanyTurnover = 750000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Benz", CompanyTurnover = 500000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Audi", CompanyTurnover = 450000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "BMW", CompanyTurnover = 700000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Mahindra", CompanyTurnover = 350000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Jaguar", CompanyTurnover = 650000 });
            CompanyDetails.Add(new CompanyDetail() { CompanyName = "Hero Honda", CompanyTurnover = 250000 });

            Metric = new List<Metrics>();
            Metric.Add(new Metrics() { ResponseTime = 43, Utilization = 32 });
            Metric.Add(new Metrics() { ResponseTime = 20, Utilization = 34 });
            Metric.Add(new Metrics() { ResponseTime = 67, Utilization = 41 });
            Metric.Add(new Metrics() { ResponseTime = 52, Utilization = 42 });
            Metric.Add(new Metrics() { ResponseTime = 71, Utilization = 48 });
            Metric.Add(new Metrics() { ResponseTime = 30, Utilization = 45 });

        }

        public IList<CompanyExpense> Expenditure {
            get;
            set;
        }
        public IList<CompanyDetail> CompanyDetails {
            get;
            set;
        }

        public IList<Metrics> Metric {
            get;
            set;
        }

        public void Dispose() {
            if (this.Expenditure != null)
                this.Expenditure.Clear();
        }
    }

    public class LabelConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value is ChartAdornment) {
                ChartAdornment pieAdornment = value as ChartAdornment;
                return String.Format((pieAdornment.Item as CompanyExpense).Expense + " : $ " + pieAdornment.YData);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return value;
        }
    }

    public class ColorConverter : IValueConverter {
        private SolidColorBrush ApplyLight(Color color) {
            return new SolidColorBrush(Color.FromArgb(color.A, (byte)(color.R * 0.9), (byte)(color.G * 0.9), (byte)(color.B * 0.9)));
        }

        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value != null && (value is ChartAdornment)) {
                ChartAdornment pieAdornment = value as ChartAdornment;
                int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
                SolidColorBrush brush = pieAdornment.Series.ColorModel.GetBrush(index) as SolidColorBrush;
                return ApplyLight(brush.Color);
            }
            return value;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return value;
        }

    }
}
