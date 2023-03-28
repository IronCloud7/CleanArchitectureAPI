namespace CA.Core.DTO;

public partial class StoreDTO
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }
}
