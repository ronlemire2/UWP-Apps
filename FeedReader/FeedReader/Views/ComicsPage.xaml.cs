using FeedReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FeedReader.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ComicsPage : Page {
        public ComicsPage() {
            this.InitializeComponent();
            Loaded += ComicsPage_Loaded;
        }

        private void ComicsPage_Loaded(object sender, RoutedEventArgs e) {
            (this.wideSeZo.ZoomedOutView as ListViewBase).ItemsSource = FeedsViewSource.View.CollectionGroups;
            (this.narrowSeZo.ZoomedOutView as ListViewBase).ItemsSource = FeedsViewSource.View.CollectionGroups;
        }

        private void switchViews_Click(object sender, RoutedEventArgs e) {
            if (wideSeZo.Visibility == Visibility.Visible) {
                wideSeZo.ToggleActiveView();
                switchViews.Content = wideSeZo.IsZoomedInViewActive ? "\uE71F" : "\uE8A3";
            }
            else {
                narrowSeZo.ToggleActiveView();
                switchViews.Content = narrowSeZo.IsZoomedInViewActive ? "\uE71F" : "\uE8A3";
            }
        }

        private void wideSeZo_ViewChangeCompleted(object sender, SemanticZoomViewChangedEventArgs e) {
            switchViews.Content = wideSeZo.IsZoomedInViewActive ? "\uE71F" : "\uE8A3";
        }

        private void narrowSeZo_ViewChangeCompleted(object sender, SemanticZoomViewChangedEventArgs e) {
            switchViews.Content = narrowSeZo.IsZoomedInViewActive ? "\uE71F" : "\uE8A3";
        }
    }
}
