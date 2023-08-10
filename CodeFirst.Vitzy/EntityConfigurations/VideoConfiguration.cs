using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.Vitzy.EntityConfigurations
{
    class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(g => g.Genre)
                .WithMany(v => v.Videos)
                .HasForeignKey(f => f.GenreId);

        }
    }
}
