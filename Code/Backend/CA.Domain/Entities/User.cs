namespace CA.Core.Entities;

public partial class User
{
    public int AccountId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual ICollection<Article> MtArticles { get; } = new List<Article>();

    public virtual ICollection<ProductType> MtProductTypes { get; } = new List<ProductType>();

    public virtual ICollection<Store> MtStores { get; } = new List<Store>();
}
