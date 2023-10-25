using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Products;

#nullable disable
public class CreateProductDto : CreateOrUpdateProductDto
{
    [Required]
    public string No { get; set; }
}
