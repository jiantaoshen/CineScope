using CineScope.Models;
using Microsoft.EntityFrameworkCore;

namespace CineScope.Data
{
    public static class MovieSeeder
    {
        public static async Task SeedMoviesAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<CineScopeContext>();

            var movies = new List<MovieModel>
            {
                new()
                {
                    Title = "The Dark Knight",
                    Genre = "Superhero",
                    Description = "Batman faces the Joker, who seeks to plunge Gotham City into chaos.",
                    ReleaseYear = 2008,
                    Rating = 9.0,
                    Duration = 152,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMDQ5MWU2YWUtNTQ4OC00Njk5LWI0NzctMjM4OGZiNmZmNGViXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "The Batman",
                    Genre = "Superhero",
                    Description = "Batman investigates a series of murders connected to Gotham's elite.",
                    ReleaseYear = 2022,
                    Rating = 7.8,
                    Duration = 176,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BYmNlZjNiYjgtOWZmMy00ZGQ5LTkzNDUtMTQ3Mzc3YjEwOTc0XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Spider-Man: No Way Home",
                    Genre = "Superhero",
                    Description = "Peter Parker seeks help from Doctor Strange after his identity is revealed.",
                    ReleaseYear = 2021,
                    Rating = 8.2,
                    Duration = 148,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BZWMyYzFjYTYtNTRjYi00OGExLWE2YzgtOGRmYjAxZTU3NzBiXkEyXkFqcGdeQXVyMzQ0MzA0NTM@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Avengers: Endgame",
                    Genre = "Superhero",
                    Description = "The Avengers assemble one final time to reverse Thanos' actions.",
                    ReleaseYear = 2019,
                    Rating = 8.4,
                    Duration = 181,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_UY1200_CR90,0,630,1200_AL_.jpg"
                },

                new()
                {
                    Title = "Iron Man",
                    Genre = "Superhero",
                    Description = "Tony Stark builds a powerful suit of armor and becomes Iron Man.",
                    ReleaseYear = 2008,
                    Rating = 7.9,
                    Duration = 126,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjg2NjVlYTEtMTVhYS00OTIzLWE0NGUtMjg0YzI1MGRhMDdhXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Spirited Away",
                    Genre = "Anime",
                    Description = "A young girl enters a magical spirit world and must save her parents.",
                    ReleaseYear = 2001,
                    Rating = 8.6,
                    Duration = 125,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTQ2MzMxMzI5MF5BMl5BanBnXkFtZTcwNDEzMTUyMQ@@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Your Name",
                    Genre = "Anime",
                    Description = "Two teenagers mysteriously swap bodies across time and distance.",
                    ReleaseYear = 2016,
                    Rating = 8.4,
                    Duration = 106,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjI1ODZkYTgtYTY3Yy00ZTJkLWFkOTgtZDUyYWM4MzQwNjk0XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Princess Mononoke",
                    Genre = "Anime",
                    Description = "A warrior becomes involved in a struggle between nature and industry.",
                    ReleaseYear = 1997,
                    Rating = 8.4,
                    Duration = 134,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BZTcyN2Y0MDYtMGI1NC00MWQ1LWFhZGMtN2U4NTcxZGYyNjljXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Demon Slayer: Mugen Train",
                    Genre = "Anime",
                    Description = "Tanjiro joins the Flame Hashira to investigate mysterious disappearances.",
                    ReleaseYear = 2020,
                    Rating = 8.2,
                    Duration = 117,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzEzYjhkYTctMWNmZS00MTc5LWI4OWUtZjFkNzNkYTNkMTJlXkEyXkFqcGc@._V1_.jpg"
                },

                new()
                {
                    Title = "Howl's Moving Castle",
                    Genre = "Anime",
                    Description = "A cursed young woman finds refuge in a magical moving castle.",
                    ReleaseYear = 2004,
                    Rating = 8.2,
                    Duration = 119,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNmM4YTFmMmItMGE3Yy00MmRkLTlmZGEtMzZlOTQzYjk3MzA2XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Interstellar",
                    Genre = "Sci-Fi",
                    Description = "Explorers travel through a wormhole in search of humanity's future.",
                    ReleaseYear = 2014,
                    Rating = 8.7,
                    Duration = 169,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Inception",
                    Genre = "Sci-Fi",
                    Description = "A thief enters dreams to steal and plant ideas.",
                    ReleaseYear = 2010,
                    Rating = 8.8,
                    Duration = 148,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "The Matrix",
                    Genre = "Sci-Fi",
                    Description = "A hacker discovers the shocking truth about reality.",
                    ReleaseYear = 1999,
                    Rating = 8.7,
                    Duration = 136,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Avatar",
                    Genre = "Sci-Fi",
                    Description = "A marine joins an alien world called Pandora.",
                    ReleaseYear = 2009,
                    Rating = 7.9,
                    Duration = 162,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BZDA0OGQxNTItMDZkMC00N2UyLTg3MzMtYTJmNjg3Nzk5MzRiXkEyXkFqcGdeQXVyMjUzOTY1NTc@._V1_FMjpg_UY2902_.jpg"
                },

                new()
                {
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Genre = "Fantasy",
                    Description = "A hobbit begins a quest to destroy a powerful ring.",
                    ReleaseYear = 2001,
                    Rating = 8.8,
                    Duration = 178,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzIxMDQ2YTctNDY4MC00ZTRhLTk4ODQtMTVlOWY4NTdiYmMwXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Genre = "Fantasy",
                    Description = "A young wizard discovers his magical heritage.",
                    ReleaseYear = 2001,
                    Rating = 7.6,
                    Duration = 152,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BZTk4MTM5YWYtNjkzZC00Yzk3LTgxYmItZGI5MThhZTc0YTdkXkEyXkFqcGc@._V1_.jpg"
                },

                new()
                {
                    Title = "Gladiator",
                    Genre = "Action",
                    Description = "A Roman general seeks revenge against a corrupt emperor.",
                    ReleaseYear = 2000,
                    Rating = 8.5,
                    Duration = 155,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BYWQ4YmNjYjEtOWE1Zi00Y2U4LWI4NTAtMTU0MjkxNWQ1ZmJiXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Top Gun: Maverick",
                    Genre = "Action",
                    Description = "Maverick returns to train the next generation of fighter pilots.",
                    ReleaseYear = 2022,
                    Rating = 8.3,
                    Duration = 130,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BOWQ1MDlmNTktNzk3My00MmUwLWJkM2QtYjg0Y2IyYTI2OWI3XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Joker",
                    Genre = "Drama",
                    Description = "A failed comedian descends into madness and becomes Gotham's most infamous criminal.",
                    ReleaseYear = 2019,
                    Rating = 8.4,
                    Duration = 122,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzY3OWQ5NDktNWQ2OC00ZjdlLThkMmItMDhhNDk3NTFiZGU4XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },

                new()
                {
                    Title = "Titanic",
                    Genre = "Romance",
                    Description = "A love story unfolds aboard the doomed RMS Titanic.",
                    ReleaseYear = 1997,
                    Rating = 7.9,
                    Duration = 194,
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_.jpg"
                }
            };

            await context.MovieModel.AddRangeAsync(movies);
            await context.SaveChangesAsync();
        }
    }
}