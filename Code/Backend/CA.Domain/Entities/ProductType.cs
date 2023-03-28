namespace CA.Core.Entities;

public partial class ProductType
{
    public int ProducttypeId { get; set; }

    public string Description { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual User Account { get; set; } = null!;

    public virtual ICollection<Article> MtArticles { get; } = new List<Article>();
}
