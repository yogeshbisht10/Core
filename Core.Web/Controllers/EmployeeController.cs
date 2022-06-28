using Core.Web.Interfaces;
using Core.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> List()
        {
            var model = await _employeeService.GetEmployees();
            return View(model);
        }



        //this is create form. design load here. 
        public async Task<IActionResult> Create()
        {
            var model = new EmployeeModel();
            return View(model);
        }

        //this method is called when any button on create form is clicked.
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel model)
        {
            return View();
        }
    }
}
