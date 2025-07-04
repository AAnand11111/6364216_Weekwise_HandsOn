using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailInventory.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; } = 0;

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation property
        public virtual Category Category { get; set; } = null!;
    }
}