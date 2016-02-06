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
    public sealed partial class PagingPage : Page {
        public PagingPage() {
            this.InitializeComponent();
            this.OrientationComboBox.SelectionChanged += OrientationComboBox_SelectionChanged;
        }

        private void OrientationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboBox = sender as ComboBox;
            if (comboBox != null) {
                if (comboBox.SelectedIndex == 0) {
                    Grid.SetRow(sfDataPager, 1);
                    Grid.SetColumn(sfDataPager, 0);
                }
                else {
                    Grid.SetRow(sfDataPager, 0);
                    Grid.SetColumn(sfDataPager, 1);
                }
            }
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e) {
            optionsStackPanel.Visibility = optionsStackPanel.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
