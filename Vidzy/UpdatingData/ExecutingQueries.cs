using System;
using System.Data.Entity;
using System.Linq;

namespace Vidzy.UpdatingData
{
    public static class ExecutingQueries
    {
        
        //exercise one
        public static void AddVideo(Video video)
        {
            using (var ctx = new VidzyContext())
            {
                ctx.Videos.Add(video);
                ctx.SaveChanges();
            }
        }
        
        public static void AddTag(params string[] tagsName)
        {
            using (var ctx = new VidzyContext())
            {
                var tags = ctx.Tags.Where(t => tagsName.Contains(t.Name)).ToList();

                foreach (var name in tagsName)
                    if (tags.All(t => t.Name != name.Trim()))
                        ctx.Tags.Add(new Tag() {Name = name});

                ctx.SaveChanges();

            }
        }
        
        public static void AddTagsToVideo(int videoId, params string[] tagsName)
        {
            using (var ctx = new VidzyContext())
            {
                var tags = ctx.Tags.Where(t => tagsName.Contains(t.Name)).ToList();

                foreach (var name in tagsName)
                    if (tags.All(t => t.Name != name.Trim()))
                        tags.Add(new Tag() {Name = name});

                var video = ctx.Videos.Single(v => v.Id == videoId);
                
                tags.ForEach(t=> video.Tags.Add(t));
                ctx.SaveChanges();

            }
                
        }
        
        public static void RemoveTagFromVideo(int videoId, params string[] tagsName)
        {
            using (var ctx = new VidzyContext())
            {
                 ctx.Tags.Where(t => tagsName.Contains(t.Name)).Load();

                 var video = ctx.Videos.Single(v => v.Id == videoId);

                 foreach (var name in tagsName)
                 {
                     var tag = ctx.Tags.SingleOrDefault(t => t.Name == name);
                     
                     video.Tags.Remove(tag);
                 }

                 ctx.SaveChanges();

            }
        }
        
        public static void RemoveVideo(int videoId)
        {
            using (var ctx = new VidzyContext())
            {
                var video = ctx.Videos.FirstOrDefault(v => v.Id == videoId);

                if (video == null) return;
                
                ctx.Videos.Remove(video);
                ctx.SaveChanges();

            }
        }
        
        public static void RemoveGenre(int genreId, bool enforceDeletingVideos)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Id == genreId);
                if (genre == null) return;

                if (enforceDeletingVideos)
                    context.Videos.RemoveRange(genre.Videos);

                context.Genres.Remove(genre);
                context.SaveChanges();
            }
        }

    }
}