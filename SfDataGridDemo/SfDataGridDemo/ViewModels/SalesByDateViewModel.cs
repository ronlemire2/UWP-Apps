using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class SalesByDateViewModel : ValidatableBindableBase {
        private string name;
        public string Name {
            get { return name; }
            set { SetProperty<string>(ref name, value); }
        }

        private decimal qS1;
        public decimal QS1 {
            get { return qS1; }
            set { SetProperty<decimal>(ref qS1, value); }
        }

        private decimal qS2;
        public decimal QS2 {
            get { return qS2; }
            set { SetProperty<decimal>(ref qS2, value); }
        }

        private decimal qS3;
        public decimal QS3 {
            get { return qS3; }
            set { SetProperty<decimal>(ref qS3, value); }
        }

        private decimal qS4;
        public decimal QS4 {
            get { return qS4; }
            set { SetProperty<decimal>(ref qS4, value); }
        }

        private decimal total;
        public decimal Total {
            get { return total; }
            set { SetProperty<decimal>(ref total, value); }
        }

        private DateTime year;
        public DateTime Date {
            get { return year; }
            set { SetProperty<DateTime>(ref year, value); }
        }
    }
}
