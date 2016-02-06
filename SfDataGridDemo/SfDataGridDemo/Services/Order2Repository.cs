using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfDataGridDemo.ViewModels;

namespace SfDataGridDemo.Services {
    public class Order2Repository : IOrder2Repository {
        private List<DateTime> OrderedDates;

        public List<Order2ViewModel> GetOrder2VMs(int count) {
            List<Order2ViewModel> order2VMs = new List<Order2ViewModel>();
            this.OrderedDates = GetDateBetween(2008, 2012, count);
            GetDetailVMs(count);
            SetShipCity();
            for (int i = 10000; i < count + 10000; i++) {
                order2VMs.Add(GetOrder(i));
            }
            return order2VMs;
        }

        private Order2ViewModel GetOrder(int i) {
            var shipcountry = ShipCountry[r.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            return new Order2ViewModel() {
                OrderId = i,
                CustomerId = CustomerId[r.Next(15)],
                EmployeeId = r.Next(1, 10),
                Freight = Convert.ToDecimal(Math.Round(r.Next(1000) + r.NextDouble(), 2)),
                ShipCountry = shipcountry,
                ShipDate = this.OrderedDates[i - 10000],
                IsClosed = i % 2 == 0 ? true : false,
                ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)],
                Order2DetailVMs = getOrderDetails(i)
            };
        }

        private List<Order2DetailViewModel> getOrderDetails(int i) {
            List<Order2DetailViewModel> orderDetails = new List<Order2DetailViewModel>();
            foreach (var or in detailVMs)
                if (or.OrderId == i)
                    orderDetails.Add(or);
            return orderDetails;
        }



        Random r = new Random();
        List<Order2DetailViewModel> detailVMs = new List<Order2DetailViewModel>();
        private void GetDetailVMs(int count) {
            detailVMs.Add(new Order2DetailViewModel(10000, 239800, 12, 5, 10, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Newyork"));
            detailVMs.Add(new Order2DetailViewModel(10000, 587929, 14, 10, 2, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            detailVMs.Add(new Order2DetailViewModel(10000, 299913, 18, 5, 10, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            detailVMs.Add(new Order2DetailViewModel(10000, 545569, 34, 10, 2, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Sydney"));
            detailVMs.Add(new Order2DetailViewModel(10000, 523456, 14, 10, 2, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10000, 239654, 18, 5, 10, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Manchester"));
            detailVMs.Add(new Order2DetailViewModel(10000, 598870, 34, 10, 2, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            detailVMs.Add(new Order2DetailViewModel(10001, 445654, 23, 76, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            detailVMs.Add(new Order2DetailViewModel(10001, 690871, 45, 23, 5, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            detailVMs.Add(new Order2DetailViewModel(10001, 434762, 45, 16, 3, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            detailVMs.Add(new Order2DetailViewModel(10001, 989875, 23, 15, 2, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            detailVMs.Add(new Order2DetailViewModel(10002, 723480, 7, 6, 4, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Newyork"));
            detailVMs.Add(new Order2DetailViewModel(10002, 245683, 30, 5, 2, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10003, 213463, 73, 9, 3, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            detailVMs.Add(new Order2DetailViewModel(10003, 890898, 11, 8, 7, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            detailVMs.Add(new Order2DetailViewModel(10003, 167590, 150, 1, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            detailVMs.Add(new Order2DetailViewModel(10009, 469879, 35, 4, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            detailVMs.Add(new Order2DetailViewModel(10009, 254389, 31, 7, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            detailVMs.Add(new Order2DetailViewModel(10010, 790859, 23, 3, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            detailVMs.Add(new Order2DetailViewModel(10010, 565560, 65, 4, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            detailVMs.Add(new Order2DetailViewModel(10010, 345767, 15, 5, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Manchester"));
            detailVMs.Add(new Order2DetailViewModel(10010, 290898, 31, 1, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            detailVMs.Add(new Order2DetailViewModel(10011, 667876, 46, 2, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            detailVMs.Add(new Order2DetailViewModel(10011, 345676, 45, 4, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10011, 289780, 41, 7, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            detailVMs.Add(new Order2DetailViewModel(10013, 195678, 80, 2, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10013, 204345, 111, 1, 7, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            detailVMs.Add(new Order2DetailViewModel(10021, 548908, 35, 2, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            detailVMs.Add(new Order2DetailViewModel(10021, 634567, 46, 7, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            detailVMs.Add(new Order2DetailViewModel(10021, 275467, 99, 5, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            detailVMs.Add(new Order2DetailViewModel(10022, 598907, 80, 3, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            detailVMs.Add(new Order2DetailViewModel(10022, 605678, 111, 1, 7, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Manchester"));
            detailVMs.Add(new Order2DetailViewModel(10022, 472345, 35, 9, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
            detailVMs.Add(new Order2DetailViewModel(10032, 445678, 35, 6, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            detailVMs.Add(new Order2DetailViewModel(10032, 690909, 46, 8, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10034, 174356, 99, 1, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            detailVMs.Add(new Order2DetailViewModel(10034, 196789, 80, 5, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10034, 206578, 111, 3, 7, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            detailVMs.Add(new Order2DetailViewModel(10042, 454578, 35, 1, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10042, 489076, 35, 9, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Washington"));
            detailVMs.Add(new Order2DetailViewModel(10045, 667890, 46, 7, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10045, 174356, 99, 3, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "London"));
            detailVMs.Add(new Order2DetailViewModel(10045, 199890, 80, 6, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Melbourne"));
            detailVMs.Add(new Order2DetailViewModel(10045, 204356, 111, 1, 7, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            detailVMs.Add(new Order2DetailViewModel(10056, 489087, 35, 2, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Brisbane"));
            detailVMs.Add(new Order2DetailViewModel(10056, 443567, 35, 7, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Perth"));
            detailVMs.Add(new Order2DetailViewModel(10056, 612367, 46, 4, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Auckland"));
            detailVMs.Add(new Order2DetailViewModel(10067, 178796, 99, 4, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Wellington"));
            detailVMs.Add(new Order2DetailViewModel(10067, 195468, 80, 2, 0, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Manchester"));
            detailVMs.Add(new Order2DetailViewModel(10067, 207657, 111, 1, 7, CustomerId[r.Next(15)], this.OrderedDates[r.Next(count - 1)], "Durban"));
        }

        public List<string> GetCustomerCities() {
            List<string> customerCities = new List<string>();

            customerCities.Add("Newyork");
            customerCities.Add("Washington");
            customerCities.Add("London");
            customerCities.Add("Sydney");
            customerCities.Add("Melbourne");
            customerCities.Add("Manchester");
            customerCities.Add("Perth");
            customerCities.Add("Brisbane");
            customerCities.Add("Durban");
            customerCities.Add("Auckland");
            customerCities.Add("Wellington");

            return customerCities;
        }



        public List<string> Customers {
            get {
                return this.CustomerId.ToList();
            }
        }
        string[] CustomerId = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
        };


        public List<string> ShipCountries {
            get {
                return this.ShipCountry.ToList();
            }
        }
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

        Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();

        /// <summary>
        /// Sets the ship city.
        /// </summary>
        private void SetShipCity() {
            string[] argentina = new string[] { "Buenos Aires" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "São Paulo" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

            string[] france = new string[] { "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles" };

            string[] germany = new string[] { "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt a.M.", "Köln", "Leipzig", "Mannheim", "München", "Münster", "Stuttgart" };

            string[] ireland = new string[] { "Cork" };

            string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };

            string[] mexico = new string[] { "México D.F." };

            string[] norway = new string[] { "Stavern" };

            string[] poland = new string[] { "Warszawa" };

            string[] portugal = new string[] { "Lisboa" };

            string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };

            string[] sweden = new string[] { "Bräcke", "Luleå" };

            string[] switzerland = new string[] { "Bern", "Genève" };

            string[] uk = new string[] { "Colchester", "Hedge End", "London" };

            string[] usa = new string[] { "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander", "Portland", "San Francisco", "Seattle", "Walla Walla" };

            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            ShipCity.Add("Argentina", argentina);
            ShipCity.Add("Austria", austria);
            ShipCity.Add("Belgium", belgium);
            ShipCity.Add("Brazil", brazil);
            ShipCity.Add("Canada", canada);
            ShipCity.Add("Denmark", denmark);
            ShipCity.Add("Finland", finland);
            ShipCity.Add("France", france);
            ShipCity.Add("Germany", germany);
            ShipCity.Add("Ireland", ireland);
            ShipCity.Add("Italy", italy);
            ShipCity.Add("Mexico", mexico);
            ShipCity.Add("Norway", norway);
            ShipCity.Add("Poland", poland);
            ShipCity.Add("Portugal", portugal);
            ShipCity.Add("Spain", spain);
            ShipCity.Add("Sweden", sweden);
            ShipCity.Add("Switzerland", switzerland);
            ShipCity.Add("UK", uk);
            ShipCity.Add("USA", usa);
            ShipCity.Add("Venezuela", venezuela);

        }


        /// <summary>
        /// Gets the date between.
        /// </summary>
        /// <param name="startYear">The start year.</param>
        /// <param name="EndYear">The end year.</param>
        /// <param name="Count">The count.</param>
        /// <returns></returns>
        private List<DateTime> GetDateBetween(int startYear, int EndYear, int Count) {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < Count; i++) {
                int year = y.Next(startYear, EndYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }
            return date;
        }

    }
}
