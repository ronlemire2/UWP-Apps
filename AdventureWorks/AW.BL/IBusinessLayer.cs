using AW.DAL.Repositories;
using AW.DAL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.BL {
    public interface IBusinessLayer {
        // http://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/
        // In a real world application the methods in the business layer would probably  
        // contain code to validate the entities before processing them and 
        // it would also be catching and logging exceptions and 
        // maybe do some caching of frequently used data as well.

        // A client application consuming the sever side code will only need references 
        // to the business layer and 
        // to the entity classes defined in the DAL project. 
        //
        // It’s important to note that there are no references or dependencies to EF in this application. 
        // In fact you could replace the EF-based DAL with another one using raw T-SQL commands 
        // to communicate with the database without affecting the client side code. 
        // The only thing in the console application that hints that EF may be involved is 
        // the connection string that was generated in the DAL project when the EDM was created and 
        // has to be added to the application’s configuration file (App.config). 
        // Connection strings used by EF contain information about the required model, 
        // the mapping files between the model and the database and 
        // how to connect to the database using the underlying data provider.

        IList<PersonPOCO> GetAllPeople();
        PersonPOCO GetDepartmentById(int businessEntityID);
        void SaveGraph<TEntity>(TEntity root) where TEntity : class, IEntityWithCrudState;

    }
}
