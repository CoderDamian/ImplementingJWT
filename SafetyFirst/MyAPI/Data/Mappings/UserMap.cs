using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPI.Models;

namespace MyAPI.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("LOGINMODEL", "CIA")
                .HasNoKey();

            builder.Property(p => p.UserName)
                .HasColumnName("USERNAME");

            builder.Property(p => p.Password)
                .HasColumnName("PASSWORD");
        }
    }
}
