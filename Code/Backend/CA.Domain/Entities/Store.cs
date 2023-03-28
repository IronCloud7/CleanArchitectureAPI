namespace CA.Core.Entities;

public partial class Store
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual User Account { get; set; } = null!;

    public virtual ICollection<Article> MtArticles { get; } = new List<Article>();
}
