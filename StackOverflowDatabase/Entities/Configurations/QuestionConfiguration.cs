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
            
            builder.HasOne(x => x.User).WithMany(x => x.Questions).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(x => x.Comments).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId);

            builder.HasMany(x => x.Tags).WithMany(x => x.Questions).UsingEntity<QuestionTag>(
                x => x.HasOne(x => x.Tag).WithMany().HasForeignKey(x => x.TagId),
                x => x.HasOne(x => x.Question).WithMany().HasForeignKey(x => x.QuestionId),
                x =>
                {
                    x.HasKey(x => new { x.TagId, x.QuestionId });
                });
        }
    }
}
