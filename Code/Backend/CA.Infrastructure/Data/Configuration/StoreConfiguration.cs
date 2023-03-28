using CA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Data.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(e => e.StoreId).HasName("pk_IdStore");

            builder.ToTable("mtStores");

            builder.HasIndex(e => new { e.StoreId, e.AccountId }, "uq_IdStore").IsUnique();

            builder.Property(e => e.StoreId).HasColumnName("store_id");
            builder.Property(e => e.AccountId).HasColumnName("account_id");
            builder.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .HasColumnName("address");
            builder.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("date")
                .HasColumnName("creationdate");
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            builder.Property(e => e.Updatedate)
                .HasColumnType("date")
                .HasColumnName("updatedate");

            builder.HasOne(d => d.Account).WithMany(p => p.MtStores)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdStore");
        }
    }
}
