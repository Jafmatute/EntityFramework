using System;

namespace Queries.UpdatingData
{
    public static class ChangeTracking
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();
        
        public static void Tracking()
        {
                //Add an object
                Ctx.Authors.Add(new Author() {Name = "Josue Flores"});
                
                //Update an object
                var author = Ctx.Authors.Find(4);
                author.Name = "MongoDB";
                
                //Remove an object
                var another = Ctx.Authors.Find(4);
                Ctx.Authors.Remove(another);

                var entries = Ctx.ChangeTracker.Entries();

                foreach (var entry in entries)
                {
                    entry.Reload(); //get the values from the database again
                    Console.WriteLine(entry.State);
                }
        }
    }
}