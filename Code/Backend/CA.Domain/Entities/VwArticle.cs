using System;
using System.Collections.Generic;

namespace CA.Core.Entities;

public partial class VwArticle
{
    public int SkuId { get; set; }

    public string Description { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int TotalInShelf { get; set; }

    public int TotalInVault { get; set; }

    public string StoreName { get; set; } = null!;

    public string ProductTypeName { get; set; } = null!;
}
