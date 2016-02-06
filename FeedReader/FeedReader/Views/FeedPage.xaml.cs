using FeedReader.Models;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class FeedPage : SessionStateAwarePage {
        public FeedPage() {
            this.InitializeComponent();
        }

        #region EventHandlers

        protected override void LoadState(object navigationParameter, Dictionary<string, object> pageState) {
            base.LoadState(navigationParameter, pageState);
        }

        protected override void SaveState(Dictionary<string, object> pageState) {
            base.SaveState(pageState);
        }

        private async void FeedPageListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // SelectionChanged handled in code behind because calling 'contentView.Navigate' from ViewModel breaks MVVM.
            // ViewModel should not know details about View.
            try {
                Selector list = sender as Selector;
                FeedItem selectedItem = list.SelectedItem as FeedItem;
                this.contentView.NavigateToString("");
                if (selectedItem != null) {
                    WaitGrid2.Visibility = Visibility.Visible;
                    progressRing2.Visibility = Visibility.Visible;
                    progressRing2.IsActive = true;
                    await Task.Delay(1);
                    this.contentView.Navigate(selectedItem.Link);
                    progressRing2.Visibility = Visibility.Collapsed;
                    progressRing2.IsActive = false;
                    WaitGrid2.Visibility = Visibility.Collapsed;
                }
                else {
                    this.contentView.NavigateToString("");
                }
            }
            catch (Exception x) {
                MessageDialog errorDialog = new MessageDialog(x.Message, "Feed Problem");
                await errorDialog.ShowAsync();
                progressRing2.Visibility = Visibility.Collapsed;
                progressRing2.IsActive = false;
                WaitGrid2.Visibility = Visibility.Collapsed;
            }
        }

        private void contentView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e) {

        }

        protected override void OnLostFocus(RoutedEventArgs e) {
            this.contentView.NavigateToString("");
            base.OnLostFocus(e);
        }

        #endregion
    }
}
