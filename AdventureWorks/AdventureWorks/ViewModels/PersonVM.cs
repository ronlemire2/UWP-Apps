using AdventureWorks.Models;
using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.ViewModels {
    public class PersonVM : ValidatableBindableBase {
        public PersonVM() {
            //this.BusinessEntityContacts = new List<BusinessEntityContact>();
            //this.EmailAddresses = new List<EmailAddress>();
            //this.PersonPhones = new List<PersonPhone>();
        }

        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public string NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string EmailPromotion { get; set; }
        public string AdditionalContactInfo { get; set; }
        public string Demographics { get; set; }
        public string rowguid { get; set; }
        public string ModifiedDate { get; set; }

        //public Employee Employee { get; set; }
        //public BusinessEntity BusinessEntity { get; set; }
        //public List<BusinessEntityContact> BusinessEntityContacts { get; set; }
        //public List<EmailAddress> EmailAddresses { get; set; }
        //public Password Password { get; set; }
        //public virtual List<PersonPhone> PersonPhones { get; set; }

        public CrudState CrudState {
            get;
            set;
        }
    }
}
