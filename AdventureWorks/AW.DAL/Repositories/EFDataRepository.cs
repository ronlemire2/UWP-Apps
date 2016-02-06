using AW.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Repositories {
    public class EFDataRepository<T> : IGenericDataRepository<T> where T : class {
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties) {
            List<T> list;
            using (var context = new AdventureWorks2012Entities()) {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties) {
            List<T> list;
            using (var context = new AdventureWorks2012Entities()) {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties) {
            T item = null;
            using (var context = new AdventureWorks2012Entities()) {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        // Works with graph (i.e. root->children->grandchildren) or just the root.
        // Client must set the State of each entity.
        public void SaveGraph<TEntity>(TEntity root) where TEntity : class, IEntityWithCrudState {
            using (var context = new AdventureWorks2012Entities()) {

                // TODO: Not sure why I'm using .Add. It works but I need to research this.
                // 6/24/2015 The Magnus Montin article says that .Add cascades through the graph.
                // DbSet.Entry:
                // You can explicitly change the state of an entity by using the DbSet.Entry method. 
                // There is no need to attach the entity to the context before using this method as it will automatically do the attachment if needed. 
                // Below is the implementation of the generic repository’s Add method. 
                // It explicitly sets the state of the entity to be inserted into the database to Added before calling SaveChanges to execute and 
                // commit the insert statement. 
                // Note that using the Entry method to change the state of an entity will only affect the actual entity that you pass in to the method. 
                // It won’t cascade through a graph and set the state of all related objects, unlike the DbSet.Add method.

                context.Set<TEntity>().Add(root);

                CheckForEntitiesWithoutCrudStateInterface(context);

                // Set the state for each entity in the graph and then push the changes to the database. 
                foreach (var entry in context.ChangeTracker.Entries<IEntityWithCrudState>()) {
                    IEntityWithCrudState stateInfo = entry.Entity;
                    entry.State = ConvertState(stateInfo.CrudState);
                    if (stateInfo.CrudState == CrudState.Unchanged) {
                        var databaseValues = entry.GetDatabaseValues();
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                }

                context.SaveChanges();
            }
        }

        private void CheckForEntitiesWithoutCrudStateInterface(AdventureWorks2012Entities context) {
            var entitiesWithoutState = from e in context.ChangeTracker.Entries()
                                       where !(e.Entity is IEntityWithCrudState)
                                       select e;

            if (entitiesWithoutState.Any()) {
                throw new NotSupportedException("All entities must implement IObjectWithState");
            }
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
