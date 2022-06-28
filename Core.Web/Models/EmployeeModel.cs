using System;

namespace Core.Web.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public int? Gender { get; set; }
        public bool? AcceptTerms { get; set; }
        public string ProfileImage { get; set; }
        public int? StateId { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
