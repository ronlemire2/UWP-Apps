using AW.DAL.Repositories;
using AW.DAL.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.BL {
    public class BusinessLayer : IBusinessLayer {
        private readonly IPersonRepository personRepository;

        // TODO: Unity.WebAPI
        public BusinessLayer() : this(new EFPersonRepository()) {
        }

        public BusinessLayer(IPersonRepository personRepository) {
            this.personRepository = personRepository;
        }

        public IList<PersonPOCO> GetPersons() {
            IList<PersonPOCO> persons = personRepository.GetPersons();
            return persons;
        }

        public PersonPOCO GetPersonById(int businessEntityId) {
            PersonPOCO personPOCO = personRepository.GetPersonById(businessEntityId);
            return personPOCO;
        }

        public int SavePersonGraph(PersonPOCO personPOCO) {
            int numRowsAffected = personRepository.SavePersonGraph(personPOCO);
            return numRowsAffected;
        }
    }
}
