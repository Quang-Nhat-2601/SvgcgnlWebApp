using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Photo
    {
        public int Id {get; set;}
        [Required]
        public string Url {get; set;}
        public int UserId {get; set;}
        public AppUser User {get; set;}
    }
}