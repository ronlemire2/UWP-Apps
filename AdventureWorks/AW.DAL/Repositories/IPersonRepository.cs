using AW.DAL.POCOs;
using AW.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Repositories {
    public interface IPersonRepository {
        IList<PersonPOCO> GetPersons();
        PersonPOCO GetPersonById(int businessEntityId);
        int SavePersonGraph(PersonPOCO personPOCO);
    }
}
