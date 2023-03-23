using System;
using System.Collections.Generic;

namespace CA.Core.Entities;

public partial class MtUser
{
    public int AccountId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual ICollection<MtArticle> MtArticles { get; } = new List<MtArticle>();

    public virtual ICollection<MtProductType> MtProductTypes { get; } = new List<MtProductType>();

    public virtual ICollection<MtStore> MtStores { get; } = new List<MtStore>();
}
