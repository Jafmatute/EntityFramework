using System;
using System.Collections.Generic;

namespace DbFirst.Vidzy
{
    abstract class Program
    {
        static void Main(string[] args)
        {
            AddVideo();
        }

        public enum Classification : byte
        {
            Silver = 1,
            Gold = 2,
            Platinum = 3
        }

        static void AddVideo()
        {
            var dbContext = new VidzyDbContext();

            var listVideos = new List<Video>()
            {
                new Video(){  Name = "Cantinflas", ReleaseDate = DateTime.Now, GenreId =1, Classification = (byte)Classification.Gold },
                new Video(){  Name = "Los tres chiflados", ReleaseDate = DateTime.Now, GenreId = 1, Classification = (byte)Classification.Platinum},
                new Video(){  Name = "Culpa Mia", ReleaseDate = DateTime.Now, GenreId = 6, Classification = (byte)Classification.Platinum}
            };


            foreach (var video in listVideos)
            {
                dbContext.AddVideo(video.Name, video.ReleaseDate, video.GenreId, video.Classification);
                dbContext.SaveChanges();

            }

            Console.WriteLine("Success");
            Console.ReadKey();


        }
    }
}
