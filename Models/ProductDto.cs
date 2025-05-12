using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models;

public class ProductDto
{
    [Required]
    public string Name { get; set; } = default!;
    
    [Required]
    public string Description { get; set; } = default!;
    
    [Required]
    public decimal Price { get; set; }
}
