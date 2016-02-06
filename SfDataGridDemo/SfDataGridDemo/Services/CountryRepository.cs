﻿using SfDataGridDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.Services {
    public class CountryRepository : ICountryRepository {
        Random r = new Random();

        public CountryRepository() {
        }

        public List<CountryViewModel> GetCountryVMs() {
            List<CountryViewModel> countryVMs = new List<CountryViewModel>();

            countryVMs.Add(new CountryViewModel("1", "Afghanistan", "Kabul", "Islamic Emirate of Afghanistan", "Asia", "Pushtu Dari", "Afghani", 34104128L, 28.1, 78.9));
            countryVMs.Add(new CountryViewModel("7", "Argentina", "Buenos Aires", "Argentine Republic", "South America", "Spanish", "Peso", 413229912, 97.2, 99));
            countryVMs.Add(new CountryViewModel("9", "Australia", "Canberra", "Commonwealth of Australia", "Australia", "English", "Australian Dollar", 34104128, 99, 56.34));
            countryVMs.Add(new CountryViewModel("29", "Barbados", "Bridgetown", "Barbados", "North America", "English", "Barbados Dollar", 274913, 99.7, 45));
            countryVMs.Add(new CountryViewModel("30", "Belarus", "Minsk", "Republic of Belarus", "Europe", "Belorussian", "Ruble", 9513664, 99.6, 67.98));
            countryVMs.Add(new CountryViewModel("31", "Belgium", "Brussels", "Kingdom of Belgium", "Europe", "Flemish (Dutch), French, German", "Euro", 10793439, 99, 96));
            countryVMs.Add(new CountryViewModel("38", "Brazil", "Brazilia", "Federative Republic of Brazil", "South America", "Portuguese", "Real", 199303225, 88.6, 30.78));
            countryVMs.Add(new CountryViewModel("45", "Cameroon", "Yaounde", "Republic of Cameroon", "Africa", "French, English", "Franc CFA", 20744860, 75.9, 87.90));
            countryVMs.Add(new CountryViewModel("50", "Chile", "Santiago", "Republic of Chile", "South America", "Spanish", "Spanish Peso", 17509658, 95.7, 88.30));
            countryVMs.Add(new CountryViewModel("53", "Colombia", "Bogota", "Republic of Colombia", "South America", "Spanish", "Spanish Peso", 47899079, 90.4, 60.70));
            countryVMs.Add(new CountryViewModel("63", "Denmark", "Copenhagen", "Kingdom of Denmark", "Europe", "Danish", "Krone", 5601189, 99, 90.34));
            countryVMs.Add(new CountryViewModel("67", "Dominica", "Roseau", "Commonwealth of Dominica", "North America", "French patois, Eng.", "East Caribbean Dollar", 67771, 94, 78.78));
            countryVMs.Add(new CountryViewModel("70", "Egypt", "Cairo", "Arab Republic of Egypt", "Africa", "Arabic", "Egyptian Pound", 84790168, 72, 99.78));
            countryVMs.Add(new CountryViewModel("75", "Ethiopia", "Addis Ababa", "Federal Democratic Republic of Ethiopia", "Africa", "Amharic", "Birr", 87631686, 42.7, 45.78));
            countryVMs.Add(new CountryViewModel("76", "Fiji", "Suva", "Republic of Fiji", "South Europe", "English", "Fijian Dollar", 879222, 93.7, 85.34));
            countryVMs.Add(new CountryViewModel("78", "France", "Paris", "French Republic", "Europe", "French", "Euro", 63644129, 99, 34.60));
            countryVMs.Add(new CountryViewModel("91", "Gambia", "Banjul", "Republic of the Gambia", "Africa", "English", "Dalasi", 1855510, 50, 98.71));
            countryVMs.Add(new CountryViewModel("100", "Guyana", "Georgetown", "Co-operative Republic of Guyana", "South America", "English", "Guyana Dollar", 456674565, 91.8, 90.87));
            countryVMs.Add(new CountryViewModel("103", "Hungary", "Budapest", "Republic of Hungary", "Europe", "Hungarian", "Forint", 758869, 99, 29.41));
            countryVMs.Add(new CountryViewModel("106", "India", "New Delhi", "Republic of India - Bharat", "Asia", "Hindi", "Rupee", 1268260518, 74.04, 56.8));
            countryVMs.Add(new CountryViewModel("107", "Indonesia", "Jakarta", "Republic of Indonesia", "Asia", "Bahasa Indonesia", "Rupiah", 246166130, 90.4, 56.78));
            countryVMs.Add(new CountryViewModel("110", "Ireland", "Dublin", "Republic of Ireland", "Europe", "Irish Gaelic, English", "Irish-Pound", 4606950, 99, 99.08));
            countryVMs.Add(new CountryViewModel("113", "Jamaica", "Kingston", "Jamaica", "Caribbean Ocean", "English", "Jamaican Dollar", 2766771, 87.9, 19.76));
            countryVMs.Add(new CountryViewModel("115", "Jordan", "Amman", "The Hashemite Kingdom of Jorden", "Asia", "Arabic", "Jordanian Dinar", 6503345, 92.6, 78.89));
            countryVMs.Add(new CountryViewModel("117", "Kenya", "Nairobi", "Republic of Kenya", "Africa", "Kiswahili, English", "Kenyan Shilling", 43501390, 87.4, 89.35));
            countryVMs.Add(new CountryViewModel("121", "Kuwait", "Kuwait City", "State of Kuwait", "Asia", "Arabic", "Kuwait Dinar", 2917194, 93.3, 70.50));
            countryVMs.Add(new CountryViewModel("126", "Liberia", "Monrovia", "Republic of Liberia", "Africa", "English", "Liberian Dollar", 4284080, 60.8, 12.90));
            countryVMs.Add(new CountryViewModel("130", "Luxembourg", "Luxemburg", "Grand Duchy of Luxembourg", "Europe", "Luxemburgish, French, English", "Euro", 525983, 100, 39.01));
            countryVMs.Add(new CountryViewModel("133", "Malawi", "Lilongwe", "Republic of Malawi", "Africa", "English, Chichewa", "Kwacha", 16238217, 74.8, 56.94));
            countryVMs.Add(new CountryViewModel("134", "Malaysia", "Kuala Lumpur", "Malaysia", "Asia", "Malay", "Ringgit", 29604978, 92.1, 12.60));
            countryVMs.Add(new CountryViewModel("150", "Namibia", "Windhoek", "Republic of Namibia", "Africa", "English", "Rand", 2387159, 88.8, 34.78));
            countryVMs.Add(new CountryViewModel("153", "Netherlands", "Amsterdam", "Kingdom of The Netherlands", "Europe", "Dutch", "Euro", 16738135, 99, 28.90));
            countryVMs.Add(new CountryViewModel("157", "Nicaragua", "Managua", "Republic of Nicaragua", "South America", "Spanish", "Gold Cordoba", 6006990, 67.5, 13.97));
            countryVMs.Add(new CountryViewModel("159", "Nigeria", "Abuja", "Federal Republic of Nigeria", "Africa", "English", "Naira", 169416887, 61.3, 23.56));
            countryVMs.Add(new CountryViewModel("170", "Paraguay", "Asuncion", "Republic of Paraguay", "South America", "Spanish", "Guarani", 6753180, 94, 45.89));
            countryVMs.Add(new CountryViewModel("182", "Rwanda", "Kigali", "Republic of Rwanda", "Africa", "Kinyarwanda, French", "Rwanda Franc", 11479847, 71.1, 98.78));
            countryVMs.Add(new CountryViewModel("192", "San Marino", "San Marino", "Most Serene Republic of San Marino", "Europe", "Italian", "Euro", 32056, 96, 78.09));
            countryVMs.Add(new CountryViewModel("195", "Senegal", "Dakar", "Republic of Senegal", "Africa", "French", "CFA Franc", 133216648, 39.3, 89));
            countryVMs.Add(new CountryViewModel("198", "Singapore", "Singapore", "Republic of Singapore", "Asia", "Malay, Chinese, Tamil", "Singapore Dollar", 5237597, 92.5, 98.80));

            return countryVMs;
        }
    }
}
