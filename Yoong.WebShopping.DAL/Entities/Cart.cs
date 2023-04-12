using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UseEntity.Entities
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid CartID { get; set; }
        
        public Guid? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
       
        [Range(100,0)]
        public int Quatity { get; set; }
    }
}
