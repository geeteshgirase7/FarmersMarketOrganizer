using System.ComponentModel.DataAnnotations;

public class Vendor
{
    public int VendorId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(100)]
    public string ContactPerson { get; set; }

    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
}
