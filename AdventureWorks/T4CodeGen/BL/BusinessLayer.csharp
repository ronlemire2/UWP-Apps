using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AW.DAL.Models;
using AW.DAL.Repositories;

namespace AW.BL {
    public class BusinessLayer : IBusinessLayer {

        private readonly IPersonRepository personRepository;

        public BusinessLayer() {
            personRepository = new EFPersonRepository();
        }

        public BusinessLayer(IPersonRepository personRepository) {
            this.personRepository = personRepository;
        }

        #region Person

        public IList<Person> GetPeople() {
            IList<Person> people = null;
            people = personRepository.GetPeople();
            return people;
        }

        public Person GetPerson(int id) {
            Person person = personRepository.GetPerson(id);
            return person;
        }

        public int SaveGraph(Person root) {
            int numRowsAffected = personRepository.SaveGraph(root);
            return numRowsAffected;
        }

        #endregion
	}
}