using System.ComponentModel.DataAnnotations;

namespace Core.Web.Data
{
    public class Employee
    {
        [Key] //key is work as identity which is auto generated in table
        public int Id { get; set; }

        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
