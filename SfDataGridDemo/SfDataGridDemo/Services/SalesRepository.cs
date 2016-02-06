using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfDataGridDemo.ViewModels;

namespace SfDataGridDemo.Services {
    public class SalesRepository : ISalesRepository {
        public ObservableCollection<SalesByYearViewModel> GetSalesDetailsByYear(int year) {
            var collection = new ObservableCollection<SalesByYearViewModel>();
            var dt = DateTime.Now.AddYears(-1);
            var r = new Random();
            for (var i = 0; i < 5; i++) {
                foreach (var person in salesPersonNames) {
                    if (r.Next(0, 3) == 0) continue;
                    var s = new SalesByYearViewModel {
                        Name = person,
                        QS1 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS2 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS3 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS4 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS5 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS6 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01)
                    };
                    s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4 + s.QS5 + s.QS6;
                    s.Year = dt.Year;
                    collection.Add(s);
                }
                dt = dt.AddYears(-1);
            }
            return collection;
        }

        public ObservableCollection<SalesByDateViewModel> GetSalesDetailsByDay(int days) {
            var collection = new ObservableCollection<SalesByDateViewModel>();
            var r = new Random();
            for (var i = 0; i < days; i++) {
                var dt = DateTime.Now;
                foreach (var person in salesPersonNames) {
                    if (r.Next(0, 3) == 0) continue;
                    var s = new SalesByDateViewModel {
                        Name = person,
                        QS1 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS2 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS3 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01),
                        QS4 = Convert.ToDecimal(r.Next(100000, 1000000) * 0.01)
                    };
                    s.Total = s.QS1 + s.QS2 + s.QS3 + s.QS4;
                    s.Date = dt.AddDays(-1 * i);
                    collection.Add(s);
                }
            }
            return collection;
        }

        private readonly List<string> salesPersonNames = new List<string>()  {
                "Gary Drury",
                "Maciej Dusza",
                "Shelley Dyck",
                "Linda Ecoffey",
                "Carla Eldridge",
                "Carol Elliott",
                "Shannon Elliott",
                "Jauna Elson",
                "Michael Emanuel",
                "Terry Eminhizer",
                "John Emory",
                "Gail Erickson",
                "Mark Erickson",
                "Martha Espinoza",
                "Julie Estes",
                "Janeth Esteves",
                "Twanna Evans"
            };
    }
}
