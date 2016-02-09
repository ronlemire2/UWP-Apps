using AW.DAL.POCOs;
using AW.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Repositories {
    public interface IPersonRepository : IGenericDataRepository<Person> {
        IList<PersonPOCO> GetAllPeople();
    }
}
