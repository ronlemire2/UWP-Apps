using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class AnnotationsPage : Page {
        public AnnotationsPage() {
            this.InitializeComponent();
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
                scatterChart1.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
        }

        public void Dispose() {
            if (this.scatterChart1 != null) {
                foreach (var series in this.scatterChart1.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.lineChart != null) {
                foreach (var series in this.lineChart.Series) {
                    series.ClearValue(ChartSeriesBase.ItemsSourceProperty);
                }
            }
            if (this.DataContext is DataViewModel)
                (this.DataContext as DataViewModel).Dispose();
            if (this.DataContext is AnnotationViewModel)
                (this.DataContext as AnnotationViewModel).Dispose();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {
            if (comboBox != null) {
                if (lineChart == null) return;
                if (comboBox.SelectedIndex == 0) {
                    lineChart.Visibility = Visibility.Visible;
                    scatterChart1.Visibility = Visibility.Collapsed;

                }
                else if (comboBox.SelectedIndex == 1) {
                    lineChart.Visibility = Visibility.Collapsed;
                    scatterChart1.Visibility = Visibility.Visible;

                }
            }
        }
    }

    public class AnnotationDataModel {
        private DateTime timestamp;

        public DateTime TimeStamp {
            get {
                return timestamp;
            }
            set {
                timestamp = value;
            }
        }
        private double rainfall;

        public double RainFall {
            get {
                return rainfall;
            }
            set {
                rainfall = value;
            }
        }

    }

    public  class DataViewModel : ObservableCollection<AnnotationDataModel>, INotifyPropertyChanged, IDisposable {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private List<AnnotationDataModel> datalist;

        public List<AnnotationDataModel> Datalist {
            get {
                return datalist;
            }
            set {
                datalist = value;
                RaisePropertyChanged("Datalist");
            }
        }
        public DataViewModel() {
            Datalist = new List<AnnotationDataModel>();
            LoadData();
        }

        async void LoadData() {
            Datalist = await GenerateData();
        }

        async Task<List<AnnotationDataModel>> GenerateData() {
            List<AnnotationDataModel> data = new List<AnnotationDataModel>();

            var Path = @"Data\Data.csv";

            data = await GetDatas(Path);
            return data;
        }

        public static async Task<List<AnnotationDataModel>> GetDatas(string fileName) {
            char[] comma = new char[] { ',' };
            char[] slashN = new char[] { '\n' };
            List<AnnotationDataModel> list = new List<AnnotationDataModel>();

            var Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await Folder.GetFileAsync(fileName);
            //StorageFile file = await StorageFile.GetFileFromPathAsync(Windows.ApplicationModel.Package.Current.InstalledLocation.Path + fileName);
            IList<string> lines = await Windows.Storage.FileIO.ReadLinesAsync(file);
            bool firstLine = true;
            string[] values;
            int count = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile" ? lines.Count() - 2 :
                             lines.Count() - 1100;
            AnnotationDataModel priceInfo;
            int index = 0;
            foreach (string line in lines) {
                if (count != -1 && index >= count)
                    break;
                if (!firstLine) {
                    values = line.Split(comma);
                    if (values.GetLength(0) > 5) {
                        priceInfo = new AnnotationDataModel() {
                            TimeStamp = DateTime.Parse(values[0], CultureInfo.InvariantCulture),
                            RainFall = double.Parse(values[1]),
                        };
                        list.Insert(index, priceInfo);
                        index++;
                    }
                }
                else {
                    firstLine = false;
                }
            }
            return list;
        }


        public void Dispose() {
            if (this.Datalist != null)
                this.Datalist.Clear();
        }
    }

    public class AnnotationViewModel : IDisposable {
        public AnnotationViewModel() {
            DataModel = new ObservableCollection<AnnotationModel>();
            DataModel.Add(new AnnotationModel() { Over = 1, Runs = 4 });
            DataModel.Add(new AnnotationModel() { Over = 2, Runs = 8, PlayerName = "CL White", Score = "10 (6)" });
            DataModel.Add(new AnnotationModel() { Over = 3, Runs = 12 });
            DataModel.Add(new AnnotationModel() { Over = 4, Runs = 3 });
            DataModel.Add(new AnnotationModel() { Over = 5, Runs = 10 });
            DataModel.Add(new AnnotationModel() { Over = 6, Runs = 6 });
            DataModel.Add(new AnnotationModel() { Over = 7, Runs = 11, PlayerName = "AJ Finch", Score = "30 (24)" });
            DataModel.Add(new AnnotationModel() { Over = 8, Runs = 5 });
            DataModel.Add(new AnnotationModel() { Over = 9, Runs = 4 });
            DataModel.Add(new AnnotationModel() { Over = 10, Runs = 12 });
            DataModel.Add(new AnnotationModel() { Over = 11, Runs = 8 });
            DataModel.Add(new AnnotationModel() { Over = 12, Runs = 14, PlayerName = "GJ Smith", Score = "25 (14)" });
            DataModel.Add(new AnnotationModel() { Over = 13, Runs = 12 });
            DataModel.Add(new AnnotationModel() { Over = 14, Runs = 15 });
            DataModel.Add(new AnnotationModel() { Over = 15, Runs = 10 });
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile") {
                DataModel.Add(new AnnotationModel() { Over = 16, Runs = 14 });
                DataModel.Add(new AnnotationModel() { Over = 17, Runs = 16 });
                DataModel.Add(new AnnotationModel() { Over = 18, Runs = 9 });
                DataModel.Add(new AnnotationModel() { Over = 19, Runs = 10, PlayerName = "GJ Bailey", Score = "78 (40)" });
                DataModel.Add(new AnnotationModel() { Over = 20, Runs = 18 });
            }
        }
        public ObservableCollection<AnnotationModel> DataModel {
            get;
            set;
        }

        public void Dispose() {
            if (this.DataModel != null)
                this.DataModel.Clear();
        }
    }

    public class AnnotationModel {
        public double Over {
            get;
            set;
        }

        public double Runs {
            get;
            set;
        }

        public string PlayerName {
            get;
            set;
        }

        public string Score {
            get;
            set;
        }
    }

    public class AnnotationDataModel1 {
        public DateTime TimeStamp {
            get;
            set;
        }
        public double RainFall {
            get;
            set;
        }

    }

    public class DataViewModel1 : ObservableCollection<AnnotationDataModel1> {
        public List<AnnotationDataModel1> Datalist {
            get;
            set;
        }

        public DataViewModel1() {
            Datalist = new List<AnnotationDataModel1>();
            Datalist = this.GetPricesFromCSVFile();
        }

        public List<AnnotationDataModel1> GetPricesFromCSVFile() {
            List<AnnotationDataModel1> list = new List<AnnotationDataModel1>();
            Random rand = new Random();
            DateTime now = new DateTime(2007, 1, 1);
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 120 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 150 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 170 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 176 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 180 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 200 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 210 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 200 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 240 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 230 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 200 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 190 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 220 });
            list.Add(new AnnotationDataModel1() { TimeStamp = now.AddMonths(list.Count()), RainFall = 200 });
            return list;
        }

    }

    public class AnnotationViewModel1 {
        public AnnotationViewModel1() {
            DataModel = new ObservableCollection<AnnotationModel1>();
            DataModel.Add(new AnnotationModel1() { Over = 1, Runs = 4 });
            DataModel.Add(new AnnotationModel1() { Over = 2, Runs = 8, PlayerName = "CL James", Score = "10 (6)" });
            DataModel.Add(new AnnotationModel1() { Over = 3, Runs = 12 });
            DataModel.Add(new AnnotationModel1() { Over = 4, Runs = 3 });
            DataModel.Add(new AnnotationModel1() { Over = 5, Runs = 10 });
            DataModel.Add(new AnnotationModel1() { Over = 6, Runs = 6 });
            DataModel.Add(new AnnotationModel1() { Over = 7, Runs = 11, PlayerName = "AJ Erich", Score = "30 (24)" });
            DataModel.Add(new AnnotationModel1() { Over = 8, Runs = 5 });
            DataModel.Add(new AnnotationModel1() { Over = 9, Runs = 4 });
            DataModel.Add(new AnnotationModel1() { Over = 10, Runs = 12 });
            DataModel.Add(new AnnotationModel1() { Over = 11, Runs = 8 });
            DataModel.Add(new AnnotationModel1() { Over = 12, Runs = 14, PlayerName = "GJ Louis", Score = "25 (14)" });
            DataModel.Add(new AnnotationModel1() { Over = 13, Runs = 12 });
            DataModel.Add(new AnnotationModel1() { Over = 14, Runs = 15 });
            DataModel.Add(new AnnotationModel1() { Over = 15, Runs = 10 });
        }
        public ObservableCollection<AnnotationModel1> DataModel {
            get;
            set;
        }
    }

    public class AnnotationModel1 {
        public double Over {
            get;
            set;
        }

        public double Runs {
            get;
            set;
        }

        public string PlayerName {
            get;
            set;
        }

        public string Score {
            get;
            set;
        }
    }
}
