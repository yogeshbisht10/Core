using Core.Web.Data;
using Core.Web.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Web.Interfaces
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<Employee> InsertEmployee(EmployeeModel model);
        Task<Employee> UpdateEmployee(EmployeeModel model);
        Task<int> DeleteEmployee(int Id);
        Task<IList<States>> GetStates();
        Task<IList<Cities>> GetCitiesByStateId(int stateId);
    }
}
