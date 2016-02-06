using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class CountryViewModel : ViewModelBase {
        #region Contructors

        public CountryViewModel() {

        }

        public CountryViewModel(string serialNumber, string countryName, string countryCapital, string officialName, string location, 
                string language, string currency, long population, double literacyRate, double percentage) {
            this.SerialNumber = serialNumber;
            this.CountryName = countryName;
            this.CountryCaptial = countryCapital;
            this.OfficialName = officialName;
            this.Location = location;
            this.Language = language;
            this.Currency = currency;
            this.Population = population;
            this.LiteracyRate = literacyRate;
            this.EconomyPercentage = percentage;
        }

        #endregion

        #region Properties

        private string serialNumber;
        public string SerialNumber {
            get {
                return serialNumber;
            }
            set {
                SetProperty<string>(ref serialNumber, value);
            }
        }

        private string countryName;
        public string CountryName {
            get {
                return countryName;
            }
            set {
                SetProperty<string>(ref countryName, value);
            }
        }

        private string countryCapital;
        public string CountryCaptial {
            get {
                return countryCapital;
            }
            set {
                SetProperty<string>(ref countryCapital, value);
            }
        }

        private string officialName;
        public string OfficialName {
            get {
                return officialName;
            }
            set {
                SetProperty<string>(ref officialName, value);
            }
        }

        private string location;
        public string Location {
            get {
                return location;
            }
            set {
                SetProperty<string>(ref location, value);
            }
        }

        private string language;
        public string Language {
            get {
                return language;
            }
            set {
                SetProperty<string>(ref language, value);
            }
        }

        private string currency;
        public string Currency {
            get {
                return currency;
            }
            set {
                SetProperty<string>(ref currency, value);
            }
        }

        private long population;
        public long Population {
            get {
                return population;
            }
            set {
                SetProperty<long>(ref population, value);
            }
        }

        private double literacyRate;
        public double LiteracyRate {
            get {
                return literacyRate;
            }
            set {
                SetProperty<double>(ref literacyRate, value);
            }
        }

        private ObservableCollection<EconomicGrowthViewModel> economyRate;
        public ObservableCollection<EconomicGrowthViewModel> EconomyRate {
            get {
                return economyRate;
            }
            set {
                SetProperty<ObservableCollection<EconomicGrowthViewModel>>(ref economyRate, value);
            }
        }


        private double economyPercentage;
        public double EconomyPercentage {
            get {
                return economyPercentage;
            }
            set {
                SetProperty<double>(ref economyPercentage, value);
            }
        }



        #endregion
    }
}
