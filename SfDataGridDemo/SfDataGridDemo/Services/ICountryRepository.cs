﻿using SfDataGridDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.Services {
    public interface ICountryRepository {
        List<CountryViewModel> GetCountryVMs();
    }
}
