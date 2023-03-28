namespace CA.Core.DTO;

public partial class UserDTO
{
    public int AccountId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime? Updatedate { get; set; }
}
