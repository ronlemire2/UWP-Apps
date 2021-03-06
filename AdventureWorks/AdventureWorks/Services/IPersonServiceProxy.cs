﻿using AdventureWorks.Models;
using AdventureWorks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Services {
    public interface IPersonServiceProxy {
        Task<List<PersonVM>> GetPersonsAsync();
        Task<int> EditPersonAsync(PersonVM personVM);
        Task<int> AddPersonAsync(PersonVM personVM);
        Task<int> DeletePersonAsync(PersonVM personVM);
    }
}
