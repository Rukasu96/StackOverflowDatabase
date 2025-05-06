using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowDatabase.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FullName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.UserNick).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(50)").IsRequired();

            builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
