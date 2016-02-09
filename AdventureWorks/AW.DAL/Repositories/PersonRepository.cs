using AW.DAL.POCOs;
using AW.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Repositories {
    public class PersonRepository : EFDataRepository<Person>, IPersonRepository {
        public IList<PersonPOCO> GetAllPeople() {
            IList<PersonPOCO> personPOCOs = new List<PersonPOCO>();

            IList<Person> people = GetAll();
            personPOCOs = PersonMapper.MapAllEFtoDAL(people).ToList();

            return personPOCOs;
        }
    }
}
