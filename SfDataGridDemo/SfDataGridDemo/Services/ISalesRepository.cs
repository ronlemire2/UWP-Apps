using SfDataGridDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.Services {
    public interface ISalesRepository {
        ObservableCollection<SalesByYearViewModel> GetSalesDetailsByYear(int year);
        ObservableCollection<SalesByDateViewModel> GetSalesDetailsByDay(int days);
    }
}
