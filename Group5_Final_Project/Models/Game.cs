namespace Group5_Final_Project.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
