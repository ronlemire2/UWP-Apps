using SfDataGridDemo.Services;
using SfDataGridDemo.ViewModels;
using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace SfDataGridDemo.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OnDemandPagingPage : Page {
        private List<OrderViewModel> source;
        private IOrderRepository orderRepository = new OrderRepository();

        public OnDemandPagingPage() {
            this.InitializeComponent();
            
            //TODO: Violates MVVM. Source needs to be initialized before OnDemandPageLoading but ViewModel OnNavigatedTo occurs after.
            source = orderRepository.GetOrderVMs(1000);

            this.sfDataGrid.SortColumnsChanging += SfDataGrid_SortColumnsChanging;
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile") {
                this.sfDataPager.DisplayMode = Syncfusion.UI.Xaml.Controls.DataPager.PageDisplayMode.PreviousNextNumeric;
            }
        }

        private void SfDataGrid_SortColumnsChanging(object sender, Syncfusion.UI.Xaml.Grid.GridSortColumnsChangingEventArgs e) {
            this.sfDataPager.PagedSource.ResetCache();
            (this.sfDataPager.PagedSource as PagedCollectionView).ResetCacheForPage(this.sfDataPager.PageIndex);
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace) {
                var sortDesc = e.AddedItems[0];
                if (sortDesc.SortDirection == ListSortDirection.Ascending) {
                    source = source.OfQueryable().AsQueryable().OrderBy(sortDesc.ColumnName).Cast<OrderViewModel>().ToList();
                }
                else {
                    source = source.OfQueryable().AsQueryable().OrderByDescending(sortDesc.ColumnName).Cast<OrderViewModel>().ToList();
                }
                this.sfDataPager.MoveToPage(this.sfDataPager.PageIndex);
            }
        }

        private void OnDemandPageLoading(object sender, Syncfusion.UI.Xaml.Controls.DataPager.OnDemandLoadingEventArgs args) {
            sfDataPager.LoadDynamicItems(args.StartIndex, source.Skip(args.StartIndex).Take(args.PageSize));
        }
    }
}
