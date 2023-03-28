using CA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Data.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(e => e.SkuId).HasName("fk_IdArticle");

            builder.ToTable("mtArticles", tb => tb.HasTrigger("ARTICLES_AI"));

            builder.HasIndex(e => new { e.SkuId, e.StoreId }, "uq_IdArticle").IsUnique();

            builder.Property(e => e.SkuId).HasColumnName("sku_id");
            builder.Property(e => e.AccountId).HasColumnName("account_id");
            builder.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("date")
                .HasColumnName("creationdate");
            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .HasColumnName("description");
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            builder.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            builder.Property(e => e.ProducttypeId).HasColumnName("producttype_id");
            builder.Property(e => e.StoreId).HasColumnName("store_id");
            builder.Property(e => e.TotalInShelf).HasColumnName("total_in_shelf");
            builder.Property(e => e.TotalInVault).HasColumnName("total_in_vault");
            builder.Property(e => e.Updatedate)
                .HasColumnType("date")
                .HasColumnName("updatedate");

            builder.HasOne(d => d.Account).WithMany(p => p.MtArticles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdArticle1");

            builder.HasOne(d => d.Producttype).WithMany(p => p.MtArticles)
                .HasForeignKey(d => d.ProducttypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdArticle3");

            builder.HasOne(d => d.Store).WithMany(p => p.MtArticles)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdArticle2");
        }
    }
}
