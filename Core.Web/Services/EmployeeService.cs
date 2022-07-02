using Core.Web.Data;
using Core.Web.Interfaces;
using Core.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            int result = 0;

            //fetch employee using linq query
            var employee = _employeeDbContext.Employees.Where(e => e.Id == Id).FirstOrDefault();
            if (employee != null)
            {
                _employeeDbContext.Remove(employee);
                await _employeeDbContext.SaveChangesAsync();
                result = 1;
            }

            return result;
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
            var model = new EmployeeModel();

            //here linq query is writen to get employee by id
            var employee = await _employeeDbContext.Employees.Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            if (employee != null)
            {
                model.Id = employee.Id;
                model.Name = employee.Name;
                model.AcceptTerms = (bool)employee.AcceptTerms;
                model.CreatedOn = employee.CreatedOn;
                model.EmailId = employee.EmailId;
                model.StateId = employee.StateId;
                model.CityId = employee.CityId;
                model.ProfileImage = employee.ProfileImage;
                model.Password = employee.Password;

                //bind dropdown. add some items on dropdown
                model.AvailableStates.Add(new SelectListItem
                {
                    Text = "-- Select State --",
                    Value = "0"
                });

                var states = await _employeeDbContext.States.ToListAsync();
                foreach (var state in states)
                {
                    model.AvailableStates.Add(new SelectListItem
                    {
                        Text = state.Name,
                        Value = state.Id.ToString()
                    });
                }

                //bind cities
                var cities = await _employeeDbContext.Cities.ToListAsync();
                foreach (var city in cities)
                    model.AvailableCities.Add(new SelectListItem
                    {
                        Text = city.Name,
                        Value = city.Id.ToString(),
                        Selected = model.CityId == city.Id ? true : false
                    });
            }

            return model;
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
            var employee = new Employee
            {
                Id = model.Id,
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

            _employeeDbContext.Employees.Update(employee);
            await _employeeDbContext.SaveChangesAsync();

            return employee;
        }
    }
}
