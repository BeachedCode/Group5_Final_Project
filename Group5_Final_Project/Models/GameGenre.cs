using System.ComponentModel.DataAnnotations;

namespace Group5_Final_Project.Models
{
    public class GameGenre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter a Genre")]
        public string? Genre { get; set; }
    }
}
