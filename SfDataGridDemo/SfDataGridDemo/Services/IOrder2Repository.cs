using SfDataGridDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.Services {
    public interface IOrder2Repository {
        List<Order2ViewModel> GetOrder2VMs(int count);
        List<string> GetCustomerCities();
    }
}
