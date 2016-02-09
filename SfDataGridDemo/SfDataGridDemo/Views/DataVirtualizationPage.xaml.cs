using SfDataGridDemo.Services;
using SfDataGridDemo.ViewModels;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace SfDataGridDemo.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataVirtualizationPage : Page {
        GridVirtualizingCollectionView view;
        ObservableCollection<EmployeeViewModel> employees;
        int itemCount = 0;
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        public DataVirtualizationPage() { 
            this.InitializeComponent();
            this.Loaded += DataVirtualizationPage_Loaded;
        }

        private void DataVirtualizationPage_Loaded(object sender, RoutedEventArgs e) {
            this.LoadView.Visibility = Visibility.Visible;
            this.GridView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void Item1_Checked(object sender, RoutedEventArgs e) {
            if (Item2 != null && Item3 != null) {
                Item2.IsChecked = false;
                Item3.IsChecked = false;
            }
            itemCount = 100000;
        }

        private void Item2_Checked(object sender, RoutedEventArgs e) {
            Item1.IsChecked = false;
            Item3.IsChecked = false;
            itemCount = 300000;
        }

        private void Item3_Checked(object sender, RoutedEventArgs e) {
            Item1.IsChecked = false;
            Item2.IsChecked = false;
            itemCount = 500000;
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            this.LoadView.Visibility = Visibility.Collapsed;
            //if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile") {
            //    this.mainGrid.Visibility = Visibility.Visible;
            //    optionbutton.Content = "Options";
            //}
            progressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            await Task.Delay(50);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            employees = employeeRepository.GetEmployeesVMs(itemCount);
            watch.Stop();
            PopulationTime.Text = watch.ElapsedMilliseconds.ToString() + " ms";
            watch.Reset();
            watch.Start();
            view = new GridVirtualizingCollectionView(employees);
            this.sfDataGrid.ItemsSource = view;
            watch.Stop();
            LoadingTime.Text = watch.ElapsedMilliseconds.ToString() + " ms";
            GridView.Visibility = Visibility.Visible;
            progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
    }
}
