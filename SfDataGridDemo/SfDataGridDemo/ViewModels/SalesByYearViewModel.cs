using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class SalesByYearViewModel : ValidatableBindableBase {
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

        private decimal qS5;
        public decimal QS5 {
            get { return qS5; }
            set { SetProperty<decimal>(ref qS5, value); }
        }

        private decimal qS6;
        public decimal QS6 {
            get { return qS6; }
            set { SetProperty<decimal>(ref qS6, value); }
        }

        private decimal total;
        public decimal Total {
            get { return total; }
            set { SetProperty<decimal>(ref total, value); }
        }

        private int year;
        public int Year {
            get { return year; }
            set { SetProperty<int>(ref year, value); }
        }
    }
}
