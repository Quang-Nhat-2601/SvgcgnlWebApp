using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public string KnownAs { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Role {get; set;} = "member";
        [Required]
        public DateTime Created {get; set;} = DateTime.UtcNow;
        public Photo Avatar {get; set;}
    }
}