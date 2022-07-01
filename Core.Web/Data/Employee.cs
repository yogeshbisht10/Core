using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Web.Data
{
    public class Employee
    {
        [Key] //key is work as identity which is auto generated in table
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailId { get; set; }

        //use radio button for gender
        public int? Gender { get; set; }

        //use for checkbox
        public bool? AcceptTerms { get; set; }

        //use for fileupload
        public string ProfileImage { get; set; }

        //use for dropdown
        public int? StateId { get; set; }

        //add cityid on employee table
        public int? CityId { get; set; }

        //use for password textbox
        public string Password { get; set; }        
        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
