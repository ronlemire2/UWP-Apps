using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Repositories {
    public class EFPersonMapper {
        #region Map EF to DAL

        public static IEnumerable<AW.DAL.Models.Person> MapAllEFtoDAL(IEnumerable<AW.EF.Person> efPeople) {
            List<AW.DAL.Models.Person> dalPeople = new List<AW.DAL.Models.Person>();

            foreach (AW.EF.Person efPerson in efPeople) {
                dalPeople.Add(EFPersonMapper.MapOneEFtoDAL(efPerson));
            }

            return dalPeople;
        }

        public static AW.DAL.Models.Person MapOneEFtoDAL(AW.EF.Person efPerson) {
            AW.DAL.Models.Person dalPerson = new AW.DAL.Models.Person();

			dalPerson.BusinessEntityID = efPerson.BusinessEntityID;
			dalPerson.PersonType = efPerson.PersonType;
			dalPerson.NameStyle = efPerson.NameStyle.ToString();
			dalPerson.Title = efPerson.Title;
			dalPerson.FirstName = efPerson.FirstName;
			dalPerson.MiddleName = efPerson.MiddleName;
			dalPerson.LastName = efPerson.LastName;
			dalPerson.Suffix = efPerson.Suffix;
			dalPerson.EmailPromotion = efPerson.EmailPromotion.ToString();
			dalPerson.AdditionalContactInfo = efPerson.AdditionalContactInfo;
			dalPerson.Demographics = efPerson.Demographics;
			dalPerson.rowguid = efPerson.rowguid.ToString();
			dalPerson.ModifiedDate = efPerson.ModifiedDate.ToShortDateString();
			dalPerson.CrudState = AW.DAL.Models.CrudState.Unchanged;

            return dalPerson;
        }

        #endregion

        #region Map DAL to EF

        public static AW.EF.Person MapOneDALtoEF(AW.DAL.Models.Person dalPerson) {
            AW.EF.Person efPerson = new AW.EF.Person();

			efPerson.BusinessEntityID = dalPerson.BusinessEntityID;
			efPerson.PersonType = dalPerson.PersonType;
			efPerson.NameStyle = bool.Parse(dalPerson.NameStyle);
			efPerson.Title = dalPerson.Title;
			efPerson.FirstName = dalPerson.FirstName;
			efPerson.MiddleName = dalPerson.MiddleName;
			efPerson.LastName = dalPerson.LastName;
			efPerson.Suffix = dalPerson.Suffix;
			efPerson.EmailPromotion = int.Parse(dalPerson.EmailPromotion);
			efPerson.AdditionalContactInfo = dalPerson.AdditionalContactInfo;
			efPerson.Demographics = dalPerson.Demographics;
			efPerson.rowguid = Guid.Parse(dalPerson.rowguid);
			efPerson.ModifiedDate = DateTime.Parse(dalPerson.ModifiedDate);

            return efPerson;
        }

        #endregion
    }
}
