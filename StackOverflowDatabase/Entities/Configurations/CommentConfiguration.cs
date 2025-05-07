using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowDatabase.Entities.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.AddedDate).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.ModifiedDate).ValueGeneratedOnUpdate();
        }
    }
}
