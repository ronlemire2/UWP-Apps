using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class PersonPhone : IEntityWithCrudState
    { 
        public PersonPhone() {
        }

		[Required]
		public int BusinessEntityID { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		[Required]
		public string PhoneNumberTypeID { get; set; }

		[Required]
		public string ModifiedDate { get; set; }

		public CrudState CrudState { get; set; }

    }
}
