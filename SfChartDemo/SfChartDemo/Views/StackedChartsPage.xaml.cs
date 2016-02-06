using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SfChartDemo.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StackedChartsPage : Page {
        public StackingColumnChartViewModel ColumnChartViewModel {
            get;
            set;
        }

        public StackingBarChartViewModel BarChartViewModel {
            get;
            set;
        }

        public StackingAreaChartViewModel AreaChartViewModel {
            get;
            set;
        }


        public StackedChartsPage() {
            this.InitializeComponent();
            ColumnChartViewModel = new StackingColumnChartViewModel();
            BarChartViewModel = new StackingBarChartViewModel();
            AreaChartViewModel = new StackingAreaChartViewModel();
            this.DataContext = this;
        }

        private void OnSelectStackSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stBarChart == null) return;
            if (selectStack != null) {
                if (selectStack.SelectedIndex == 0) {
                    stBarChart.PrimaryAxis.ZoomFactor = 1;
                    stBarChart.SecondaryAxis.ZoomFactor = 1;
                    stBarChart.Visibility = Visibility.Visible;
                    stColumnChart.Visibility = Visibility.Collapsed;
                    stAreaChart.Visibility = Visibility.Collapsed;
                    stBar100Chart.Visibility = Visibility.Collapsed;
                    stColumn100Chart.Visibility = Visibility.Collapsed;
                    stArea100Chart.Visibility = Visibility.Collapsed;
                }
                else if (selectStack.SelectedIndex == 1) {
                    stColumnChart.PrimaryAxis.ZoomFactor = 1;
                    stColumnChart.SecondaryAxis.ZoomFactor = 1;
                    stBarChart.Visibility = Visibility.Collapsed;
                    stColumnChart.Visibility = Visibility.Visible;
                    stAreaChart.Visibility = Visibility.Collapsed;
                    stBar100Chart.Visibility = Visibility.Collapsed;
                    stColumn100Chart.Visibility = Visibility.Collapsed;
                    stArea100Chart.Visibility = Visibility.Collapsed;
                }
                else if (selectStack.SelectedIndex == 2) {
                    stAreaChart.PrimaryAxis.ZoomFactor = 1;
                    stAreaChart.SecondaryAxis.ZoomFactor = 1;
                    stBarChart.Visibility = Visibility.Collapsed;
                    stColumnChart.Visibility = Visibility.Collapsed;
                    stAreaChart.Visibility = Visibility.Visible;
                    stBar100Chart.Visibility = Visibility.Collapsed;
                    stColumn100Chart.Visibility = Visibility.Collapsed;
                    stArea100Chart.Visibility = Visibility.Collapsed;
                }
                else if (selectStack.SelectedIndex == 3) {
                    stAreaChart.PrimaryAxis.ZoomFactor = 1;
                    stAreaChart.SecondaryAxis.ZoomFactor = 1;
                    stBarChart.Visibility = Visibility.Collapsed;
                    stColumnChart.Visibility = Visibility.Collapsed;
                    stAreaChart.Visibility = Visibility.Collapsed;
                    stBar100Chart.Visibility = Visibility.Visible;
                    stColumn100Chart.Visibility = Visibility.Collapsed;
                    stArea100Chart.Visibility = Visibility.Collapsed;
                }
                else if (selectStack.SelectedIndex == 4) {
                    stAreaChart.PrimaryAxis.ZoomFactor = 1;
                    stAreaChart.SecondaryAxis.ZoomFactor = 1;
                    stBarChart.Visibility = Visibility.Collapsed;
                    stColumnChart.Visibility = Visibility.Collapsed;
                    stAreaChart.Visibility = Visibility.Collapsed;
                    stBar100Chart.Visibility = Visibility.Collapsed;
                    stColumn100Chart.Visibility = Visibility.Visible;
                    stArea100Chart.Visibility = Visibility.Collapsed;
                }
                else if (selectStack.SelectedIndex == 5) {
                    stAreaChart.PrimaryAxis.ZoomFactor = 1;
                    stAreaChart.SecondaryAxis.ZoomFactor = 1;
                    stBarChart.Visibility = Visibility.Collapsed;
                    stColumnChart.Visibility = Visibility.Collapsed;
                    stAreaChart.Visibility = Visibility.Collapsed;
                    stBar100Chart.Visibility = Visibility.Collapsed;
                    stColumn100Chart.Visibility = Visibility.Collapsed;
                    stArea100Chart.Visibility = Visibility.Visible;
                }
            }
        }

        public void Dispose() {
            if (this.stBarChart != null) {
                foreach (var series in this.stBarChart.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.stBar100Chart != null) {
                foreach (var series in this.stBar100Chart.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.stAreaChart != null) {
                foreach (var series in this.stAreaChart.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.stArea100Chart != null) {
                foreach (var series in this.stArea100Chart.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.stColumnChart != null) {
                foreach (var series in this.stColumnChart.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.stColumn100Chart != null) {
                foreach (var series in this.stColumn100Chart.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.DataContext is StackingColumnChartViewModel)
                (this.DataContext as StackingColumnChartViewModel).Dispose();
            if (this.DataContext is StackingBarChartViewModel)
                (this.DataContext as StackingBarChartViewModel).Dispose();
            if (this.DataContext is StackingAreaChartViewModel)
                (this.DataContext as StackingAreaChartViewModel).Dispose();
        }
    }

    public class StackingColumnChartViewModel : IDisposable {

        public StackingColumnChartViewModel() {
            this.MedalDetails = new ObservableCollection<Medal>();

            MedalDetails.Add(new Medal() { CountryName = "USA", GoldMedals = 395, SilverMedals = 319, BronzeMedals = 296 });
            MedalDetails.Add(new Medal() { CountryName = "Germany", GoldMedals = 247, SilverMedals = 284, BronzeMedals = 320 });
            MedalDetails.Add(new Medal() { CountryName = "UK", GoldMedals = 207, SilverMedals = 255, BronzeMedals = 253 });
            MedalDetails.Add(new Medal() { CountryName = "France", GoldMedals = 191, SilverMedals = 212, BronzeMedals = 233 });
            MedalDetails.Add(new Medal() { CountryName = "Italy", GoldMedals = 190, SilverMedals = 157, BronzeMedals = 174 });
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile") {
                MedalDetails.Add(new Medal() { CountryName = "Sweden", GoldMedals = 142, SilverMedals = 160, BronzeMedals = 173 });
                MedalDetails.Add(new Medal() { CountryName = "Australia", GoldMedals = 131, SilverMedals = 137, BronzeMedals = 164 });
                MedalDetails.Add(new Medal() { CountryName = "Japan", GoldMedals = 123, SilverMedals = 112, BronzeMedals = 126 });
            }
        }

        public ObservableCollection<Medal> MedalDetails {
            get;
            set;
        }

        public void Dispose() {
            if (this.MedalDetails != null)
                this.MedalDetails.Clear();
        }
    }

    public class StackingBarChartViewModel : IDisposable {

        public StackingBarChartViewModel() {
            this.GoldInventoryDetails = new ObservableCollection<GoldInventory>();

            GoldInventoryDetails.Add(new GoldInventory() { Year = 2005, Inferred = 1100, Measured = 750, Reserves = 900 });
            GoldInventoryDetails.Add(new GoldInventory() { Year = 2006, Inferred = 1200, Measured = 500, Reserves = 1000 });
            GoldInventoryDetails.Add(new GoldInventory() { Year = 2007, Inferred = 900, Measured = 700, Reserves = 1200 });
            GoldInventoryDetails.Add(new GoldInventory() { Year = 2008, Inferred = 950, Measured = 1000, Reserves = 900 });
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile") {
                GoldInventoryDetails.Add(new GoldInventory() { Year = 2009, Inferred = 900, Measured = 1100, Reserves = 1000 });
                GoldInventoryDetails.Add(new GoldInventory() { Year = 2010, Inferred = 900, Measured = 1200, Reserves = 1000 });
                GoldInventoryDetails.Add(new GoldInventory() { Year = 2011, Inferred = 1000, Measured = 1100, Reserves = 1050 });
            }
        }
        public ObservableCollection<GoldInventory> GoldInventoryDetails {
            get;
            set;
        }

        public void Dispose() {
            if (this.GoldInventoryDetails != null)
                this.GoldInventoryDetails.Clear();
        }
    }

    public class StackingAreaChartViewModel : IDisposable {
        public StackingAreaChartViewModel() {
            this.TemperatureData = new ObservableCollection<Temperatue>();

            TemperatureData.Add(new Temperatue() {
                Margin = new Thickness(25, 0, 0, 0),
                Year = "2008",
                Autumn = 30,
                Spring = 35,
                Summer = 43,
                Winter = 29
            });
            TemperatureData.Add(new Temperatue() {
                Margin = new Thickness(0, 0, 0, 0),
                Year = "2009",
                Autumn = 30,
                Spring = 35,
                Summer = 43,
                Winter = 29
            });
            TemperatureData.Add(new Temperatue() {
                Margin = new Thickness(0, 0, 0, 0),
                Year = "2010",
                Autumn = 32,
                Spring = 37,
                Summer = 47,
                Winter = 27
            });
            TemperatureData.Add(new Temperatue() {
                Margin = new Thickness(0, 0, 0, 0),
                Year = "2011",
                Autumn = 34,
                Spring = 35,
                Summer = 43,
                Winter = 25
            });
            TemperatureData.Add(new Temperatue() {
                Margin = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile" ?
                                                        new Thickness(0, 0, 0, 0) : new Thickness(0, 0, 25, 0),
                Year = "2012",
                Autumn = 28,
                Spring = 36,
                Summer = 49,
                Winter = 27
            });
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile") {
                TemperatureData.Add(new Temperatue() {
                    Margin = new Thickness(0, 0, 25, 0),
                    Year = "2013",
                    Autumn = 31,
                    Spring = 30,
                    Summer = 52,
                    Winter = 30
                });
            }
        }
        public ObservableCollection<Temperatue> TemperatureData {
            get;
            set;
        }

        public void Dispose() {
            if (this.TemperatureData != null)
                this.TemperatureData.Clear();
        }
    }

    public class Temperatue {
        public Thickness Margin {
            get;
            set;
        }

        public string Year {
            get;
            set;
        }

        public double Spring {
            get;
            set;
        }

        public double Summer {
            get;
            set;
        }

        public double Autumn {
            get;
            set;
        }

        public double Winter {
            get;
            set;
        }

    }

    public class Medal {
        public string CountryName {
            get;
            set;
        }

        public double GoldMedals {
            get;
            set;
        }

        public double SilverMedals {
            get;
            set;
        }

        public double BronzeMedals {
            get;
            set;
        }

    }

    public class GoldInventory {
        public double Year {
            get;
            set;
        }

        public double Inferred {
            get;
            set;
        }

        public double Measured {
            get;
            set;
        }

        public double Reserves {
            get;
            set;
        }
    }
}
