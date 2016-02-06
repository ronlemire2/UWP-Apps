using Bing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BingSearcher.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImagesPage : Page {
        public ImagesPage() {
            this.InitializeComponent();
        }

        private async void Search_Click(object sender, RoutedEventArgs e) {
            string accountKey = "<ApiKey goes here>";

            var context = new BingSearchContainer(new Uri("https://api.datamarket.azure.com/Data.ashx/Bing/Search"));
            context.Credentials = new NetworkCredential(accountKey, accountKey);

            var result = await context.Image(this.SearchQuery.Text, "en-US", null, null, null, null).ExecuteAsync();
            ImagesList.ItemsSource = result.ToList();
        }

        private async void Save_Click(object sender, RoutedEventArgs e) {
            var image = ImagesList.SelectedItem as ImageResult;
            if (image == null) return;

            var uri = new Uri(image.MediaUrl);
            var filename = uri.Segments[uri.Segments.Length - 1];
            var extension = System.IO.Path.GetExtension(filename);

            var picker = new FileSavePicker();
            picker.SuggestedFileName = filename;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeChoices.Add(extension.Trim('.').ToUpper(), new string[] { extension });

            var saveFile = await picker.PickSaveFileAsync();
            if (saveFile != null) {
                Status.Text = "Download Started";
                var download = new BackgroundDownloader().CreateDownload(uri, saveFile);
                await download.StartAsync();
                Status.Text = "Download Complete";
            }
        }
    }
}
