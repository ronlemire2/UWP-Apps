using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SfDataGridDemo.Helpers {
    class TableSummaryStyleSelector : StyleSelector {
        protected override Windows.UI.Xaml.Style SelectStyleCore(object item, Windows.UI.Xaml.DependencyObject container) {
            if ((item as SummaryRecordEntry).SummaryRow.ShowSummaryInRow) {
                var style = Application.Current.Resources["tableSummaryCell"] as Style;
                if (style != null)
                    return style;
            }
            else {
                var style = Application.Current.Resources["normaltableSummaryCell"] as Style;
                if (style != null)
                    return style;
            }
            return base.SelectStyleCore(item, container);
        }
    }
    class GroupSummaryStyleSelector : StyleSelector {
        protected override Windows.UI.Xaml.Style SelectStyleCore(object item, Windows.UI.Xaml.DependencyObject container) {
            if ((item as SummaryRecordEntry).SummaryRow.ShowSummaryInRow) {
                var style = Application.Current.Resources["groupSummaryCell"] as Style;
                if (style != null)
                    return style;
            }
            else {
                var style = Application.Current.Resources["normalgroupSummaryCell"] as Style;
                if (style != null)
                    return style;
            }
            return base.SelectStyleCore(item, container);
        }
    }

    //class TableSummaryStyleSelector : StyleSelector {
    //    protected override Style SelectStyleCore(object item, DependencyObject container) {
    //        return App.Current.Resources["tableSummaryCellstyle"] as Style;
    //    }
    //}
}
