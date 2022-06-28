using Core.Web.Data;
using Core.Web.Interfaces;
using Core.Web.Models;
using System.Collections.Generic;
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

        public async Task<int> InsertEmployee(EmployeeModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateEmployee(EmployeeModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
