namespace Group5_Final_Project.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? GenreId { get; set; }
        public GameGenre? Genre { get; set; }  
        public int? DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public int? Rating {get; set;}

    }
}
