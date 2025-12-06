using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onetoneRelationship.Models
{
    public class UserProfile
    {
        // Add [Key] attribute to specify primary key
        [Key]
        public int UserId { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        // Navigation Property
        public User User { get; set; } = null!;
    }
}