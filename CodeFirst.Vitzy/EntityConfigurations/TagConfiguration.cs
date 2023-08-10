using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.Vitzy.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}