using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SfDataGridDemo.Converters {
    public class SortClickActionConverter : IValueConverter {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language) {
            var index = value as int?;
            return index == 0 ? SortClickAction.SingleClick : SortClickAction.DoubleClick;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
