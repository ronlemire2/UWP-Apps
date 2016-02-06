using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class CustomerViewModel : ValidatableBindableBase {
        private string customerId;
        public string CustomerId {
            get { return customerId; }
            set { SetProperty<string>(ref customerId, value); }
        }

        private string companyName;
        public string CompanyName {
            get { return companyName; }
            set { SetProperty<string>(ref companyName, value); }
        }

        private string contactName;
        public string ContactName {
            get { return contactName; }
            set { SetProperty<string>(ref contactName, value); }
        }

        private string contactTitle;
        public string ContactTitle {
            get { return contactTitle; }
            set { SetProperty<string>(ref contactTitle, value); }
        }

        private string address;
        public string Address {
            get { return address; }
            set { SetProperty<string>(ref address, value); }
        }

        private string city;
        public string City {
            get { return city; }
            set { SetProperty<string>(ref city, value); }
        }

        private string postalCode;
        public string PostalCode {
            get { return postalCode; }
            set { SetProperty<string>(ref postalCode, value); }
        }

        private string country;
        public string Country {
            get { return country; }
            set { SetProperty<string>(ref country, value); }
        }

        private OrderViewModel orderVM;
        public OrderViewModel OrderVM {
            get { return orderVM; }
            set { SetProperty<OrderViewModel>(ref orderVM, value); }
        }

        private ProductViewModel[] productVMs;
        public ProductViewModel[] ProductVMs {
            get { return productVMs; }
            set { SetProperty<ProductViewModel[]>(ref productVMs, value); }
        }

    }
}
