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

namespace PrismBasicsDemo.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LifecycleAddPage : SessionStateAwarePage {
        public LifecycleAddPage() {
            this.InitializeComponent();
        }

        protected override void SaveState(Dictionary<string, object> pageState) {
            if (pageState == null) {
                return;
            }

            base.SaveState(pageState);

            pageState["SessionStateAwarePageTextBox"] = SessionStateAwarePageTextBox.Text;
        }

        protected override void LoadState(object navigationParameter, Dictionary<string, object> pageState) {
            if (pageState == null) {
                return;
            }

            base.LoadState(navigationParameter, pageState);

            SessionStateAwarePageTextBox.Text = pageState["SessionStateAwarePageTextBox"].ToString();
        }
    }
}
