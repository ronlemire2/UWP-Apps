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

        // TODO: Use AutoMapper
        public static PersonPOCO MapOneEFtoDAL(Person efPerson) {
            PersonPOCO dalPersonPOCO = new PersonPOCO();

            dalPersonPOCO.BusinessEntityID = efPerson.BusinessEntityID;
            dalPersonPOCO.PersonType = efPerson.PersonType;
            dalPersonPOCO.NameStyle = efPerson.NameStyle.ToString();
            dalPersonPOCO.Title = efPerson.Title;
            dalPersonPOCO.FirstName = efPerson.FirstName;
            dalPersonPOCO.MiddleName = efPerson.MiddleName;
            dalPersonPOCO.LastName = efPerson.LastName;
            dalPersonPOCO.Suffix = efPerson.Suffix;
            dalPersonPOCO.EmailPromotion = efPerson.EmailPromotion.ToString();
            dalPersonPOCO.AdditionalContactInfo = efPerson.AdditionalContactInfo;
            dalPersonPOCO.Demographics = efPerson.Demographics;
            dalPersonPOCO.rowguid = efPerson.rowguid.ToString();
            dalPersonPOCO.ModifiedDate = efPerson.ModifiedDate.ToString();
            dalPersonPOCO.CrudState = CrudState.Unchanged;

            return dalPersonPOCO;
        }

        #endregion

        #region Map DAL to EF

        public static Person MapOneDALtoEF(PersonPOCO dalPersonPOCO) {
            Person efPerson = new Person();

            efPerson.BusinessEntityID = dalPersonPOCO.BusinessEntityID;
            efPerson.PersonType = dalPersonPOCO.PersonType;
            efPerson.NameStyle = bool.Parse(dalPersonPOCO.NameStyle);
            efPerson.Title = dalPersonPOCO.Title;
            efPerson.FirstName = dalPersonPOCO.FirstName;
            efPerson.MiddleName = dalPersonPOCO.MiddleName;
            efPerson.LastName = dalPersonPOCO.LastName;
            efPerson.Suffix = dalPersonPOCO.Suffix;
            efPerson.EmailPromotion = int.Parse(dalPersonPOCO.EmailPromotion);
            efPerson.AdditionalContactInfo = dalPersonPOCO.AdditionalContactInfo;
            efPerson.Demographics = dalPersonPOCO.Demographics;
            efPerson.rowguid = Guid.Parse(dalPersonPOCO.rowguid);
            efPerson.ModifiedDate = DateTime.Parse(dalPersonPOCO.ModifiedDate);

            return efPerson;
        }

        #endregion
    }
}
