using Prism.Windows.Mvvm;
using SfDataGridDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Navigation;
using System.Windows.Input;
using Prism.Commands;
using System.Reflection;
using Windows.UI.Xaml.Controls;

namespace SfDataGridDemo.ViewModels {
    public class BasicFilteringPageViewModel : ViewModelBase {
        private IEmployeeRepository employeeRepository;
        internal delegate void FilterChanged();
        internal FilterChanged filterChanged;

        #region Constructors

        public BasicFilteringPageViewModel(IEmployeeRepository employeeRepository) {
            this.employeeRepository = employeeRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            EmployeeVMs = employeeRepository.GetEmployeesVMs(200).ToList();
            base.OnNavigatedTo(e, viewModelState);
        }

        #endregion


        #region Properties

        private List<EmployeeViewModel> employeeVMs;
        public List<EmployeeViewModel> EmployeeVMs {
            get { return employeeVMs; }
            set { employeeVMs = value; }
        }

        private List<string> _comboBoxItemsSource = new List<string>();
        public List<string> ComboBoxItemsSource {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }

        private ICommand textchanged;
        public ICommand TextChanged {
            get { return new DelegateCommand<object>(TextChangeEvent, args => true); }
            set { textchanged = value; OnPropertyChanged("TextChanged"); }
        }

        private void TextChangeEvent(object parm) {
            if (parm != null) {
                this.FilterText = parm.ToString();
                filterChanged();
            }
        }

        public ICommand ComboChanged {
            get { return new DelegateCommand<object>(ComboxChangedEvent, args => { return true; }); }
        }

        public ICommand FilterComboChanged {
            get { return new DelegateCommand<object>(FilterComboxChangedEvent, args => { return true; }); }
        }

        private void FilterComboxChangedEvent(object pram) {
            if (pram != null) {
                this.FilterOption = (pram as ComboBoxItem).Content.ToString();
                filterChanged();
            }
        }

        private void ComboxChangedEvent(object parm) {
            if (parm != null) {
                this.FilterCondition = (parm as ComboBoxItem).Content.ToString();
                filterChanged();
            }
        }

        private string filterOption = "All Columns";
        public string FilterOption {
            get { return filterOption; }
            set {
                filterOption = value;
                OnPropertyChanged("FilterOption");
            }
        }

        private string filterText = string.Empty;
        public string FilterText {
            get { return filterText; }
            set {
                filterText = value;
                OnPropertyChanged("FilterText");
            }
        }
        private string filterCondition;
        public string FilterCondition {
            get { return filterCondition; }
            set {
                filterCondition = value;
                OnPropertyChanged("FilterCondition");
            }
        }

        public bool FilterRecords(object o) {
            double res;
            bool checkNumeric = double.TryParse(FilterText, out res);
            var item = o as EmployeeViewModel;
            if (item != null && FilterText.Equals("")) {
                return true;
            }
            else {
                if (item != null) {
                    if (checkNumeric && !FilterOption.Equals("All Columns")) {
                        if (FilterCondition == null || FilterCondition.Equals("Contains") || FilterCondition.Equals("StartsWith") || FilterCondition.Equals("EndsWith"))
                            FilterCondition = "Equals";
                        bool result = MakeNumericFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                    else if (FilterOption.Equals("All Columns")) {
                        if (item.Name.ToLower().Contains(FilterText.ToLower()) ||
                            item.Title.ToLower().Contains(FilterText.ToLower()) ||
                            item.Salary.ToString().ToLower().Contains(FilterText.ToLower()) || item.EmployeeId.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Gender.ToLower().Contains(FilterText.ToLower()))
                            return true;
                        return false;
                    }
                    else {
                        if (FilterCondition == null || FilterCondition.Equals("Equals") || FilterCondition.Equals("LessThan") || FilterCondition.Equals("GreaterThan") || FilterCondition.Equals("NotEquals"))
                            FilterCondition = "Contains";
                        bool result = MakeStringFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                }
            }
            return false;
        }

        private bool MakeNumericFilter(EmployeeViewModel o, string option, string condition) {
            var value = (o.GetType().GetTypeInfo()).GetDeclaredProperty(option);
            var exactValue = value.GetValue(o);
            double res;
            bool checkNumeric = double.TryParse(exactValue.ToString(), out res);
            if (checkNumeric) {
                switch (condition) {
                    case "Equals":
                        if (Convert.ToDouble(exactValue) == (Convert.ToDouble(FilterText)))
                            return true;
                        break;
                    case "GreaterThan":
                        if (Convert.ToDouble(exactValue) > Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "LessThan":
                        if (Convert.ToDouble(exactValue) < Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "NotEquals":
                        if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                            return true;
                        break;
                }
            }
            return false;
        }

        private bool MakeStringFilter(EmployeeViewModel o, string option, string condition) {
            var value = (o.GetType().GetTypeInfo()).GetDeclaredProperty(option);
            var exactValue = value.GetValue(o);
            exactValue = exactValue.ToString().ToLower();
            string text = FilterText.ToLower();
            var methods = (typeof(string).GetTypeInfo()).GetDeclaredMethods(condition);
            if (methods.Count() != 0) {
                var methodInfo = methods.FirstOrDefault();
                bool result1 = (bool)methodInfo.Invoke(exactValue, new object[] { text });
                return result1;
            }
            else
                return false;
        }


        #endregion
    }
}
