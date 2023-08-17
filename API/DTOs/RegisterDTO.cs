using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName {get; set;}
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Password {get; set;}
        [Required]
        public string KnownAs {get; set;}
        [Required]
        public string Gender {get; set;}
    }
}