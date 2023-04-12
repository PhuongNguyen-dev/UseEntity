using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UseEntity.Entities
{
    [Table("User")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserId { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string UserName { get; set; }
        [MaxLength(150)]
        public string Password { get; set; }
        [MaxLength(150)]
        public string? FirstName { get; set; }
        [MaxLength(150)]
        public string? LastName { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(250)]
        public Geneder Geneder { get; set; }
        [MaxLength(250)]
        public string? Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public enum Geneder
    {
        Đực = 0,
        Cái = 1,
        Bêđê = 2,
    }
}
