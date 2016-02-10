using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class PersonFilter : IEntityWithCrudState
    { 
        public PersonFilter() {
        }

		[Required]
		public string Id { get; set; }

		[Required]
		public string StateProvinceCode { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public CrudState CrudState { get; set; }

    }
}
