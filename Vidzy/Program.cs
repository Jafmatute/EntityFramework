using System;
using System.Linq;
using Vidzy.LoadingRelatedObjects;
using static Vidzy.Classification;

namespace Vidzy
{
    class Program
    {
        public static VidzyContext Ctx { get; set; } = new VidzyContext();

        static void Main(string[] args)
        {
            //ListOfGenresAndNumberOfVideosSortedByNumber();
            
            LazyLoadingNotWorking.LazyNotWorking();

            //Console.ReadKey();
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