using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class Address : IEntityWithCrudState
    { 
        public Address() {
        }

		[Required]
		public int AddressID { get; set; }

		[Required]
		public string AddressLine1 { get; set; }

		[Required]
		public string AddressLine2 { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string StateProvinceID { get; set; }

		[Required]
		public string PostalCode { get; set; }

		[Required]
		public string rowguid { get; set; }

		[Required]
		public string ModifiedDate { get; set; }

		public CrudState CrudState { get; set; }

    }
}
