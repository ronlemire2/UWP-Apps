using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AW.DAL.Models;
using AW.EF;

namespace AW.DAL.Repositories {
    public class EFPersonRepository : IPersonRepository {
        public IList<AW.DAL.Models.Person> GetPeople() {
            List<AW.EF.Person> efPeople;
            using (var context = new AdventureWorks2012Entities()) {
                IQueryable<AW.EF.Person> dbQuery = context.People;
                efPeople = dbQuery
                    .AsNoTracking()
                    .ToList();
            }

            List<AW.DAL.Models.Person> dalPeople;
            dalPeople = EFPersonMapper.MapAllEFtoDAL(efPeople).ToList();

            return dalPeople;
        }

        public AW.DAL.Models.Person GetPerson(int businessEntityID) {
            AW.EF.Person efPerson;
            using (var context = new AdventureWorks2012Entities()) {
                efPerson = context.People.Where(p => p.BusinessEntityID == businessEntityID)
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            AW.DAL.Models.Person dalPerson;
            dalPerson = EFPersonMapper.MapOneEFtoDAL(efPerson);
            return dalPerson;
        }

        public int SaveGraph(AW.DAL.Models.Person dalPerson) {
            int numRowsAffected = 0;

            AW.EF.Person efPerson = EFPersonMapper.MapOneDALtoEF(dalPerson);
            try {
                using (var context = new AdventureWorks2012Entities()) {
                    context.Set<AW.EF.Person>().Add(efPerson);
                    var entry = context.ChangeTracker.Entries<AW.EF.Person>().Where(e => e.Entity.BusinessEntityID == dalPerson.BusinessEntityID).FirstOrDefault();
                    entry.State = ConvertState(dalPerson.CrudState);
                    if (dalPerson.CrudState == CrudState.Unchanged) {
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
