using System;
using System.Linq;
using Vidzy.LoadingRelatedObjects;
using Vidzy.UpdatingData;
using static Vidzy.Classification;

namespace Vidzy
{
    class Program
    {
        public static VidzyContext Ctx { get; set; } = new VidzyContext();

        static void Main(string[] args)
        {
            //exercise 1
            var video = new Video
            {
                Name = "Terminator 1",
                ReleaseDate = new DateTime(1984,10,26),
                GenreId = 2,
                Classification = Classification.Silver
            };
            
            //ExecutingQueries.AddVideo(video);
            
            //exercise 2
            //ExecutingQueries.AddTag("Drama", "classics");
            
            //exercise 3
            //ExecutingQueries.AddTagsToVideo(1, "classics","drama", "comedy");
            
            //Exercise 4
            //ExecutingQueries.RemoveTagFromVideo(1, "comedy");
            
            // Exercise 5
            //ExecutingQueries.RemoveVideo(1);
            
            //Exercise 6
            ExecutingQueries.RemoveGenre(2, enforceDeletingVideos: true);
            
        }

        private static void ActionMoviesSortedByName()
        {
            var movies = Ctx.Videos
                .Where(v => v.GenreId == 2).OrderBy(v => v.Name);

            foreach (var movie in movies) Console.WriteLine(movie.Name);
        }

        public static void GoldDramaMoviesSortedByReleaseDate()
        {
            var movies = Ctx.Videos
                .Where(v => v.Classification == Gold && v.GenreId == 7)
                .OrderByDescending(v => v.ReleaseDate);

            foreach (var movie in movies) Console.WriteLine(movie.Name);
        }

        public static void AllMoviesProjected()
        {
            var movies = Ctx.Videos
                .Select(v => new { MovieName = v.Name, Genre = v.Genre.Name });

            foreach (var movie in movies) Console.WriteLine(movie.MovieName);
        }

        public static void AllMoviesGroupedByClassification()
        {
            var movies = Ctx.Videos
                .GroupBy(v => v.Classification)
                .Select(g => new
                {
                    Classification = g.Key,
                    Videos = g.OrderBy(v => v.Name)
                });

            foreach (var group in movies)
            {
                Console.WriteLine(group.Classification);

                foreach (var c in group.Videos) Console.WriteLine(@"    {0}", c.Name);
            }
        }

        public static void ListClassificationSortedAlphabeticallyAndCountVideos()
        {
            var movies = Ctx.Videos
                .GroupBy(v => v.Classification)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count(),
                }).OrderByDescending(g => g.Count);

            foreach (var movie in movies)
            {
                Console.WriteLine(@"{0} ({1})", movie.Name, movie.Count);
            }
        }

        public static void ListOfGenresAndNumberOfVideosSortedByNumber()
        {
            var movies = Ctx.Genres
                .GroupJoin(Ctx.Videos, g => g.Id, v => v.GenreId,
                    (genre, videos) => new
                    {
                        NameGenre = genre.Name,
                        Videos = videos.Count(),
                    }).OrderByDescending(g => g.Videos);

            foreach (var movie in movies)
            {
                Console.WriteLine(@"{0} ({1})", movie.NameGenre, movie.Videos);
            }
        }
    }
}