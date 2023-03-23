using System;
using System.Collections.Generic;

namespace CA.Core.Entities;

public partial class MtArticle
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

    public virtual MtUser Account { get; set; } = null!;

    public virtual MtProductType Producttype { get; set; } = null!;

    public virtual MtStore Store { get; set; } = null!;
}
