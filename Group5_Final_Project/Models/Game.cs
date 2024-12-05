using System.ComponentModel.DataAnnotations;

namespace Group5_Final_Project.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required (ErrorMessage= "Please Enter a Name")]
        public string? Name { get; set; }
        [Required (ErrorMessage = "Please Select a Genre")]
        public int? GenreId { get; set; }
        public GameGenre? Genre { get; set; }
        [Required (ErrorMessage = "Please Select a Developer")]
        public int? DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        [Required (ErrorMessage = "Please enter a Release Date")]
        public DateOnly? ReleaseDate { get; set; }
        [Required (ErrorMessage ="Please enter a Rating")]
        [Range (1,10, ErrorMessage = "Rating must be between 1 and 10")]
        public int? Rating {get; set;}

    }
}
