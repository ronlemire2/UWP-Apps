using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AW.EF;
using AW.DAL.POCOs;
using AutoMapper;

namespace AW.DAL.Repositories {
    public class PersonMapper {
        static MapperConfiguration config;

        static PersonMapper() {
            config = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonPOCO>()
                .ForMember(dest => dest.NameStyle, opt => opt.MapFrom(src => src.NameStyle.ToString()))
                .ForMember(dest => dest.EmailPromotion, opt => opt.MapFrom(src => src.EmailPromotion.ToString()))
                .ForMember(dest => dest.rowguid, opt => opt.MapFrom(src => src.rowguid.ToString()))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedDate.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.NameStyle, opt => opt.MapFrom(src => bool.Parse(src.NameStyle)))
                .ForMember(dest => dest.EmailPromotion, opt => opt.MapFrom(src => int.Parse(src.EmailPromotion)))
                .ForMember(dest => dest.rowguid, opt => opt.MapFrom(src => Guid.Parse(src.rowguid)))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.Parse(src.ModifiedDate)))
            );
        }

        #region Map EF to DAL

        public static IEnumerable<PersonPOCO> MapAllEFtoDAL(IEnumerable<Person> efPeople) {
            List<PersonPOCO> dalPeople = new List<PersonPOCO>();

            foreach (Person efPerson in efPeople) {
                dalPeople.Add(PersonMapper.MapOneEFtoDAL(efPerson));
            }

            return dalPeople;
        }

        public static PersonPOCO MapOneEFtoDAL(Person efPerson) {
            var mapper = config.CreateMapper();
            PersonPOCO dalPersonPOCO = mapper.Map<PersonPOCO>(efPerson);
            return dalPersonPOCO;
        }

        #endregion

        #region Map DAL to EF

        public static Person MapOneDALtoEF(PersonPOCO dalPersonPOCO) {
            var mapper = config.CreateMapper();
            Person efPerson = mapper.Map<Person>(dalPersonPOCO);
            return efPerson;
        }

        #endregion
    }
}


//PersonPOCO dalPersonPOCO = new PersonPOCO();
//dalPersonPOCO.BusinessEntityID = efPerson.BusinessEntityID;
//dalPersonPOCO.PersonType = efPerson.PersonType;
//dalPersonPOCO.NameStyle = efPerson.NameStyle.ToString();
//dalPersonPOCO.Title = efPerson.Title;
//dalPersonPOCO.FirstName = efPerson.FirstName;
//dalPersonPOCO.MiddleName = efPerson.MiddleName;
//dalPersonPOCO.LastName = efPerson.LastName;
//dalPersonPOCO.Suffix = efPerson.Suffix;
//dalPersonPOCO.EmailPromotion = efPerson.EmailPromotion.ToString();
//dalPersonPOCO.AdditionalContactInfo = efPerson.AdditionalContactInfo;
//dalPersonPOCO.Demographics = efPerson.Demographics;
//dalPersonPOCO.rowguid = efPerson.rowguid.ToString();
//dalPersonPOCO.ModifiedDate = efPerson.ModifiedDate.ToString();
//dalPersonPOCO.CrudState = CrudState.Unchanged;


