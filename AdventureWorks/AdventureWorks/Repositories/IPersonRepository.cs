using AdventureWorks.Models;
using AdventureWorks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repositories {
    public interface IPersonRepository {
        Task<List<PersonVM>> GetPersonsAsync();
        Task<int> EditPersonAsync(PersonVM personVM);
        Task<int> AddPersonAsync(PersonVM personVM);
        Task<int> DeletePersonAsync(PersonVM personVM);
    }
}
