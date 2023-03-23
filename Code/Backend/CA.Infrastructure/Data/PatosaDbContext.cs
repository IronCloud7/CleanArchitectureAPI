using CA.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Data;

public partial class PatosaDbContext : DbContext
{
    public PatosaDbContext()
    {
    }

    public PatosaDbContext(DbContextOptions<PatosaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MtArticle> MtArticles { get; set; }

    public virtual DbSet<MtProductType> MtProductTypes { get; set; }

    public virtual DbSet<MtStore> MtStore { get; set; }

    public virtual DbSet<MtUser> MtUsers { get; set; }

    public virtual DbSet<SchemaVersion> SchemaVersions { get; set; }

    public virtual DbSet<VwArticle> VwArticles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MtArticle>(entity =>
        {
            entity.HasKey(e => e.SkuId).HasName("fk_IdArticle");

            entity.ToTable("mtArticles", tb => tb.HasTrigger("ARTICLES_AI"));

            entity.HasIndex(e => new { e.SkuId, e.StoreId }, "uq_IdArticle").IsUnique();

            entity.Property(e => e.SkuId).HasColumnName("sku_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("date")
                .HasColumnName("creationdate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProducttypeId).HasColumnName("producttype_id");
            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.TotalInShelf).HasColumnName("total_in_shelf");
            entity.Property(e => e.TotalInVault).HasColumnName("total_in_vault");
            entity.Property(e => e.Updatedate)
                .HasColumnType("date")
                .HasColumnName("updatedate");

            entity.HasOne(d => d.Account).WithMany(p => p.MtArticles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdArticle1");

            entity.HasOne(d => d.Producttype).WithMany(p => p.MtArticles)
                .HasForeignKey(d => d.ProducttypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdArticle3");

            entity.HasOne(d => d.Store).WithMany(p => p.MtArticles)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdArticle2");
        });

        modelBuilder.Entity<MtProductType>(entity =>
        {
            entity.HasKey(e => e.ProducttypeId).HasName("pk_IdProductType");

            entity.ToTable("mtProductTypes");

            entity.HasIndex(e => new { e.ProducttypeId, e.AccountId }, "uq_IdProductType").IsUnique();

            entity.Property(e => e.ProducttypeId).HasColumnName("producttype_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationdate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("updatedate");

            entity.HasOne(d => d.Account).WithMany(p => p.MtProductTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdProductType");
        });

        modelBuilder.Entity<MtStore>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("pk_IdStore");

            entity.ToTable("mtStores");

            entity.HasIndex(e => new { e.StoreId, e.AccountId }, "uq_IdStore").IsUnique();

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .HasColumnName("address");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("date")
                .HasColumnName("creationdate");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Updatedate)
                .HasColumnType("date")
                .HasColumnName("updatedate");

            entity.HasOne(d => d.Account).WithMany(p => p.MtStores)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdStore");
        });

        modelBuilder.Entity<MtUser>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("pk_IdUser");

            entity.ToTable("mtUsers");

            entity.HasIndex(e => e.AccountId, "uq_IdUser").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Createdate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Updatedate)
                .HasColumnType("datetime")
                .HasColumnName("updatedate");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<SchemaVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SchemaVersions_Id");

            entity.Property(e => e.Applied).HasColumnType("datetime");
            entity.Property(e => e.ScriptName).HasMaxLength(255);
        });

        modelBuilder.Entity<VwArticle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_articles");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_type_name");
            entity.Property(e => e.SkuId).HasColumnName("sku_id");
            entity.Property(e => e.StoreName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("store_name");
            entity.Property(e => e.TotalInShelf).HasColumnName("total_in_shelf");
            entity.Property(e => e.TotalInVault).HasColumnName("total_in_vault");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
