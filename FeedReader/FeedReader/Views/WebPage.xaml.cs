using FeedReader.Models;
using FeedReader.ViewModels;
using Prism.Windows.Mvvm;
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

namespace FeedReader.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WebPage : SessionStateAwarePage {
        public WebPage() {
            this.InitializeComponent();
            this.contentView.NavigationCompleted += ContentView_NavigationCompleted;
            this.contentView.NavigationStarting += ContentView_NavigationStarting;
            this.contentView.NavigationFailed += ContentView_NavigationFailed;
        }

        #region EventHandlers

        private void ContentView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args) {
            progressBar.Visibility = Visibility.Visible;
            webGrid.Visibility = Visibility.Collapsed;
        }

        private void ContentView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args) {
            progressBar.Visibility = Visibility.Collapsed;
            webGrid.Visibility = Visibility.Visible;
        }

        private void ContentView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e) {

        }

        protected override void LoadState(object navigationParameter, Dictionary<string, object> pageState) {
            FeedItem selectedFeedItem = (FeedItem)navigationParameter;
            this.contentView.Navigate(selectedFeedItem.Link);
            this.DataContext = selectedFeedItem;
            base.LoadState(navigationParameter, pageState);
        }

        protected override void SaveState(Dictionary<string, object> pageState) {
            this.contentView.NavigateToString("");
            base.SaveState(pageState);
        }

        #endregion

        private async void back_Click(object sender, RoutedEventArgs e) {
            // http://stackoverflow.com/questions/11720913/winrt-webview-back-button
            await contentView.InvokeScriptAsync("eval", new[] { "history.go(-1)" });

            // TODO: Instead of javascript try these -
            // https://social.msdn.microsoft.com/Forums/en-US/7580c125-c27d-4b15-9bcc-ced5b201436b/creating-a-simple-backbutton-with-webview-in-windows-metro?forum=winappswithnativecode
            // http://stackoverflow.com/questions/7873632/adding-back-and-forward-button-for-webbrowser-control

        }
    }
}
