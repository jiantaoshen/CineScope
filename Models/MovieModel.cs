namespace CineScope.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public int Duration { get; set; }
        public string PosterUrl { get; set; } = string.Empty;
    }
}
