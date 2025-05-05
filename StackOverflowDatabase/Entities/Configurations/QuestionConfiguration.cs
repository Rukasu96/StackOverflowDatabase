using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowDatabase.Entities.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.Topic).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Views).HasDefaultValue(0);
            builder.Property(x => x.Likes).HasDefaultValue(0);
        }
    }
}
