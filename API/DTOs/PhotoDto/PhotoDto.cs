namespace API.DTOs;

public class PhotoDto
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    public int VendorID { get; set; }
}
