using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Models 
{
    public partial class CountryRegion : IEntityWithCrudState
    { 
        public CountryRegion() {
        }

		[Required]
		public string CountryRegionCode { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string ModifiedDate { get; set; }

		public CrudState CrudState { get; set; }

    }
}
