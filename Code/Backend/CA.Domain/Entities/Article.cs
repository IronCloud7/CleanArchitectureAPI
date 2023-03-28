namespace CA.Core.Entities;

public partial class Article
{
    public int SkuId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int TotalInShelf { get; set; }

    public int TotalInVault { get; set; }

    public int ProducttypeId { get; set; }

    public int StoreId { get; set; }

    public int AccountId { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual User Account { get; set; } = null!;

    public virtual ProductType Producttype { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
