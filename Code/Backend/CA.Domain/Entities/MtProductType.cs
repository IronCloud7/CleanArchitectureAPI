using System;
using System.Collections.Generic;

namespace CA.Core.Entities;

public partial class MtProductType
{
    public int ProducttypeId { get; set; }

    public string Description { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual MtUser Account { get; set; } = null!;

    public virtual ICollection<MtArticle> MtArticles { get; } = new List<MtArticle>();
}
