using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class BusinessEntityAddress : IEntityWithCrudState
    { 
        public BusinessEntityAddress() {
        }

		[Required]
		public int BusinessEntityID { get; set; }

		[Required]
		public string AddressID { get; set; }

		[Required]
		public string AddressTypeID { get; set; }

		[Required]
		public string rowguid { get; set; }

		[Required]
		public string ModifiedDate { get; set; }

		public CrudState CrudState { get; set; }

    }
}
