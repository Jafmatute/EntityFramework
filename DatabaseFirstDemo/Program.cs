using System;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new DatabaseFirstDemoEntities();

            var post = new Posts()
            {
                DatePublished = DateTime.Now,
                Title = "title",
                Body = "body"
            };

            ctx.Posts.Add(post);
            ctx.SaveChanges();

        }
    }
}
