using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Web.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            AvailableStates = new List<SelectListItem>();
            AvailableCities = new List<SelectListItem>();
        }
        public int Id { get; set; }

        //required is used for giving validation to the property.
        //in this model you can set any type of validation and also create custom validation

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter email id")]
        public string EmailId { get; set; }
        public int? Gender { get; set; }
        public bool AcceptTerms { get; set; }

        //[Required(ErrorMessage ="Please upload profile image")]
        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "Please select state")]
        public int? StateId { get; set; }

        [Required(ErrorMessage = "Please select city")]
        public int? CityId { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
        public IList<SelectListItem> AvailableCities { get; set; }
    }
}
