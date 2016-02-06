using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class DataBindingPage : Page {
        public DataBindingPage() {
            this.InitializeComponent();
            this.comboBinding.SelectionChanged += SelectionChanged;
        }

        private async void SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e) {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                if (dataBindArea != null) {
                    if (!(dataBindArea.Content is ListBindingUC) && ((ComboBoxItem)e.AddedItems[0]).Content.Equals("List"))
                        dataBindArea.Content = new ListBindingUC();
                    else
                        dataBindArea.Content = new ObservableCollectionBindingUC();
                }
            });

        }

        public void Dispose() {
            this.comboBinding.SelectionChanged -= SelectionChanged;
            if (dataBindArea.Content != null) {
                if (dataBindArea.Content is ListBindingUC) {
                    (dataBindArea.Content as ListBindingUC).Dispose();
                }
                else if (dataBindArea.Content is ObservableCollectionBindingUC) {
                    (dataBindArea.Content as ObservableCollectionBindingUC).Dispose();
                }
            }
        }
    }
}
