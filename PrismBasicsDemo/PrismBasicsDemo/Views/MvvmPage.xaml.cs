using PrismBasicsDemo.ViewModels;
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
    public sealed partial class MvvmPage : Page {
        public MvvmPage() {
            this.InitializeComponent();
            PlanetCoverFlowSlider.Focus(FocusState.Programmatic);
        }

        // 1/13/2016 I tried doing Interactivity Event Binding but got this error:
        // Cannot add instance of type Microsoft.Xaml.Interactions.Core.EventTriggerBehavior to a collection of type Microsoft.Xaml.Interactivity.BehaviorCollection.
        // Not sure what the problem is. CoverFlow inherits from ItemsControl same as ListView which works with Interactivity Event Binding.
        private void PlanetCoverFlow_SelectedItemChanged(CoverFlowUWP.CoverFlowEventArgs e) {
            ((MvvmPageViewModel)this.DataContext).SelectedPlanetVM = (PlanetViewModel)e.Item;
        }
    }
}
