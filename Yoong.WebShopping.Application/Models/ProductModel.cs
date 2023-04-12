using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace UseEntity.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string ImageUrl { get; set; }
        
    }
    
}
