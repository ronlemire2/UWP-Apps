using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class Order2DetailViewModel : ValidatableBindableBase {
        static int imageCount = 0;
        static int pname = 0;

        public Order2DetailViewModel(int orderId, int productId, decimal unitPrice, int quantity, decimal discount, string customerId,
            DateTime orderDate, string city) {
            var shipcountry = imageCount < 15 ? ShipCountry[imageCount] : ShipCountry[0];
            Discount = discount;
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            CustomerId = customerId;
            OrderDate = orderDate;
            CustomerCity = city;
            CityDescription = shipcountry;
            ProductName = pname + productId % 2 == 0 ? ProductNames[0] : ProductNames[1];
            if (pname > 2)
                pname = 0;
            IsClosed = imageCount % 2 == 0 ? true : false;
            if (imageCount % 2 == 0)
                ImagePath = "Brazil";
            else if (imageCount % 3 == 0)
                ImagePath = "Canada";
            else if (imageCount % 5 == 0)
                ImagePath = "Germany";
            else
                ImagePath = "Italy";
            imageCount++;
            if (imageCount > 15)
                imageCount = 1;
        }

        private int orderId;
        public int OrderId {
            get { return orderId; }
            set { SetProperty<int>(ref orderId, value); }

        }

        private DateTime orderDate;
        public DateTime OrderDate {
            get { return orderDate; }
            set { SetProperty<DateTime>(ref orderDate, value); }
        }

        private int productId;
        public int ProductId {
            get { return productId; }
            set { SetProperty<int>(ref productId, value); }

        }

        private decimal unitPrice;
        public decimal UnitPrice {
            get { return unitPrice; }
            set { SetProperty<decimal>(ref unitPrice, value); }
        }

        private int quantity;
        public int Quantity {
            get { return quantity; }
            set { SetProperty<int>(ref quantity, value); }
        }

        private decimal discount;
        public decimal Discount {
            get { return discount; }
            set { SetProperty<decimal>(ref discount, value); }
        }

        private string customerId;
        public string CustomerId {
            get { return customerId; }
            set { SetProperty<string>(ref customerId, value); }
        }

        private string customerCity;
        public string CustomerCity {
            get { return customerCity; }
            set { SetProperty<string>(ref customerCity, value); }
        }

        private string cityDescription;
        public string CityDescription {
            get { return cityDescription; }
            set { SetProperty<string>(ref cityDescription, value); }
        }

        private string productName;
        public string ProductName {
            get { return productName; }
            set { SetProperty<string>(ref productName, value); }
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

        private ObservableCollection<ProductViewModel> productDetails = new ObservableCollection<ProductViewModel>();
        public ObservableCollection<ProductViewModel> ProductDetails {
            get {
                GetProductDetails();
                return productDetails;
            }
            set {
                SetProperty<ObservableCollection<ProductViewModel>>(ref productDetails, value);
            }
        }

        Random r = new Random();
        private void GetProductDetails() {
            for (int i = 0; i < 40; i++) {
                ProductViewModel p = new ProductViewModel();
                p.ProductName = ProductNames[r.Next(ProductNames.Count() - 1)];
                p.Year2008 = r.Next(100, 300);
                p.Year2009 = r.Next(400, 600);
                this.productDetails.Add(p);
            }
        }

        string[] ProductNames = new string[]
        {
            "Laptop",
            "Watch",
            "Footware"
        };

        string[] ShipCountry = new string[]
        {

            "Argentina",
            "Austria",
            "Belgium",
            "Brazil",
            "Canada",
            "Denmark",
            "Finland",
            "France",
            "Germany",
            "Ireland",
            "Italy",
            "Mexico",
            "Norway",
            "Poland",
            "Portugal",
            "Spain",
            "Sweden",
            "Switzerland",
            "UK",
            "USA",
            "Venezuela"
        };
    }
}
