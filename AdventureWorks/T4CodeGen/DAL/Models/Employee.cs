using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class Employee : IEntityWithCrudState
    { 
        public Employee() {
        }

		[Required]
		public int BusinessEntityID { get; set; }

		[Required]
		public string NationalIDNumber { get; set; }

		[Required]
		public string LoginID { get; set; }

		[Required]
		public string OrganizationNode { get; set; }

		[Required]
		public string OrganizationLevel { get; set; }

		[Required]
		public string JobTitle { get; set; }

		[Required]
		public string BirthDate { get; set; }

		[Required]
		public string MaritalStatus { get; set; }

		[Required]
		public string Gender { get; set; }

		[Required]
		public string HireDate { get; set; }

		[Required]
		public string SalariedFlag { get; set; }

		[Required]
		public string VacationHours { get; set; }

		[Required]
		public string SickLeaveHours { get; set; }

		[Required]
		public string CurrentFlag { get; set; }

		[Required]
		public string rowguid { get; set; }

		[Required]
		public string ModifiedDate { get; set; }

		public CrudState CrudState { get; set; }

    }
}
