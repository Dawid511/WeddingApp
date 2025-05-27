namespace API.DTOs;

public class CreatePhotoDto
{
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    public string? PublicId { get; set; }
    public int VendorID { get; set; }
}
