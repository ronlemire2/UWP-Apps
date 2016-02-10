﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AW.DAL.Models;

namespace AW.DAL.Repositories {
    public interface IPersonRepository {
        IList<Person> GetPeople();
        Person GetPerson(int id);
        int SaveGraph(Person root);
    }
}