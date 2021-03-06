﻿using SfDataGridDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.Services {
    public class OrderRepository : IOrderRepository {
        int customerIdCount = 0;
        Random r = new Random(1);
        Random code = new Random(7643123);
        Random cost = new Random();

        public OrderRepository() {
        }

        public List<OrderViewModel> GetOrderVMs(int count) {
            List<OrderViewModel> orderVMs = new List<OrderViewModel>();
            if (ShipCity.Count == 0)
                SetShipCity();
            for (int i = 10000; i < count + 10000; i++) {
                orderVMs.Add(GetOrderVM(i));
            }
            return orderVMs;
        }

        public List<string> GetShipCountries() {
            return ShipCountries;
        }

        public List<string> Customers {
            get {
                return this.CustomerId.ToList();
            }
        }

        public List<string> ShipCountries {
            get {
                return this.ShipCountry.ToList();
            }
        }

        private OrderViewModel GetOrderVM(int i) {
            var shipcountry = ShipCountry[r.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            var vm = new OrderViewModel();
            if (i % 3 == 0) {
                vm.IsClosed = true;
            }
            vm.CustomerId = GetCustomerId(i);
            vm.OrderId = i;
            vm.OrderDate = new DateTime(r.Next(2011, 2013), r.Next(1, 12), r.Next(1, 28));
            vm.Quantity = r.Next(20, 60);
            vm.UnitPrice = unitPrice[r.Next(35)];
            vm.Freight = Math.Round(r.Next(1000) + r.NextDouble(), 2);
            vm.Discount = ((r.Next(20, 40)));
            vm.ShipCountry = shipcountry;
            vm.ShipPostalCode = shipPostalCode[r.Next(shipPostalCode.Count() - 1)];
            vm.ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)];
            vm.ShipDate = new DateTime(r.Next(2012, 2014), r.Next(1, 12), r.Next(1, 28));
            vm.Expense = cost.Next(2000, 4000);
            vm.EmployeeId = "" + arr[r.Next(5)] + arr[r.Next(5)] + arr[r.Next(5)] + r.Next(100, 200);
            return vm;
        }

        string GetCustomerId(int i) {
            if (i % 4 != 0 || i == 0) {
                return CustomerId[customerIdCount];
            }
            else {
                if (i % 4 == 0)
                    customerIdCount++;

                if (customerIdCount > 9)
                    customerIdCount = 0;

                return CustomerId[customerIdCount];
            }
        }

        char[] arr = new char[]{
        'A','E','H','F','X','G'
        };

        decimal[] unitPrice = new decimal[] { 28.5m, 336.2m, 88.3m, 86, 512, 41, 253.3m, 33, 87, 45.1m, 78.3m, 19, 56.7m, 23.3m, 59, 91, 32.8m, 264.5m, 63.7m, 434.2m, 15.9m, 21.9m, 45, 70.3m, 42.5m, 67.2m, 34.9m, 379.9m, 0, 59.2m, 412.6m, 19.8m, 42.7m, 78, 26.8m };

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

        string[] shipPostalCode = new string[]
        {

            "10100",
            "H1J 1C3",
            "S-844 67",
            "1734",
            "8200",
            "90110",
            "04179",
            "1675",
            "OX15 4NB",
            "08737-363",
            "4980",
            "1204",
            "1081",
            "5020",
            "59000",
            "67000",
            "87110",
            "24100",
            "51100",
            "31000",
            "05023"
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

        OrderViewModel IOrderRepository.GetOrderVM(int i) {
            throw new NotImplementedException();
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
            "FOLIG",
            "SHIWL",
            "ASDFI",
            "YIWOL",
            "SIEPZ",
            "UIKOC",
            "BNUTQ",
            "FDKIO",
            "UJIKW",
            "QOLPX",
            "WJXKO",
            "SXEWD",
            "ZXSOL",
            "KKMJU",
            "QMICP",
            "SJWII",
            "WDOPO",
            "SAIOP",
            "SSOLE",
            "CUEMC",
            "HWIMQ"
        };
    }
}
