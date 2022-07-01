using System.ComponentModel.DataAnnotations;

namespace Core.Web.Data
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
    }
}
