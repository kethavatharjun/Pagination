using System.ComponentModel.DataAnnotations;

namespace onetoneRelationship.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        // Navigation Property
        public UserProfile Profile { get; set; } = null!;
    }

}