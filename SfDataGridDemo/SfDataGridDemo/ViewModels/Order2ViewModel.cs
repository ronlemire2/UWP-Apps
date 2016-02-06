using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class Order2ViewModel : ValidatableBindableBase {
        private List<Order2DetailViewModel> order2DetailVMs;
        public List<Order2DetailViewModel> Order2DetailVMs {
            get { return order2DetailVMs; }
            set {
                SetProperty<List<Order2DetailViewModel>>(ref order2DetailVMs, value);
            }
        }

        private int orderId;
        public int OrderId {
            get { return orderId; }
            set { SetProperty<int>(ref orderId, value); }

        }

        private string customerId;
        public string CustomerId {
            get { return customerId; }
            set { SetProperty<string>(ref customerId, value); }
        }

        private System.Nullable<int> employeeId;
        public System.Nullable<int> EmployeeId {
            get { return employeeId; }
            set { SetProperty<System.Nullable<int>>(ref employeeId, value); }

        }

        private DateTime shipDate;
        public DateTime ShipDate {
            get { return shipDate; }
            set { SetProperty<DateTime>(ref shipDate, value); }
        }

        private string shipCity;
        public string ShipCity {
            get { return shipCity; }
            set { SetProperty<string>(ref shipCity, value); }
        }

        private string shipCountry;
        public string ShipCountry {
            get { return shipCountry; }
            set { SetProperty<string>(ref shipCountry, value); }
        }

        private decimal freight;
        public decimal Freight {
            get { return freight; }
            set { SetProperty<decimal>(ref freight, value); }
        }

        private bool isClosed;
        public bool IsClosed {
            get { return isClosed; }
            set { SetProperty<bool>(ref isClosed, value); }
        }
    }
}
