using Core.Web.Interfaces;
using Core.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

            //bind dropdown. add some items on dropdown

            model.AvailableStates.Add(new SelectListItem
            {
                Text = "-- Select State --",
                Value = "0"
            });

            var states = await _employeeService.GetStates();
            foreach (var state in states)
            {
                model.AvailableStates.Add(new SelectListItem
                {
                    Text = state.Name,
                    Value = state.Id.ToString()
                });
            }

            return View(model);
        }

        //this method is called when any button on create form is clicked.
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel model,
            IFormFile UserProfileImage)
        {
            if (UserProfileImage == null)
                ModelState.AddModelError("", "Please select profile image");

            if (UserProfileImage != null && !string.IsNullOrEmpty(UserProfileImage.FileName))
            {
                try
                {
                    if (string.IsNullOrEmpty(UserProfileImage.ContentType))
                        ModelState.AddModelError("", "Please select profile image");

                    if (ModelState.IsValid)
                    {
                        Random rnd = new Random();
                        var randomId = rnd.Next(10000, 99999);
                        var pathtosave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/profile");
                        var filename = ContentDispositionHeaderValue.Parse(UserProfileImage.ContentDisposition).FileName.Trim('"');
                        var renamefile = randomId.ToString() + "." + filename.Split('.').Last();
                        var fullpath = Path.Combine(pathtosave, renamefile);
                        using (var stream = new FileStream(fullpath, FileMode.Create))
                        {
                            UserProfileImage.CopyTo(stream);
                        }

                        model.ProfileImage = renamefile;
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }


            if (ModelState.IsValid) //if all the validation is done then this if condition return true else return false
            {
                //after all validation. save the form
                var employee = await _employeeService.InsertEmployee(model);
                if (employee != null)
                {
                    return RedirectToAction("List", "Employee");
                }
            }

            return View(model);
        }


        public async Task<IActionResult> Edit(int Id)
        {
            //send model to edit view other wise it will give error           
            var model = await _employeeService.GetEmployeeById(Id);
            return View(model);
        }

        /// <summary>
        /// this method hit when employee view page button click
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeModel model,
             IFormFile UserProfileImage)
        {
            if (UserProfileImage != null && !string.IsNullOrEmpty(UserProfileImage.FileName))
            {
                try
                {
                    if (string.IsNullOrEmpty(UserProfileImage.ContentType))
                        ModelState.AddModelError("", "Please select profile image");

                    if (ModelState.IsValid)
                    {
                        Random rnd = new Random();
                        var randomId = rnd.Next(10000, 99999);
                        var pathtosave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/profile");
                        var filename = ContentDispositionHeaderValue.Parse(UserProfileImage.ContentDisposition).FileName.Trim('"');
                        var renamefile = randomId.ToString() + "." + filename.Split('.').Last();
                        var fullpath = Path.Combine(pathtosave, renamefile);
                        using (var stream = new FileStream(fullpath, FileMode.Create))
                        {
                            UserProfileImage.CopyTo(stream);
                        }

                        model.ProfileImage = renamefile;
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }


            if (ModelState.IsValid) //if all the validation is done then this if condition return true else return false
            {
                //after all validation. save the form
                var employee = await _employeeService.UpdateEmployee(model);
                if (employee != null)
                {
                    return RedirectToAction("List", "Employee");
                }
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _employeeService.DeleteEmployee(Id);
            if (result > 0)
            {
                //redirect to action is used to redirect to page. first parameter belongs to action name
                //second parameter belongs to controller name
                
                return RedirectToAction("List", "Employee");
            }

            return View();
        }



        /// <summary>
        /// get all the cities by stateid
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetCitiesBySid(int stateId)
        {
            var cities = await _employeeService.GetCitiesByStateId(stateId);

            //select cities using linq query
            var result = (from c in cities
                          select new { id = c.Id, name = c.Name }).ToList();

            return Json(result);
        }




    }
}
