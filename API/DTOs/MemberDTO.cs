using API.Entities;

namespace API.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string KnownAs { get; set; }
        public string Gender { get; set; }
        public string Role {get; set;}
        public DateTime Created {get; set;}
        public PhotoDTO Avatar {get; set;}
    }
}