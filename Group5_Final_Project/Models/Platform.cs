using System.ComponentModel.DataAnnotations;

namespace Group5_Final_Project.Models
{
    public class Platform
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Please enter a Platform Name")]
        public string? Name { get; set; }
    }
}
