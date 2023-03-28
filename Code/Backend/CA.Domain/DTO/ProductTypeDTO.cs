namespace CA.Core.DTO;

public partial class ProductTypeDTO
{
    public int ProducttypeId { get; set; }

    public string Description { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime? Updatedate { get; set; }
}
