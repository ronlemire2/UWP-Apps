using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FeedReader.Views {
    public sealed partial class FeedsHeaderUC : UserControl {
        public FeedsHeaderUC() {
            this.InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }

        // FeedType property
        public string FeedType {
            get { return (string)GetValue(FeedTypeProperty); }
            set { SetValueDp(FeedTypeProperty, value); }
        }
        public static readonly DependencyProperty FeedTypeProperty =
            DependencyProperty.Register("FeedType", typeof(string), typeof(FeedsHeaderUC), new PropertyMetadata(null));


        // reuse
        public event PropertyChangedEventHandler PropertyChanged;
        void SetValueDp(DependencyProperty property, object value, [System.Runtime.CompilerServices.CallerMemberName] String p = null) {
            SetValue(property, value);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
