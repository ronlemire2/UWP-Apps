using Prism.Unity.Windows;
using Prism.Windows.Navigation;
using SfDataGridDemo.Controls;
using SfDataGridDemo.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SfDataGridDemo {
    /// <summary>
    /// The "chrome" layer of the app that provides top-level navigation with
    /// proper keyboarding navigation.
    /// </summary>
    public sealed partial class AppShell : Page {
        // Declare the top level nav items
        private List<NavMenuItem> navlist = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "AddNewRow",
                    DestPage = typeof(AddNewRowPage),
                    PageToken = "AddNewRow"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "AdvancedFiltering",
                    DestPage = typeof(AdvancedFilteringPage),
                    PageToken = "AdvancedFiltering"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "AutoCellMerge",
                    DestPage = typeof(AutoCellMergePage),
                    PageToken = "AutoCellMerge"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "AutoRowHeight",
                    DestPage = typeof(AutoRowHeightPage),
                    PageToken = "AutoRowHeight"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "BasicFiltering",
                    DestPage = typeof(BasicFilteringPage),
                    PageToken = "BasicFiltering"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "CellMerge",
                    DestPage = typeof(CellMergePage),
                    PageToken = "CellMerge"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "CellSelection",
                    DestPage = typeof(CellSelectionPage),
                    PageToken = "CellSelection"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "ColumnSizing",
                    DestPage = typeof(ColumnSizingPage),
                    PageToken = "ColumnSizing"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "DataBinding",
                    DestPage = typeof(DataBindingPage),
                    PageToken = "DataBinding"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "DataValidation",
                    DestPage = typeof(DataValidationPage),
                    PageToken = "DataValidation"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "DataVirtualization",
                    DestPage = typeof(DataVirtualizationPage),
                    PageToken = "DataVirtualization"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "Editing",
                    DestPage = typeof(EditingPage),
                    PageToken = "Editing"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "ExcelExporting",
                    DestPage = typeof(ExcelExportingPage),
                    PageToken = "ExcelExporting"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "FreezePanes",
                    DestPage = typeof(FreezePanesPage),
                    PageToken = "FreezePanes"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "GettingStarted",
                    DestPage = typeof(GettingStartedPage),
                    PageToken = "GettingStarted"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "Grouping",
                    DestPage = typeof(GroupingPage),
                    PageToken = "Grouping"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "GroupSummaries",
                    DestPage = typeof(GroupSummariesPage),
                    PageToken = "GroupSummaries"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "IncrementalLoading",
                    DestPage = typeof(IncrementalLoadingPage),
                    PageToken = "IncrementalLoading"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "IntervalGrouping",
                    DestPage = typeof(IntervalGroupingPage),
                    PageToken = "IntervalGrouping"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "MasterDetail",
                    DestPage = typeof(MasterDetailPage),
                    PageToken = "MasterDetail"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "NestedGrids",
                    DestPage = typeof(NestedGridsPage),
                    PageToken = "NestedGrids"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "NestedPropertyBinding",
                    DestPage = typeof(NestedPropertyBindingPage),
                    PageToken = "NestedPropertyBinding"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "OnDemandPaging",
                    DestPage = typeof(OnDemandPagingPage),
                    PageToken = "OnDemandPaging"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "Paging",
                    DestPage = typeof(PagingPage),
                    PageToken = "Paging"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "PdfExporting",
                    DestPage = typeof(PdfExportingPage),
                    PageToken = "PdfExporting"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "Printing",
                    DestPage = typeof(PrintingPage),
                    PageToken = "Printing"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "Serialization",
                    DestPage = typeof(SerializationPage),
                    PageToken = "Serialization"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "Sorting",
                    DestPage = typeof(SortingPage),
                    PageToken = "Sorting"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "SortBySummary",
                    DestPage = typeof(SortBySummaryPage),
                    PageToken = "SortBySummary"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "Styling",
                    DestPage = typeof(StylingPage),
                    PageToken = "Styling"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "StackedHeaders",
                    DestPage = typeof(StackedHeadersPage),
                    PageToken = "StackedHeaders"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "UnboundColumn",
                    DestPage = typeof(UnboundColumnPage),
                    PageToken = "UnboundColumn"
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.OutlineStar,
                    Label = "UnboundRow",
                    DestPage = typeof(UnboundRowPage),
                    PageToken = "UnboundRow"
                },
            });

        public static AppShell Current = null;

        // rjl: Changed original Mical Lewis' code to use Prism's Navigation Frame instead of AppShell's Frame.
        private Frame appFrame;
        public Frame AppFrame { get { return appFrame; } }

        public void SetContentFrame(Frame frame) {
            splitView.Content = frame;
            appFrame = frame;

            // Add what was previously done in AppShell.xaml
            appFrame.Navigating += OnNavigatingToPage;
            appFrame.Navigated += OnNavigatedToPage;
            appFrame.ContentTransitions = new Windows.UI.Xaml.Media.Animation.TransitionCollection();
            NavigationThemeTransition navTransition = new NavigationThemeTransition();
            navTransition.DefaultNavigationTransitionInfo = new EntranceNavigationTransitionInfo();
            appFrame.ContentTransitions.Add(navTransition);
        }

        public void SetMenuPaneContent(UIElement content) {
            splitView.Pane = content;
        }

        /// <summary>
        /// Initializes a new instance of the AppShell, sets the static 'Current' reference,
        /// adds callbacks for Back requests and changes in the SplitView's DisplayMode, and
        /// provide the nav menu list with the data to display.
        /// </summary>
        public AppShell() {

            this.InitializeComponent();

            this.Loaded += (sender, args) => {
                Current = this;

                //this.TogglePaneButton.Focus(FocusState.Programmatic);
            };

            this.splitView.RegisterPropertyChangedCallback(
                SplitView.DisplayModeProperty,
                (s, a) => {
                    // Ensure that we update the reported size of the TogglePaneButton when the SplitView's
                    // DisplayMode changes.
                    this.CheckTogglePaneButtonSizeChanged();
                });

            //SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;

            // If on a phone device that has hardware buttons then we hide the app's back button.
            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")) {
                this.backButton.Visibility = Visibility.Collapsed;
            }

            NavMenuList.ItemsSource = navlist;
        }

        /// <summary>
        /// Default keyboard focus movement for any unhandled keyboarding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppShell_KeyDown(object sender, KeyRoutedEventArgs e) {
            FocusNavigationDirection direction = FocusNavigationDirection.None;
            switch (e.Key) {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.GamepadDPadLeft:
                case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
                case Windows.System.VirtualKey.NavigationLeft:
                    direction = FocusNavigationDirection.Left;
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.GamepadDPadRight:
                case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                case Windows.System.VirtualKey.NavigationRight:
                    direction = FocusNavigationDirection.Right;
                    break;

                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.GamepadDPadUp:
                case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
                case Windows.System.VirtualKey.NavigationUp:
                    direction = FocusNavigationDirection.Up;
                    break;

                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.GamepadDPadDown:
                case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
                case Windows.System.VirtualKey.NavigationDown:
                    direction = FocusNavigationDirection.Down;
                    break;
            }

            if (direction != FocusNavigationDirection.None) {
                var control = FocusManager.FindNextFocusableElement(direction) as Control;
                if (control != null) {
                    control.Focus(FocusState.Programmatic);
                    e.Handled = true;
                }
            }
        }

        #region BackRequested Handlers

        //private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e) {
        //    bool handled = e.Handled;
        //    this.BackRequested(ref handled);
        //    e.Handled = handled;
        //}

        private void backButton_Click(object sender, RoutedEventArgs e) {
            // Get a hold of the current frame so that we can inspect the app back stack.
            if (this.AppFrame == null)
                return;

            // Check to see if this is the top-most page on the app back stack.
            if (this.AppFrame.CanGoBack) {
                // If not, set the event to handled and go back to the previous page in the app.
                this.AppFrame.GoBack();
            }
        }

        #endregion

        #region Navigation

        /// <summary>
        /// Navigate to the Page for the selected <paramref name="listViewItem"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="listViewItem"></param>
        private void NavMenuList_ItemInvoked(object sender, ListViewItem listViewItem) {
            var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(listViewItem);

            if (item != null) {
                if (item.DestPage != null &&
                    item.DestPage != this.AppFrame.CurrentSourcePageType) {
                    this.AppFrame.Navigate(item.DestPage, item.Arguments);
                }
            }
        }

        /// <summary>
        /// Ensures the nav menu reflects reality when navigation is triggered outside of
        /// the nav menu buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back) {
                var item = (from p in this.navlist where p.DestPage == e.SourcePageType select p).SingleOrDefault();
                if (item == null && this.AppFrame.BackStackDepth > 0) {
                    // In cases where a page drills into sub-pages then we'll highlight the most recent
                    // navigation menu item that appears in the BackStack
                    foreach (var entry in this.AppFrame.BackStack.Reverse()) {
                        item = (from p in this.navlist where p.DestPage == entry.SourcePageType select p).SingleOrDefault();
                        if (item != null)
                            break;
                    }
                }

                var container = (ListViewItem)NavMenuList.ContainerFromItem(item);

                // While updating the selection state of the item prevent it from taking keyboard focus.  If a
                // user is invoking the back button via the keyboard causing the selected nav menu item to change
                // then focus will remain on the back button.
                if (container != null) container.IsTabStop = false;
                NavMenuList.SetSelectedItem(container);
                if (container != null) container.IsTabStop = true;
            }
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e) {
            // After a successful navigation set keyboard focus to the loaded page
            if (e.Content is Page && e.Content != null) {
                var control = (Page)e.Content;
                control.Loaded += Page_Loaded;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            ((Page)sender).Focus(FocusState.Programmatic);
            ((Page)sender).Loaded -= Page_Loaded;
            this.CheckTogglePaneButtonSizeChanged();
            titleTextBlock.Text = ((Page)sender).Name;
        }

        #endregion

        public Rect TogglePaneButtonRect {
            get;
            private set;
        }

        /// <summary>
        /// An event to notify listeners when the hamburger button may occlude other content in the app.
        /// The custom "PageHeader" user control is using this.
        /// </summary>
        public event TypedEventHandler<AppShell, Rect> TogglePaneButtonRectChanged;

        /// <summary>
        /// Callback when the SplitView's Pane is toggled open or close.  When the Pane is not visible
        /// then the floating hamburger may be occluding other content in the app unless it is aware.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TogglePaneButton_Checked(object sender, RoutedEventArgs e) {
            this.CheckTogglePaneButtonSizeChanged();
        }

        /// <summary>
        /// Check for the conditions where the navigation pane does not occupy the space under the floating
        /// hamburger button and trigger the event.
        /// </summary>
        private void CheckTogglePaneButtonSizeChanged() {
            if (this.splitView.DisplayMode == SplitViewDisplayMode.Inline ||
                this.splitView.DisplayMode == SplitViewDisplayMode.Overlay) {
                //var transform = this.TogglePaneButton.TransformToVisual(this);
                //var rect = transform.TransformBounds(new Rect(0, 0, this.TogglePaneButton.ActualWidth, this.TogglePaneButton.ActualHeight));
                //this.TogglePaneButtonRect = rect;
            }
            else {
                this.TogglePaneButtonRect = new Rect();
            }

            var handler = this.TogglePaneButtonRectChanged;
            if (handler != null) {
                // handler(this, this.TogglePaneButtonRect);
                handler.DynamicInvoke(this, this.TogglePaneButtonRect);
            }
        }

        /// <summary>
        /// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
        /// using the associated Label of each item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavMenuItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args) {
            if (!args.InRecycleQueue && args.Item != null && args.Item is NavMenuItem) {
                args.ItemContainer.SetValue(AutomationProperties.NameProperty, ((NavMenuItem)args.Item).Label);
            }
            else {
                args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
            }
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e) {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

    }
}
