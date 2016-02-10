using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class Person : IEntityWithCrudState
    { 
        public Person() {
        }

		[Required]
		public int BusinessEntityID { get; set; }

		[Required]
		public string PersonType { get; set; }

		[Required]
		public string NameStyle { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string MiddleName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Suffix { get; set; }

		[Required]
		public string EmailPromotion { get; set; }

		[Required]
		public string AdditionalContactInfo { get; set; }

		[Required]
		public string Demographics { get; set; }

		[Required]
		public string rowguid { get; set; }

		[Required]
		public string ModifiedDate { get; set; }

		public CrudState CrudState { get; set; }

    }
}
