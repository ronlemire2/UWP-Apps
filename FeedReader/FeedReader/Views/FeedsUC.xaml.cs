using FeedReader.Models;
using FeedReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
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
    public sealed partial class FeedsUC : UserControl {
        public FeedsUC() {
            this.InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }

        // Feeds property
        public ObservableCollection<Feed> Feeds {
            get { return (ObservableCollection<Feed>)GetValue(FeedsProperty); }
            set { SetValueDp(FeedsProperty, value); }
        }
        public static readonly DependencyProperty FeedsProperty =
            DependencyProperty.Register("Feeds", typeof(ObservableCollection<string>), typeof(FeedsUC), new PropertyMetadata(null));

        // SelectedFeed property
        public Feed SelectedFeed {
            get { return (Feed)GetValue(SelectedFeedProperty); }
            set { SetValueDp(SelectedFeedProperty, value); }
        }
        public static readonly DependencyProperty SelectedFeedProperty =
            DependencyProperty.Register("SelectedFeed", typeof(Feed), typeof(FeedsUC), new PropertyMetadata(0));

        // Name property
        public string FeedName {
            get { return (string)GetValue(FeedNameProperty); }
            set { SetValueDp(FeedNameProperty, value); }
        }
        public static readonly DependencyProperty FeedNameProperty =
            DependencyProperty.Register("FeedName", typeof(string), typeof(FeedsUC), new PropertyMetadata(null));

        // LastUpdated property
        public string LastUpdated {
            get { return (string)GetValue(LastUpdatedProperty); }
            set { SetValueDp(LastUpdatedProperty, value); }
        }
        public static readonly DependencyProperty LastUpdatedProperty =
            DependencyProperty.Register("LastUpdated", typeof(string), typeof(FeedsUC), new PropertyMetadata(null));

        // GridViewSelectionChangedCommand property
        // http://stackoverflow.com/questions/29126224/how-do-i-bind-wpf-commands-between-a-usercontrol-and-a-parent-window
        public ICommand GridViewSelectionChangedCommand {
            get { return (ICommand)GetValue(GridViewSelectionChangedCommandProperty); }
            set { SetValueDp(GridViewSelectionChangedCommandProperty, value); }
        }
        public static readonly DependencyProperty GridViewSelectionChangedCommandProperty =
            DependencyProperty.Register(
                "GridViewSelectionChangedCommand",
                typeof(ICommand),
                typeof(FeedsUC),
                new PropertyMetadata(null));

        // ListViewSelectionChangedCommand property
        // http://stackoverflow.com/questions/29126224/how-do-i-bind-wpf-commands-between-a-usercontrol-and-a-parent-window
        public ICommand ListViewSelectionChangedCommand {
            get { return (ICommand)GetValue(ListViewSelectionChangedCommandProperty); }
            set { SetValueDp(ListViewSelectionChangedCommandProperty, value); }
        }
        public static readonly DependencyProperty ListViewSelectionChangedCommandProperty =
            DependencyProperty.Register(
                "ListViewSelectionChangedCommand",
                typeof(ICommand),
                typeof(FeedsUC),
                new PropertyMetadata(null));


        // reuse
        public event PropertyChangedEventHandler PropertyChanged;
        void SetValueDp(DependencyProperty property, object value, [System.Runtime.CompilerServices.CallerMemberName] String p = null) {
            SetValue(property, value);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        private void FeedsListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //((BasePageViewModel)this.DataContext).SelectedFeed = (Feed)FeedsListView.SelectedItem;
        }

        private void FeedsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ((BasePageViewModel)this.DataContext).SelectedFeed = (Feed)FeedsGridView.SelectedItem;

        }
    }
}
