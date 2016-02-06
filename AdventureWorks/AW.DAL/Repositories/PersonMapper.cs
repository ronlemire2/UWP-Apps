using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AW.EF;
using AW.DAL.VMs;

namespace AW.DAL.Repositories {
    public class PersonMapper {
        #region Map EF to DAL

        public static IEnumerable<PersonPOCO> MapAllEFtoDAL(IEnumerable<Person> efPeople) {
            List<PersonPOCO> dalPeople = new List<PersonPOCO>();

            foreach (Person efPerson in efPeople) {
                dalPeople.Add(PersonMapper.MapOneEFtoDAL(efPerson));
            }

            return dalPeople;
        }

        public static PersonPOCO MapOneEFtoDAL(Person efPerson) {
            PersonPOCO dalPersonPOCO = new PersonPOCO();

            dalPersonPOCO.BusinessEntityID = efPerson.BusinessEntityID;
            dalPersonPOCO.CrudState = CrudState.Unchanged;

            return dalPersonPOCO;
        }

        #endregion

        #region Map DAL to EF

        public static Person MapOneDALtoEF(PersonPOCO dalPersonPOCO) {
            Person efPerson = new Person();

            efPerson.BusinessEntityID = efPerson.BusinessEntityID;

            return efPerson;
        }

        #endregion
    }
}
