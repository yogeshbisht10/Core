using Core.Web.Data;
using Core.Web.Interfaces;
using Core.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeDbContext _employeeDbContext;
        public EmployeeService(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public async Task<int> DeleteEmployee(int Id)
        {
            throw new System.NotImplementedException();
        }

        //show cities by state id
        public async Task<IList<Cities>> GetCitiesByStateId(int stateId)
        {
            //linq query to get default list record where stateid is found

            var cities = _employeeDbContext.Cities.Where(c => c.StateId == stateId).ToList();
            return cities;
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<EmployeeModel>> GetEmployees()
        {
            var model = new List<EmployeeModel>();

            var employee = _employeeDbContext.Employees;

            foreach (var item in employee)
            {
                model.Add(new EmployeeModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsActive = item.IsActive
                });
            }

            return model;
        }

        //get all state list
        public async Task<IList<States>> GetStates()
        {
            var states = _employeeDbContext.States.ToList();
            return states;
        }

        public async Task<Employee> InsertEmployee(EmployeeModel model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                AcceptTerms = model.AcceptTerms,
                CityId = model.CityId,
                CreatedOn = DateTime.Now,
                EmailId = model.EmailId,
                Gender = model.Gender,
                IsActive = true,
                Password = model.Password,
                ProfileImage = model.ProfileImage,
                StateId = model.StateId
            };

            _employeeDbContext.Employees.Add(employee);
            await _employeeDbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateEmployee(EmployeeModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
