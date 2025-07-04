using System.ComponentModel.DataAnnotations;

namespace RetailInventory.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}