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
        Task<int> InsertEmployee(EmployeeModel model);
        Task<int> UpdateEmployee(EmployeeModel model);
        Task<int> DeleteEmployee(int Id);
    }
}
