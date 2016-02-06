using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Models;
using AdventureWorks.Services;

namespace AdventureWorks.Repositories {
    public class PersonRepository : IPersonRepository {
        private readonly IPersonServiceProxy personServiceProxy;

        public PersonRepository(IPersonServiceProxy personServiceProxy) {
            this.personServiceProxy = personServiceProxy;
        }


        public async Task<List<PersonVM>> GetPeopleAsync() {
            var people = await personServiceProxy.GetPeopleAsync();
            return people;
        }

        public Task<int> AddPersonAsync(PersonVM personVM) {
            throw new NotImplementedException();
        }

        public Task<int> DeletePersonAsync(PersonVM personVM) {
            throw new NotImplementedException();
        }

        public Task<int> EditPersonAsync(PersonVM personVM) {
            throw new NotImplementedException();
        }
    }
}
