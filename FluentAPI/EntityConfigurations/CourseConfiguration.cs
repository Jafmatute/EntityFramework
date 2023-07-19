using System.Data.Entity.ModelConfiguration;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>

    {
        public CourseConfiguration()
        {
            ToTable("tbl_Course");
            HasKey(c => c.Id);

            Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(200);

            Property(n => n.Name)
            .IsRequired()
            .HasMaxLength(255);

            HasRequired(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(c => c.AuthorId)
            .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);


            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                m.MapRightKey("TagId");

            });


        }
    }
}
