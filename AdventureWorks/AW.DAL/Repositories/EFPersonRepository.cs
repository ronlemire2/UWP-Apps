using AW.DAL.POCOs;
using AW.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Repositories {
    public class EFPersonRepository : IPersonRepository {
        public IList<PersonPOCO> GetPersons() {
            List<PersonPOCO> personPOCOs;

            // Get Persons from database.
            List<Person> persons;
            using (var context = new AdventureWorks2012Entities()) {
                IQueryable<EF.Person> dbQuery = context.People;
                persons = dbQuery
                    .AsNoTracking()
                    .ToList();
            }

            // Map Persons from database into PersonPOCOs.
            personPOCOs = PersonMapper.MapAllEFtoDAL(persons).ToList();
            return personPOCOs;
        }

        public PersonPOCO GetPersonById(int businessEntityId) {
            PersonPOCO personPOCO = null;

            // Get Person from database.
            Person person;
            using (var context = new AdventureWorks2012Entities()) {
                person = context.People.Where(p => p.BusinessEntityID == businessEntityId)
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            // Map Person from database into PersonPOCO.
            personPOCO = PersonMapper.MapOneEFtoDAL(person);
            return personPOCO;
        }

        public int SavePersonGraph(PersonPOCO personPOCO) {
            int numRowsAffected = 0;

            Person person = PersonMapper.MapOneDALtoEF(personPOCO);
            try {
                using (var context = new AdventureWorks2012Entities()) {
                    context.Set<Person>().Add(person);
                    var entry = context.ChangeTracker.Entries<Person>().Where(e => e.Entity.BusinessEntityID == personPOCO.BusinessEntityID).FirstOrDefault();
                    entry.State = ConvertState(personPOCO.CrudState);
                    if (personPOCO.CrudState == CrudState.Unchanged) {
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }

                    numRowsAffected = context.SaveChanges();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) {
                if (ex.InnerException != null && ex.InnerException is System.Data.SqlClient.SqlException
                   && ((System.Data.SqlClient.SqlException)ex.InnerException).ErrorCode == 8152)
                    throw ex.InnerException;
                else
                    throw ex;
            }

            return numRowsAffected;
        }

        public EntityState ConvertState(CrudState crudState) {
            switch (crudState) {
                case CrudState.Added:
                    return EntityState.Added;
                case CrudState.Modified:
                    return EntityState.Modified;
                case CrudState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}
