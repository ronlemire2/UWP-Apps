using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class ProductViewModel : ValidatableBindableBase {

        private int productId;
        public int ProductId {
            get { return productId; }
            set { SetProperty<int>(ref productId, value); }

        }

        private string productModel;
        public string ProductModel {
            get { return productModel; }
            set { SetProperty<string>(ref productModel, value); }
        }

        private string productBrand;
        public string ProductBrand {
            get { return productBrand; }
            set { SetProperty<string>(ref productBrand, value); }
        }

        private int userRating;
        public int UserRating {
            get { return userRating; }
            set { SetProperty<int>(ref userRating, value); }

        }

        private string productName;
        public string ProductName {
            get { return productName; }
            set { SetProperty<string>(ref productName, value); }
        }

        private bool availability;
        public bool Availability {
            get { return availability; }
            set { SetProperty<bool>(ref availability, value); }
        }
        private decimal price;
        public decimal Price {
            get { return price; }
            set { SetProperty<decimal>(ref price, value); }
        }

        private int shippingDays;
        public int ShippingDays {
            get { return shippingDays; }
            set { SetProperty<int>(ref shippingDays, value); }
        }

        private string productType;
        public string ProductType {
            get { return productType; }
            set { SetProperty<string>(ref productType, value); }
        }

        private decimal year2008;
        public decimal Year2008 {
            get { return year2008; }
            set { SetProperty<decimal>(ref year2008, value); }
        }

        private decimal year2009;
        public decimal Year2009 {
            get { return year2009; }
            set { SetProperty<decimal>(ref year2009, value); }
        }

        private decimal year2010;
        public decimal Year2010 {
            get { return year2010; }
            set { SetProperty<decimal>(ref year2010, value); }
        }

        private decimal year2011;
        public decimal Year2011 {
            get { return year2011; }
            set { SetProperty<decimal>(ref year2011, value); }
        }

        private decimal year2012;
        public decimal Year2012 {
            get { return year2012; }
            set { SetProperty<decimal>(ref year2012, value); }
        }

        private decimal year2013;
        public decimal Year2013 {
            get { return year2013; }
            set { SetProperty<decimal>(ref year2013, value); }
        }

        private decimal totalSales;
        public decimal TotalSales {
            get { return totalSales; }
            set { SetProperty<decimal>(ref totalSales, value); }
        }

        private decimal average;
        public decimal Average {
            get { return average; }
            set { SetProperty<decimal>(ref average, value); }
        }

        private decimal min;
        public decimal Min {
            get { return min; }
            set { SetProperty<decimal>(ref min, value); }
        }

        private decimal max;
        public decimal Max {
            get { return max; }
            set { SetProperty<decimal>(ref max, value); }
        }

        private decimal sum;
        public decimal Sum {
            get { return sum; }
            set { SetProperty<decimal>(ref sum, value); }
        }
        private int count;
        public int Count {
            get { return count; }
            set { SetProperty<int>(ref count, value); }
        }

        private int numCount;
        public int NumCount {
            get { return numCount; }
            set { SetProperty<int>(ref numCount, value); }
        }




    }
}
