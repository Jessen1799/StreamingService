
namespace StreamingService.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }


        public Movie(int id, string title, string genre, int releaseYear, string director, double rating)
        {
            this.Id = id;
            this.Title = title;
            this.Genre = genre;
            this.ReleaseYear = releaseYear;
            this.Director = director;
            this.Rating = rating;
        }


    }
}
