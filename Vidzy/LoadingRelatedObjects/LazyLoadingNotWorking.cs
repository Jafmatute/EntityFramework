using System;
using System.Data.Entity;
using System.Linq;

namespace Vidzy.LoadingRelatedObjects
{
    public static class LazyLoadingNotWorking
    {
        public static VidzyContext Ctx { get; set; } = new VidzyContext();
        public static void LazyNotWorking()
        {
            var videos = Ctx.Videos.ToList();

            Console.WriteLine();
            Console.WriteLine(@"LAZZY LOADING");
            
            foreach (var video in videos) Console.WriteLine(@"Video: {0} - Genre: {1}", video.Name, video.Genre.Name);

            //Eager Loading
            var VideosWithGenres = Ctx.Videos.Include("Genre").ToList();

            Console.WriteLine();
            Console.WriteLine(@"EAGER LOADING");
            foreach (var video in VideosWithGenres) Console.WriteLine(@"{0} - {1}", video.Name, video.Genre.Name);
            
            
            // Explicit loading
            Ctx.Genres.Load();

            Console.WriteLine();
            Console.WriteLine(@"EXPLICIT LOADING");
            foreach (var v in videos)
                Console.WriteLine(@"{0} ({1})", v.Name, v.Genre.Name);
        }
    }
}