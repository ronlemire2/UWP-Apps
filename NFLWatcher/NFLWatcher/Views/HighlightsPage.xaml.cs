using MyToolkit.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace NFLWatcher.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HighlightsPage : Page {
        public HighlightsPage() {
            this.InitializeComponent();
        }

        // TODO: Do this in an MVVM way.
        // http://stackoverflow.com/questions/10631748/mvvm-pattern-violation-mediaelement-play
        // http://anand-prakash.net/2013/03/31/using-and-customizing-player-framework-in-windows-8-xaml-apps/
        // http://playerframework.codeplex.com/
        private async void YouTubeSearchItems_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var url = await YouTube.GetVideoUriAsync(YouTubeUrl.Text, YouTubeQuality.Quality720P);
            if (url != null) {
                player.Source = url.Uri;
                player.Play();
            }
            else {
                var messageDialog = new MessageDialog("MyToolkit not working.");
                await messageDialog.ShowAsync();
            }
        }
    }
}
