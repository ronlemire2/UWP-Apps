using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SfDataGridDemo.ViewModels {
    public class UserViewModel : ValidatableBindableBase {
        private int userId;
        public int UserId {
            get { return userId; }
            set { SetProperty<int>(ref userId, value); }

        }

        private string name;
        public string Name {
            get { return name; }
            set { SetProperty<string>(ref name, value); }
        }

        private DateTime dateofBirth;
        public DateTime DateofBirth {
            get { return dateofBirth; }
            set { SetProperty<DateTime>(ref dateofBirth, value); }
        }

        private string email;
        public string Email {
            get { return email; }
            set { SetProperty<string>(ref email, value); }
        }

        private string contactNo;
        [StringLength(14, ErrorMessage = "The “ContactNo” field must be a string with a maximum length of 14.")]
        public string ContactNo {
            get { return contactNo; }
            set { SetProperty<string>(ref contactNo, value); }
        }

        private string city;
        public string City {
            get { return city; }
            set { SetProperty<string>(ref city, value); }
        }

        private int salary;
        [Range(10000, 30000, ErrorMessage = "The “Salary” field can range from 10000 through 30000.")]
        public int Salary {
            get { return salary; }
            set { SetProperty<int>(ref salary, value); }

        }

        public bool HasErrors {
            get {
                throw new NotImplementedException();
            }
        }

    }
}
