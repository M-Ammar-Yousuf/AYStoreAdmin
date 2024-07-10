using System.ComponentModel.DataAnnotations;

namespace AYStoreAdmin.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name ="Name")]
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? ShortDescription { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
