using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.Vitzy.EntityConfigurations
{
    class GenreConfiguration : EntityTypeConfiguration<Genre>
    {

        public GenreConfiguration()
        {
            Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
