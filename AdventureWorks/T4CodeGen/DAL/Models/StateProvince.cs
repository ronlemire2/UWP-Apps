using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class StateProvince : IEntityWithCrudState
    { 
        public StateProvince() {
        }

		[Required]
		public int StateProvinceID { get; set; }

		[Required]
		public string StateProvinceCode { get; set; }

		[Required]
		public string CountryRegionCode { get; set; }

		[Required]
		public string IsOnlyStateProvinceFlag { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string TerritoryID { get; set; }

		[Required]
		public string rowguid { get; set; }

		[Required]
		public string ModifiedDate { get; set; }

		public CrudState CrudState { get; set; }

    }
}
