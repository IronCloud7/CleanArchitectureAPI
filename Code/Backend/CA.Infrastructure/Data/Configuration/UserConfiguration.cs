using CA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.AccountId).HasName("pk_IdUser");

            builder.ToTable("mtUsers");

            builder.HasIndex(e => e.AccountId, "uq_IdUser").IsUnique();

            builder.Property(e => e.AccountId).HasColumnName("account_id");
            builder.Property(e => e.Createdate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            builder.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            builder.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            builder.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordhash");
            builder.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("updatedate");
            builder.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        }
    }
}
