using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.ViewModels {
    public class EmployeeViewModel : ValidatableBindableBase {
        private int employeeId;
        public int EmployeeId {
            get { return employeeId; }
            set { SetProperty<int>(ref employeeId, value); }

        }

        private string name;
        public string Name {
            get { return name; }
            set { SetProperty<string>(ref name, value); }
        }

        private long nationalIdNumber;
        public long NationalIdNumber {
            get { return nationalIdNumber; }
            set { SetProperty<long>(ref nationalIdNumber, value); }

        }

        private int contactId;
        public int ContactId {
            get { return contactId; }
            set { SetProperty<int>(ref contactId, value); }

        }

        private string loginId;
        public string LoginId {
            get { return loginId; }
            set { SetProperty<string>(ref loginId, value); }
        }

        private int managerId;
        public int ManagerId {
            get { return managerId; }
            set { SetProperty<int>(ref managerId, value); }

        }

        private string title;
        public string Title {
            get { return title; }
            set { SetProperty<string>(ref title, value); }
        }

        private DateTime birthDate;
        public DateTime BirthDate {
            get { return birthDate; }
            set { SetProperty<DateTime>(ref birthDate, value); }
        }

        private string maritalStatus;
        public string MaritalStatus {
            get { return maritalStatus; }
            set { SetProperty<string>(ref maritalStatus, value); }
        }

        private string gender;
        public string Gender {
            get { return gender; }
            set { SetProperty<string>(ref gender, value); }
        }

        private DateTime hireDate;
        public DateTime HireDate {
            get { return hireDate; }
            set { SetProperty<DateTime>(ref hireDate, value); }
        }

        private int sickLeaveHours;
        public int SickLeaveHours {
            get { return sickLeaveHours; }
            set { SetProperty<int>(ref sickLeaveHours, value); }

        }

        private decimal salary;
        public decimal Salary {
            get { return salary; }
            set { SetProperty<decimal>(ref salary, value); }

        }

        private bool employeeStatus;
        public bool EmployeeStatus {
            get { return employeeStatus; }
            set { SetProperty<bool>(ref employeeStatus, value); }

        }

    }
}
