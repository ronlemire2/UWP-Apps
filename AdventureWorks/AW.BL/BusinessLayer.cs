using AW.DAL.Repositories;
using AW.DAL.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.BL {
    public class BusinessLayer : IBusinessLayer {
        private readonly IPersonRepository personRepository;

        // TODO: Unity.WebAPI
        public BusinessLayer() : this(new PersonRepository()) {
        }

        public BusinessLayer(IPersonRepository personRepository) {
            this.personRepository = personRepository;
        }

        public IList<PersonPOCO> GetAllPeople() {
            IList<PersonPOCO> people = personRepository.GetAllPeople();
            return people;
        }

        public PersonPOCO GetDepartmentById(int businessEntityID) {
            throw new NotImplementedException();
        }

        void IBusinessLayer.SaveGraph<TEntity>(TEntity root) {
            throw new NotImplementedException();
        }

        //public Department GetDepartmentByName(string departmentName) {
        //    Department dept = _deptRepository.GetSingle(
        //        d => d.Name.Equals(departmentName),
        //        d => d.Employees); //include related employees
        //    SetDepartmentStateUnchanged(dept);
        //    return dept;
        //}

        //// Currently not being used by Mm.WebApi.
        //public Department GetDepartmentById(int departmentId) {
        //    Department dept = _deptRepository.GetSingle(
        //        d => d.Id.Equals(departmentId),
        //        d => d.Employees); //include related employees
        //    SetDepartmentStateUnchanged(dept);
        //    return dept;
        //}

        //public void SaveGraph<TEntity>(TEntity root) where TEntity : class, IObjectWithState {
        //    _deptRepository.SaveGraph(root);
        //}

        //private void SetDepartmentStateUnchanged(Department dept) {
        //    dept.State = State.Unchanged;
        //    foreach (Employee emp in dept.Employees) {
        //        emp.State = State.Unchanged;
        //    }
        //}
    }
}
