using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class OrderViewModel : ValidatableBindableBase {
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

        private string employeeId;
        public string EmployeeId {
            get { return employeeId; }
            set { SetProperty<string>(ref employeeId, value); }
        }

        private DateTime orderDate;
        public DateTime OrderDate {
            get { return orderDate; }
            set { SetProperty<DateTime>(ref orderDate, value); }
        }

        private int quantity;
        public int Quantity {
            get { return quantity; }
            set { SetProperty<int>(ref quantity, value); }
        }

        private decimal unitPrice;
        public decimal UnitPrice {
            get { return unitPrice; }
            set { SetProperty<decimal>(ref unitPrice, value); }
        }

        private decimal discount;
        public decimal Discount {
            get { return discount; }
            set { SetProperty<decimal>(ref discount, value); }
        }

        private double freight;
        public double Freight {
            get { return freight; }
            set { SetProperty<double>(ref freight, value); }
        }

        private decimal expense;
        public decimal Expense {
            get { return expense; }
            set { SetProperty<decimal>(ref expense, value); }
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

        private string shipPostalCode;
        public string ShipPostalCode {
            get { return shipPostalCode; }
            set { SetProperty<string>(ref shipPostalCode, value); }
        }

        private string imagePath;
        public string ImagePath {
            get { return imagePath; }
            set { SetProperty<string>(ref imagePath, value); }
        }

        private bool isClosed;
        public bool IsClosed {
            get { return isClosed; }
            set { SetProperty<bool>(ref isClosed, value); }
        }

    }
}
