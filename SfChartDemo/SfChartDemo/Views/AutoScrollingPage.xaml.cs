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
    public sealed partial class AutoScrollingPage : Page {
        private SfChart chart;
        DispatcherTimer timer = new DispatcherTimer();
        DateTime date;

        public AutoScrollingPage() {
            this.InitializeComponent();
            date = new DateTime();
            chart = Chart1;
            timer.Start();
            timer.Interval = TimeSpan.FromMilliseconds(150);
            timer.Tick += timer_Tick;
            XAxis.ActualRangeChanged += XAxis_ActualRangeChanged;
        }

        private void XAxis_ActualRangeChanged(object sender, ActualRangeChangedEventArgs e) {
            if (!e.IsScrolling && e.ActualMaximum != null) {
                e.VisibleMinimum = (double)e.ActualMaximum - 50d;
            }
        }


        private void timer_Tick(object sender, object e) {
            if (this.chart.Series[0].ItemsSource == null) return;
            var data = this.chart.DataContext as ProductDetails;
            date = data[data.Count - 1].Speed.AddMinutes(1d);
            Random rand = new Random();
            data.Add(new Product() { Speed = date, Rate = rand.Next(100, 250) });
        }

    }

    public class Product {
        public DateTime Speed {
            get;
            set;
        }

        public DateTime Date {
            get;
            set;
        }

        public double Rate {
            get;
            set;
        }
    }

    public class ProductDetails : ObservableCollection<Product> {
        public ProductDetails() {
            Random rand = new Random();
            DateTime dt = DateTime.Now;

            for (int i = 11; i < 140; i++) {
                this.Add(new Product { Rate = rand.Next(110, 240), Speed = dt });
                dt = dt.AddMinutes(i);
            }

        }
    }

    public class ProductDetails5 : ObservableCollection<Product> {
        public ProductDetails5() {
            Random rand = new Random();
            DateTime dt = DateTime.Now;
            int count = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile" ? 30 : 20;
            for (int i = 10; i < count; i++) {
                this.Add(new Product { Rate = rand.Next(110, 240), Speed = dt, Date = dt.AddDays(i) });
                dt = dt.AddMinutes(i);
            }

        }
    }
}

