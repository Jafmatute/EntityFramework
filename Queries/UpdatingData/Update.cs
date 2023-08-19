namespace Queries.UpdatingData
{
    public static class Update
    {
        public static PlutoContext Ctx { get; set; } = new PlutoContext();
        
        public static void UpdateObject()
        {
            //var courses = Ctx.Courses.Find(1,2,3,10);
            var course = Ctx.Courses.Find(10);
            course.Name = "Master Clean Code";
            course.AuthorId = 2;

            Ctx.SaveChanges();

        }
    }
}