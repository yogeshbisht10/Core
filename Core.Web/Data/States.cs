using System.ComponentModel.DataAnnotations;

namespace Core.Web.Data
{
    public class States
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
