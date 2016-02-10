using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AW.DAL.Models;

namespace AW.BL {
    public interface IBusinessLayer {
        IList<Person> GetPeople();
        Person GetPerson(int id);
        int SaveGraph(Person root);
    }
}