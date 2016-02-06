using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class EconomicGrowthViewModel : ViewModelBase {
        private int year;
        public int Year {
            get {
                return year;
            }
            set {
                SetProperty<int>(ref year, value);
            }
        }

        private double growthPercentage;
        public double GrowthPercentage {
            get {
                return growthPercentage;
            }
            set {
                SetProperty<double>(ref growthPercentage, value);
            }
        }
    }
}
